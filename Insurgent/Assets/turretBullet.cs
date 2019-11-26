using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject impactEffect;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();

        if (coll.CompareTag("Player") && hs.playerresettime <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            DestroyProj();
            hs.playerHealth -= 1;
            hs.playerresettime = 2.5f;
        }
        else if (coll.CompareTag("Tiles"))
        {
            return;
        }
        else
        {
            return;
        }
    }

    void DestroyProj()
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
