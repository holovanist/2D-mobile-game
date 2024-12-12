using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Make sure to use the new Input System

public class PlayerMovement : MonoBehaviour
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
    public float jumpTime;
    private bool isJumping;
    private bool stopjump;


    private @InputSystem_Actions playerInputActions;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stopjump = false;
        playerInputActions = new @InputSystem_Actions();
        moveAction = playerInputActions.Player.Move;
        jumpAction = playerInputActions.Player.Jump;

        playerInputActions.Enable();
    }

    void FixedUpdate()
    {
        Vector2 moveInputVector = moveAction.ReadValue<Vector2>();
        moveInput = moveInputVector.x;

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);

        if (isGrounded && jumpAction.triggered)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.linearVelocity = Vector2.up * JumpForce;
            isGrounded = false;
        }

        if (jumpAction.IsPressed() && isJumping && stopjump == false)
        {
            if (jumpTimeCounter > 0)
            {
                rb.linearVelocity = Vector2.up * JumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }else
        {
            stopjump = true;
        }

        if (isGrounded && !jumpAction.IsPressed())
        {
            isJumping = false;
            stopjump = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
}
