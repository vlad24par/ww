using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Units;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected abstract UnitParams DefaultParams { get; }
    protected int Health;

    private void Start()
    {
        Health = DefaultParams.Health;
    }

    public virtual void Move()
    {
        
    }

    public virtual void Attack()
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
