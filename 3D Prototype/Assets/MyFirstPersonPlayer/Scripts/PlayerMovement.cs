/*
* (Conner Ogle)
* (3D Prototype)
* (Controls player movement and gravity)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    //variables for gravity
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;

    //variables for checking if on ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public float JumpHeight = 3f;

    private void Awake()
    {
        gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //getting input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        //add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        //we multiply velocity by Time.deltaTime again to 
        //simulate gravity accelerating in a free fall
        controller.Move(velocity * Time.deltaTime);
    }
}
