using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKick : MonoBehaviour
{
    public Animator animator;
    public int damage = 40;
    public GameObject kickEffect;

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(coll.name);

        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (coll.CompareTag("EnemyB"))
        {
            coll.GetComponent<EnemyB>().TakeDamage(damage);
        }
        else if (coll.CompareTag("Enemy_Fire"))
        {
            coll.GetComponent<Enemy_fireh>().TakeDamage(damage);
        }
        else if (coll.CompareTag("LavaBoss"))
        {
            coll.GetComponent<bossScript>().TakeDamage(damage);
        }
        else if (coll.CompareTag("bat"))
        {
            coll.GetComponent<batScript>().TakeDamage(damage);
        }
        Instantiate(kickEffect, transform.position, transform.rotation);
    }
}