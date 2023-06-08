using System.Collections.Generic;
using DefaultNamespace.Units;
using UnityEngine;

namespace Units
{
    public class Division : MonoBehaviour
    {
        private List<UnitType> _units;

        public void SetInfo(List<UnitType> units)
        {
            _units = units;
        }
    }
}