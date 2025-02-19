using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;
    private Vector3 originPosition; // Store the player's original position

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originPosition = transform.position; // Store the starting position
    }

    private void Update()
    {
        // Teleport player back if they fall below -4.4 on Y-axis
        if (transform.position.y < -4.4f)
        {
            transform.position = originPosition;
            rb.linearVelocity = Vector2.zero; // Reset velocity to prevent instant falling again
        }

        // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Get player movement input
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Flip character direction based on movement
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
