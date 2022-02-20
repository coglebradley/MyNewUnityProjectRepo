﻿/*
* (Conner Ogle)
* (Prototype 3)
* (Controls player movement along with modifying its gravity)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //Set the reference variables to components
        rb = GetComponent<Rigidbody>();


        jumpForceMode = ForceMode.Impulse;
        //Modify gravity
        //Physics.gravity *= gravityModifier;

        //Modify gravity if it has not already been increased above 10
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }
}
