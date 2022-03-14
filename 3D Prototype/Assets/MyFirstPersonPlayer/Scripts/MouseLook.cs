
/*
* (Conner Ogle)
* (3D Prototype)
* (Allows player to look around with mouse)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public GameObject player;
    private float verticalLookRotation = 0f;
    // Update is called once per frame
    void Update()
    {
        //Get mouse input and assign it to two floats
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        //Rotate player GameObject with horiznoal mouse input
        player.transform.Rotate(Vector3.up * mouseX);

        //Rotate camera around the x axis with vertical mouse input
        verticalLookRotation -= mouseY;
        //Clamp the rotation so the player does not over-rotate
        //and look behind themselves upside down
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        //Apply rotation based on clamped input
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }

    //hide and lock our cursor to the center of the screen
    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
