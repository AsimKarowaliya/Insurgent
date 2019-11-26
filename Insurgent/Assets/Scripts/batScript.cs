using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batScript : MonoBehaviour
{
    public int health = 1;
    public GameObject az;
    private Transform playerPos;
    public GameObject DeathEffect;
    private Vector2 pos;
    public float speed;

    void Start()
    {
        pos = new Vector2(this.transform.position.x, this.transform.position.y);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        detechplayerscript AZ = az.GetComponent<detechplayerscript>();
        if (AZ.playerInRange == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(playerPos.position.x, playerPos.position.y + 0.2f), speed * Time.deltaTime);
            az.SetActive(false);
        }

        if (this.transform.position.x < playerPos.position.x)
        {
            this.transform.localScale = new Vector2(-1, 1);
        }
        else if (this.transform.position.x > playerPos.position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
        }

        var dist = Vector2.Distance(playerPos.position, this.transform.position);
        if(dist >= 10)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, pos, speed * Time.deltaTime);
            az.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        smScript.PlaySound("bat/Die1");
        if (health <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            Destroy(gameObject);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();
        if (coll.CompareTag("Player") && hs.playerresettime <= 0 && !az.activeInHierarchy)
        {
            ultBarscript.ultMeter += 0.5f;
            smScript.PlaySound("bat/Attack2");
            HealthSystem SN = coll.GetComponent<HealthSystem>();
            SN.playerHealth -= 1;
            SN.playerresettime = 2;
        }
    }
}
