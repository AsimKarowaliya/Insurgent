using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFirePointScript : MonoBehaviour
{
    public GameObject LavaBomb;
    private Transform playerPos;
    private Animator LavaBoss;

    private float tba;
    public float stba = 2f;
    private float timer = 3;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        LavaBoss = GameObject.FindGameObjectWithTag("LavaBoss").GetComponent<Animator>();
    }

    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(playerPos.position.x, this.transform.position.y), 100 * Time.deltaTime);

        if (LavaBoss.GetBool("isUp") == true && timer <= 0)
        {
            if(tba <= 0)
            {
                Instantiate(LavaBomb, transform.position, transform.rotation);
                tba = stba;
            }
            else
            {
                tba -= Time.deltaTime;
            }
        }
        else if (LavaBoss.GetBool("isUp") == true)
        {
            timer -= Time.deltaTime;
        }
    }
}
