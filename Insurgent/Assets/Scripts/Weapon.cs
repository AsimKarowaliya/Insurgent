using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int Ammo;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Ammo > 0) 
        {
            Shoot();
            animator.SetBool("IsShooting", true);
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }

        if (Ammo == 0)
        {
            Invoke("bulletreset", 5);
        }
    }

    void bulletreset()
    {
        Ammo = 5;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Ammo--;
    }
}
