using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleB2 : StateMachineBehaviour
{
    private float timer;
    private float state;
    public float minT;
    public float maxT;

    private Transform playerPos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minT, maxT);
        state = Random.Range(0, 2);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0 && state == 0)
        {
            animator.SetTrigger("meltup");
        }
        else if(timer <= 0 && state == 1)
        {
            animator.SetTrigger("meltdown");
        }
        else
        {
            timer -= Time.deltaTime;
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
