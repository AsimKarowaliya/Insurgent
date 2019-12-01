using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizFireBall : MonoBehaviour
{
    public int damage = 40;
    public float speed = 2f;
    private Rigidbody2D rb;
    public GameObject flash;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -1 * speed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();

        if (coll.CompareTag("Player") && hs.playerresettime <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            Destroy(gameObject);
            Instantiate(flash, transform.position, transform.rotation);
            HealthSystem SN = coll.GetComponent<HealthSystem>();
            SN.playerHealth -= 1;
            SN.playerresettime = 2.5f;
        }
        else if (coll.CompareTag("Tiles"))
        {
            Destroy(gameObject);
            Instantiate(flash, transform.position, transform.rotation);
        }
        else
        {
            return;
        }
    }
}
