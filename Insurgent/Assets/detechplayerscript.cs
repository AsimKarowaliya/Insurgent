using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detechplayerscript : MonoBehaviour
{
    public bool playerInRange;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
}
