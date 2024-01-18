using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotManager : EnemyManager
{
    public EnemyFSM robotMode = EnemyFSM.Chase;
    private Animator anim;
    public bool isAttacking;

    public Image background,fill,border;

    float lastPos = 0;

    float speed;

    bool dead = false;

    public AudioSource deathSound;

    public GameObject deathParticles;

    public FieldOfView FOV;

    public GameObject weapon;

    public bool onCooldown = false;
    public float chargeChargeTime, chargeDuration, chargeSpeed;

    EnemyFSM lastAttack = EnemyFSM.Explode;

    public Transform spawnPt;
    public RotateToPlayer rotate;

    public GameObject shieldSprite;

    public bool chestOpen = false;
    bool alreadyOpened = false;

    public Material shining;
    public Material normal;

    void Awake()
    {
        LevelManager.SwitchToBossMusic();
        anim = transform.gameObject.GetComponent<Animator>();
    }

    public enum EnemyFSM
    {
        FireMissile,
        Charge,
        Explode,
        Cooldown,
        Chase
    }

    protected void DoAction(EnemyFSM enemyMode)
    {
        switch (enemyMode)
        {
            case EnemyFSM.FireMissile:
                FireMissile();
                break;

            case EnemyFSM.Charge:
                Charge();
                break;

            case EnemyFSM.Explode:
                Explode();
                break;

            case EnemyFSM.Cooldown:
                Cooldown();
                break;

            case EnemyFSM.Chase:
                Chase();
                break;
        }
    }

    public void FireMissile()
    {
        if (!isAttacking)
        {
            isAttacking = true; 
            StartCoroutine(RocketDuration()); 
        }
    }
    public void Cooldown()
    {
        if (!onCooldown)
        {
            onCooldown = true;
            Invoke("CooldownTimer", 2f);
        } 
    }
    public void Explode()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("Explode");
            StartCoroutine(Explosion()); 
        } 
    }
    public void Charge()
    {
        if (!isAttacking)
        { 
            isAttacking = true;
            anim.SetTrigger("Charge");
            StartCoroutine(ChargeDuration());
        } 
    } 
    IEnumerator ChargeDuration()
    {
        Vector3 dir;
        SetInvincible();
        int i = 0;
        while (i < 2)
        {
            if (player.transform.position.x > transform.position.x)
            {
                dir=new Vector3(1, 0, 0);
            }
            else
            {
                dir=new Vector3(-1, 0, 0);
            }

            anim.SetTrigger("Charge");
            GetComponent<FacePlayer>().enabled = false;
            yield return new WaitForSeconds(chargeChargeTime);

            float startTime = Time.time;
            weapon.SetActive(true);
            while (Time.time - startTime < chargeDuration)
            {
                transform.position += dir * Time.deltaTime * chargeSpeed;
                yield return null;
            } 
            GetComponent<FacePlayer>().enabled = true;
            weapon.SetActive(false);
            i++;
            yield return new WaitForSeconds(0.3f);
        }
        isAttacking = false;
        SetVincible();
    }
    IEnumerator RocketDuration()
    {
        rotate.enabled = true;
        int i = 0;

        while (i < 3)
        {
            var rocket=Instantiate(Resources.Load<GameObject>("Weapons/RobotMissile"), spawnPt.position, Quaternion.identity);
            rocket.transform.up = player.transform.position - spawnPt.position;
            rocket.GetComponent<HomingMissile>().target = player.transform;
            i++;
            yield return new WaitForSeconds(1f);
        }
        isAttacking = false;
        rotate.enabled = false;
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

    public override void Update()
    {
        base.Update();
        if (GetComponent<EnemyHealth>().getHealth() <= 0 && !dead)
        {
            GetComponent<EnemyHealth>().DisableIndicator();
            StopAllCoroutines();
            weapon.SetActive(false);
            dead = true;
            anim.SetTrigger("Death");
            GetComponent<FacePlayer>().enabled = false;
            StartCoroutine(FadeHealthBar());
        }

        if (dead)
        {
            return;
        }
        if (player)
        {
            float width = transform.position.x - player.transform.position.x;
            float height = transform.position.y - player.transform.position.y;
            float angle = Mathf.Atan(transform.position.y - player.transform.position.y / transform.position.x - player.transform.position.x);

            switch (robotMode)
            {
                case EnemyFSM.FireMissile:
                    if (!isAttacking)
                    {
                        robotMode = EnemyFSM.Cooldown;
                    }
                    break;

                case EnemyFSM.Charge:
                    if (!isAttacking)
                    {
                        robotMode = EnemyFSM.Cooldown;
                    }
                    break;

                case EnemyFSM.Explode:
                    if (!isAttacking)
                    {
                        robotMode = EnemyFSM.Cooldown;
                    }
                    break;

                case EnemyFSM.Cooldown:
                    if (Vector3.Distance(transform.position, player.transform.position) > 20f)
                    {
                        robotMode = EnemyFSM.Chase;
                        anim.SetBool("Walking", true);
                    }
                    else if(!onCooldown)
                    {
                        robotMode = GetNextAttack();
                    }
                    break;

                case EnemyFSM.Chase: 
                    if (Vector3.Distance(transform.position, player.transform.position) <= 15f)
                    {
                        anim.SetBool("Walking", false);
                        robotMode = EnemyFSM.Cooldown;
                    } 
                    break;
            }
        }
        DoAction(robotMode);
    }
    EnemyFSM GetNextAttack()
    {
        if (lastAttack == EnemyFSM.FireMissile)
        {
            lastAttack= EnemyFSM.Charge;
            return EnemyFSM.Charge;
        }
        else if (lastAttack == EnemyFSM.Charge)
        {
            lastAttack = EnemyFSM.Explode;
            return EnemyFSM.Explode;
        }
        lastAttack = EnemyFSM.FireMissile;
        return EnemyFSM.FireMissile;
    } 
    public void CooldownTimer()
    {
        onCooldown = false; 
    }
    public IEnumerator Explosion()
    {
        SetInvincible();
        while (!chestOpen)
        {
            yield return null;
        }
        //change shader
        GetComponent<SpriteRenderer>().material = shining;
        yield return new WaitForSeconds(0.5f);
        Instantiate(Resources.Load<GameObject>("RobotExplosion"), transform.position, Quaternion.identity);
        chestOpen = false; 
        isAttacking = false;
        GetComponent<SpriteRenderer>().material = normal;
        SetVincible();
    }
    public IEnumerator AttackDuration()
    {
        yield return new WaitForSeconds(3f);
        
        isAttacking = false;
    }

    void SetSpeed()
    {
        speed = Mathf.Abs((transform.position.x - lastPos)) * 200f;
        lastPos = transform.position.x;
    } 
    public void SetInvincible()
    {
        GetComponent<EnemyHealth>().SetInvulnerable();
        shieldSprite.SetActive(true);
    }
    public void SetVincible()
    {
        GetComponent<EnemyHealth>().SetVulnerable();
        shieldSprite.SetActive(false);
    }
    IEnumerator FadeHealthBar()
    {
        while (fill.color.a > 0)
        {
            Color fillColor = fill.color;
            Color backgroundColor = background.color;
            Color borderColor = border.color;

            float fadeRate = 0.01f;

            fillColor.a -= fadeRate;
            backgroundColor.a -= fadeRate;
            borderColor.a -= fadeRate;

            fill.color = fillColor;
            background.color = backgroundColor;
            border.color = borderColor;

            yield return new WaitForSeconds(0.01f);
        }
        AudioManager.Play("RobotExplosion");
        yield return new WaitForSeconds(1f);
        var newRobot=Instantiate(Resources.Load<GameObject>("DestroyedRobot"), transform.position, Quaternion.identity);
         
        if(transform.localRotation.eulerAngles.y == 0)
        { 
            newRobot.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        LevelManager.SwitchToMusic();
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        LevelManager.SwitchToMusic();
    }
}
