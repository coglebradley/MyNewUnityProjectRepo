/*
* (Conner Ogle)
* (Assignment 6)
* (weapon from video)
*/
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damageBonus;

    public Enemy enemyHoldingWeapon;

    private void Awake()
    {
        enemyHoldingWeapon = gameObject.GetComponent<Enemy>();
        EnemyEatWeapon(enemyHoldingWeapon);
    }

    protected void EnemyEatWeapon(Enemy enemy)
    {
        Debug.Log("Enemy Eats weapon");
    }
    public void Recharge()
    {
        Debug.Log("Recharging weapon!");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}