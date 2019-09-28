using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroAI : MonoBehaviour
{

    public int health = 100;
    public GameObject DeathEffect;

    private Material whiteFlash;
    private Material matDefault;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        whiteFlash = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMat", 0.2f);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        if (hitInfo.CompareTag("Bullet"))
        {
            Destroy(hitInfo.gameObject);
            sr.material = whiteFlash;
        }
    }

    void ResetMat()
    {
        sr.material = matDefault;
    }

}
