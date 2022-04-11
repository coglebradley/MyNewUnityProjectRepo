/*
* (Conner Ogle)
* (Prototype 4)
* (Updates the text on screen)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public SpawnManager spawnManagerScript;

    public GameObject Player;
    public GameObject SpawnManager;

    public Text Instructions;
    public Text WaveNumber;

    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        if (spawnManagerScript == null)
        {
            spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instructions.gameObject.SetActive(false);
            WaveNumber.gameObject.SetActive(true);
        }
        //Display score until game is over
        if (!playerControllerScript.gameOver)
        {
            WaveNumber.text = "Wave: " + spawnManagerScript.waveNumber;
        }

        //Loss Condition: Hit bomb (even once)
        if (playerControllerScript.gameOver && !won)
        {
            WaveNumber.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        //Win Condition: 10 points
        if ( spawnManagerScript.waveNumber > 10)
        {
            playerControllerScript.gameOver = true;
            won = true;

            WaveNumber.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        //Press R to restart if game is over
        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
