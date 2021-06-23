using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    private bool m_FacingRight = false;

    public float bulletForce;

    public Transform target;

    public GameObject projectile;
    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            // Turn towards the target
            if (target.position.x < transform.position.x)
            {
                if (m_FacingRight)
                {
                    Flip();
                }
            }

            if (target.position.x > transform.position.x)
            {
                if (!m_FacingRight)
                {
                    Flip();
                }
            }
            
            //Check to see if it's time to attack
            if (Time.time > lastAttackTime + attackDelay)
            {
                    //hit the player

                    if (!m_FacingRight)
                    {
                        GameObject newMissile = Instantiate(projectile, transform.position, transform.rotation);
                        newMissile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(bulletForce * -1, 0f));
                        lastAttackTime = Time.time;
                    }
                    else
                    {
                        GameObject newMissile = Instantiate(projectile, transform.position, transform.rotation);
                        newMissile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(bulletForce, 0f));
                        lastAttackTime = Time.time;
                    }
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        if (m_FacingRight)
        {
            m_FacingRight = false;
        }
        else
        {
            m_FacingRight = true;
        }

        transform.Rotate(0f, 180f, 0f);
    }

    // Check to see if the player is within our attack range
}
