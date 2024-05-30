using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathScreenCanvas; // Reference to the death screen canvas
    private GameTimer gameTimer;

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
    }

    public void Die()
    {
        // Enable the death screen canvas
        deathScreenCanvas.SetActive(true);

        // Stop the timer
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
        }

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

