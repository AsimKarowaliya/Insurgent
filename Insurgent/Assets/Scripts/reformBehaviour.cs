using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reformBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    private float state;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        state = Random.Range(0, 3);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(state == 0)
        {
            animator.SetTrigger("meltdown");
        }
        else if(state == 1)
        {
            animator.SetTrigger("idle2");
        }
        else if(state == 2)
        {
            animator.SetTrigger("meltup");
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
