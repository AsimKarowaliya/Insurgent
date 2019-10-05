using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    Image healthBar;
    public float health = 100;
    public GameObject DeathEffect;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            // enemy explosion
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);

        if (coll.CompareTag("Bullet"))
        {
            healthBar.fillAmount = health / 100;
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.2f);
        }

        if (coll.CompareTag("Player"))
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            HealthSystem SN = coll.GetComponent<HealthSystem>();
            SN.playerHealth -= 1;
        }

    }

    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}