using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static int playerHP = 5;
    public float speed = 2.0f;
    public static int direction=3;


    public GameObject lightObject;
    public static int lightLength;

    int playerx, playery;
    public static int px, py;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(lightObject,Vector3.zero,Quaternion.identity);
    
    }

    // Update is called once per frame
    void Update()
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
    }
    public void damaged()
    {
        playerHP--;
    }

}
