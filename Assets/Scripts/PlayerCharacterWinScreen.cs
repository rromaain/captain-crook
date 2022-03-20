using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterWinScreen : MonoBehaviour
{
    public GameObject ChestOpened;

    [SerializeField] private Transform winScreenRoot = null;
    
    void Update(){
        if (ChestOpened.activeInHierarchy == true && ChestOpened.activeSelf == true)
        {
            this.winScreenRoot.gameObject.SetActive(true);
        }else{
             this.winScreenRoot.gameObject.SetActive(false);
        }
    }
}
