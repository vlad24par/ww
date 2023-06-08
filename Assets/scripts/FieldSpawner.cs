using System.Collections.Generic;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    [SerializeField] private List<Sell> _sellsPrefabs;
    [SerializeField] private List<FieldSettings> _fieldSettingsList;
    [SerializeField] private FieldController _fieldController;

    [SerializeField] private int X;
    [SerializeField] private int Y;
    [SerializeField] uint Given_Index;

    private int Number_Of_Biomes = 10000;

    void Start()
    {
        BuildFieldBySettings();
    }

    private void BuildField()
    {
        float Bioms_indecks;
        float Bioms_indecks2;
        
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                Bioms_indecks = Given_Index;
                Bioms_indecks2 = Given_Index;
                Number_Of_Biomes = Random.Range(0, 5);
                
                switch (Number_Of_Biomes)
                {
                    case 1: 
                        Number_Of_Biomes = 1;
                        break;
                    case 2: 
                        Number_Of_Biomes = 10;
                        break;
                    case 3: 
                        Number_Of_Biomes = 100;
                        break;
                    case 4: 
                        Number_Of_Biomes = 1000;
                        break;
                    case 5: 
                        Number_Of_Biomes = 10000;
                        break;
                    
                    default:
                        Number_Of_Biomes = 11111;
                        break;
                }
                
                Bioms_indecks /= Number_Of_Biomes;
                Bioms_indecks = Mathf.Floor(Bioms_indecks);
                
                Bioms_indecks2 /= (Number_Of_Biomes / 10);
                Bioms_indecks2 = Mathf.Floor(Bioms_indecks2);
                
                Bioms_indecks = Bioms_indecks2 - Bioms_indecks * 10;
                var prefab = _sellsPrefabs[(int)Bioms_indecks];
                
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity,transform);
            }
        }
    }

    private void BuildFieldBySettings()
    {
        var fieldId = Random.Range(0, _fieldSettingsList.Count);
        var settings = _fieldSettingsList[fieldId];
        
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                var value = Random.Range(0, 101);
                if (value <= settings.HillPercent)
                {
                    SpawnSell(_sellsPrefabs[0], new Vector3(i, j, 0));
                    continue;
                }

                if (value <= settings.HillPercent + 
                    settings.MountainPercent)
                {
                    SpawnSell(_sellsPrefabs[1], new Vector3(i, j, 0));
                    continue;
                }

                if (value <= settings.HillPercent + 
                    settings.MountainPercent + 
                    settings.ForestPercent)
                {
                    SpawnSell(_sellsPrefabs[2], new Vector3(i, j, 0));
                    continue;
                }

                if (value <= settings.HillPercent + 
                    settings.MountainPercent+ 
                    settings.ForestPercent + 
                    settings.FieldPercent)
                {
                    SpawnSell(_sellsPrefabs[3], new Vector3(i, j, 0));
                    continue;
                }
                
                SpawnSell(_sellsPrefabs[4], new Vector3(i, j, 0));
            }
        }
        
        _fieldController.StartGame();
    }

    private void SpawnSell(Sell prefab, Vector3 position)
    {
        var sell = Instantiate(prefab, position, Quaternion.identity,transform);
        _fieldController.AddSell(sell);
    }
}
