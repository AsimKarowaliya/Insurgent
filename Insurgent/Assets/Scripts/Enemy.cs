using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float health = 100;
    public GameObject DeathEffect;

    //Image healthBar;

    //void Start()
    //{
    //    healthBar = GetComponent<Image>();
    //}

    public void TakeDamage(int damage)
    {
        health -= damage;
        //healthBar.fillAmount = health / 100;

        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}