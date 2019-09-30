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
            if (Input.GetButtonDown("Fire1") && animator.GetBool("IsCrouching") == false)
            {
                timeBtwAttack = startTimeBtwAttack;
                Shoot();
                Invoke("Delay", 0.3f);
            }
            else
            {
                animator.SetBool("IsShooting", false);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                timeBtwAttack = startTimeBtwAttack;
                Kick();
                Invoke("Delay", 0.2f);
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

    void Delay()
    {
        animator.SetBool("IsShooting", false);
        animator.SetBool("IsKicking", false);
    }

    void Shoot()
    {
        animator.SetBool("IsShooting", true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Kick()
    {
        animator.SetBool("IsKicking", true);
    }
}
