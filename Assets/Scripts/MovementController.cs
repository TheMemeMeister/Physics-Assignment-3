using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public float speed = 6;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            //in unity we move on x and z axis
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, TargetAngle, 0) * Vector3.forward;
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }
    }
}
