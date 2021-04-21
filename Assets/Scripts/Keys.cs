using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            pInfo.KeysCollected++;
            Debug.Log("collected key");
            Destroy(gameObject);
        }

    }
   
}

