using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Sell> _sellsPrefabs;

    [SerializeField] private int X;
    [SerializeField] private int Y;
    [SerializeField] int Bioms_max;

    private int Bioms_min;
    private float float_Bioms;


    void Start()
    {


        float_Bioms = Bioms_max / 10;
        float_Bioms = Mathf.Floor(float_Bioms);
        Bioms_min = Bioms_max - ((int)float_Bioms * 10);



        Bioms_max = (Bioms_max - Bioms_min) / 10;
        BuildField();
    }

    private void BuildField()
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                var random_biom_id = Random.Range(Bioms_min,Bioms_max);

                var prefab = _sellsPrefabs[random_biom_id];
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity,transform);
            }
        }
    }
}
