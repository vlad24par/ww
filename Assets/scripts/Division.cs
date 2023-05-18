using System;
using System.Collections.Generic;
using DefaultNamespace.Units;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Division : MonoBehaviour
    {
        [SerializeField] private List<UnitParams> _unitsParams = new List<UnitParams>();
        [SerializeField] private Button _addTankButton;
        [SerializeField] private Button _addArtilleryButton;
        [SerializeField] private Button _addInfanceButton;
        
        private List<UnitType> _units = new List<UnitType>();

        private void OnEnable()
        {
            _addTankButton.onClick.AddListener(() => AddUnit(UnitType.Tank));
            _addArtilleryButton.onClick.AddListener(() => AddUnit(UnitType.Artillery));
            _addInfanceButton.onClick.AddListener(() => AddUnit(UnitType.Infantry));
        }

        private void OnDisable()
        {
            _addTankButton.onClick.RemoveListener(() => AddUnit(UnitType.Tank));
            _addArtilleryButton.onClick.RemoveListener(() => AddUnit(UnitType.Artillery));
            _addInfanceButton.onClick.RemoveListener(() => AddUnit(UnitType.Infantry));
        }

        private void AddUnit(UnitType type)
        {
            _units.Add(type);
            ShowDivisionHP();
        }
        
        public void RemoveUnit(UnitType type)
        {
            if (_units.Contains(type))
                _units.Remove(type);
            ShowDivisionHP();
        }

        private void ShowDivisionHP()
        {
            var hp = 0;
            var attack = 0;
            foreach (var unit in _units)
            {
                hp += _unitsParams.Find(x => x.Type == unit).Health;
                attack += _unitsParams.Find(x => x.Type == unit).Attack;
            }
            
            Debug.Log(hp);
        }
    }
}