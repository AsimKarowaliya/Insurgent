using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        
        if(hitInfo.gameObject.name == "burning-ghoul1")
        {
        Destroy(hitInfo.gameObject);
        }
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}