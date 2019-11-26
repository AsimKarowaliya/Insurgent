using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ult_script : MonoBehaviour
{

    public int damage = 40;
    public float ultTime = 15f;

    void Update()
    {
        Destroy(gameObject, ultTime);
    }

    void OnTriggerEnter2D(Collider2D Info)
    {
        //Debug.Log(Info.name);

        if (Info.CompareTag("Enemy"))
        {
            Info.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (Info.CompareTag("EnemyB"))
        {
            Info.GetComponent<EnemyB>().TakeDamage(damage);
        }
        else if (Info.CompareTag("Enemy_Fire"))
        {
            //shake.CamShake();
            Info.GetComponent<Enemy_fireh>().TakeDamage(damage);
        }
        else if (Info.CompareTag("LavaBoss"))
        {
            Info.GetComponent<bossScript>().TakeDamage(damage);
            Destroy(gameObject, ultTime);
        }
        else
        {
            return;
        }

    }
}
