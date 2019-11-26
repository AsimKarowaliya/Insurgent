using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaBombScript : MonoBehaviour
{
    public GameObject impactEffect;


    void OnTriggerEnter2D(Collider2D coll)
    {

        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();

        if (coll.CompareTag("Player") && hs.playerresettime <= 0)
        {
            DestroyProj();
            ultBarscript.ultMeter += 0.5f;
            hs.playerHealth -= 1;
            hs.playerresettime = 2.5f;
        }
        else if (coll.CompareTag("Tiles"))
        {
            DestroyProj();
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

}
