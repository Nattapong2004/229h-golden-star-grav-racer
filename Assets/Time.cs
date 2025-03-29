// SimpleTimerUI.cs
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTimerUI : MonoBehaviour
{
    public TMP_Text timerText; 
    private float startTime;
    private bool isRunning;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            float currentTime = Time.time - startTime;
            UpdateTimerDisplay(currentTime);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        // แปลงเวลาเป็นนาที:วินาที.มิลลิวินาที
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100f) % 100f);

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}