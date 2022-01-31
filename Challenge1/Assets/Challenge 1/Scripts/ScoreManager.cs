/*
* (Conner Ogle)
* (Challenge 1)
* (Used to determine the score and if the player has won or lost)
*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //variables
    public static bool gameOver = false;
    public static bool won = false;
    public static int score = 0;

    public Text textbox;

    void Start()
    {
        //used to reset the values after restarting the game
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is not over, display score
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        //win condition: 5 or more points

        if (score >= 5)
        {
            won = true;
            gameOver = true;
        }
        //displays a victory or a lose based on what condition was met
        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You win!\nPress R to Try Again!";
            }
            else
            {
                textbox.text = "You lose!\nPress R to Try Again!";
            }
            //pressing r, the player reloads the game
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


        }
    }
}
