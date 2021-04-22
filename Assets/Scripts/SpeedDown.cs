using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{
    public Rigidbody ninjabody;
    Vector3 oldVel;
    public float speedDown = 2;
    void Start()
    {
        ninjabody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oldVel = ninjabody.velocity;

    }

    void OnTriggerStay(Collider other) 
    {
        Debug.Log("Collision with Pointy Boi");
        if (other.gameObject.CompareTag("Player"))
        {

            ninjabody.velocity /= speedDown;


        }
    }
}