using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkBehaviour : StateMachineBehaviour
{
    private float timer;
    public float minT;
    public float maxT;

    public int length = 1;

    public GameObject enemyAI;
    private Transform AI_pos1;
    private Transform AI_pos2;
    private Transform playerPos;
    public float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minT, maxT);
        AI_pos1 = GameObject.FindGameObjectWithTag("targer_ai1").GetComponent<Transform>();
        AI_pos2 = GameObject.FindGameObjectWithTag("targer_ai2").GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("isWalking", true);

        for (int i = 0; i < length; i++)
        {
            Instantiate(enemyAI, AI_pos1.position, AI_pos1.rotation);
            Instantiate(enemyAI, AI_pos2.position, AI_pos2.rotation);
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(playerPos.position.x, animator.transform.position.y), speed * Time.deltaTime);

        if (timer <= 0)
        {
            animator.SetTrigger("idle");
            animator.SetBool("isWalking", false);
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
