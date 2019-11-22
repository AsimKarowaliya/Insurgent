using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public int playerHealth;
    public int numOfHearts;

    public float playerresettime = 0;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    GameObject plya;


    void Start()
    {
        playerresettime = 0;
        plya = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

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

        if (playerresettime > 0 && playerHealth > 0)
        {
            playerresettime -= Time.deltaTime;
            playerflash();
        }

    }

    void playerflash()
    {
        Invoke("sc", 0.1f);
        Invoke("rsc", 0.51f);
    }

    void rsc()
    {
        plya.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
    void sc()
    {
        plya.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
    }

}
