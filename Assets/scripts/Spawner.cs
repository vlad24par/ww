using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] Vector3 _Teil_Position;

    [SerializeField] GameObject wild;
    [SerializeField] GameObject boloto;
    [SerializeField] GameObject cholm;
    [SerializeField] GameObject choru;
    [SerializeField] GameObject pole;



    public Vector3 vector;



    private float random_biom;
    private float X = -5.5f;
    private float Y;
    private float Z;
    private int stop_spawn;
    private int next_leyer;
    [SerializeField] int end_spawn;


    // Start is called before the first frame update
    void Start()
    {
        X = -5;
        stop_spawn = 0;
        start_spawn();
    }

    public void start_spawn()
    {
        while (stop_spawn < 10)
        {
            random_biom = Random.Range(1, 5);

            if (random_biom == 1)
            {
                teil_position();
                Instantiate(wild, vector, Quaternion.identity);
            }
            else if (random_biom == 2)
            {
                teil_position();
                Instantiate(boloto, vector, Quaternion.identity);
            }
            else if (random_biom == 3)
            {
                teil_position();
                Instantiate(cholm, vector, Quaternion.identity);
            }
            else if (random_biom == 4)
            {
                teil_position();
                Instantiate(choru, vector, Quaternion.identity);
            }
            else if (random_biom == 5)
            {
                teil_position();
                Instantiate(pole, vector, Quaternion.identity);
            }
            stop_spawn += 1;
        }
    }


    public void teil_position()
    {
        vector = new Vector3(X += 1, Y, Z);
        next_leyer += 1;
        end_spawn = end_spawn + 1;
        if (end_spawn == 45)
        { 

        }
        else if (next_leyer == 10)
        {
            vector = new Vector3(-5, Y += 1, Z);
            stop_spawn = 0;
            next_leyer = 0;
            start_spawn();
        }
    }


}
