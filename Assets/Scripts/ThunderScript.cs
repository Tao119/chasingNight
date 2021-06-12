using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    GameObject[] enemies;
    public GameObject illust;
    public GameObject defeat;
    GameObject[] defeatAnime;
    // Start is called before the first frame update
    void Start()
    {
        var _color=this.gameObject.GetComponent<SpriteRenderer>().color;
        _color.a = 0;
        this.gameObject.GetComponent<SpriteRenderer>().color=_color;

        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            illust.transform.localScale = new Vector3(0.5f, 0.5f, 0) * StageGenerator.squareScale;
            defeat.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0);
            Instantiate(illust, enemy.transform.position, Quaternion.identity);
            Instantiate(defeat, enemy.transform.position, Quaternion.identity);
            Invoke("removeAnimation", 0.75f);
            Destroy(enemy);
            PlayerScript.enemyObjectnumber--;

            //Color _color = enemy.GetComponent<SpriteRenderer>().color;
            //_color.a = 0;
            //enemy.GetComponent<SpriteRenderer>().color = _color;

        }
        Invoke("destroy", 1.0f);
        defeatAnime = GameObject.FindGameObjectsWithTag("defeat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void destroy()
    {
        Destroy(this.gameObject);
        
    }
    void removeAnimation()
    {
        foreach (GameObject anime in defeatAnime)
        {
            Destroy(anime);
        }
    }
}
