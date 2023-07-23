using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            // Collision with an object tagged as "OtherObject" occurred.
            // Do something here, like destroying the other object.
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            // The collision with the object tagged as "OtherObject" ended.
            // Do something here if needed.
        }
    }
}
