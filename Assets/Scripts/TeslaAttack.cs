using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullt;
    public float nextAttackTime = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()//Contains shooting logic
    {
        Instantiate(bullt, firePoint.position, firePoint.rotation);

    }
}
