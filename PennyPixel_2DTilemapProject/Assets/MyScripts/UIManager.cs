/*
* (Conner Ogle)
* (Assignment 5A)
* (Deals with incrementing score and resetting game)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public bool gameOver = false;
    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //Display score until game is over
        if (!gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        //Win Condition: 10 points
        if (score >= 10)
        {
            gameOver = true;
            won = true;

            //playerControllerScript.StopRunning();

            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        //Press R to restart if game is over
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}