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
    private void OnCollisionEnter(Collision other)
    {
      
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Approached Door");
            Doorcan.SetActive(true);
            if(pInfo.KeysCollected == KeysRequired)
            {
                pInfo.KeysCollected = 0; //taking keys away from the player
                //open the door, update the key num
            }
        }
      
    }

    

}
