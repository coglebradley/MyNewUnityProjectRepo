using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* (Conner Ogle)
* (Prototype 2)
* (deals with spawning of animals )
*/

public class SpawnManager : MonoBehaviour
{
    //set this array of references in the inspector
    public GameObject[] prefabToSpawn;

    //variables for spawn position
    private float leftBound = -9;
    private float rightBound = 9;
    private float SpawnPosZ = 20;

    public HealthSystem healthSystem;

    void Start()
    {
        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);
        StartCoroutine(SpawnRandomPrefabWithCoroutine());

        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }
    //uses our method to spawn based on coroutine
    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        //add a 3 second delay befire first spawning objects
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            float RandomDelay = Random.Range(0.8f, 2.0f);

            yield return new WaitForSeconds(RandomDelay);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
        
    }

    //spawns animals
    void SpawnRandomPrefab()
    {
        //pick a random animal index
        int prefabIndex = Random.Range(0, prefabToSpawn.Length);

        //generate a random spawn position
        Vector3 SpawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, SpawnPosZ);

        Instantiate(prefabToSpawn[prefabIndex], SpawnPos, prefabToSpawn[prefabIndex].transform.rotation);
    }
}
