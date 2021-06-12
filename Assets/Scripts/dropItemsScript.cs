using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItemsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            switch (this.gameObject.name)
            {
                case "thunder(Clone)":
                    ItemController.itemStock[0]++;
                    break;
                case "miniThunder(Clone)":

                    ItemController.itemStock[1]++;
                    break;
                case "shield(Clone)":

                    ItemController.itemStock[3]++;
                    break;
                case "buff(Clone)":

                    ItemController.itemStock[2]++;
                    break;

            }
            Destroy(this.gameObject);
            ItemGenerator.isExisting = false;
        }
    }
}
