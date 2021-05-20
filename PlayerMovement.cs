using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpforce;
    public Transform cellingCheck;
    public Transform groundCheck;
    public Layermask groundObjects;
    public float CheckRadius;
    public int maxJumpCount;
  
    private Rigidbody2D rb; // allows script too use rigidbody2D
    private bool facingRight = true; // makes left negative and right always posotive 
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int JumpCount;

    // Awake is called after all objects are initialized. Called in a random order.
    private void Awake()
    {
        rb = Getcomponent<Rigidbody2D>(); // will look for a component on this Gameobject (what the script is attached to) of type Rigidbody2D.
    }

    private void Start()
    {
        JumpCount = maxJumpCount;
    }
   
    // Update is called once per frame
    void Update()
    {
        // Get inputs
        ProcessInputs();

        Animate();
    }

    // Better for handling physics, can be called multiple times per update frame.
    private void FixedUpdate()
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, groundObjects);
        if (isGrounded)
        {
            JumpCount = maxJumpCount;
        }

        //move
        Move();
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // scale of -1 -> 1.
        if (Input.GetButtonDown("Jump") && JumpCount > 0)
        {
            isJumping = true
        }
    }
  
    // this is to track and facilitate movment 
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
         if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpforce));
            JumpCount--;
        }
        isJumping = false
    }

    private void Animate()
    {
        //Animate ( this function allows the charcter to face right if right is pressed and face left if left is pressed)
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter()
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; // inverse bool
        transform.rotate(0f, 10f, 0f);
    }
}

