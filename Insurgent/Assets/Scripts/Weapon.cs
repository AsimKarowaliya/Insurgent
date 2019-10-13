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
    private PlayerMovement pm;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }
    void Update()
    {

        if(timeBtwAttack <= 0)
        {
            if (Input.GetButtonUp("Fire1") && animator.GetBool("IsCrouching") == false && animator.GetBool("IsJumping") == false)
            {
                timeBtwAttack = startTimeBtwAttack;
                Shoot();
                // play shoot sound
                Invoke("Delay", 0.3f);
            }
            else
            {
                animator.SetBool("IsShooting", false);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                timeBtwAttack = startTimeBtwAttack;
                animator.SetBool("IsKicking", true);
                // play kick sound
                Invoke("Delay", 0.2f);
            }
            else
            {
                animator.SetBool("IsKicking", false);
            }

            if (pm.jj == true && Input.GetButtonDown("Fire2"))
            {
                animator.SetBool("FlyKick", true);
                animator.SetBool("IsJumping", false);
            }
            else
            {
                animator.SetBool("FlyKick", false);
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
        animator.SetBool("FlyKick", false);
    }

    void Shoot()
    {
        animator.SetBool("IsShooting", true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
