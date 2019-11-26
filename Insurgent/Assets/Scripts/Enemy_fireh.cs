using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_fireh : MonoBehaviour
{
    public GameObject healthBar;
    public float health = 100;
    public GameObject DeathEffect;
    public GameObject bodyEffect;
    public GameObject redeffect;
    public Animator FireAnim;

    public void TakeDamage(int damage)
    {
        AI_patrol rdt = GetComponent<AI_patrol>();
        //rdt.resetDT();
        health -= damage;

        //AI_patrol PT = this.GetComponent<AI_patrol>();
        //if (PT.goingRight == true)
        //{
        //    this.transform.Translate(Vector2.right * 15 * Time.deltaTime);
        //}
        //else
        //{
        //    this.transform.Translate(Vector2.left * 15 * Time.deltaTime);
        //}
        if(health >= 0)
        {
            healthBar.gameObject.GetComponent<Image>().fillAmount = health / 3;
        }
        

        if (health <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(bodyEffect, transform.position, Quaternion.identity);
            Instantiate(redeffect, transform.position, Quaternion.identity);
            //FireAnim.SetBool("enemydead", true);
            Destroy(gameObject);
            Destroy(healthBar);
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
            Instantiate(bodyEffect, transform.position, Quaternion.identity);
            FireAnim.SetBool("enemydead", true);
            Destroy(gameObject);
            Destroy(healthBar);
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
