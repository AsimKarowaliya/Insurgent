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
        Patrol rdt = GetComponent<Patrol>();
        rdt.resetDT();
        health -= damage;

        Patrol PT = this.GetComponent<Patrol>();
        if (PT.goingRight == true)
        {
            this.transform.Translate(Vector2.right * 15 * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(Vector2.left * 15 * Time.deltaTime);
        }
        
        healthBar.fillAmount = health / 3;

        if (health <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            // enemy explosion sound
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);

        if (coll.CompareTag("Bullet"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.2f);
        }

        if (coll.CompareTag("flykick"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.2f);
        }

        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();
        if (coll.CompareTag("Player") && hs.playerresettime <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            HealthSystem SN = coll.GetComponent<HealthSystem>();
            SN.playerHealth -= 1;
            SN.playerresettime = 2;
        }

    }

    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}