using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* (Conner Ogle)
* (Challenge 2)
* (Destroys balls after contact and increments score)
*/

public class DetectCollisionsX : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScore").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthSystem.score++;
        Destroy(gameObject);
    }
}
