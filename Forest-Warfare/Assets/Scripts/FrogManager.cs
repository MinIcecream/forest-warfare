using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FrogManager : MonoBehaviour
{
    GameObject player;
    EnemyFSM frogMode = EnemyFSM.Wander;
    private Animator anim;
    public bool isAttacking;
    float lastPos = 0;

    public AudioSource deathSound;

    public GameObject deathParticles;

    bool dead = false;

    public Explode explosion;

    public FieldOfView FOV;


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
            anim.SetTrigger("Explode");
            StartCoroutine(AttackAnimDuration());
        }
    }
    public void Wander()
    {

    }
    public void Chase()
    {
        if (player)
        {
            float speed = Mathf.Abs((transform.position.x - lastPos)) * 200f;
            lastPos = transform.position.x;
            anim.SetFloat("speed", speed);

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
        }
    }

    public void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, checkRadius, whatIsGround);
        
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
                    if (Vector3.Distance(transform.position, player.transform.position) > 3 && isAttacking == false)
                    {
                        frogMode = EnemyFSM.Wander;
                    }
                    break;
                case EnemyFSM.Wander:

                    if (FOV.visibleTargets.Count > 0)
                    {
                        frogMode = EnemyFSM.Chase;
                    }
                    break;
                case EnemyFSM.Chase:
                    if (FOV.visibleTargets.Count == 0&&grounded)
                    {
                        frogMode = EnemyFSM.Wander;
                    }
                    if (Vector3.Distance(transform.position, player.transform.position) <= 3 &&grounded)
                    {
                        frogMode = EnemyFSM.Attack;
                    }
                    anim.SetFloat("speed", 0);
                    break;
            }
        }

        DoAction(frogMode);
    }
    public IEnumerator AttackAnimDuration()
    {
        yield return new WaitForSeconds(1);
        explosion.Explosion();
    }
    public IEnumerator JumpAnimDuration(){
        if(Vector3.Distance(transform.position, player.transform.position) > 7){
            
        }
        else{

        }
    }
}
