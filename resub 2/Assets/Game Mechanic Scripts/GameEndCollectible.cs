using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player found the collectible, end the game
            EndGame();
        }
    }

    private void EndGame()
    {
        // Implement your game-ending logic here
        Debug.Log("Game Over!");
        // For example, you can show a game-over screen, display a score, or perform other end-game actions.

        // To quit the game, you can uncomment the line below (use with caution in a real game)
        // Application.Quit();
    }
}
