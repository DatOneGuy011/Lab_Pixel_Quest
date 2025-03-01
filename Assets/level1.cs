using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{
    // Movement variables
    [Header("Movement Settings")]
    [Tooltip("Movement speed in units per second")]
    public float moveSpeed = 5f;

    // Jump variables - made public for easy tweaking in the inspector
    [Header("Jump Settings")]
    [Tooltip("Jump force applied when jumping")]
    public float jumpForce = 10f;
    [Tooltip("Maximum number of jumps before touching the ground")]
    public int maxJumps = 2; // Set to 2 by default for double jump
    [Tooltip("How long the player can hold jump button for variable height")]
    public float jumpBufferTime = 0.1f;
    [Tooltip("Time in seconds that the player can still jump after leaving a platform")]
    public float coyoteTime = 0.2f;
    [Tooltip("Multiplier applied to velocity when jump button is released early")]
    public float jumpCutMultiplier = 0.5f;
    [Tooltip("Gravity scale when falling")]
    public float fallGravityMultiplier = 2.5f;

    // Private variables
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpsRemaining;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    private bool isJumping;
    private bool jumpInputThisFrame;

    // Ground check
    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }


    void Update()
    {
        // Check for jump input
        jumpInputThisFrame = Input.GetKeyDown(KeyCode.Space);

        // Ground check
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Reset jumps when grounded
        if (isGrounded && !wasGrounded)
        {
            jumpsRemaining = maxJumps;
            isJumping = false;
        }

        // Coyote time logic
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Jump buffer timing
        if (jumpInputThisFrame)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Jump logic - separated for clarity
        HandleJumping();

        // Jump cut when releasing jump button
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.velocity.y > 0 && isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutMultiplier);
            }
        }

        // Apply higher gravity when falling
        rb.gravityScale = (rb.velocity.y < 0) ? fallGravityMultiplier : 1f;

        // Debug info
        Debug.Log($"Jumps Remaining: {jumpsRemaining}, IsGrounded: {isGrounded}, Coyote: {coyoteTimeCounter}");
    }

    void HandleJumping()
    {
        // Check if we can jump (either through coyote time or remaining jumps)
        bool canCoyoteJump = coyoteTimeCounter > 0f && jumpsRemaining == maxJumps;
        bool canMultiJump = jumpsRemaining > 0 && !isGrounded;

        if (jumpBufferCounter > 0f && (canCoyoteJump || canMultiJump))
        {
            Jump();
            jumpBufferCounter = 0f;

            // Only decrease jumps if it's not the first jump when in coyote time
            if (canMultiJump || (canCoyoteJump && jumpsRemaining < maxJumps))
            {
                jumpsRemaining--;
            }
            else if (canCoyoteJump)
            {
                // This is the first jump using coyote time
                jumpsRemaining = maxJumps - 1;
            }

            // Reset coyote time after using it
            if (canCoyoteJump)
            {
                coyoteTimeCounter = 0f;
            }
        }
    }
    void FixedUpdate()
    {
        // WASD/Arrow key movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
    }
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
