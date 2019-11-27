using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    public bool jump = false;
    public bool jj = false;
    public bool crouch = false;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        CharacterController2D CC = GetComponent<CharacterController2D>();

        if (Input.GetButtonDown("Jump") && CC.playerdead == false)
        {
            //smScript.StopSound("stop");
            jump = true;
            jj = true;
            animator.SetBool("IsJumping", true);
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        HealthSystem SN = GetComponent<HealthSystem>();
        if(SN.playerHealth <= 0)
        {
            animator.SetTrigger("IsDead");
            CC.playerdead = true;
            animator.SetBool("IsJumping", false);
            horizontalMove = 0;
        }

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
        jj = false;
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}