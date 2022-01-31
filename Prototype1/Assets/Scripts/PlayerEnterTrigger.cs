/*
* (Conner Ogle)
* (Prototype1 )
* (Increments scores)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//attach this to the player
public class PlayerEnterTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
    }
}
  
