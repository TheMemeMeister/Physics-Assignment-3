using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public float speed = 5;

    private Rigidbody ninjaRB;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float jumpForce = 10f;
    public LayerMask groundLayers;
    public CapsuleCollider col;
    void Start()
    {
        ninjaRB = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, ninjaRB.velocity.y, vertical).normalized;
        Vector3 lateraldirection = new Vector3(horizontal, 0.0f, vertical).normalized;
        //Vector3 movement = new Vector3(horizontal, 0, vertical);
        //ninjaRB.AddForce(movement * speed);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            ninjaRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (lateraldirection.magnitude >= 0.1)
        {
            //in unity we move on x and z axis
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, TargetAngle, 0) * Vector3.forward;
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }
    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
