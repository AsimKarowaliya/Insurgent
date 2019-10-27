using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public int playerHealth;
    public int numOfHearts;
    private int oldplayerHealth;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    GameObject plya;


    void Start()
    {
        plya = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        oldplayerHealth = playerHealth;

        if (playerHealth > numOfHearts)
        {
            playerHealth = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

}
