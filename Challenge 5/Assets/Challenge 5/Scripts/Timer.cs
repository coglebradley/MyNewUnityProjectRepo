/*
* (Conner Ogle)
* (Challenge 5)
* (Script to track time left and display it)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 60;
    public Text timeText;

    private GameManagerX gameManagerX;

    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        //timerIsRunning = true;
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerX.isGameActive)
        {
            timerIsRunning = true;
            DisplayTime(timer);
            if (timer > 0)
            {
                
                timer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time ran out");
                timer = 0;
                timerIsRunning = false;
                gameManagerX.GameOver();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        string secondsLeft = string.Format("{0:00}", seconds);
        timeText.text = ("Time left: " + secondsLeft);
    }
}
