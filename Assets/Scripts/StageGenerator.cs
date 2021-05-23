using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{

   
    int len;
    public static float squareScale;
    
    public static GameObject[,] stageObject;
    public GameObject[] GObject;

    public GameObject player;

    // Start is called before the first frame update
    void Start(){
        
        string[] stageLayout ={
            "000    ",
            "010000 ",
            "011110 ",
            "010010 ",
            "0100100",
            "0111110",
            "0000000"
        };
        stageObject = new GameObject[stageLayout.GetLength(0), stageLayout[0].Length];

       

        len = Mathf.Max(stageLayout.GetLength(0), stageLayout[0].Length);
        squareScale = 10.0f / len;

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
                        stageObject[i,j] =Instantiate(GObject[0], new Vector3(-j * squareScale, -i * squareScale, -10), Quaternion.identity)as GameObject;
                        break;
                    case "1":
                        stageObject[i,j] = Instantiate(GObject[1], new Vector3(-j * squareScale, -i * squareScale, 0), Quaternion.identity) as GameObject;
                        break;

                }
                if (stageLayout[i].Substring(j, 1)!=" ") {
                    stageObject[i, j].transform.localScale = new Vector3(squareScale, squareScale, 0);
                }
            }
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
