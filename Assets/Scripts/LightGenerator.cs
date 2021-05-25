using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerScript.direction)
        {
            case 0:
                transform.position = new Vector3(-PlayerScript.px + (((float)PlayerScript.lightLength + 1) / 2), -PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(PlayerScript.lightLength, 1, 0) * StageGenerator.squareScale;
                break;
            case 1:
                transform.position = new Vector3(-PlayerScript.px - (((float)PlayerScript.lightLength + 1) / 2), -PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(PlayerScript.lightLength, 1, 0) * StageGenerator.squareScale;
                break;
            case 2:
                transform.position = new Vector3(-PlayerScript.px, ((float)PlayerScript.lightLength+1)/2- PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(1, PlayerScript.lightLength, 0) * StageGenerator.squareScale;
                break;
            case 3:
                transform.position = new Vector3(-PlayerScript.px, -(((float)PlayerScript.lightLength + 1) / 2) - PlayerScript.py, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10);
                transform.localScale = new Vector3(1, PlayerScript.lightLength, 0) * StageGenerator.squareScale;
                break;

        }
    }
    
}
