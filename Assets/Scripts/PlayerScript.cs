using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;



public class PlayerScript : MonoBehaviour
{
    public static int playerHP;
    public float speed = 2.0f;
    public static int direction = 3;

    public static bool isProtected;

    public static bool isPlaying;

    public int lightedCount=0;


    public GameObject lightObject;

    GameObject lightObject2;
    public GameObject lightObject1;
    public static int lightLength;

    public static int enemyObjectnumber=0;

    int playerx, playery;
    public static int px, py;
    public static string clearedStageName;

    public GameObject OnSwitch;


    public GameObject damageAnimation;
    GameObject damageAnimation1;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = StageGenerator.HPLevel;
        lightedCount = 0;
        Instantiate(lightObject, Vector3.zero, Quaternion.identity);
        isPlaying = true;
        enemyObjectnumber = 0;
        isProtected = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isPlaying)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                direction = 0;

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
                direction = 2;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
                direction = 3;
            }
        }

        playerx = -Mathf.RoundToInt(transform.position.x / StageGenerator.squareScale);
        playery = -Mathf.RoundToInt(transform.position.y / StageGenerator.squareScale);
        px = playerx;
        py = playery;

        //Debug.Log(playerx + "," + playery);
        lightLength = -1;

        while (StageGenerator.location[playery, playerx] == 1)
        {

            switch (direction)
            {
                case 0:
                    playerx--;
                    break;
                case 1:
                    playerx++;
                    break;
                case 2:
                    playery--;
                    break;
                case 3:
                    playery++;
                    break;

            }
            lightLength++;

        }
        // Debug.Log(lightLength);



        if (playerHP <= 0)
        {
            SceneManager.LoadScene("GameOver");
            playerHP = 5;
        }
        if (lightedCount==StageGenerator.lightSwitch.Length&& enemyObjectnumber<=0)
        {
            clearedStageName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Clear");
        }
    }
    public void damaged()
    {
        if (isProtected == false)
        {
            damageAnimation1 = Instantiate(damageAnimation, transform.position, Quaternion.identity) as GameObject;
            damageAnimation1.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0);

            Invoke("removeAnimation", 0.5f);
            playerHP--;
            pause(1.0f);
        }
        else
        {
            isProtected = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "switch")
        {
            
            for (int i = 0; i < StageGenerator.lightSwitch.Length; i++)
            {
                if (Input.GetMouseButton(0)) {
                    if (collision.gameObject.transform.position == (-1 * StageGenerator.lightSwitch[i] * StageGenerator.squareScale + new Vector3(0, 0, -10)))
                    {
                        GameObject Onswitch1= Instantiate(OnSwitch, collision.gameObject.transform.position, Quaternion.identity)as GameObject;
                       
                        Onswitch1.transform.localScale = new Vector3(StageGenerator.squareScale / 2,StageGenerator.squareScale / 2, 0);
                        Destroy(collision.gameObject);
                        lightObject2 = Instantiate(lightObject1, new Vector3(-StageGenerator.switchManager[i].z, -StageGenerator.switchManager[i].w, 0) * StageGenerator.squareScale + new Vector3(0, 0, -10), Quaternion.identity) as GameObject;
                        lightObject2.transform.localScale = new Vector3(StageGenerator.switchManager[i].x, StageGenerator.switchManager[i].y, 0) * StageGenerator.squareScale;
                        lightedCount++;
                        pause(2.0f);
                       // Debug.Log(i);
                    }
                }
            }
        }

    }
    public void pause(float n)
    {
        speed = 0;
        isPlaying = false;
        Invoke("reStart",n);
    }
    void reStart()
    {
        speed = 2.0f;
        isPlaying = true;

    }
    
    void removeAnimation()
    {
        Destroy(damageAnimation1);
    }
}
