using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the timer text UI element
    private float elapsedTime;
    private bool isRunning;

    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100F) % 100F);
        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
