using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public SpawnManagerX spawnManagerScript;

    public GameObject Player;
    public GameObject SpawnManager;

    public Text Instructions;
    public Text WaveText;

    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
       
        if (spawnManagerScript == null)
        {
            spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instructions.gameObject.SetActive(false);
            WaveText.gameObject.SetActive(true);
        }
        //Display score until game is over
        if (!spawnManagerScript.gameOver)
        {
            WaveText.text = "Wave: " + (spawnManagerScript.waveCount-1);
        }

        //player has let the balls scored
        if (spawnManagerScript.gameOver && !won)
        {
            WaveText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        //Win Condition: 10 waves have passed
        if (spawnManagerScript.waveCount > 10)
        {
            spawnManagerScript.gameOver = true;
            won = true;

            WaveText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        //Press R to restart if game is over
        if (spawnManagerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
