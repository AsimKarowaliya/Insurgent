using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyB : MonoBehaviour
{
    public Transform firePoint;
    public GameObject proj;
    public GameObject DeathEffect;

    Image healthBar;
    public float health = 100;

    public Animator animator;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform targetleft;
    public Transform targetright;

    private bool insideZone = false;
    public float dist;

    void Start()
    {
        healthBar = GetComponent<Image>();
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwShots <= 0)
        {
            RaycastHit2D zoneleft = Physics2D.Raycast(targetleft.position, Vector2.left, dist);
            RaycastHit2D zoneright = Physics2D.Raycast(targetright.position, Vector2.right, dist);

            if (zoneleft.collider == true && zoneleft.transform.gameObject.tag == "Player")
            {
                insideZone = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
                //Debug.Log("SHootingleft");
            }
            else if (zoneright.collider == true && zoneright.transform.gameObject.tag == "Player")
            {
                insideZone = true;
                transform.eulerAngles = new Vector3(0, -180, 0);
                //Debug.Log("SHootingright");
            }
            else
            {
                insideZone = false;
            }

            GameObject plyahealth = GameObject.Find("Player");
            HealthSystem SN = plyahealth.GetComponent<HealthSystem>();
            if (insideZone == true && SN.playerHealth != 0)
            {
                animator.SetBool("ThrowFireball", true);
                timeBtwShots = startTimeBtwShots;
                Invoke("ShootPlayer", 1.6f);
            }
            else
            {
                animator.SetBool("ThrowFireball", false);
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        
        health -= damage;
        this.transform.Translate(Vector2.right * 15 * Time.deltaTime);
        healthBar.fillAmount = health / 4;

        if (health <= 0)
        {
            ultBarscript.ultMeter += 0.5f;
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);

        if (coll.CompareTag("Bullet"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.2f);
        }

        //if (coll.CompareTag("Player"))
        //{
        //    Instantiate(DeathEffect, transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //    HealthSystem SN = coll.GetComponent<HealthSystem>();
        //    SN.playerHealth -= 1;
        //}

    }

    void Delay()
    {
        animator.SetBool("ThrowFireball", false);
    }

    void ShootPlayer()
    {
        Instantiate(proj, firePoint.position, Quaternion.identity);
        Invoke("Delay", 0.3f);
    }

    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
