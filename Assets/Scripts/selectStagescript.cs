using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectStagescript : MonoBehaviour
{
    bool isMoving;
    string stageName;
    int movingDirection;
    string[] stageNames =
        {
            "DemoStage",
            "Stage1-1"
        };
    public static bool[] isCleared=
        {
        false,false
        };

    GameObject clearedObject;
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < stageNames.Length; i++) {
            if (stageNames[i] == PlayerScript.clearedStageName)
            {
                isCleared[i] = true;
            }
            clearedObject = GameObject.Find(stageNames[i]);
            if (isCleared[i]) {
                clearedObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                clearedObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }



        isMoving = false;
        transform.position = new Vector3(-5,-2,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)&&isMoving==false)
        {
            isMoving = true;
            movingDirection = 1;
            Invoke("resetDirection",1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)&&isMoving==false)
        {
            isMoving = true;
            movingDirection = 2;
            Invoke("resetDirection", 1.0f);
        }
        if (movingDirection==1)
        {
            transform.position += new Vector3(1, 0, 0)*Time.deltaTime*8;
        }else if (movingDirection == 2)
        {

            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * 8;
        }
        if (Input.GetMouseButtonDown(0) && isMoving==false)
        {
            SceneManager.LoadScene(stageName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "stage")
        {
            stageName = collision.name;
        }
    }
    void resetDirection() {
        movingDirection = 0;
        isMoving = false;
    }

}
