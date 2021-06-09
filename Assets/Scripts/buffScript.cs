using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyScript.strength = 3;
        Invoke("endBuff",3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void endBuff()
    {
        EnemyScript.strength = 1;
        Destroy(this.gameObject);
    }
}
