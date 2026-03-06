using UnityEngine;

public class CharacterRunner : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 8f; // Faster speed helps clear jumps
    public float jumpForce = 12f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Keep the runner upright
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        // Important for fast movement
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        // We only control X and keep the existing Y velocity (gravity/jump)
        rb.linearVelocity = new Vector3(-moveSpeed, rb.linearVelocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Using Tags is much cleaner than checking names!
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.name.Contains("Cube"))
        {
            Jump();
        }
    }

    // Check if staying on ground
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.name.Contains("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.name.Contains("Floor"))
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            // Set Y velocity directly for a snappy, instant jump
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0);
            isGrounded = false;
            Debug.Log("Jumping!");
        }
    }
}