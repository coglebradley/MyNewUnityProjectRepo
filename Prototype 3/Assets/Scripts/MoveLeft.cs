/*
* (Conner Ogle)
* (Prototype 3)
* (Makes the objects continously move left and determines the bound in which they'll be destroyed)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 30f;

    private PlayerController playerControllerScript;

    private float leftBound = -7;

    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();   
    }
    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            //moves the player left
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //if we are out of bounds ot the left and the gameObject is an Obstacle, destroy this gameObject
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
