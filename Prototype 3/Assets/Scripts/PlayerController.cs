/*
* (Conner Ogle)
* (Prototype 3)
* (Controls player movement and gravity, along with player animation, particle effects, and audio)
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

    public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Set the reference variables to components
        rb = GetComponent<Rigidbody>();
        //Set the reference to our Animator component
        playerAnimator = GetComponent<Animator>();

        //set reference variables to audio source
        playerAudio = GetComponent<AudioSource>();

        //Start running animation on start
        playerAnimator.SetFloat("Speed_f", 2.0f);

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
    {   //jumping when the play hits space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            //sets trigger to play jump animation
            playerAnimator.SetTrigger("Jump_trig");

            //stop playing dirt particle on jump
            dirtParticle.Stop();

            //play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            //play dirt particle when the player hits the ground
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            //play the death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //play explosion particle
            explosionParticle.Play();
            //stop  dirt particle
            dirtParticle.Stop();
            //play crash sound
            playerAudio.PlayOneShot(crashSound, 1.0f);


        }
    }
}
