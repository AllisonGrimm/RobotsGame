using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFight : MonoBehaviour
{
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    public float bulletForce;

    public Transform target;

    public GameObject projectile;
    private bool m_FacingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            // Turn towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 180f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 360 * Time.deltaTime);

            if (Time.time > lastAttackTime + attackDelay)
            {
                GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-bulletForce, 0f));
                lastAttackTime = Time.time;
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
