using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniThunderScript : MonoBehaviour
{
    GameObject[] enemies;
    int a;
    public GameObject illust;
    // Start is called before the first frame update
    void Start()
    {
        var __color = this.gameObject.GetComponent<SpriteRenderer>().color;
        __color.a = 0;
        this.gameObject.GetComponent<SpriteRenderer>().color = __color;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            illust.transform.localScale = new Vector3(1, 1, 0) * StageGenerator.squareScale;
            Instantiate(illust, enemy.transform.position, Quaternion.identity,enemy.transform);
            Color _color = enemy.GetComponent<SpriteRenderer>().color;
            _color.a *= 0.2f;
            enemy.GetComponent<SpriteRenderer>().color = _color;
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