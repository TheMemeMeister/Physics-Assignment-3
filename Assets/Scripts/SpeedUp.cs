using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public Rigidbody ninjabody;
    Vector3 oldVel;
    public float speedDown = 2f;
    void Start()
    {
        ninjabody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oldVel = ninjabody.velocity;

    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Collision with Speed Trap");
        if (other.gameObject.CompareTag("Player"))
        {
            ninjabody.velocity /= speedDown;


        }
    }
}