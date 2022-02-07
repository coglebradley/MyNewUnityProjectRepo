using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* (Conner Ogle)
* (Prototype 2)
* (Destroys objects out of bounds and decreases health)
*/

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem healthSystemScript;

    private void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //if food goes out of bounds
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < bottomBound)
        {
            //Debug.Log("Game Over!");

            //grab the health system script and call the TakeDamage()
            healthSystemScript.TakeDamage();

            Destroy(gameObject);
        }
    }
}
