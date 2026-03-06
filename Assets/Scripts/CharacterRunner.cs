using UnityEngine;

public class CharacterRunner : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component for physics-based jumping
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the character constantly in the negative X direction
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    // Detect when the character touches another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we hit is a "Cube" 
        // Tip: You can also use Tags (e.g., collision.gameObject.CompareTag("Obstacle"))
        if (collision.gameObject.name.Contains("Cube"))
        {
            Jump();
        }

        // Logic to reset jump ability when touching the ground
        if (collision.gameObject.name.Contains("Floor") || collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            // Apply upward force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("Character jumped over the cube!");
        }
    }
}