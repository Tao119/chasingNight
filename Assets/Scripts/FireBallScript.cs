using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    int ballDirection;
    // Start is called before the first frame update
    void Start()
    {
        ballDirection = BossScript.direction;
    }

    // Update is called once per frame
    void Update()
    {
        switch (ballDirection)
        {
            case 0:
                transform.position += new Vector3(4, 0, 0) * Time.deltaTime;
                break;
            case 1:
                transform.position -= new Vector3(4, 0, 0) * Time.deltaTime;
                break;
            case 2:
                transform.position += new Vector3(0, 4, 0) * Time.deltaTime;
                break;
            case 3:
                transform.position -= new Vector3(0, 4, 0) * Time.deltaTime;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("damaged");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
