using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public Transform attackpoint2;
    public Transform attackpoint3;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public int damage = 2;
    public float nextAttackTime = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                Debug.Log("attack");
            }
        }
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);
        foreach (Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
        }
        Collider2D[] hitenemies2 = Physics2D.OverlapCircleAll(attackpoint2.position, attackrange, enemyLayers);
        foreach (Collider2D enemy in hitenemies2)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
        }
        Collider2D[] hitenemies3 = Physics2D.OverlapCircleAll(attackpoint3.position, attackrange, enemyLayers);
        foreach (Collider2D enemy in hitenemies3)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
        Gizmos.DrawWireSphere(attackpoint2.position, attackrange);
        Gizmos.DrawWireSphere(attackpoint3.position, attackrange);
    }
}
