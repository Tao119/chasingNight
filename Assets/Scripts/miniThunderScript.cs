using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniThunderScript : MonoBehaviour
{
    GameObject[] enemy;
    int a;
    public GameObject illust;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerScript.enemyObjectnumber;
        enemy = new GameObject[a];
        for (int i = 0; i < a; i++)
        {
            enemy[i] = GameObject.Find("Enemy(Clone)");
            transform.localScale = new Vector3(1, 1, 0) * StageGenerator.squareScale;
            Instantiate(illust, enemy[i].transform.position, Quaternion.identity,enemy[i].transform);
            Color _color = enemy[i].GetComponent<SpriteRenderer>().color;
            _color.a *= 0.2f;
            enemy[i].GetComponent<SpriteRenderer>().color = _color;
        }
        Invoke("destroy",1.0f);
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