using System;
using DefaultNamespace;
using UnityEngine;

public class Sell : MonoBehaviour
{

    [SerializeField] int attack;
    [SerializeField] int defence;
    [SerializeField] int patency;
    [SerializeField] private Collider _collider;

    public SellType SellType;
    public event Action OnClick;

    
}
