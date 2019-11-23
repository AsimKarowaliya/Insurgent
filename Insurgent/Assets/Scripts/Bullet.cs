﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 40;
    public float speed = 10f;
    public Rigidbody2D rb;

    public GameObject flashEffect;
    GameObject other;

    private Shake shake;

    void Start()
    {
        rb.velocity = transform.right * speed;
        other = GameObject.FindGameObjectWithTag("Flash");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);

        if (hitInfo.CompareTag("Enemy"))
        {
            //shake.CamShake();
            hitInfo.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (hitInfo.CompareTag("EnemyB"))
        {
            //shake.CamShake();
            hitInfo.GetComponent<EnemyB>().TakeDamage(damage);
        }
        else if (hitInfo.CompareTag("Enemy_Fire"))
        {
            //shake.CamShake();
            hitInfo.GetComponent<Enemy_fireh>().TakeDamage(damage);
        }
        else if (hitInfo.CompareTag("Tiles"))
        {
            Destroy(gameObject);
        }
        else if (hitInfo.CompareTag("LavaBoss"))
        {
            //shake.CamShake();
            Destroy(gameObject);
            hitInfo.GetComponent<bossScript>().TakeDamage(damage);
        }
        else if (hitInfo.CompareTag("bat"))
        {
            Destroy(gameObject);
            hitInfo.GetComponent<batScript>().TakeDamage(damage);
        }
        else
        {
            return;
        }

        Instantiate(flashEffect, transform.position, transform.rotation);
        // impact sound
        Destroy(gameObject);
        Destroy(other);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}