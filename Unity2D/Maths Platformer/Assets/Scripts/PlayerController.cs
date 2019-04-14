using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //movement variables
    public float speed = 20f;
    private float moveInput;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private bool facingRight = true;

    //jumping variables
    public float jumpForce = 20f;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
    public Transform groundCheck;
    public GameObject respawnPoint;
    private int extraJump;
    public int extraJumpsValue;
    private float distance = 2f;

    //animation variable
    public Animator animator;
    private GameController gameController;

    //Audio
    public AudioClip CoinSound;
    public AudioClip DeathSound;
    public AudioClip Timer;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        extraJump = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded == true){ //everytime the player touches the ground, his number of jumps is reset.
            extraJump = extraJumpsValue;
            //OnLandEvent();
        }

        if (Input.GetKeyUp(KeyCode.Space) && extraJump > 0) { //checks for w or spacebar and how many jumps.
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }else if(Input.GetKeyUp(KeyCode.Space) && extraJump == 0 && isGrounded == true){
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForce;
        }

       Debug.DrawLine(groundCheck.position, groundCheck.position + (groundCheck.right * distance), Color.green);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Timer")
        {
            audio.clip = Timer;
            audio.Play();
        }

        if (collision.gameObject.tag == "Coin")
        {
            audio.clip = CoinSound;
            audio.Play();
            collision.gameObject.SetActive(false);
            gameController.Pickup();

        }

        if(collision.gameObject.tag == "Kill")
        {
            audio.clip = DeathSound;
            audio.Play();
            this.transform.position = respawnPoint.transform.position;
        }
    }
    private void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //isGrounded = Physics2D.Raycast(groundCheck.position, groundCheck.right, distance);
        moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));  //sets the animator variables for run and jump so the correct animations play.
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);  //moves player horizontally. 

        if(facingRight == false && moveInput > 0){  //check to see which direction the character is facing and moving.
            Flip(); 
        }else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }

    public void ChangeSpawn(Transform newRespawn)
    {
        respawnPoint.transform.position = newRespawn.transform.position;
    }

    public void StopTimer()
    {
        audio.Stop();
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
