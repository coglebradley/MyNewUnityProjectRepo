/*
* (Conner Ogle)
* (3D Prototype)
* (Targets to be shot and and if all are destroyed the player wins)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private UIManager UIManager;

    private void Start()
    {
        UIManager = GameObject.FindObjectOfType<UIManager>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        UIManager.score--;
        Destroy(gameObject);
    }
}
