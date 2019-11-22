using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkBehaviourIntro : StateMachineBehaviour
{
    public float timer = 10f;

    private Transform playerPos;
    private float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        speed = Random.Range(1, 4);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(playerPos.position.x, animator.transform.position.y), speed * Time.deltaTime);

        if (timer <= 0)
        {
            animator.SetTrigger("idle");
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
