using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    float timer;
    float interval = 5.0f;
    Vector3[] spawnableLocation;
    int Num = 0;
    int count;
    int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        Num = 0;
        count = 0;
        for (int i = 0; i < StageGenerator.lengthy; i++)
        {
            for (int j = 0; j < StageGenerator.lengthx; j++)
            {
                if (StageGenerator.location[i,j]==1)
                {
                   // if (LightGenerator.isLighted[i, j] == false)
                  //  {
                        spawnableLocation[Num] = new Vector3(-j, -i, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                   // }
                    Num++;
                    count++;
                }
            }
        }

        timer -= Time.deltaTime; 
        if (timer < 0)
        { 
            Spawn(); 
            timer = interval;
        }
            


        
    }
    void Spawn()
    {
        randomNum = Random.Range(0,count);
        Instantiate(enemy, spawnableLocation[randomNum], Quaternion.identity);
        enemy.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0);
    }
    public void countFloor()
    {
          spawnableLocation = new Vector3[StageGenerator.floorNumber];
    }
}
