/*
* (Conner Ogle)
* (Prototype 5)
* (Script for the prefabs. Deals spawn position, speed, and collisions)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //add a force upwards multiplied by a randomized speed
        targetRb.AddForce(RandomizedForce(), ForceMode.Impulse);

        //add a torque (rotational forece) with randomized xyz values
        targetRb.AddTorque(RandomizedTorque(), RandomizedTorque(), RandomizedTorque(),
            ForceMode.Impulse);

        //set the position with a randomized x value
        transform.position = RandomSpawnPos();

        //set reference to GameManager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

    private float RandomizedTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomizedForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
