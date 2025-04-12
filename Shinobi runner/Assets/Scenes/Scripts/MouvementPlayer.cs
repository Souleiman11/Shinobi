using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;

    // Add multi-jump variables
    public int maxJumpCount = 2; // Set this to how many jumps you want (2 for double jump)
    private int jumpsRemaining = 0;
    private Rigidbody2D rb;
    public float additionalJumpForce = 400f; // Force for additional jumps

    public Animator animator;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumpCount;
    }
    
    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump")){
            // Only allow jumping if we have jumps remaining
            if(jumpsRemaining > 0) {
                // For first jump, use controller's jump
                if(jumpsRemaining == maxJumpCount) {
                    jump = true;
                }
                // For additional jumps, apply force directly
                else {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset vertical velocity
                    rb.AddForce(new Vector2(0f, additionalJumpForce));
                }
                
                animator.SetBool("isjumping", true);
                animator.SetBool("isgrounded", false);
                
                // Decrease remaining jumps
                jumpsRemaining--;
            }
        }
    }

    public void OnLanding(){
        animator.SetBool("isjumping", false);
        animator.SetBool("isgrounded", true);
        
        // Reset jump count when landing
        jumpsRemaining = maxJumpCount;
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}


/*public class MovementPlayer : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;

    public Animator animator;
    // Add variables for multi-jump
    public int maxJumpCount = 2; // Set this to how many jumps you want to allow
    private int currentJumpCount = 0;

    
    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;

        
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump")){
            // Only allow jumping if we haven't reached the max jump count
            if(currentJumpCount < maxJumpCount){
            jump = true;
            currentJumpCount++;
            animator.SetBool("isjumping", true);
            animator.SetBool("isgrounded", false);
            }
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
}*/
