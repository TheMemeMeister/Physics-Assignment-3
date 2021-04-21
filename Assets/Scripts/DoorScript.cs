using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Doorcan;
    public int KeysRequired;
    private void Start()
    {
       
        Doorcan.SetActive(false);
        KeysRequired = 2;
    }
    private void OnTriggerStay(Collider other)
    {
      
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Approached Door");
            Doorcan.SetActive(true);
            if(pInfo.KeysCollected == KeysRequired)
            {
                if (Input.GetKeyDown(KeyCode.E)) //refactor this if it works
                    {
                    Debug.Log("E pressed");
                    pInfo.KeysCollected = 0; //taking keys away from the player
                }
               
            }
            
        }
      
    }

    

}
