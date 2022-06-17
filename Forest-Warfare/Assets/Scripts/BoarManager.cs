using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BoarManager : MonoBehaviour
{
    GameObject player;
    EnemyFSM boarMode = EnemyFSM.Wander;
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
            anim.SetBool("Attack", true);
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

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5f * Time.deltaTime);
        }
    }

    public void Update()
    {
        if (GetComponent<EnemyHealth>().getHealth() <= 0 && !dead)
        {
            dead = true;
            GetComponent<EnemyDeath>().Death(deathSound, deathParticles);
        }

        if (player)
        {
            float width = transform.position.x - player.transform.position.x;
            float height = transform.position.y - player.transform.position.y;
            float angle = Mathf.Atan(transform.position.y - player.transform.position.y / transform.position.x - player.transform.position.x);

            switch (boarMode)
            {
                case EnemyFSM.Attack:
                    if (Vector3.Distance(transform.position, player.transform.position) > 6.5f && isAttacking == false)
                    {
                        boarMode = EnemyFSM.Wander;
                    }
                    break;
                case EnemyFSM.Wander:
                    if (FOV.visibleTargets.Count > 0)
                    {
                        boarMode = EnemyFSM.Chase;
                    }
                    break;
                case EnemyFSM.Chase:
                    if (FOV.visibleTargets.Count == 0)
                    {
                        boarMode = EnemyFSM.Wander;
                    }
                    if (Vector3.Distance(transform.position, player.transform.position) <= 6.5f)
                    {
                        boarMode = EnemyFSM.Attack;
                    }
                    anim.SetFloat("speed", 0);
                    break;
            }
        }
        DoAction(boarMode);
    }

    public IEnumerator AttackDuration()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<BoarCharge>().enabled = true;
        if(player.transform.position.x > transform.position.x)
        {
            GetComponent<BoarCharge>().Direction(new Vector3(1,0,0));
        }
        else
        {
            GetComponent<BoarCharge>().Direction(new Vector3(-1, 0, 0));
        }
        GetComponent<FacePlayer>().enabled = false;
        yield return new WaitForSeconds(1.3f);

         
        GetComponent<BoarCharge>().enabled = false;
        GetComponent<FacePlayer>().enabled = true;
        anim.SetBool("Attack", false);

        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }

    void SetSpeed()
    {
        speed = Mathf.Abs((transform.position.x - lastPos)) * 200f;
        lastPos = transform.position.x;
    }
}
