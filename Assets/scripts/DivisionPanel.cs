using System.Collections.Generic;
using DefaultNamespace.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DivisionPanel : MonoBehaviour
    {

        [SerializeField] private List<UnitParams> _unitsParams = new List<UnitParams>();
        [SerializeField] private Button _addTankButton;
        [SerializeField] private Button _addArtilleryButton;
        [SerializeField] private Button _addInfanceButton;
        [SerializeField] private Button _removeTankButton;
        [SerializeField] private Button _removeArtilleryButton;
        [SerializeField] private Button _removeInfanceButton;
        
        [SerializeField] public TMP_Text _healthText;
        [SerializeField] public TMP_Text _attakText;
        [SerializeField] public TMP_Text _defenceText;
        [SerializeField] public TMP_Text _potencText;
        [SerializeField] public TMP_Text _speedText;
        
        public List<UnitType> Units = new List<UnitType>();

        private void OnEnable()
        {
            _addTankButton.onClick.AddListener(() => AddUnit(UnitType.Tank));
            _addArtilleryButton.onClick.AddListener(() => AddUnit(UnitType.Artillery));
            _addInfanceButton.onClick.AddListener(() => AddUnit(UnitType.Infantry));
            
            _removeTankButton.onClick.AddListener(() => RemoveUnit(UnitType.Tank));
            _removeArtilleryButton.onClick.AddListener(() => RemoveUnit(UnitType.Artillery));
            _removeInfanceButton.onClick.AddListener(() => RemoveUnit(UnitType.Infantry));
        }

        private void OnDisable()
        {
            _addTankButton.onClick.RemoveListener(() => AddUnit(UnitType.Tank));
            _addArtilleryButton.onClick.RemoveListener(() => AddUnit(UnitType.Artillery));
            _addInfanceButton.onClick.RemoveListener(() => AddUnit(UnitType.Infantry));
            
            _removeTankButton.onClick.RemoveListener(() => RemoveUnit(UnitType.Tank));
            _removeArtilleryButton.onClick.RemoveListener(() => RemoveUnit(UnitType.Artillery));
            _removeInfanceButton.onClick.RemoveListener(() => RemoveUnit(UnitType.Infantry));
        }

        private void AddUnit(UnitType type)
        {
            Units.Add(type);
            ShowDivisionHP();
        }

        private void RemoveUnit(UnitType type)
        {
            if (Units.Contains(type))
                Units.Remove(type);
            ShowDivisionHP();
        }

        private void ShowDivisionHP()
        {
            var hp = 0;
            var attack = 0;
            var defence = 0;
            var potence = 0;
            var speed = 0;
            foreach (var unit in Units)
            {
                hp += _unitsParams.Find(x => x.Type == unit).Health;
                attack += _unitsParams.Find(x => x.Type == unit).Attack;
                defence += _unitsParams.Find(x => x.Type == unit).Deffence;
                potence += _unitsParams.Find(x => x.Type == unit).Attack;
                speed += _unitsParams.Find(x => x.Type == unit).Speed;
            }

            _healthText.text = "Health: " + hp;
            _attakText.text = "atttack: " + attack;
            _defenceText.text = "defence: " + defence;
            _potencText.text = "potence: " + potence;
            _speedText.text = "potence: " + speed;
        }
    }
}