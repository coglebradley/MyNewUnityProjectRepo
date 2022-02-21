/*
* (Conner Ogle)
* (Challenge 3)
* (Player movement, sounds, and collision detections)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    public int score = 0;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //makes sure gravity isn't increased on a reload
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            //determines if player is within a bound
            if (isLowEnough())
            {
                //moves player up
                playerRb.AddForce(Vector3.up * floatForce);
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            //increments score on hitting money
            score++;

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            //bounces balloon up after colliding with ground
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            //plays audio too
            playerAudio.PlayOneShot(bounceSound, 2.0f);
        }

    }
    //a boolean to determine the bound the play is restricted by
    private bool isLowEnough()
    {
        //can't go too high
        if(transform.position.y < 15)
        {
            return true;
        }
        else
        {
            //If the balloon is moving fast it will take a long time to return to the player screen,
            //so adds a force to help make that time shorter
            playerRb.AddForce(Vector3.down * 30);
            return false;
        }
    }

}
