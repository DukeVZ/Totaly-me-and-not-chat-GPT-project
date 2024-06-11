using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;

    void Start()
    {
        if (player != null)
        {
            player.SetActive(true);
            Debug.Log("Player activated.");
        }
        else
        {
            Debug.LogError("Player is not assigned.");
        }

        if (mainCamera != null)
        {
            mainCamera.SetActive(true);
            Debug.Log("Main Camera activated.");
        }
        else
        {
            Debug.LogError("Main Camera is not assigned.");
        }
    }
}
