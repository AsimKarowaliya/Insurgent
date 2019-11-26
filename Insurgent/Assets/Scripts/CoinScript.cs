using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject textC = GameObject.Find("TotalCoinText");
        totalCoinScript TC = textC.GetComponent<totalCoinScript>();

        if (col.CompareTag("Player"))
        {
            smScript.PlaySound("coin-sound");
            Destroy(gameObject);
            TC.coins += 1;
        }

    }

}
