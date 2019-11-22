using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaPunchScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {

        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();

        if (coll.CompareTag("Player") && hs.playerresettime <= 0)
        {
            hs.playerHealth -= 1;
            hs.playerresettime = 2.5f;
        }

    }
}
