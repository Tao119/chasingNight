using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialStage : MonoBehaviour
{
    int rank;
    int check;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    bool isGenerated;
    public GameObject enemy;
    GameObject[] switchOff;
    GameObject enemy1;
    bool itemtem;
    public GameObject[] items;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        check = 0;
        rank = 0;
        isGenerated = false;
        count = 0;
        itemtem = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rank);
        switch (rank){
            case 0:
                switchOff = GameObject.FindGameObjectsWithTag("switch");
               // if (count == 0)
               // {
               //     for(int i = 0; i < 4; i++)
                //    {
                //        switchOff[i].gameObject.SetActive(false);
                //    }
                //    count = 1;
                //}
                PlayerScript.isPlaying = false;
                text1.gameObject.SetActive(true);
                Invoke("rankPlus0",3.0f);
                break;
            case 1:
                text1.gameObject.SetActive(false);
                PlayerScript.isPlaying = true;
                tutorial1();
                break;
            case 2:
                PlayerScript.isPlaying = false;
                enemy.transform.localScale = Vector3.one * StageGenerator.squareScale;
                if (isGenerated==false) {
                    enemy1=Instantiate(enemy, new Vector3(-3 * StageGenerator.squareScale, -StageGenerator.squareScale, 0), Quaternion.identity)as GameObject;
                    isGenerated = true;
                }
                enemy1.transform.position = new Vector3(-3 * StageGenerator.squareScale, -StageGenerator.squareScale, 0);
                text2.gameObject.SetActive(true);
                Invoke("rankPlus1", 3.0f);
                break;
            case 3:
                PlayerScript.isPlaying = true;
                text2.gameObject.SetActive(false);
                tutorial2();
                break;
            case 4:
                PlayerScript.isPlaying = false;

                text3.gameObject.SetActive(true);
                Invoke("rankPlus2", 3.0f);
                break;
            case 5:
                item();
                PlayerScript.isPlaying = false;
                text3.gameObject.SetActive(false);
                text4.gameObject.SetActive(true);
                Invoke("rankPlus3", 2.0f);
                break;
            case 6:
                PlayerScript.isPlaying = false;
                text4.gameObject.SetActive(false);
                text5.gameObject.SetActive(true);
                Invoke("rankPlus4", 2.0f);
                break;
            case 7:
                PlayerScript.isPlaying = false;
                text5.gameObject.SetActive(false);
                text6.gameObject.SetActive(true);
                Invoke("rankPlus5", 2.0f);
                break;
            case 8:
                PlayerScript.isPlaying = true;
                text6.gameObject.SetActive(false);
                break;
        }
    }
    void rankPlus0()
    {
        rank = 1;
    }
    void rankPlus1()
    {
        rank=3;
    }
    void rankPlus2()
    {
        rank = 5;
    }
    void rankPlus3()
    {
        rank = 6;
    }
    void rankPlus4()
    {
        rank = 7;
    }
    void rankPlus5()
    {
        rank = 8;
    }
    void tutorial1()
    {
        if (PlayerScript.px == 3 && PlayerScript.py == 1&&check==0)
        {
            check++;
        }
        if (PlayerScript.px == 3 && PlayerScript.py == 3 && check == 1)
        {
            check++;
        }
        if (PlayerScript.px == 1 && PlayerScript.py == 3 && check == 2)
        {
            check++;
        }
        if (PlayerScript.px == 1 && PlayerScript.py == 1 && check == 3)
        {
            rank=2;
        }
    }
    void tutorial2()
    {
        if (PlayerScript.playerHP<5)
        {
            PlayerScript.playerHP = 5;
            rank=2;
        }
        if (GameObject.FindGameObjectWithTag("enemy") == null)
        {
            rank=4;
        }
        else
        {

            enemy1.transform.position = new Vector3(-3 * StageGenerator.squareScale, -StageGenerator.squareScale, 0);
        }
    }
   void item()
    {
        if (itemtem == false)
        {
            for(int i = 0; i < 6; i++)
                {
                items[i].gameObject.SetActive(true);
            }
            itemtem = true;
        }
    }
}
