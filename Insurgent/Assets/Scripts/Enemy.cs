using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    Image healthBar;
    public float health = 100;
    public GameObject DeathEffect;

    //private Material matWhite;
    //private Material[] matDefault;
    //SpriteRenderer sr;

    void Start()
    {
        healthBar = GetComponent<Image>();
        //matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        //matDefault = sr.materials;
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
            //sr.materials = matWhite;
        }
        //else
        //{
        //    Invoke("ResetMat", 0.2f);
        //}

        if (coll.CompareTag("Player"))
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            HealthSystem SN = coll.GetComponent<HealthSystem>();
            SN.playerHealth -= 1;
        }

    }

    //void ResetMat()
    //{
    //    sr.materials = matDefault;
    //}
}