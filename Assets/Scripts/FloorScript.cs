using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public int floorx, floory;
    // Start is called before the first frame update
    void Start()
    {
        floorx = -Mathf.RoundToInt(transform.position.x / StageGenerator.squareScale);
        floory = -Mathf.RoundToInt(transform.position.y / StageGenerator.squareScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name=="light1(Clone)" )
        {
            EnemyGenerator.isLighted[floory,floorx] = true;
            //Debug.Log(floorx+","+floory);
            Destroy(this.gameObject);
        }
        
    }
}
