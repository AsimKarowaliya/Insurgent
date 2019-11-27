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
            smScript.PlaySound("kick-hit");
            coll.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (coll.CompareTag("EnemyB"))
        {
            smScript.PlaySound("kick-hit");
            coll.GetComponent<EnemyB>().TakeDamage(damage);
        }
        else if (coll.CompareTag("Enemy_Fire"))
        {
            smScript.PlaySound("kick-hit");
            coll.GetComponent<Enemy_fireh>().TakeDamage(damage);
        }
        else if (coll.CompareTag("LavaBoss"))
        {
            smScript.PlaySound("kick-hit");
            coll.GetComponent<bossScript>().TakeDamage(damage);
        }
        else if (coll.CompareTag("bat"))
        {
            smScript.PlaySound("kick-hit");
            coll.GetComponent<batScript>().TakeDamage(damage);
        }
        else if (coll.CompareTag("Wiz"))
        {
            smScript.PlaySound("kick-hit");
            coll.GetComponent<wizScript>().TakeDamage(damage);
        }
        Instantiate(kickEffect, transform.position, transform.rotation);
    }
}