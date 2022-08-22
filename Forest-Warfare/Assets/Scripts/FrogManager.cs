using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FrogManager : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    EnemyFSM frogMode = EnemyFSM.Wander;
    private Animator anim;
    public bool isAttacking;

    public AudioSource deathSound;

    public GameObject deathParticles;

    bool dead = false;

    public Explode explosion;

    public FieldOfView FOV;
    public bool canJump = true;

    public bool grounded = true;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Transform feet;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        anim = transform.gameObject.GetComponent<Animator>();
    }

    protected enum EnemyFSM
    {
        Attack,
        Wander,
        Chase
    }

    protected void DoAction(EnemyFSM enemyMode)
    {
        switch (enemyMode)
        {
            case EnemyFSM.Attack:
                Attack();
                break;
            case EnemyFSM.Wander:
                Wander();
                break;
            case EnemyFSM.Chase:
                Chase();
                break;
        }
    }

    public void Attack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(AttackCheck());
        }
    }
    public void Wander()
    {

    }
    public void Chase()
    {
        if (player&&grounded&&canJump)
        {
            canJump = false;
            Instantiate(Resources.Load<GameObject>("Dust"), feet.position, Quaternion.identity);
            if (Vector2.Distance(transform.position, player.transform.position) > 7)
            {
                Vector2 dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y+10);
                Debug.Log(dir.normalized * 800);
                GetComponent<Rigidbody2D>().AddForce(dir.normalized * 800);
                StartCoroutine(JumpCooldown());
            }
            else
            {
                Vector2 dir = new Vector2(50*(player.transform.position.x - transform.position.x), player.transform.position.y - transform.position.y + 400);
                GetComponent<Rigidbody2D>().AddForce(dir);
                Debug.Log(dir);
                StartCoroutine(JumpCooldown());
            }
        }
    }

    public void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, checkRadius, whatIsGround);
        anim.SetBool("grounded", grounded);
        if (GetComponent<EnemyHealth>().getHealth() <= 0 && !dead)
        {
            dead = true;
            explosion.Explosion();
        }

        if (player)
        {
            float width = transform.position.x - player.transform.position.x;
            float height = transform.position.y - player.transform.position.y;
            float angle = Mathf.Atan(transform.position.y - player.transform.position.y / transform.position.x - player.transform.position.x);

            switch (frogMode)
            {
                case EnemyFSM.Attack:
                    if (Vector2.Distance(transform.position, player.transform.position) > 5 && isAttacking == false)
                    {
                        frogMode = EnemyFSM.Wander;
                    }
                    break;
                case EnemyFSM.Wander:
                    if (Vector2.Distance(transform.position, player.transform.position) <= 5)
                    {
                        frogMode = EnemyFSM.Attack;
                    }
                    else if (FOV.visibleTargets.Count > 0)
                    {
                        frogMode = EnemyFSM.Chase;
                    } 
                    break;
                case EnemyFSM.Chase:
                    if (FOV.visibleTargets.Count == 0)
                    {
                        frogMode = EnemyFSM.Wander;
                    }
                    break;
            }
        }

        DoAction(frogMode);
    }
    public IEnumerator AttackAnimDuration()
    {
        yield return new WaitForSeconds(2);
        explosion.Explosion();
    }
    public IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(2.5f);
        canJump = true;
    }

    public IEnumerator AttackCheck()
    {
        yield return new WaitForSeconds(.75f);
        if (Vector2.Distance(transform.position, player.transform.position) <= 7)
        {
            anim.SetTrigger("Explode");
            StartCoroutine(AttackAnimDuration());
        }
        else
        {
            isAttacking = false;
        }
        yield break;
    }
}
