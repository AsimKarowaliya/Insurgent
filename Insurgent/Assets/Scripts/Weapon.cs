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
                animator.SetBool("IsShooting", true);
            }
            else
            {
                animator.SetBool("IsShooting", false);
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
    }

    void Kick()
    {

    }
}
