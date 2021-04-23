using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpikeTrap : MonoBehaviour
{
    
    public GameObject spawnPoint;
    public Rigidbody nb; //ninja
    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        nb  = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
     void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.CompareTag("Player"))
            {
                //move player to spawn on collision
            nb.velocity = Vector3.zero;
            player = other.gameObject;
            player.transform.position = spawnPoint.transform.position;
          //  nb.transform.position = spawnPoint.transform.position;
                Debug.Log("Ninja fell out of bounds or hit trapsadasdasdasd");
            
            pInfo.Lives--;
                
                if (pInfo.Lives == 0)
                {
                    SceneManager.LoadScene("LoseScene");
                    Debug.Log("you lose");
                }
            }
        
    }
}
