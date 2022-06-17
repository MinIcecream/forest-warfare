using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    GameObject player;
    EnemyFSM bombMode = EnemyFSM.Wander;
    private Animator anim;
    public bool isAttacking;
    float lastPos = 0;

    public AudioSource deathSound;

    public GameObject deathParticles;

    bool dead = false;

    public Explode explosion;

    public FieldOfView FOV;

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
            anim.SetTrigger("Attack");
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

            switch (bombMode)
            {
                case EnemyFSM.Attack:
                    if (Vector3.Distance(transform.position, player.transform.position) > 3 && isAttacking == false)
                    {
                        bombMode = EnemyFSM.Wander;
                    }
                    break;
                case EnemyFSM.Wander:

                    if (FOV.visibleTargets.Count > 0)
                    {
                        bombMode = EnemyFSM.Chase;
                    }
                    break;
                case EnemyFSM.Chase:
                    if (FOV.visibleTargets.Count == 0)
                    {
                        bombMode = EnemyFSM.Wander;
                    }
                    if (Vector3.Distance(transform.position, player.transform.position) <= 3)
                    {
                        bombMode = EnemyFSM.Attack;
                    }
                    anim.SetFloat("speed", 0);
                    break;
            }
        }

        DoAction(bombMode);
    }
    public IEnumerator AttackAnimDuration()
    {
        yield return new WaitForSeconds(1);
        explosion.Explosion();
    }
}
