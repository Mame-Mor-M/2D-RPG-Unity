using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyTarget;

    public float speed;
    public float enemyRange;
    public float Health;
    public float maxHealth;

    public float xpGiven;

    public bool inRange = false;
    public bool isTouching = false;

    public SpriteRenderer sprite;
    private float counter = 0.3f;

    private bool isHurt = false;
    public bool isDead = false;

    private bool isSwinging = false;

    public float meleeDamage;

    public Transform playerPos;

    public GameObject healthBar;
    private Vector3 localScale;
    private Vector3 scaleChange;
    public bool gettingEXP = false;


    EnemyCQC EnemyCombat;
    fireProjectile Projectile;
    PlayerCQC PlayerCombat;
    PlayerController playCtrl;

    public Rigidbody2D enemyRig;
    void Start()
    {
        EnemyCombat = FindObjectOfType<EnemyCQC>();
        Projectile = FindObjectOfType<fireProjectile>();
        PlayerCombat = FindObjectOfType<PlayerCQC>();
        playCtrl = FindObjectOfType<PlayerController>();

        Health = maxHealth;
        localScale = healthBar.transform.localScale;

        scaleChange.x = Health/3;
        healthBar.transform.localScale = localScale;
        healthBar.transform.localScale += scaleChange/3;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead == false)
        {
            isTouching = true;

            if (collision.gameObject.tag == "Projectile")
            {
                Health -= Projectile.projectileDamage;
                sprite.color = new Color(255, 0, 0, 255);
                isHurt = true;

                scaleChange.x = Health/3;
                healthBar.transform.localScale = localScale;
                healthBar.transform.localScale += scaleChange/3;

                if (Health <= 0)
                {
                    transform.Rotate(Vector3.forward * -90);
                    isDead = true;
                    isTouching = false;
                    inRange = false;
                    GiveEXP();
                    GetComponent<Collider2D>().enabled = false;
                    enemyRig.isKinematic = true;

                }

                if (isDead == true)
                {
                    Destroy(healthBar);

                }


            }
        }
        

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTouching = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        playCtrl.xpBar.SetEXP(playCtrl.exp);
        if (isDead == false)
        {
            InRange();
            if(playerPos == null)
            {
                return;
            }

            float dist = Vector3.Distance(playerPos.position, transform.position);
            if (inRange == true && isTouching == false)
            {
                transform.Translate(Vector3.right * Time.deltaTime * -speed);
            }
            

            if(dist <= 2f)
            {
                if(PlayerCombat.damagingEnemy == true)
                {
                    TakeDamage();
                }
                
            }
                
        
            
            else if (inRange == false ||isTouching == true)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed * 0);
            }


            if (inRange == true && isTouching == true)
            {
                EnemyCombat.Attack();
            }

        }

        if (isHurt == true)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                sprite.color = new Color(255, 255, 255, 255);
                counter = 0.3f;
                isHurt = false;
            }
        }

        


        Debug.Log("inRange: " + inRange);
        Debug.Log("IsTouching: " + isTouching);
        Debug.Log("HP: " + Health);
        Debug.Log("XP: " + playCtrl.exp);


    }

    void InRange()
    {
        float dist = Vector3.Distance(playerPos.position, transform.position);
        if (dist <= enemyRange)
        {
            inRange = true;
            
        }   

        if (dist >= enemyRange)
        {
            inRange = false;

        }

    }

    public void TakeDamage()
    {
        Health -= meleeDamage;
        sprite.color = new Color(255, 0, 0, 255);
        isHurt = true;

        if (Health <= 0)
        {
            transform.Rotate(Vector3.forward * -90);
            isDead = true;
            inRange = false;
            isTouching = false;
            GiveEXP();
            GetComponent<Collider2D>().enabled = false;
            enemyRig.isKinematic = true;

        }

        scaleChange.x = Health/3;
        healthBar.transform.localScale = localScale;
        healthBar.transform.localScale += scaleChange/3;
        if(isDead == true)
        {
            Destroy(healthBar);
        }
    }

    public void GiveEXP()
    {
        playCtrl.exp += xpGiven;
        gettingEXP = true;
        playCtrl.xpBar.SetEXP(playCtrl.exp);
    }

}

