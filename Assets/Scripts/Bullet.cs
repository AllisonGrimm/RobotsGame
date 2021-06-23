using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody2D rb;
    public int damage = 3;
    public GameObject impactEffect;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();//If we hit an enemy

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);//Makes an impact effect on the space shot

        Destroy(gameObject);
    }
}
