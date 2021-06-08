using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStageScript : MonoBehaviour
{
    string stageName;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        stageName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && player.transform.position==transform.position)
        {
            Debug.Log(stageName);
            SceneManager.LoadScene(stageName);
        }
    }
}
