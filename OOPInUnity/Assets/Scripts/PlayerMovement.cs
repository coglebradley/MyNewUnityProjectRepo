/*
* (Conner Ogle)
* (Assignment 6)
* (Controlling the ball's movement)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;
    public Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    }
    void FixedUpdate()
    {
        moveBall(movement);
    }
    void moveBall(Vector3 direction)
    {
        rb.AddForce(direction * speed);
    }
    
}
