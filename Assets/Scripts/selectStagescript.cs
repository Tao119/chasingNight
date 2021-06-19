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
    public GameObject road;

    public GameObject stage;

    public static int[] stockItem;

    Animator animator;

    Transform transform1;


    //ステージ追加ごとに変更

    string[] stageNames =
        {
        //    "DemoStage",
        "Tutorial",
            "Stage1-1",
            "Stage1-2",
            "Stage1-3",
            "Stage2-1",
            "Stage2-2",
            "Stage2-3",
            "Stage3-1",
            "Stage3-2",
            //"Stage3-3",
            "Stage4-1",
            "Stage4-2",
            //"Stage4-3",
            //"DemoStage",
            "BossStage"
        };
    public static bool[] isCleared=
        {
    //    false,
        false,false,false,false,false,false,false,false,false,false,false,false
            //,false,false
        };

    GameObject clearedObject;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = this.gameObject.GetComponent<Animator>();
        transform1 = GameObject.Find("Canvas").transform;
        timer = 0;
        for(int i = 0; i < stageNames.Length; i++) {
            textObject.text = stageNames[i];
            textObject.color = Color.red;
            textObject.fontSize = 100;
            Instantiate(textObject, new Vector3(-5 + 8 * i, 2, 0), Quaternion.identity, transform1);
            GameObject stage1 = Instantiate(stage, new Vector3(-5 + 8 * i, -2, 0), Quaternion.identity)as GameObject;

            stage1.name = stageNames[i];
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
                if (i < stageNames.Length - 1)
                {
                    Instantiate(road, new Vector3(-1 + 8 * i, -2, 0), Quaternion.identity);
                }
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
        if (PlayerScript.StageName != null)
        {
            transform.position = GameObject.Find(PlayerScript.StageName).transform.position;
        }
        else
        {
            transform.position = GameObject.Find("Stage1-1").transform.position;
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
                animator.SetInteger("direction", movingDirection);
                Invoke("resetDirection", 1.0f);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && isMoving == false && transform.position.x>=1)
            {
                isMoving = true;
                movingDirection = 2;
                animator.SetInteger("direction", movingDirection);
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
        animator.SetInteger("direction", movingDirection);
        isMoving = false;
    }

}
