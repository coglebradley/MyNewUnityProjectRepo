using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
* (Conner Ogle)
* (Challenge 2)
* (Displays score in textbox)
*/

public class DisplayScore : MonoBehaviour
{

    public Text textbox;

   
    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();

        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //gets score from healthsystem
        textbox.text = "Score: " + HealthSystem.score;

    }
}
