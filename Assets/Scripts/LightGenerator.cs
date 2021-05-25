using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGenerator : MonoBehaviour
{
    public static bool[,] isLighted;
    // Start is called before the first frame update
    void Start()
    {
        isLighted = new bool[StageGenerator.lengthy,StageGenerator.lengthx];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < StageGenerator.lengthy; i++)
        {
            for (int j = 0; j < StageGenerator.lengthx; j++)
            {
                isLighted[i, j] = false;
            }
        }
                switch (PlayerScript.direction)
        {
            
            case 0:
                transform.position = new Vector3(-PlayerScript.px + (((float)PlayerScript.lightLength + 1) / 2), -PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(PlayerScript.lightLength, 1, 0) * StageGenerator.squareScale;
                for (int i=0;i<=PlayerScript.lightLength;i++)
                {
                    isLighted[PlayerScript.py, PlayerScript.px - i]=true;
                }
                break;
            case 1:
                transform.position = new Vector3(-PlayerScript.px - (((float)PlayerScript.lightLength + 1) / 2), -PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(PlayerScript.lightLength, 1, 0) * StageGenerator.squareScale;
                for (int i = 0; i <= PlayerScript.lightLength; i++)
                {
                    isLighted[PlayerScript.py, PlayerScript.px + i]=true;
                 }
                break;
            case 2:
                transform.position = new Vector3(-PlayerScript.px, ((float)PlayerScript.lightLength+1)/2- PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(1, PlayerScript.lightLength, 0) * StageGenerator.squareScale;
                for (int i = 0; i <= PlayerScript.lightLength; i++)
                {
                    isLighted[PlayerScript.py-i, PlayerScript.px] = true;
                }
                break;
            case 3:
                transform.position = new Vector3(-PlayerScript.px, -(((float)PlayerScript.lightLength + 1) / 2) - PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(1, PlayerScript.lightLength, 0) * StageGenerator.squareScale;
                for (int i = 0; i <= PlayerScript.lightLength; i++)
                {
                    isLighted[PlayerScript.py+i, PlayerScript.px] = true;
                }
                break;

        }
    }
    
}
