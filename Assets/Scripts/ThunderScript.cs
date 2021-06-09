using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    GameObject[] enemy;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerScript.enemyObjectnumber;
        enemy = new GameObject[a];
        for (int i = 0; i < a; i++)
        {
            enemy[i] = GameObject.Find("Enemy(Clone)");
            transform.localScale = new Vector3(1, 1, 0) * StageGenerator.squareScale;
            Instantiate(this.gameObject, enemy[i].transform.position, Quaternion.identity);
            Color _color = enemy[i].GetComponent<SpriteRenderer>().color;
            _color.a = 0;
            enemy[i].GetComponent<SpriteRenderer>().color=_color;
            Invoke("destroy", 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void destroy()
    {
        Destroy(this.gameObject);
        
    }
}
