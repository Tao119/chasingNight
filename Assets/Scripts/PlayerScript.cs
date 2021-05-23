using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public float speed = 2.0f;
    public static int direction=3;

    float timer;
    float interval = 0.0002f;

    public GameObject lightPart;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    
}
    private void FixedUpdate()
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
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Vector3 v = new Vector3(Mathf.RoundToInt(this.gameObject.transform.position.x / StageGenerator.squareScale), Mathf.RoundToInt(this.gameObject.transform.position.y / StageGenerator.squareScale), Mathf.RoundToInt(this.gameObject.transform.position.z / StageGenerator.squareScale));
            Vector3 correctedPosition = v * StageGenerator.squareScale;
            if(direction>=2)
            {
                timer = 0;
                Instantiate(lightPart,correctedPosition , Quaternion.identity);
                lightPart.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale / 10, 0);
            }
            else
            {
                timer = 0;
                Instantiate(lightPart, correctedPosition, Quaternion.identity);
                lightPart.transform.localScale = new Vector3(StageGenerator.squareScale / 10, StageGenerator.squareScale, 0);
            }
        }
    }

}
