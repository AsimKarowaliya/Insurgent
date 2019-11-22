using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meltdownb : StateMachineBehaviour
{
    private float timer;
    public float minT;
    public float maxT;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minT, maxT);
        animator.SetBool("isDown", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("reformDown");
            animator.SetBool("isDown", false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
