using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaAttack : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 5;
    public GameObject impactEffect;
    public LineRenderer lineR;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))//Whenever the player presses the fire button
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()//Contains shooting logic
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if(hitInfo)
        {
            /*hitInfo.transform.GetComponent<Enemy>();//If we hit an enemy

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }*/

            //Instantiate(impactEffect, hitInfo.point,Quaternion.identity);//Makes an impact effect on the space shot

            lineR.SetPosition(0, firePoint.position);//Makes a line from fire point to where shot
            lineR.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineR.SetPosition(0, firePoint.position);//Makes a line from fire point to where shot
            lineR.SetPosition(0, firePoint.position+firePoint.right*100);
        }
        lineR.enabled = true;//Shows the line from the weapon to where the attack hits

        yield return new WaitForSeconds(0.02f);

        lineR.enabled = false;
    }
}
