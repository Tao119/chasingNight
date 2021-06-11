using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    GameObject player;


    GameObject displayedItem;


    public GameObject[] itemSlot;
    public GameObject[] illustSlot;
    int[] itemStock;
    int slotNumber;
    public Text stockText;

    // Start is called before the first frame update
    void Start()
    {
        slotNumber = 0;
        player = GameObject.Find("Player(Clone)");
        itemStock = new int[] {1,1,2,2};
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (slotNumber != 0)
            {
                slotNumber--;
            }
            else
            {
                slotNumber = itemSlot.Length-1;
            }
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if (slotNumber != itemSlot.Length-1)
            {
                slotNumber++;
            }
            else
            {
                slotNumber = 0;
            }
        }
        for(int i = 0; i < itemSlot.Length; i++)
        {
            if (i == slotNumber)
            {
                illustSlot[i].gameObject.SetActive(true);
            }
            else
            {
                illustSlot[i].gameObject.SetActive(false);
            }
        }


        if(itemStock[slotNumber]>0 && Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(itemSlot[slotNumber], player.transform.position, Quaternion.identity,player.transform);
            itemStock[slotNumber]--;
        }
        stockText.text = itemStock[slotNumber].ToString();
    }
}
