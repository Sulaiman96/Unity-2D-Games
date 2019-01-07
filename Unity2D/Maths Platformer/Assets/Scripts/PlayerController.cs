using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 20f;

    //movement variables
    private float moveInput;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private bool facingRight = true;

    //jumping variables
    public float jumpForce = 20f;
    private bool isGrounded;
    public Transform groundCheck;
    private int extraJump;
    public int extraJumpsValue;
    private float distance = 2f;

    //animation variable
    public Animator animator;

	// Use this for initialization
	void Start () {
        extraJump = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded == true){ //everytime the player touches the ground, his number of jumps is reset.
            extraJump = extraJumpsValue;
            OnLandEvent();
        }

        if (Input.GetKeyUp(KeyCode.Space) && extraJump > 0) { //checks for w or spacebar and how many jumps.
            animator.SetBool("isGround", false);
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }else if(Input.GetKeyUp(KeyCode.Space) && extraJump == 0 && isGrounded == true){
            animator.SetBool("isGround", false);
            rb.velocity = Vector2.up * jumpForce;
        }

       //Debug.DrawLine(groundCheck.position, groundCheck.position + (groundCheck.right * distance), Color.green);
	}

    private void FixedUpdate(){
        isGrounded = Physics2D.Raycast(groundCheck.position, groundCheck.right, distance);
        moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));  //sets the animator variables for run and jump so the correct animations play.
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);  //moves player horizontally. 

        if(facingRight == false && moveInput > 0){  //check to see which direction the character is facing and moving.
            Flip(); 
        }else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }

    public void OnLandEvent(){
        animator.SetBool("isGround", true);
    }

    //This method keeps the scale (size) of the character and multiplies the x co-ordinates by -1 which flips the character. 
    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
