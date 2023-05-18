using UnityEngine;

namespace DefaultNamespace.Units
{
    [CreateAssetMenu(fileName = "UnitParams", menuName = "Settings/UnitParams")]
    public class UnitParams : ScriptableObject
    {
        public UnitType Type;
        public int Health = 100;
        public int Attack = 10;
        public int Deffence = 5;
        public int Speed = 1;
        public int Patency = 1;//проходимость
    }
}