using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalCoinScript : MonoBehaviour
{
    public int coins;
    public Text TotalCoin;

    void Update()
    {
        TotalCoin.text = ("x " + coins);
    }
}
