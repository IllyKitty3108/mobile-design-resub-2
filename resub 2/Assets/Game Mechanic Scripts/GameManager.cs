using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            // Add any game over logic here, such as showing a game over screen or resetting the level.
            Debug.Log("Game Over"); // Add a debug log to see if the method is being called.
            // For example, you can restart the level after the game over condition.
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
