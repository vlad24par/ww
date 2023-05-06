using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Sell> _sellsPrefabs;

    [SerializeField] private int X;
    [SerializeField] private int Y;
    [SerializeField] float Given_Index;
    private float Bioms_indecks;
    private float Bioms_indecks2;
    private int Number_Of_Biomes = 10000;

    void Start()
    {
        BuildField();
    }

    private void BuildField()
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                Bioms_indecks = Given_Index;
                Bioms_indecks2 = Given_Index;
                Number_Of_Biomes = Random.Range(1, 5);
                if (Number_Of_Biomes == 1)
                {
                    Number_Of_Biomes = 10;
                }
                else if (Number_Of_Biomes == 2)
                {
                    Number_Of_Biomes = 100;
                }
                else if (Number_Of_Biomes == 3)
                {
                    Number_Of_Biomes = 1000;
                }
                else if (Number_Of_Biomes == 4)
                {
                    Number_Of_Biomes = 10000;
                }
                Bioms_indecks = Bioms_indecks / Number_Of_Biomes;
                Bioms_indecks = Mathf.Floor(Bioms_indecks);
                Bioms_indecks2 = Bioms_indecks2 / (Number_Of_Biomes / 10);
                Bioms_indecks2 = Mathf.Floor(Bioms_indecks2);
                Bioms_indecks = Bioms_indecks2 - Bioms_indecks * 10;
                var prefab = _sellsPrefabs[(int)Bioms_indecks];
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity,transform);
            }
        }
    }
}
