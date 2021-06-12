using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static int direction = 3;
    int[] directionOption;
    int directionOptionNumber = 0;

    int count=0;

    public static int strength;

    float timer;
    float speedTimer;
    public float speed = 2;
    Animator animator;

    //bool isLighted1=false;

    public GameObject defeatAnimation;
    public GameObject enemy;
    public GameObject fireball;
    GameObject defeatAnimation1;

    bool isAnimated;

    SpriteRenderer spriteRenderer;


    int enemyx, enemyy;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one * StageGenerator.squareScale * 3;
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0;
        enemyx = -Mathf.RoundToInt(transform.position.x / StageGenerator.squareScale);
        enemyy = -Mathf.RoundToInt(transform.position.y / StageGenerator.squareScale);
        directionOption = new int[4];
        directionOptionNumber = 0;
        speedTimer = 0;
        strength = 1;
        startDirection();
        count = 0;
        isAnimated = false;
        EnemyScript.speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        speedTimer += Time.deltaTime;
        if (speedTimer>=2)
        {
            fireball.transform.localScale = Vector3.one * StageGenerator.squareScale*2;
            Instantiate(fireball, transform.position, Quaternion.identity);
            speedTimer = 0;
            count++;
            if (count >= 4)
            {
                enemy.transform.localScale = Vector3.one * StageGenerator.squareScale;
                Instantiate(enemy, transform.position, Quaternion.identity);
                Instantiate(enemy, transform.position, Quaternion.identity);
                Instantiate(enemy, transform.position, Quaternion.identity);
                PlayerScript.enemyObjectnumber += 3;
                count = 0;

            }

        }
            

        //Debug.Log(enemyx+","+enemyy);
        enemyx = -Mathf.RoundToInt(transform.position.x / StageGenerator.squareScale);
        enemyy = -Mathf.RoundToInt(transform.position.y / StageGenerator.squareScale);
        if (direction == 0)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            //animator.SetFloat("x", 1.0f);
            //animator.SetFloat("y", 0.0f);
        }
        else if (direction == 1)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            //animator.SetFloat("x", -1.0f);
            //animator.SetFloat("y", 0.0f);
        }
        else if (direction == 2)
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            //animator.SetFloat("x", 0.0f);
            //animator.SetFloat("y", 1.0f);
        }
        else if (direction == 3)
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            //animator.SetFloat("x", 0.0f);
            //animator.SetFloat("y", -1.0f);
        }

        if (transform.position.x >= 0 || transform.position.x <= -10 || transform.position.y <= -10 || transform.position.y >= 0)
        {
            Destroy(this.gameObject);
        }
        //var color = spriteRenderer.color;
        //if (color.a<255 && isLighted1==false)
        //{
        //   color.a+= Time.deltaTime * 0.8f;
        //    spriteRenderer.color = color;
        //}

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
        if (StageGenerator.location[enemyy + 2, enemyx] == 1 && direction != 2)
        {
            directionOption[directionOptionNumber] = 3;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy - 2, enemyx] == 1 && direction != 3)
        {
            directionOption[directionOptionNumber] = 2;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx + 2] == 1 && direction != 0)
        {
            directionOption[directionOptionNumber] = 1;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx - 2] == 1 && direction != 1)
        {
            directionOption[directionOptionNumber] = 0;
            directionOptionNumber++;
        }
        if (directionOptionNumber == 0)
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
        int randomNumber = Random.Range(0, directionOptionNumber);
        direction = directionOption[randomNumber];

        animator.SetInteger("direction", direction);





    }

    public void startDirection()
    {

        //Debug.Log("1:"+StageGenerator.location[enemyy , enemyx]);
        if (StageGenerator.location[enemyy + 2, enemyx] == 1)
        {
            directionOption[directionOptionNumber] = 3;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy - 2, enemyx] == 1)
        {
            directionOption[directionOptionNumber] = 2;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx + 2] == 1)
        {
            directionOption[directionOptionNumber] = 1;
            directionOptionNumber++;
        }
        if (StageGenerator.location[enemyy, enemyx - 2] == 1)
        {
            directionOption[directionOptionNumber] = 0;
            directionOptionNumber++;
        }
        int randomNumber = Random.Range(0, directionOptionNumber);
        direction = directionOption[randomNumber];

        //Debug.Log(direction+","+directionOptionNumber);

        animator = this.gameObject.GetComponent<Animator>();
        animator.SetInteger("direction", direction);

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && PlayerScript.isPlaying == true)
        {
            other.SendMessage("damaged");


            //Debug.Log(PlayerScript.enemyObjectnumber);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "light(Clone)")
        {
            var color = spriteRenderer.color;
            color.a -= Time.deltaTime * strength / StageGenerator.len/2;
            spriteRenderer.color = color;
            //if ((Mathf.Abs(enemyx - PlayerScript.px) <= 3 * StageGenerator.squareScale && Mathf.Abs(enemyy - PlayerScript.py) == 0)|| (Mathf.Abs(enemyy - PlayerScript.py) <= 3 * StageGenerator.squareScale && Mathf.Abs(enemyx - PlayerScript.px) == 0) && PlayerScript.isPlaying==true)
            if (color.a <= 0 && isAnimated==false)
            {
                //collision.gameObject.SendMessage("pause",1.0f);
                defeatAnimation1 = Instantiate(defeatAnimation, transform.position, Quaternion.identity) as GameObject;
                defeatAnimation1.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0)*6;
                Invoke("removeAnimation", 0.75f);
                isAnimated = true;
            }
        }
    }


    void removeAnimation()
    {
        Destroy(defeatAnimation1);
        Destroy(this.gameObject);
    }
}
