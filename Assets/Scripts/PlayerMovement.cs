using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity; //keep track of gravity and jumping
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //Referances
    private CharacterController cont;
    private Animator anim;
    public Transform cam;
    private void Start()
    {
        cont = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

       if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //grounded -> start applying gravity
            anim.SetBool("IsJumping", false);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        //moveDirection = transform.TransformDirection(moveDirection);
        Vector3 lateraldirection = new Vector3(horizontal, 0.0f, vertical).normalized;
        if (isGrounded) //no movement in air
        {
            

            if (direction != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (direction != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (direction == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 movDir = Quaternion.Euler(0f, TargetAngle, 0) * Vector3.forward;
        cont.Move(movDir.normalized * Time.deltaTime);
        //cont.Move(moveDirection * Time.deltaTime); //calcullate grav

        velocity.y += gravity * Time.deltaTime;

        cont.Move(velocity * Time.deltaTime); //apply grav to player
    }


    private void Idle()
    {
      
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        moveSpeed = 0;//reset movespeed to stop sliding

    }
    private void Walk()
    {
        Debug.Log("Walk");
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        moveSpeed = walkSpeed;
    }
    private void Run()
    {
        Debug.Log("Run");
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetBool("IsJumping", true);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "SpeedBoost":
                moveSpeed = 25f;
                break;
            case "SpeedDown":
                moveSpeed = 2;
                break;
        }
    }
    

}
