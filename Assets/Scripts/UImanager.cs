using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
    public Text HPText;
    public Text damagedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = "HP : " + PlayerScript.playerHP;
    }
    public void damaged()
    {
        damagedText.gameObject.SetActive(true);
        Invoke("nonActive",0.3f);
    }
    void nonActive()
    {
        damagedText.gameObject.SetActive(false);
    }
}
