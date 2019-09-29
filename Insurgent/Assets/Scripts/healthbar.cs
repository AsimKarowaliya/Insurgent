using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    Image healthBar;
    private static float xhealth;

    void Start()
    {
        healthBar = GetComponent<Image>();
        xhealth = 100f;
    }

    public void ChangeHealth(int damage)
    {
        xhealth -= damage;
    }

    void Update()
    {
        healthBar.fillAmount = xhealth / 100;
    }

}
