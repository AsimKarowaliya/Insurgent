using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float Ammo = 3f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Ammo > 0)
        {
            Ammo -= 1;
        }

        if (Input.GetButtonDown("Fire1") && Ammo == 0)
        {
            Invoke("bulletreset", 3);
        }

        if (Input.GetButtonDown("Fire1") && Ammo > 0) 
        {
            //Invoke("Shoot", 1);
            Shoot();
            animator.SetBool("IsShooting", true);
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
    }

    void bulletreset()
    {
        Ammo = 3;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
