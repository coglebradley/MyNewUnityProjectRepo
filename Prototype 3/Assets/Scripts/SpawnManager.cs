/*
* (Conner Ogle)
* (Prototype 3)
* (Spawns obstacles)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    // Start is called before the first frame update

    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        //spawns the obstacles
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        //prevents obstacles from spawning if game is over
        if (playerControllerScript.gameOver == false)
        {
            //method that creates obstacle objects to be spawned
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
