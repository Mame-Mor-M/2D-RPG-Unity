using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCQC : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayers;

    public float attackTimer = 0;
    public float attackCooldown;

    public bool damagingEnemy = false;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= 1 * Time.deltaTime;
        if (attackTimer <= 0)
        { 
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
                anim.SetTrigger("BasicSwing");
            }

        }
       
        else
        {
            damagingEnemy = false;
        }
    }

    public void Attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("You hit the enemy!" + enemy.name);
            damagingEnemy = true;
            attackTimer = attackCooldown;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
