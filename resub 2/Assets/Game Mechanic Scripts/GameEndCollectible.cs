using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCollectible : MonoBehaviour
{
    
    private GameManager gameManager; // Reference to the GameManager script.

    private void Start()
    {
        // Find the GameManager in the scene and get its script component.
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Optionally, play a sound or particle effect when the item is collected.
            // You can also increase the player's score or apply other game mechanics.

            // Call the GameOver() method from the GameManager to trigger the game over condition.
            if (gameManager != null)
            {
                gameManager.GameOver();
            }

            Destroy(gameObject);
        }
    }
}

