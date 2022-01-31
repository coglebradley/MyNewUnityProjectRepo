/*
* (Conner Ogle)
* (Challenge 1)
* (Spins the propeller)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //rotates the propeller on the z axis
        transform.Rotate(Vector3.forward * 25);
    }
}
