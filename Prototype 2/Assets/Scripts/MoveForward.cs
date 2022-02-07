using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* (Conner Ogle)
* (Prototype 2)
* (animals and food use to move forward)
*/
public class MoveForward : MonoBehaviour
{
    public float speed = 40;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
