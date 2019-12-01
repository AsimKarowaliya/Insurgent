using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProj : MonoBehaviour
{
    public float speed;
    public GameObject flashEffect;
    private GameObject other;
    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        other = GameObject.FindGameObjectWithTag("Flash");
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProj();
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        GameObject thePlayer = GameObject.Find("Player");
        HealthSystem hs = thePlayer.GetComponent<HealthSystem>();

        if (coll.CompareTag("Player") && hs.playerresettime <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            DestroyProj();
            HealthSystem SN = coll.GetComponent<HealthSystem>();
            SN.playerHealth -= 1;
            SN.playerresettime = 2.5f;
        }
        else if (coll.CompareTag("Tiles"))
        {
            DestroyProj();
        }
        else
        {
            return;
        }
    }

    void DestroyProj()
    {
        Destroy(gameObject);
        Instantiate(flashEffect, transform.position, transform.rotation);
        Destroy(other, 1.0f);
    }
}
