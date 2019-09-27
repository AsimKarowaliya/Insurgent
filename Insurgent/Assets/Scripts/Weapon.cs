using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timeBtwAttack;
    public float startTimeBtwAttack;

    // Update is called once per frame
    void Update()
    {

        if(timeBtwAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                timeBtwAttack = startTimeBtwAttack;
                Shoot();
            }
            else
            {
                animator.SetBool("IsShooting", false);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                timeBtwAttack = startTimeBtwAttack;
                Kick();
            }
            else
            {
                animator.SetBool("IsKicking", false);
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }


    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("IsShooting", true);
    }

    void Kick()
    {
        animator.SetBool("IsKicking", true);
    }
}
