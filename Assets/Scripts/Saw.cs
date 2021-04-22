using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Saw : MonoBehaviour
{
    public float Speed;
    public float AngularSpeed;
    public GameObject NinjaSpawn;
    protected Rigidbody r; //this trap
    public Rigidbody nb; //ninja

  
    void Start()
    {
        r = GetComponent<Rigidbody>();
        nb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = r.velocity.magnitude;
        AngularSpeed = r.angularVelocity.magnitude;


        r.maxAngularVelocity = float.MaxValue;

       
        r.AddTorque(Vector3.right);
       
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //resets position of the ball when ball falls out of the play area 
            nb.velocity = Vector3.zero;
            nb.transform.position = NinjaSpawn.transform.position;
            Debug.Log("Ninja fell out of bounds or hit trap");
            pInfo.Lives--;
            if (pInfo.Lives-- == 0)
            {
                SceneManager.LoadScene("Lose Scene");
                Debug.Log("you lose");
            }
        }
    }
}
