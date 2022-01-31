/*
* (Conner Ogle)
* (Challenge 1)
* (Allows the camera to follow the player)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    //offset to determine the camera position
    public GameObject plane;
    private Vector3 offset = new Vector3(25,0, 10);

 
   

    // Update is called once per frame
    void Update()
    {
        //determine the camera position using plane position and the given offset
        transform.position = plane.transform.position + offset;
    }
}
