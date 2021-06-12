using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] items;
    public GameObject item;
    float timer;
    float interval = 10.0f;
    Vector3[] spawnableLocation;
    int Num = 0;
    int count;
    int randomNum;
    Transform parent;

    public static bool isExisting;

    // Start is called before the first frame update
    void Start()
    {
        timer = interval*2;
        isExisting = false;
        Invoke("countFloor",1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            Num = 0;
            count = 0;
            if (isExisting == false)
            {
                for (int i = 0; i < StageGenerator.lengthy; i++)
                {
                    for (int j = 0; j < StageGenerator.lengthx; j++)
                    {
                        if (StageGenerator.location[i, j] == 1)
                        {
                            spawnableLocation[Num] = new Vector3(-j, -i, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);

                            Num++;
                            count++;
                        }
                    }
                }
                Spawn();
                timer = interval;
            }

        }
        timer -= Time.deltaTime;
      
            // Debug.Log(isLighted[1,1]+","+isLighted[StageGenerator.lengthy-2, StageGenerator.lengthx-2]);
        




    }
    void Spawn()
    {
        if (count > 0)
        {
            randomNum = Random.Range(0, count);
            int i = Random.Range(0,items.Length);
            items[i].transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0)/2;
            Instantiate(items[i], spawnableLocation[randomNum], Quaternion.identity);
            isExisting = true;
        }
    }
    public void countFloor()
    {
        spawnableLocation = new Vector3[StageGenerator.floorNumber];
    }
    void setting()
    {
        EnemyGenerator.isLighted = new bool[StageGenerator.lengthy, StageGenerator.lengthx];
        for (int i = 0; i < StageGenerator.lengthy; i++)
        {
            for (int j = 0; j < StageGenerator.lengthx; j++)
            {
                EnemyGenerator.isLighted[i, j] = false;
            }
        }
    }
}