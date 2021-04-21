using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
  
     private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
           
            DestroyKey();
        }

    }
    void DestroyKey()
    {


        pInfo.KeysCollected++;
        Debug.Log("collected key");
        Destroy(gameObject);
    }
}

