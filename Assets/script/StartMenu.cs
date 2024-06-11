using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with your game scene name
    }

    public void ReturnToStartMenu()
    {
        SceneManager.LoadScene("StartMenuScene"); // Replace with your start menu scene name
    }
}
