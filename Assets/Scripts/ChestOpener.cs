using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GameObject ChestClosed, ChestOpened;
    // Start is called before the first frame update
    void Start()
    {
        ChestClosed.SetActive(true);
        ChestOpened.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerInventory != null)
        {
            if(playerInventory.keyCount > 0)
            {
                ChestClosed.SetActive(false);
                ChestOpened.SetActive(true);
                playerInventory.keyCount -= 1;
            }
        }
    }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     ChestClosed.SetActive(true);
    //     ChestOpened.SetActive(false);
    // }
}
