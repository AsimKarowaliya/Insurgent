using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public float health = 100;
    public GameObject DeathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    //void OnTriggerEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        HealthSystem SN = gameObject.GetComponent<HealthSystem>();
    //        SN.playerHealth -= 1;
    //    }
    //}

}


//Image healthBar;

//void Start()
//{
//    healthBar = GetComponent<Image>();
//}

//healthBar.fillAmount = health / 100;