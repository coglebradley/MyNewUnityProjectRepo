/*
* (Conner Ogle)
* (3D Prototype)
* (Deals with managing cube destroys and victory)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 10;
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

        scoreText.text = "Cubes Left: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //Display score until game is over
        if (!gameOver)
        {
            scoreText.text = "Cubes Left: " + score;
        }

        //Win after destroying all 10, thus score 0
        if (score <=0)
        {
            gameOver = true;
            won = true;

            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        //Press R to restart if game is over
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}