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
    public Material whiteF;
    private Material matDef;

    void Start()
    {
        plya = GameObject.FindGameObjectWithTag("Player");
        matDef = plya.GetComponent<SpriteRenderer>().material;
        whiteF = Resources.Load("WhiteFlash", typeof(Material)) as Material;
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

//plya.GetComponent<SpriteRenderer>().color = Color.red;
//plya.GetComponent<SpriteRenderer>().material = whiteF;

//plya.GetComponent<SpriteRenderer>().color = Color.white;
//plya.GetComponent<SpriteRenderer>().material = matDef;