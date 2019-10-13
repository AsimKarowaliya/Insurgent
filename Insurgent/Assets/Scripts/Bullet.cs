using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 40;
    public float speed = 10f;
    public Rigidbody2D rb;

    public GameObject flashEffect;
    GameObject other;

    void Start()
    {
        rb.velocity = transform.right * speed;
        other = GameObject.FindGameObjectWithTag("Flash");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);

        if (hitInfo.CompareTag("Enemy"))
        {
            hitInfo.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (hitInfo.CompareTag("EnemyB"))
        {
            hitInfo.GetComponent<EnemyB>().TakeDamage(damage);
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