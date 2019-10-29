using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone_script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSystem HS = collision.GetComponent<HealthSystem>();
            HS.playerHealth = 0;
        }
    }
}
