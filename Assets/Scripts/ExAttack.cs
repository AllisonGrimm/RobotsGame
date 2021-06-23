using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public int damage = 15;
    public float nextAttackTime = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
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
        foreach(Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackpoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
