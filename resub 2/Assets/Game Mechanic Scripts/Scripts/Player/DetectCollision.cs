using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Reference to the player controller script (assuming you have one)
    public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player character detected the floor object
            playerController.SetIsGrounded(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player character is no longer on the floor object
            playerController.SetIsGrounded(false);
        }
    }
}
