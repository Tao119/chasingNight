using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    GameObject[] enemy;
    int a;
    public GameObject illust;
    public GameObject defeat;
    GameObject defeatAnime;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerScript.enemyObjectnumber;
        enemy = new GameObject[a];
        for (int i = 0; i < a; i++)
        {
            enemy[i] = GameObject.Find("Enemy(Clone)");
            illust.transform.localScale = new Vector3(0.5f, 0.5f, 0) * StageGenerator.squareScale;
            defeat.transform.localScale = new Vector3(StageGenerator.squareScale, StageGenerator.squareScale, 0);
            transform.localScale = new Vector3(1, 1, 0) * StageGenerator.squareScale;
            //Instantiate(illust, enemy[i].transform.position, Quaternion.identity);
            defeatAnime= Instantiate(defeat, enemy[i].transform.position, Quaternion.identity)as GameObject;
            Invoke("removeAnimation", 0.75f);
            PlayerScript.enemyObjectnumber --;
            Debug.Log(PlayerScript.enemyObjectnumber);

        }
        Invoke("destroy", 1.0f);
        for(int i=0; i < a; i++)
        {
            Destroy(enemy[i]);
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
    void removeAnimation()
    {
        Destroy(defeatAnime);
    }
}
