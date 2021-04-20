using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public Rigidbody ninjabody;
    Vector3 oldVel;
    void Start()
    {
        ninjabody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oldVel = ninjabody.velocity;

    }

    void OnTriggerEnter(Collision other) 
    {
        Debug.Log("Collision with Speed Trap");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Speed Zone");


            ContactPoint cp = other.contacts[0];
            // similar to my bumper effect, creates a sliding feel
            ninjabody.velocity += cp.normal * 2000;


        }
    }
}