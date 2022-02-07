//This script is based on https://www.youtube.com/watch?v=3uyolYVsiWc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
* (Conner Ogle)
* (Challenge 2)
* (Health system display and will restart the game based on condiitons)
*/

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public static int score = 0;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool gameOver = false;

    public GameObject gameOverText;

    public GameObject gameVictoryText;


    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        //If health is somehow more than max health, set health to max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }


        for (int i = 0; i < hearts.Count; i++)
        {
            //Display full or empty heart sprite based on current health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Show the number of hearts equal to current max health
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        //if health is 0 game is lost
        if (health == 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
        //if score is above 5 the game is won
        if(score >= 5)
        {
            gameOver = true;
            gameVictoryText.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }


    }

    public void TakeDamage()
    {
        health--;
    }

    public void AddMaxHealth()
    {
        maxHealth++;
    }


}
