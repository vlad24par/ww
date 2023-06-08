using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Units;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected abstract UnitParams DefaultParams { get; }
    public int Health;
    public int Attack;
    public int Deffence;
    public int Speed;
    public int Patency;

    private void Start()
    {
        Health = DefaultParams.Health;
        Health = DefaultParams.Attack;
        Health = DefaultParams.Deffence;
        Health = DefaultParams.Speed;
        Health = DefaultParams.Patency;
    }

    public virtual void Move()
    {
        
    }

    public void ReceiveDamage(int damage)
    {
        Health -= damage;
        
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    private void Die()
    {
        
    }
}
