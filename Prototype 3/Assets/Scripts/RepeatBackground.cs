﻿/*
* (Conner Ogle)
* (Prototype 3)
* (Brief description of the code in the file.
* For example: controls player movement)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //save the starting position of the background to a Vector3 variable
        startPosition = transform.position;

        //set the repeatWidth to half of the width of the background using the BoxCollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the background is further to the left than the repeatWidth, reset it to its startPosition
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
