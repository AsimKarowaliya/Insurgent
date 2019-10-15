using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKick : MonoBehaviour
{
    public Animator animator;
    public int damage = 40;

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
    }
}