/*
* (Conner Ogle)
* (Challenge 1)
* (TriggerZone that increments player score after passing)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    //variables
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        //determines if the passed object has the tag player AND the trigger has not already been used.
        if (other.CompareTag("Player") && !triggered)
        {
           //increments score
            triggered = true;
            ScoreManager.score++;
        }

    }
}
