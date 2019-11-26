using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossScript : MonoBehaviour
{
    public int health;
    public int damage;
    //private float timeBA = 1.5f;

    public Slider healthbar;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health;
        var state = Random.Range(0, 2);

        if (health <= 50 && anim.GetBool("isIdle") == true)
        {
            if(state == 0)
            {
                anim.SetTrigger("meltup");
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", false);
            }
            else if (state == 1)
            {
                anim.SetTrigger("meltdown");
                anim.SetBool("isIdle", false);
            }
            
        }

        if(health <= 50 && anim.GetBool("isWalking") == true)
        {
            anim.SetTrigger("idle2");
        }
    }

    public void TakeDamage(int dmg)
    {

        health -= dmg;

        if (health <= 0)
        {
            //Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);

        if (coll.CompareTag("Bullet"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.1f);
        }

        if (coll.CompareTag("flykick"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.1f);
        }

        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();
        if (coll.CompareTag("Player") && hs.playerresettime <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
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