using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivateScript : MonoBehaviour
{
    public static float timer;
    SpriteRenderer spriteRenderer;
    Color color;

    public Text startText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<=4.0f) {
            color.a = timer/4.0f;
            spriteRenderer.color = color;
        }
        if (4.0f<=timer&&timer<=8.0f)
        {
            transform.localScale = Vector3.one*(14.0f - timer) / 10.0f;
            transform.position += new Vector3(-3.6f,-2,0)/4.0f*Time.deltaTime;
        }
        if (timer >= 8.5f)
        {
            if (startText.gameObject.activeSelf == false)
            {
                startText.gameObject.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Invoke("loadNextScene",1.0f);
            }
        }
        timer += Time.deltaTime;
    }
    void loadNextScene()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
