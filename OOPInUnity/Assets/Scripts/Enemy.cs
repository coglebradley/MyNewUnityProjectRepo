using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{

    protected float speed;
    protected int health;


    [SerializeField] protected Weapon weapon;
    protected virtual void Awake()
    {
        weapon = gameObject.AddComponent<Weapon>();
        speed = 5f;
        health = 100;
    }
    // Start is called before the first frame update

    protected abstract void Attack(int amount);
    void Start()
    {
        
    }

    public abstract void TakeDamage(int amount);

    // Update is called once per frame
    void Update()
    {
        
    }
}
