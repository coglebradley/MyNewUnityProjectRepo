using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* (Conner Ogle)
* (Prototype 2)
* (allows the player to shoot the food)
*/
public class ShootPrefab : MonoBehaviour
{
    public GameObject prefabToShoot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToShoot, transform.position, prefabToShoot.transform.rotation);
        }
    }
}
