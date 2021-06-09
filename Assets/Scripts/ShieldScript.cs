using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript.isProtected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.isProtected==false)
        {
            Destroy(this.gameObject);
        }
    }
}
