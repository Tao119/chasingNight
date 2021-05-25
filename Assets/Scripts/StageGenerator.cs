using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{

   
    int len;
    public static float squareScale;
    
    GameObject[,] stageObject;
    public static int[,] location;
    public GameObject[] GObject;

    public static int lengthx;

    public GameObject player;
    public GameObject enemy;


    // Start is called before the first frame update
    void Start() {

        string[] stageLayout ={
            "0000000000000",
            "0111111111110",
            "0101010101000",
            "0101010101000",
            "0111111111100",
            "0000000000000"
        };
        stageObject = new GameObject[stageLayout.GetLength(0), stageLayout[0].Length];
        location = new int[stageLayout.GetLength(0), stageLayout[0].Length];

        lengthx = stageLayout.GetLength(0);

        len = Mathf.Max(stageLayout.GetLength(0), stageLayout[0].Length);
        squareScale = 10.0f / len;

        Debug.Log(squareScale);

        Instantiate(player, new Vector3(-squareScale, -squareScale, -10), Quaternion.identity);
        player.transform.localScale = new Vector3(squareScale, squareScale, 0);


       




        for (int i = 0; i < stageLayout.GetLength(0); i++)
        {
            for (int j = 0; j < stageLayout[i].Length; j++)
            {
                switch (stageLayout[i].Substring(j, 1))
                {
                    case " ":
                        break;
                    case "0":
                        location[i, j] = 0;
                        stageObject[i,j] =Instantiate(GObject[0], new Vector3(-j * squareScale, -i * squareScale, -10), Quaternion.identity)as GameObject;
                        break;
                    case "1":
                        location[i, j] = 1;
                        stageObject[i,j] = Instantiate(GObject[1], new Vector3(-j * squareScale, -i * squareScale, 0), Quaternion.identity) as GameObject;
                        break;

                }
                if (stageLayout[i].Substring(j, 1)!=" ") {
                    stageObject[i, j].transform.localScale = new Vector3(squareScale, squareScale, 0);
                }
            }
        }

        enemyGenerate();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void enemyGenerate()
    {
        Instantiate(enemy, new Vector3(-squareScale, -squareScale, -10), Quaternion.identity);
        enemy.transform.position = new Vector3(-squareScale, -squareScale, -10);
        enemy.transform.localScale = new Vector3(squareScale, squareScale, 0);
    }
}
