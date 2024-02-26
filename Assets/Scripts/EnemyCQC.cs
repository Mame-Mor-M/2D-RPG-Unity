using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCQC : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayers;

    public float attackTimer = 0;
    public float attackCooldown;

    public bool damagingPlayer = false;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("dama player " + damagingPlayer);
    }

    public void Attack()
    {
            attackTimer -= 1 * Time.deltaTime;
            if(attackTimer <= 0)
            {
                damagingPlayer = true;
                attackTimer = attackCooldown;
            }
            else
            {
                damagingPlayer = false;
            }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;

        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
