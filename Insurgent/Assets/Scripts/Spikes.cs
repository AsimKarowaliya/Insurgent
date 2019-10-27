using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : MonoBehaviour
{
    Image healthBar;
    public GameObject DeathEffect;
    public float health = 100;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    void Start()
    {
        healthBar = GetComponent<Image>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        this.transform.Translate(Vector2.left * 25 * Time.deltaTime);
        healthBar.fillAmount = health / 100;

        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            // enemy explosion sound
        }
    } 
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("spike"))
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
