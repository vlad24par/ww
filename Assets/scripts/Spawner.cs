using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Sell> _sellsPrefabs;

    [SerializeField] private int X;
    [SerializeField] private int Y;


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
                var random_biom_id = Random.Range(0, _sellsPrefabs.Count);

                var prefab = _sellsPrefabs[random_biom_id];
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity,
                    transform);
            }
        }
    }
}
