using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private CircleCollider2D collider;
    public GameObject deathEffect;

    // health information
    public int maxHealth = 100;
    public int currentHealth;
    public HealthController healthController;
    private bool dieOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthController.SetMaxHealth(maxHealth);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //myAnimator = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !dieOnce)
        {
            dieOnce = true;
            currentHealth = 0;
            // AudioController.Instance.PlaySFX(sfxToPlay);
            StartCoroutine(deathCoroutine());
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthController.SetHealth(currentHealth);
    }

    IEnumerator deathCoroutine()
    {
        var position = transform.position;
        var clone = Instantiate(deathEffect, position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(clone);
        Destroy(gameObject);
    }
}
