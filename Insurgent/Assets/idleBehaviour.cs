using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehaviour : StateMachineBehaviour
{
    public float tba;
    private float timer;
    public float minT;
    public float maxT;
    
    public int length = 1;

    public GameObject Fireball;
    private Transform FirePoint_pos;
    private Transform playerPos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minT, maxT);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        FirePoint_pos = GameObject.FindGameObjectWithTag("targer_ai").GetComponent<Transform>();

        //for (int i = 0; i < length; i++)
        //{
        //    //if(tba <= 0)
        //    //{
        //    //    Instantiate(Fireball, FirePoint_pos.position, FirePoint_pos.rotation);
        //    //    tba = 2f;
        //    //}
        //    //else
        //    //{
        //    //    tba -= Time.deltaTime;
        //    //}
        //    //Instantiate(Fireball, FirePoint_pos.position, FirePoint_pos.rotation);
        //}

        animator.SetBool("isIdle", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <= 0)
        {
            animator.SetTrigger("walk");
            animator.SetBool("isIdle", false);
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (tba <= 0)
        {
            Instantiate(Fireball, FirePoint_pos.position, FirePoint_pos.rotation);
            tba = 2f;
        }
        else
        {
            tba -= Time.deltaTime;
        }

        if (animator.transform.position.x < playerPos.position.x)
        {
            animator.transform.localScale = new Vector2(-1, 1);
        }
        else if (animator.transform.position.x > playerPos.position.x)
        {
            animator.transform.localScale = new Vector2(1, 1);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
