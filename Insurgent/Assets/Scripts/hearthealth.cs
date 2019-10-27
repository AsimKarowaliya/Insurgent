using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearthealth : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem SN = thePlayer.GetComponent<HealthSystem>();

        if (col.CompareTag("Player") && SN.playerHealth != 5)
        {
            Destroy(gameObject);
            SN.playerHealth += 1;
        }
    }
}
