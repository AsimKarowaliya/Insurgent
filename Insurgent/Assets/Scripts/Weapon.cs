﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Animator animator; //animator controller for Player
    public Transform firePoint; //gameobject transform for firepoint
    public GameObject bulletPrefab; //load redfireball
    public GameObject blueBulletPrefab; // load bluefireball
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private PlayerMovement pm;
    public float chargeTimer=0;
    public KeyCode ca;
    public bool fullCharge = false;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKey(ca))
        {
            chargeTimer += Time.deltaTime;
            animator.SetBool("IsCharging", true);
            PlayerMovement rs = GetComponent<PlayerMovement>();
            rs.runSpeed = 0;

            if (chargeTimer > 2)
            {
                fullCharge = true;
            }
            else if (chargeTimer < 2 || animator.GetBool("IsCrouching") == true || animator.GetBool("IsJumping") == true)
            {
                fullCharge = false;
            }

        }
        else
        {
            animator.SetBool("IsCharging", false);
            PlayerMovement rs = GetComponent<PlayerMovement>();
            rs.runSpeed = 30;
            chargeTimer = 0;
        }

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(ca) && fullCharge == true && animator.GetBool("IsCrouching") == false && animator.GetBool("IsJumping") == false)
            {
                timeBtwAttack = startTimeBtwAttack;
                animator.SetTrigger("fullcharge");
                animator.SetBool("IsCharging", false);
                ShootBlue();
                Invoke("Delay", 0.3f);
            }

            if (Input.GetButtonUp("Fire1") && fullCharge == false && animator.GetBool("IsCrouching") == false && animator.GetBool("IsJumping") == false)
            {
                timeBtwAttack = startTimeBtwAttack;
                animator.SetTrigger("fullcharge");
                animator.SetBool("IsCharging", false);
                Shoot();
                Invoke("Delay", 0.3f);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                timeBtwAttack = startTimeBtwAttack;
                animator.SetBool("IsKicking", true);
                Invoke("Delay", 0.2f);
            }

            if (pm.jj == true && Input.GetButtonDown("Fire2"))
            {
                timeBtwAttack = startTimeBtwAttack;
                animator.SetBool("FlyKick", true);
                animator.SetBool("IsJumping", false);
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
        chargeTimer = 0;
    }

    void ShootBlue()
    {
        animator.SetBool("IsShooting", true);
        Instantiate(blueBulletPrefab, firePoint.position, firePoint.rotation);
        chargeTimer = 0;
    }

}

//    if (timeBtwAttack <= 0)
//    {

//        if (Input.GetKey(ca))
//        {
//            chargeTimer += Time.deltaTime;
//            animator.SetBool("IsCharging", true);
//            PlayerMovement rs = GetComponent<PlayerMovement>();
//            rs.runSpeed = 0;
//        }
//        else if (chargeTimer < 2 || animator.GetBool("IsCrouching") == true || animator.GetBool("IsJumping") == true)
//        {
//            PlayerMovement rs = GetComponent<PlayerMovement>();
//            rs.runSpeed = 40;
//            chargeTimer = 0;
//            animator.SetBool("IsCharging", false);
//        }

//        if (Input.GetKey(ca) && animator.GetBool("IsCrouching") == false && chargeTimer > 2 && animator.GetBool("IsJumping") == false)
//        {
//            timeBtwAttack = startTimeBtwAttack;
//            animator.SetTrigger("fullcharge");
//            animator.SetBool("IsCharging", false);
//            ShootBlue();
//            Invoke("Delay", 0.3f);
//        }

//        if (Input.GetButtonUp("Fire1") && animator.GetBool("IsCrouching") == false && chargeTimer < 2 && animator.GetBool("IsJumping") == false)
//        {
//            timeBtwAttack = startTimeBtwAttack;
//            animator.SetTrigger("fullcharge");
//            animator.SetBool("IsCharging", false);
//            Shoot();
//            Invoke("Delay", 0.3f);
//        }

//        if (Input.GetButtonDown("Fire2"))
//        {
//            timeBtwAttack = startTimeBtwAttack;
//            animator.SetBool("IsKicking", true);
//            // play kick sound
//            Invoke("Delay", 0.2f);
//        }

//        if (pm.jj == true && Input.GetButtonDown("Fire2"))
//        {
//            timeBtwAttack = startTimeBtwAttack;
//            animator.SetBool("FlyKick", true);
//            animator.SetBool("IsJumping", false);
//        }

//    }
//    else
//    {
//        timeBtwAttack -= Time.deltaTime;
//    }