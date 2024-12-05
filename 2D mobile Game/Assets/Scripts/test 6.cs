using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 12f;
    public float wallSlideSpeed = 2f;
    public float wallCheckDistance = 0.5f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool isWallJumping;

    private float horizontalInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HandleInput();
        CheckGroundStatus();
        CheckWallStatus();
        HandleMovement();
        HandleWallSliding();
        HandleJumping();
    }

    private void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void CheckGroundStatus()
    {
        // Cast a box downwards to check if the player is grounded
        isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    private void CheckWallStatus()
    {
        // Cast a box to check if the player is touching a wall on the side
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * horizontalInput, wallCheckDistance, wallLayer);
        if (hit.collider != null && !isGrounded)
        {
            isTouchingWall = true;
        }
        else
        {
            isTouchingWall = false;
        }

        // Wall sliding condition
        if (isTouchingWall && !isGrounded && rb.linearVelocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void HandleMovement()
    {
        if (isWallSliding)
        {
            // Apply the wall slide effect, preventing the player from getting stuck at the top
            WallSlide();
        }
        else if (!isWallJumping)
        {
            // Regular movement
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        }
    }

    private void HandleWallSliding()
    {
        if (isWallSliding && !isGrounded)
        {
            // Stop horizontal movement when sliding on the wall
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

            // Ensure that sliding continues even near the top of the wall (avoiding stuck behavior)
            if (rb.linearVelocity.y < 0)
            {
                // Apply wall sliding speed
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed));
            }
        }
    }

    private void HandleJumping()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Normal jump from the ground
            Jump();
        }
        else if (isTouchingWall && !isGrounded && Input.GetButtonDown("Jump"))
        {
            // Wall jump (jumping off the wall)
            WallJump();
        }

        // Jump canceling - cancel upward velocity when jumping and pressing down
        if (!isGrounded && !isWallSliding && rb.linearVelocity.y > 0 && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Cancel jump
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void WallJump()
    {
        isWallJumping = true;
        Vector2 wallJumpDirection = isTouchingWall ? new Vector2(-horizontalInput, 1f).normalized : Vector2.up;
        rb.linearVelocity = new Vector2(wallJumpDirection.x * wallJumpForce, wallJumpDirection.y * wallJumpForce);
        StartCoroutine(ResetWallJump());
    }

    private IEnumerator ResetWallJump()
    {
        yield return new WaitForSeconds(0.1f);
        isWallJumping = false;
    }

    private void WallSlide()
    {
        // Apply wall slide effect to ensure the player continues sliding down even near the top of the wall
        if (isWallSliding && rb.linearVelocity.y < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed));
        }

        // Prevent the player from getting stuck at the top by adjusting collider behavior
        // Ensure that sliding speed is maintained even when near the top of the wall
    }
}
