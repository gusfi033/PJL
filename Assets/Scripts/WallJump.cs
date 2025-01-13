using UnityEngine;

public class WallJump : MonoBehaviour
{
    public float wallJumpForce = 10f;
    public float jumpForce = 5f;
    public float wallCheckDistance = 1f;
    public LayerMask wallLayer;

    private Rigidbody rb;
    private bool isTouchingWall = false;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if grounded (on the floor)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        // Check if touching the wall
        isTouchingWall = Physics.Raycast(transform.position, transform.right, wallCheckDistance, wallLayer) ||
                          Physics.Raycast(transform.position, -transform.right, wallCheckDistance, wallLayer);

        // Wall jump
        if (isTouchingWall && !isGrounded && Input.GetButtonDown("Jump"))
        {
            WallJumpAction();
        }

        // Regular jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            RegularJump();
        }
    }

    void WallJumpAction()
    {
        // Apply force upwards and sideways
        Vector3 jumpDirection = new Vector3(1f, 1f, 0f).normalized; // Adjust if needed
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
        rb.AddForce(jumpDirection * wallJumpForce, ForceMode.Impulse);
    }

    void RegularJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
