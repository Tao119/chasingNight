using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    int direction=3;
    int[] directionOption;
    int directionOptionNumber=0;

    float timer;

    public float speed = 2.5f;

    int enemyx, enemyy;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        enemyx = -Mathf.RoundToInt(transform.position.x / StageGenerator.squareScale);
        enemyy = -Mathf.RoundToInt(transform.position.y / StageGenerator.squareScale);
        directionOption = new int[4];
        directionOptionNumber = 0;
        startDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemyx+","+enemyy);
        enemyx = -Mathf.RoundToInt(transform.position.x / StageGenerator.squareScale);
        enemyy = -Mathf.RoundToInt(transform.position.y / StageGenerator.squareScale);
        if (direction==0)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else if (direction==1)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        else if (direction==2)
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        else if (direction==3)
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }

        if (transform.position.x >= 0 || transform.position.x <= -10 || transform.position.y <= -10 || transform.position.y >= 0)
        {
            Destroy(this.gameObject);
            PlayerScript.enemyObjectnumber--;
        }




    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= StageGenerator.squareScale / speed)
        {
            changeDirection();
            timer = 0;
        }
    }
    void changeDirection()
    {
        directionOptionNumber = 0;
        if (StageGenerator.location[enemyy + 1, enemyx] == 1 && direction!=2)
        {
            directionOption[directionOptionNumber] = 3;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy - 1, enemyx] == 1 && direction != 3)
        {
            directionOption[directionOptionNumber] = 2;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx + 1] == 1 && direction != 0)
        {
            directionOption[directionOptionNumber] = 1;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx - 1] == 1 && direction != 1)
        {
            directionOption[directionOptionNumber] = 0;
            directionOptionNumber++;
        }
        if(directionOptionNumber==0)
        {
            switch (direction)
            {
                case 0:
                    directionOption[0] = 1;
                    break;
                case 1:
                    directionOption[0] = 0;
                    break;
                case 2:
                    directionOption[0] = 3;
                    break;
                case 3:
                    directionOption[0] = 2;
                    break;
            }
            directionOptionNumber = 1;
        }

        //Debug.Log(direction + "," + directionOptionNumber + "," + directionOption[0]+","+ StageGenerator.location[enemyy + 1, enemyx]);
        int randomNumber = Random.Range(0,directionOptionNumber);
        direction = directionOption[randomNumber];




        
    }

    public void startDirection()
    {
        //Debug.Log("1:"+StageGenerator.location[enemyy , enemyx]);
        if (StageGenerator.location[enemyy + 1, enemyx] == 1)
        {
            directionOption[directionOptionNumber] = 3;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy - 1, enemyx] == 1)
        {
            directionOption[directionOptionNumber] = 2;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx + 1] == 1)
        {
            directionOption[directionOptionNumber] = 1;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx - 1] == 1)
        {
            directionOption[directionOptionNumber] = 0;
            directionOptionNumber++;
        }
        int randomNumber = Random.Range(0, directionOptionNumber);
        direction = directionOption[randomNumber];
        //Debug.Log(direction+","+directionOptionNumber);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("damaged");
            Destroy(this.gameObject);
            PlayerScript.enemyObjectnumber--;
        } 
    }
    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "light(Clone)")
        {
            if ((Mathf.Abs(enemyx - PlayerScript.px) <= 3 * StageGenerator.squareScale && Mathf.Abs(enemyy - PlayerScript.py) == 0)|| (Mathf.Abs(enemyy - PlayerScript.py) <= 3 * StageGenerator.squareScale && Mathf.Abs(enemyx - PlayerScript.px) == 0) && PlayerScript.isPlaying==true)
            {
                Destroy(this.gameObject);
                //collision.gameObject.SendMessage("pause",1.0f);
                PlayerScript.enemyObjectnumber--;
            }
        }
    }
}
