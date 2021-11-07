using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerMinutes;
    public Text timerSeconds;

    public float startTime;
    public float stopTime;
    public float timerTime;
    public bool isRunning = false;


    public void Start()
    {
        TimeStart();
    }

    public void TimeStart()
    {
        if(!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }

    public void TimerStop()
    {
        if (isRunning)
        {
            isRunning = false;
            stopTime = timerTime;
        }
    }

    public void TimerReset()
    {
        timerMinutes.text = timerSeconds.text = "00";
    }

    public void TimerContinue()
    {
        if(!isRunning)
        {
            isRunning = true;

        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            TimerStop();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TimerContinue();
        }

        timerTime = stopTime + (Time.time - startTime);
        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;

        if(isRunning)
        {
            timerMinutes.text = minutesInt.ToString();
            timerSeconds.text = secondsInt.ToString(); 
        }
    }
}
