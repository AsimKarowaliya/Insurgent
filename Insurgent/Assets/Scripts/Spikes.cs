using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : MonoBehaviour
{
    Image healthBar;
    //public GameObject DeathEffect;
    public float health = 100;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    void Start()
    {
        healthBar = GetComponent<Image>();
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            //Instantiate( transform.position, Quaternion.identity);
            //Destroy(gameObject);
            HealthSystem SN = coll.GetComponent<HealthSystem>();
            SN.playerHealth -= 1;
        }
    }
    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
