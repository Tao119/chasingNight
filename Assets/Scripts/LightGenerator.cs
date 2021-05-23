using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGenerator : MonoBehaviour
{
    int a;
    public GameObject player;
    Rigidbody2D playerbody;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerScript.direction;
        playerbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 0)
        {
            transform.position += new Vector3(10*Time.deltaTime + playerbody.velocity.x, 0, 0);
        }
        else if (a == 1)
        {
            transform.position += new Vector3(-10*Time.deltaTime + playerbody.velocity.x, 0, 0);
        }
        else if (a == 2)
        {
            transform.position += new Vector3(0, 10*Time.deltaTime + playerbody.velocity.y, 0);
        }
        else if (a == 3)
        {
            transform.position += new Vector3(0, -10*Time.deltaTime + playerbody.velocity.y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="wall")
        {
            Destroy(this.gameObject);
        }
    }
}
