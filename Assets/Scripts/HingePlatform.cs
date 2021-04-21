using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HingePlatform : MonoBehaviour
{

    [SerializeField, Range(1, 100000), Tooltip("How many Newtons Used")]
    public float hitForce = 1000f;
    [SerializeField, Range(1, 1000), Tooltip("Friction on Hinge Plat")]
    public float flipperFriction = 150;

    public float resetposition = 0f;
    public float pressedPosition = 45f; //Use gameobjects intead?

    HingeJoint Hj;
    // Start is called before the first frame update
    void Start()
    {
        Hj = GetComponent<HingeJoint>();
        //Hj.useSpring = true;
    }


     void OnTriggerEnter(Collider other)
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitForce;
        spring.damper = flipperFriction;
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Activated Hinge Trap");
            spring.targetPosition = pressedPosition;
        }
        Hj.spring = spring;
        Hj.useLimits = true;  //might want to clamp this instead
    }
}
