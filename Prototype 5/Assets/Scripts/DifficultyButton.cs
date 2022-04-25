/*
* (Conner Ogle)
* (Prototype 5)
* (Script for difficulty buttons)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;

    private GameManager gameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(SetDifficulty);

        //set reference to GameManager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
