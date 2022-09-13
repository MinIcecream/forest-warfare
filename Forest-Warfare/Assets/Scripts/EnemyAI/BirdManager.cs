using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BirdManager : EnemyManager
{ 
    EnemyFSM birdMode = EnemyFSM.Wander;
    private Animator anim;
    public bool isAttacking;
    float lastPos = 0;

    float speed;

    bool dead = false;

    public AudioSource deathSound;

    public GameObject deathParticles;

    public FieldOfView FOV;

    void Awake()
    { 
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
            StartCoroutine(AttackDuration());
            SetSpeed();
        }
    }
    public void Wander()
    {

    }
    public void Chase()
    {
        if (player)
        {
            SetSpeed();
            anim.SetFloat("speed", speed);

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
        }
    }

    public override void Update()
    {
        base.Update();

        if (GetComponent<EnemyHealth>().getHealth() <= 0 && !dead)
        {
            dead = true;
            GetComponent<EnemyDeath>().Death(deathParticles);
        }

        if (player)
        {
            float width = transform.position.x - player.transform.position.x;
            float height = transform.position.y - player.transform.position.y;
            float angle = Mathf.Atan(transform.position.y - player.transform.position.y / transform.position.x - player.transform.position.x);

            switch (birdMode)
            {
                case EnemyFSM.Attack:
                    if (Vector3.Distance(transform.position, player.transform.position) > 10f && isAttacking == false)
                    {
                        birdMode = EnemyFSM.Wander;
                    }
                    break;
                case EnemyFSM.Wander:

                    if (FOV.visibleTargets.Count > 0)
                    {
                        birdMode = EnemyFSM.Chase;
                    }
                    break;
                case EnemyFSM.Chase:
                    if (FOV.visibleTargets.Count == 0)
                    {
                        birdMode = EnemyFSM.Wander;
                    }
                    if (Vector3.Distance(transform.position, player.transform.position) <= 10f)
                    {
                        birdMode = EnemyFSM.Attack;
                    }
                    anim.SetFloat("speed", 0);
                    break;
            }
        }
        DoAction(birdMode);
    }

    public IEnumerator AttackDuration()
    {
        yield return new WaitForSeconds(1.6f);
        Vector2 direction = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y).normalized;
        if (!dead)
        {
            GetComponent<BirdShoot>().Fire(direction); 
        } 
        yield return new WaitForSeconds(1f);
        isAttacking = false;

    }

    void SetSpeed()
    {
        speed = Mathf.Abs((transform.position.x - lastPos)) * 200f;
        lastPos = transform.position.x;
    }
}
