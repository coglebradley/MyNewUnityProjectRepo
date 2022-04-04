/*
* (Conner Ogle)
* (Assignment 6)
* (Final object to touch to complete level)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelObject : MonoBehaviour
{
    public string levelName;
    private void OnCollisionEnter(Collision collision)
    {
        //only if player collides with final object
        if (collision.gameObject.name == "Player")
        {
            //unload level then load next
            GameManager.Instance.UnloadCurrentLevel();
            GameManager.Instance.LoadLevel(levelName);
        }
    }
}
