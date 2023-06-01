using System;
using System.Collections.Generic;
using DefaultNamespace.Units;
using UnityEngine;

namespace DefaultNamespace
{
    public class UnitSpawner: MonoBehaviour
    {
        [SerializeField] GameObject unit;
        [SerializeField] Vector2 position;
        private List<Unit> _units = new List<Unit>();
        public void creitTroops()
        {
           Instantiate(unit, position,Quaternion.identity); 
        }
    }
}