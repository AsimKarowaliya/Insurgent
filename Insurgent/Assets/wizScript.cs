using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wizScript : MonoBehaviour
{
    public GameObject healthBar;
    public float health;
    private float h;
    private Transform playerPos;
    public GameObject DeathEffect;
    public GameObject redeffect;
    private Animator Wanim;
    public Transform firePoint;
    public GameObject proj;
    private float tba;
    public float stba;
    public float attackDistance = 7f;

    void Start()
    {
        h = health;
        Wanim = this.GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (this.transform.position.x < playerPos.position.x)
        {
            this.transform.localScale = new Vector2(-1, 1);
            firePoint.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (this.transform.position.x > playerPos.position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
            firePoint.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        var dist = Vector2.Distance(playerPos.position, this.transform.position);
        if (dist <= attackDistance)
        {
            if(tba <= 0)
            {
                Wanim.SetTrigger("Shoot");
                Invoke("Shoot", 0.8f);
                tba = stba;
            }
            else
            {
                tba -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //smScript.PlaySound("bat/Die1");
        if (health <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            Destroy(gameObject);
            Destroy(healthBar);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(redeffect, transform.position, Quaternion.identity);
        }

        if (health >= 0)
        {
            healthBar.gameObject.GetComponent<Image>().fillAmount = health / h;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
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
    }

    void Shoot()
    {
        Instantiate(proj, firePoint.position, firePoint.rotation);
    }

    void ResetMat()
    {
        if(h == 5)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color((93/255), (220/255), 1, 1);
        }
    }
}
