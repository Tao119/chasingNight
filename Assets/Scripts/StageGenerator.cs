using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{

   
    int len;
    float squareScale;

    public GameObject[,] stageObject;
    public GameObject[] GObject;

    // Start is called before the first frame update
    void Start(){
        
        string[] stageLayout ={
            "00000000",
            "01111110",
            "01000010",
            "01101110",
            "00101010",
            "01111010",
            "01001110",
            "00000000"
        };
        stageObject = new GameObject[stageLayout.GetLength(0), stageLayout[0].Length];


        len = Mathf.Max(stageLayout.GetLength(0), stageLayout[0].Length);
        squareScale = 10.0f / len;




        for (int i = 0; i < stageLayout.GetLength(0); i++)
        {
            for (int j = 0; j < stageLayout[i].Length; j++)
            {
                switch (stageLayout[i].Substring(j, 1))
                {
                    case "0":
                        stageObject[i,j] =Instantiate(GObject[0], new Vector3(i * squareScale, j * squareScale, 0), Quaternion.identity)as GameObject;
                        break;
                    case "1":
                        stageObject[i,j] = Instantiate(GObject[1], new Vector3(i * squareScale, j * squareScale, 0), Quaternion.identity) as GameObject;
                        break;
                }
                
                 stageObject[i,j].transform.localScale = new Vector3(squareScale,squareScale,0);
            }
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
