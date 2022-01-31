/*
* (Conner Ogle)
* (Challenge 1)
* (Player will lose if out of the defined bounds)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        //the bounds that the player cannot leave otherwise they will lose
        if (transform.position.y > 80 | transform.position.y < -51)
        {
            ScoreManager.gameOver = true;
        }

    }
}
