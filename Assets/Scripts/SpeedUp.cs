using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public Rigidbody ninjabody;
    Vector3 oldVel;
    public float speedUp = 100f;
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
        Debug.Log("Collision with Speed Trap");
        if (other.gameObject.CompareTag("Player"))
        {
            ninjabody.velocity *= speedUp;


        }
    }
}