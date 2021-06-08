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
    Transform parent;

    public static bool[,] isLighted;
    public GameObject spawnMark;
    public GameObject spawnMark1;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
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
                    if (isLighted[i, j] == false)
                    {
                        spawnableLocation[Num] = new Vector3(-j, -i, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);

                        Num++;
                        count++;
                    }
                }
            }
        }

        timer -= Time.deltaTime; 
        if (timer < 0)
        { 
            Spawn(); 
            timer = interval;
           // Debug.Log(isLighted[1,1]+","+isLighted[StageGenerator.lengthy-2, StageGenerator.lengthx-2]);
        }
            


        
    }
    void Spawn()
    {
        if (count>0) {
            randomNum = Random.Range(0, count);
            Instantiate(enemy, spawnableLocation[randomNum], Quaternion.identity);
            spawnMark1= Instantiate(spawnMark, spawnableLocation[randomNum], Quaternion.identity)as GameObject;
            spawnMark1.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0);
            Invoke("removeMark",1.5f);
            // Debug.Log(spawnableLocation[randomNum]);
            enemy.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0);
            PlayerScript.enemyObjectnumber++;
        }
    }
    public void countFloor()
    {
          spawnableLocation = new Vector3[StageGenerator.floorNumber];
    }
    void setting()
    {
        isLighted = new bool[StageGenerator.lengthy, StageGenerator.lengthx];
        for (int i = 0; i < StageGenerator.lengthy; i++)
        {
            for (int j = 0; j < StageGenerator.lengthx; j++)
            {
                isLighted[i, j] = false;
            }
        }
    }
    void removeMark()
    {
        Destroy(spawnMark1);
    }
}
