using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectStagescript : MonoBehaviour
{
    bool isMoving;
    string stageName;
    int movingDirection;
    float timer;
    public static int clearedStageNumber;
    public Canvas canvasObject;
    public Text textObject;
    public Text allClearedText;

    Transform transform1;

    string[] stageNames =
        {
        //    "DemoStage",
            "Stage1-1",
            "Stage1-2",
            "Stage1-3",
            "DemoStage"
        };
    public static bool[] isCleared=
        {
    //    false,
        false,false,false,false
        };

    GameObject clearedObject;
    // Start is called before the first frame update
    void Start()
    {
        transform1 = GameObject.Find("Canvas").transform;
        timer = 0;
        for(int i = 0; i < stageNames.Length; i++) {
            textObject.text = stageNames[i];
            textObject.color = Color.red;
            textObject.fontSize = 100;
            Instantiate(textObject, new Vector3(-5 + 8 * i, 2, 0), Quaternion.identity, transform1);

            if (stageNames[i] == PlayerScript.clearedStageName)
            {
                isCleared[i] = true;
                
            }
            clearedObject = GameObject.Find(stageNames[i]);
            if (isCleared[i]) {
                clearedObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                textObject.text = "cleared!!";
                textObject.color = Color.yellow;
                textObject.fontSize = 50;
                Instantiate(textObject, new Vector3(-5 + 8 * i, 3, 0), Quaternion.identity, transform1);
            }
            else
            {
                clearedObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
                if (i != 0 && isCleared[i] == true && isCleared[i - 1] == true)
                {
                    clearedStageNumber = i + 1;
                } else if (i == 0 && isCleared[i] == true)
                {
                    clearedStageNumber = i + 1;
                }
        }
        if (isCleared[stageNames.Length-1]==true && GameoverManager.isDisplayed==0)
        {
            SceneManager.LoadScene("AllClear");
        }
        if(GameoverManager.isDisplayed == 1)
        {
            allClearedText.gameObject.SetActive(true);
        }
        else
        {
            allClearedText.gameObject.SetActive(false);
        }



        isMoving = false;
        if (PlayerScript.clearedStageName != null)
        {
            transform.position = GameObject.Find(PlayerScript.clearedStageName).transform.position;
        }
        else
        {
            transform.position = GameObject.Find(stageNames[0]).transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && isMoving == false && transform.position.x<=-7+8*clearedStageNumber)
            {
                isMoving = true;
                movingDirection = 1;
                Invoke("resetDirection", 1.0f);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && isMoving == false && transform.position.x>=1)
            {
                isMoving = true;
                movingDirection = 2;
                Invoke("resetDirection", 1.0f);
            }
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
