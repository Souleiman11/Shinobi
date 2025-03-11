using System.Globalization;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;

    public Animator animator;
    
    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;

        
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("isjumping", true);
            animator.SetBool("isgrounded", false);
        }
    }

    public void OnLanding(){
        animator.SetBool("isjumping", false);
        animator.SetBool("isgrounded", true);

    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
