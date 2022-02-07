using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* (Conner Ogle)
* (Challenge 2)
* (SpawnManager that deals with spawning of balls)
*/

public class SpawnManagerX : MonoBehaviour
{
    //variables
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -13;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    public HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        //coroutine that calls our method
        StartCoroutine(SpawnRandomPrefabWithCoroutine());
        //finds healthsystem
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }
    //waits 2 seconds before spawning objects and then has a delay between 3 and 5 seconds
    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(2f);

        while (!healthSystem.gameOver)
        {
            SpawnRandomBall();

            float RandomDelay = Random.Range(3f, 5f);

            yield return new WaitForSeconds(RandomDelay);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        //used to randomly spawn all of the balls
        int prefabIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[prefabIndex], spawnPos, ballPrefabs[prefabIndex].transform.rotation);
    }

}
