using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer;

    private bool isGrounded;
    private Transform playerTransform;
    private float groundCheckRadius = 0.1f;

    private void Start()
    {
        playerTransform = transform.parent; // Assuming the GroundCheck is a child of the player object.
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
