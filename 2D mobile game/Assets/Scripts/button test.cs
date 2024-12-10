using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Make sure to use the new Input System

public class PlayerMovement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float JumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private float jumpTimeCounter;
    public float jumpTime; // Time a player can hold the jump button for variable jump height
    private bool isJumping;
    //private Animator anim;

    [SerializeField] float timer;

    // New input actions
    private @InputSystem_Actions playerInputActions;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        // Initialize input actions
        playerInputActions = new @InputSystem_Actions();
        moveAction = playerInputActions.Player.Move;
        jumpAction = playerInputActions.Player.Jump;

        // Enable the input actions
        playerInputActions.Enable();
    }

    void FixedUpdate()
    {
        // Read the Move action as a Vector2 and use only the x component for horizontal movement
        Vector2 moveInputVector = moveAction.ReadValue<Vector2>();
        moveInput = moveInputVector.x;

        // Apply movement to the Rigidbody
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    private void Update()
    {
        /*if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            if (jumpAction.triggered && timer >= .5f)
            {
                timer = 0;
                anim.SetTrigger("click");
            }
        }*/

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);

        // Jumping logic - Trigger jump immediately when the button is pressed (if grounded)
        if (isGrounded && jumpAction.triggered)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime; // Reset jump time counter
            rb.linearVelocity = Vector2.up * JumpForce; // Apply the initial jump force
            //anim.SetBool("isJumping", true); // Set animation for jump start
        }

        // If jump button is held down, allow variable jump height
        if (jumpAction.IsPressed() && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.linearVelocity = Vector2.up * JumpForce; // Keep applying jump force
                jumpTimeCounter -= Time.deltaTime; // Decrease jump time counter
            }
        }

        // Reset jump logic when landing on the ground
        if (isGrounded && !jumpAction.IsPressed())
        {
            isJumping = false; // Stop jumping if player releases the jump key
            //anim.SetBool("isJumping", false); // Set animation for landing
        }

        // Handle sprite flip based on movement direction
        /*int x = (int)moveInput;
        anim.SetInteger("x", x);
        if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Handle the "click" animation trigger
        if (jumpAction.triggered && timer >= .5f)
        {
            timer = 0;
            anim.SetTrigger("click");
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    // Dispose of input actions when no longer needed
    private void OnDisable()
    {
        playerInputActions.Disable();
    }
}
