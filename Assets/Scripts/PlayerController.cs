
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    public float speed;
    public bool isFacingRight = true;
    public float health;
    public float maxHealth;


    public float exp;
    public float maxEXP;
    public float extraXP;
    public XPBar xpBar;
    public int level;

    public float damageTaken;
    public HealthBar healthBar;
    public Slider xpBarSlider;
    EnemyCQC EnemyCombat;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCombat = FindObjectOfType<EnemyCQC>();
        health = maxHealth;
        exp = 0;
        healthBar.SetMaxHealth(maxHealth);
        xpBar.SetEXP(exp);
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        xpBarSlider.maxValue = maxEXP;
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(horizontal * speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (horizontal > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(horizontal * speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        Vector3 CharacterScale = transform.localScale;
        if (horizontal > 0 && isFacingRight || horizontal < 0 && !isFacingRight)
        {

            Flip();
            
        }

        if(EnemyCombat.damagingPlayer == true)
        {
            TakeDamage();
        }

       if(exp >= maxEXP)
        {
            level += 1;
            extraXP = exp - maxEXP;
            exp = 0 + extraXP;
            maxEXP += 50;


        }

        Debug.Log("LEVEL: " + level);
        Debug.Log("Max EXP: " + maxEXP);
    }

    public void TakeDamage()
    {
        health -= damageTaken;
        healthBar.SetHealth(health);
    }


    public void Flip()
    {

        transform.Rotate(Vector3.up * 180);
        isFacingRight = !isFacingRight;

    }

    
}
