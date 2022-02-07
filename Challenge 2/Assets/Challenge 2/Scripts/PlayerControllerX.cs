using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* (Conner Ogle)
* (Challenge 2)
* (Plays shoots the dogs on the screen and has a timer)
*/
public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog and time must be = 0 or below
        if (Input.GetKeyDown(KeyCode.Space) && time <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            //the timer has been set to 3 after shooting the dog
            time = 3;
        }
        //uses time.deltatime to subtract 3 until it reaches 0 
        time -= Time.deltaTime;

    }
}
