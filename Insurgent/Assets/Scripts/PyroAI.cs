using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroAI : MonoBehaviour
{

    public int health = 100;
    public GameObject DeathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
