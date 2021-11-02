using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{

    public bool timerActive = false;
    public float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    public void Start()
    {
        currentTime = startMinutes * 60;
    }

    public void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if(currentTime <= 0)
            {
                timerActive = false;
                Start();
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartTimer();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopTimer();
        }


    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

}
