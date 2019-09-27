using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKick : MonoBehaviour
{

    public int damage = 40;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        PyroAI enemy = hitInfo.GetComponent<PyroAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}