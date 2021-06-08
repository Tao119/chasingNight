using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTextManager : MonoBehaviour
{
    float alpha_Sin;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        alpha_Sin = Mathf.Sin(2*Time.time) / 2 + 0.5f;
        Color _color = text .color;

        _color.a = alpha_Sin;

         text.color = _color;
    }
    
}
