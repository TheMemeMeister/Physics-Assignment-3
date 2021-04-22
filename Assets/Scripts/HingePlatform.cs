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

    public float springConstant = 0;
    public float resetposition = 0f;
    public float pressedPosition = 45f; //Use gameobjects intead?

    HingeJoint Hj = null;
    JointSpring JS;
    
    // Start is called before the first frame update
    void Start()
    {
        Hj = GetComponent<HingeJoint>();
        Hj.useSpring = true;
         JS = new JointSpring();
        JS.spring = hitForce;
        JS.damper = flipperFriction;
        Hj.spring = JS;
    }
    

      void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Activated Hinge Trap");
            JS.targetPosition = pressedPosition;
            Hj.spring = JS;
        }
      
    }
}

