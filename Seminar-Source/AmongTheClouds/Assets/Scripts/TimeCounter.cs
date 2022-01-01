using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    Text timeUI; //time counter UI text

    float startTime; //pocetno vrijeme, klik na play
    float ellapsedTime;
    bool startCounter;
    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        startCounter = false;

        timeUI = GetComponent<Text> ();
    }

    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    public void StopTimeCounter()
    {
        startCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startCounter) //true
        {
            ellapsedTime = Time.time - startTime;

            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;

            timeUI.text = string.Format("{00:00}:{1:00}", minutes, seconds);
        }
    }
}
