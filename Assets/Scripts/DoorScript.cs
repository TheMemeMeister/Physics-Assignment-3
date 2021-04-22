using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
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


    public GameObject Doorcan;
    public int KeysRequired;
    private void Start()
    {
       
        Doorcan.SetActive(false);
        KeysRequired = 2;

        Hj = GetComponent<HingeJoint>();
        Hj.useSpring = true;
        JS = new JointSpring();
        JS.spring = hitForce;
        JS.damper = flipperFriction;
        Hj.spring = JS;
    }
    private void OnTriggerStay(Collider other)
    {
      
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Approached Door");
            Doorcan.SetActive(true);
            if(pInfo.KeysCollected == KeysRequired)
            {
                if (Input.GetKeyDown(KeyCode.E)) //refactor this if it works
                    {
                    Debug.Log("E pressed");
                    pInfo.KeysCollected = 0; //taking keys away from the player
                    interact();
                }
               
            }
            
        }
      
    }

    public void interact()
    {
        JS.targetPosition = pressedPosition;
        Hj.spring = JS;
    }

}
