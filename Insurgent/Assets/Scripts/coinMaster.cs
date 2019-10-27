using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class coinMaster : MonoBehaviour
{
    public int points;
    public Text pointsText;

    void Update()
    {
        pointsText.text = ("Points: "+ points);
    }
}
