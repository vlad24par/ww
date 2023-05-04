using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Units;
using UnityEngine;

public class Tank : Unit
{
    protected override UnitParams DefaultParams => new UnitParams()
    {
        Attack = 120,
        Health = 1000,
        Deffence = 100,
        Speed = 3
    };
}
