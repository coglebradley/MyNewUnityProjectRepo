﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float speed;
    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerUp;

    private float powerupStrength = 15.0f;

    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //move our powerup indicator to the ground below our player
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }
    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player collied with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            //get a local reference to enemy rb
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            //set a Vector3 with a direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            //add force away from player
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
