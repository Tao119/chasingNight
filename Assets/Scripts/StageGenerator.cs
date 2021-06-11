using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageGenerator : MonoBehaviour
{

   
    public static int len;
    public static float squareScale;
    
    GameObject[,] stageObject;
    GameObject[,] stageObject2;
    public static int[,] location;
    public GameObject[] GObject;
    public GameObject enemyGenerator;

    public static int lengthx,lengthy;

    public GameObject player;
    public GameObject enemy;
    public GameObject boss;
    public GameObject switchObject;
    public GameObject switchObject1;

    public static int HPLevel;


    public static int floorNumber = 0;

    string[] stageLayout ={
            "0000000000000",
            "0111111111110",
            "0101010101010",
            "0111010101110",
            "0101111111010",
            "0111010101110",
            "0101010101010",
            "0111111111110",
            "0000000000000"
        };

    public static Vector3[] lightSwitch = {
            new Vector3(1,7.5f,0),
            new Vector3(3,0.5f,0),
            new Vector3(9,0.5f,0),
            new Vector3(11,0.5f,0),
            new Vector3(10,2.5f,0),
            new Vector3(10,5.5f,0),
            new Vector3(5,7.5f,0),
            new Vector3(7,7.5f,0),
            new Vector3(0.5f,1,0),
            new Vector3(11.5f,7,0),
            new Vector3(3.5f,3,0),
            new Vector3(9.5f,4,0),
            new Vector3(3.5f,5,0)
        };


    public static Vector4[] switchManager = {
            new Vector4(1,7,1,4),
            new Vector4(1,7,3,4),
            new Vector4(1,7,9,4),
            new Vector4(1,7,11,4),
            new Vector4(1,1,10,3),
            new Vector4(1,1,10,5),
            new Vector4(1,7,5,4),
            new Vector4(1,7,7,4),
            new Vector4(11,1,6,1),
            new Vector4(11,1,6,7),
            new Vector4(3,1,2,3),
            new Vector4(7,1,6,4),
            new Vector4(3,1,2,5),
        };

    // Start is called before the first frame update
    void Start() {
        switch (SceneManager.GetActiveScene().name)
        {
            case "DemoStage":
                stageLayout = new string[]{
                    "0000000000000",
                    "0111111111110",
                    "0101010101010",
                    "0111010101110",
                    "0101111111010",
                    "0111010101110",
                    "0101010101010",
                    "0111111111110",
                    "0000000000000"
                };
                lightSwitch =　new Vector3[]{
                    new Vector3(1, 7.5f, 0),
                    new Vector3(3, 0.5f, 0),
                    new Vector3(9, 0.5f, 0),
                    new Vector3(11, 0.5f, 0),
                    new Vector3(10, 2.5f, 0),
                    new Vector3(10, 5.5f, 0),
                    new Vector3(5, 7.5f, 0),
                    new Vector3(7, 7.5f, 0),
                    new Vector3(0.5f, 1, 0),
                    new Vector3(11.5f, 7, 0),
                    new Vector3(3.5f, 3, 0),
                    new Vector3(9.5f, 4, 0),
                    new Vector3(3.5f, 5, 0)
                };
                switchManager = new Vector4[]{
                    new Vector4(1, 7, 1, 4),
                    new Vector4(1, 7, 3, 4),
                    new Vector4(1, 7, 9, 4),
                    new Vector4(1, 7, 11, 4),
                    new Vector4(1, 1, 10, 3),
                    new Vector4(1, 1, 10, 5),
                    new Vector4(1, 7, 5, 4),
                    new Vector4(1, 7, 7, 4),
                    new Vector4(11, 1, 6, 1),
                    new Vector4(11, 1, 6, 7),
                    new Vector4(3, 1, 2, 3),
                    new Vector4(7, 1, 6, 4),
                    new Vector4(3, 1, 2, 5),
                };
                HPLevel = 8;
                break;
            case "Stage1-1":
                stageLayout = new string[]{
                    "00000",
                    "01000",
                    "01000",
                    "01110",
                    "00000"
                };
                lightSwitch = new Vector3[]{
                    new Vector3(1,0.5f,0),
            new Vector3(3.5f,3,0),
                };
                switchManager = new Vector4[]{
            new Vector4(1,3,1,2),
            new Vector4(3,1,2,3),
                };
                HPLevel = 2;
                break;
            case "Stage1-2":
                stageLayout = new string[]{
                    "00000",
                    "01110",
                    "01010",
                    "01110",
                    "00000"
                };
                lightSwitch = new Vector3[]{
                    new Vector3(1,0.5f,0),
            new Vector3(3,3.5f,0),
            new Vector3(0.5f,3,0),
            new Vector3(3.5f,1,0),
                };
                switchManager = new Vector4[]{
            new Vector4(1,3,1,2),
            new Vector4(1,3,3,2),
            new Vector4(3,1,2,3),
            new Vector4(3,1,2,1),
                };
                HPLevel = 2;
                break;
            case "Stage1-3":
                stageLayout = new string[]{
                    "000000",
                    "010010",
                    "010010",
                    "011110",
                    "000000"
                };
                lightSwitch = new Vector3[]{
                    new Vector3(1,0.5f,0),
            new Vector3(0.5f,3,0),
            new Vector3(4,0.5f,0),
                };
                switchManager = new Vector4[]{
            new Vector4(1,3,1,2),
            new Vector4(4,1,2.5f,3),
            new Vector4(1,3,4,2),
                };
                HPLevel = 2;
                break;
            case "Stage2-1":
                stageLayout = new string[]{
                    "000000000",
                    "001010100",
                    "011111110",
                    "001010100",
                    "000000000"
                };
                lightSwitch = new Vector3[]{
                    new Vector3(2,0.5f,0),
            new Vector3(4,3.5f,0),
            new Vector3(6,0.5f,0),
            new Vector3(7.5f,2,0),

                };
                switchManager = new Vector4[]{
            new Vector4(1,3,3,2),
            new Vector4(1,3,4,2),
            new Vector4(1,3,6,2),
            new Vector4(7,1,4,2),
                };
                HPLevel = 4; 
                break;
            case "Stage2-2":
                stageLayout = new string[]{
                    "000000000",
                    "001010100",
                    "011111110",
                    "001010100",
                    "000000000"
                };
                lightSwitch = new Vector3[]{
                    new Vector3(2,0.5f,0),
            new Vector3(4,3.5f,0),
            new Vector3(6,0.5f,0),
            new Vector3(7.5f,2,0),

                };
                switchManager = new Vector4[]{
            new Vector4(1,3,3,2),
            new Vector4(1,3,4,2),
            new Vector4(1,3,6,2),
            new Vector4(7,1,4,2),
                };
                HPLevel = 4;
                break;
            case "BossStage":
                stageLayout = new string[]{
                    "00000000000000000",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "01111111111111110",
                    "00000000000000000"
                };
                lightSwitch = new Vector3[]{
                    new Vector3(1,0.5f,0),
                    new Vector3(3,0.5f,0),
                    new Vector3(5,0.5f,0),
                    new Vector3(7,0.5f,0),
                    new Vector3(9,0.5f,0),
                    new Vector3(11,0.5f,0),
                    new Vector3(13,0.5f,0),
                    new Vector3(15,0.5f,0),
                    new Vector3(2,15.5f,0),
                    new Vector3(4,15.5f,0),
                    new Vector3(6,15.5f,0),
                    new Vector3(8,15.5f,0),
                    new Vector3(10,15.5f,0),
                    new Vector3(12,15.5f,0),
                    new Vector3(14,15.5f,0),

                };
                switchManager = new Vector4[]{
            new Vector4(1,15,1,8),
            new Vector4(1,15,3,8),
            new Vector4(1,15,5,8),
            new Vector4(1,15,7,8),
            new Vector4(1,15,9,8),
            new Vector4(1,15,11,8),
            new Vector4(1,15,13,8),
            new Vector4(1,15,15,8),
            new Vector4(1,15,2,8),
            new Vector4(1,15,4,8),
            new Vector4(1,15,6,8),
            new Vector4(1,15,8,8),
            new Vector4(1,15,10,8),
            new Vector4(1,15,12,8),
            new Vector4(1,15,14,8)
                };
                HPLevel = 10;
                break;
        }



        stageObject = new GameObject[stageLayout.GetLength(0), stageLayout[0].Length];
        stageObject2 = new GameObject[stageLayout.GetLength(0), stageLayout[0].Length];
        location = new int[stageLayout.GetLength(0), stageLayout[0].Length];
   
        lengthy = stageLayout.GetLength(0);
        lengthx = stageLayout[0].Length;
        if (SceneManager.GetActiveScene().name != "BossStage")
        {
            enemyGenerator.SendMessage("setting");
        }

        len = Mathf.Max(stageLayout.GetLength(0), stageLayout[0].Length);
        squareScale = 10.0f / len;


        


       




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
                        stageObject2[i, j] = Instantiate(GObject[2], new Vector3(-j * squareScale, -i * squareScale, -10), Quaternion.identity) as GameObject;
                        stageObject2[i, j].transform.localScale = new Vector3(squareScale, squareScale, 0);
                        floorNumber++;
                        break;
                        
                }
                if (stageLayout[i].Substring(j, 1)!=" ") {
                    stageObject[i, j].transform.localScale = new Vector3(squareScale, squareScale, 0);
                }
            }
        }

        for (int i = 0; i < lightSwitch.Length; i++)
        {
            switchObject1= Instantiate(switchObject, -1*lightSwitch[i] * squareScale + new Vector3(0, 0, -10), Quaternion.identity)as GameObject ;
            switchObject1.transform.localScale= new Vector3(squareScale/2, squareScale/2, 0);
        }
        if (SceneManager.GetActiveScene().name != "BossStage")
        {
            enemyGenerator.SendMessage("countFloor");
        }
        player.transform.localScale = new Vector3(squareScale, squareScale, 0);
        Instantiate(player, new Vector3(-squareScale, -squareScale, -10), Quaternion.identity);
        Instantiate(boss, new Vector3(-10*squareScale, -10*squareScale, -10), Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
}
