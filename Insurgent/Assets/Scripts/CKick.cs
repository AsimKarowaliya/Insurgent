using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKick : MonoBehaviour
{
    public int damage = 40;

    void OnTriggerExit2D(Collider2D Info)
    {
        Debug.Log(Info.name);

        if (Info.CompareTag("Enemy"))
        {
            Info.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}