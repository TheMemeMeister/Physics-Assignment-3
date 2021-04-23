using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class pInfo // Player Info, accessible anywhere. Makes things a lot easier without the need of instancing.
{
    [SerializeField] public static int KeysCollected = 0;
    [SerializeField] public static int Lives = 3;
}
public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float SpeedModifier = 1;
 
    public TextMeshProUGUI keyText;
    private Vector3 moveDirection;
    private Vector3 velocity; //keep track of gravity and jumping
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    Vector3 jumpVelocity;
    Vector3 LinearVelocity;
    [SerializeField] public TextMeshProUGUI livesText;
    //turning
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    ////slopes
    //public float heightpadding = 0.05f;
    //public LayerMask ground;
    //public float maxGroundAngle = 120;
    //private float groundangle;
    //Referances
    private CharacterController cont;
    private Animator anim;
    public Transform cam;
    private Rigidbody ninjaRB;
    private void Start()
    {
        cont = GetComponent<CharacterController>();
        ninjaRB = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        pInfo.KeysCollected = 0;
    }
    

    // Update is called once per frame
    private void Update()
    {
        Move();
        keyText.text = "Keys: " + pInfo.KeysCollected.ToString();
        livesText.text = "Lives: " + pInfo.Lives.ToString();
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        float distance = 0.3f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            
        }
    }
    private void Move()
    {
        //isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask); //This needs to be for differant layers, rn all interactables MUST be set to ground. not using second raycasts yet but still bad form

     
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        //moveDirection = transform.TransformDirection(moveDirection);
        Vector3 lateraldirection = new Vector3(horizontal, 0.0f, vertical).normalized;
        //ninjaRB.velocity = new Vector3(horizontal, ninjaRB.velocity.y, vertical); If time, use this to recode player movement
       
        if (isGrounded) //no movement in air
        {

            anim.SetBool("IsJumping", false);
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
            //jumpVelocity = Input.GetKeyDown(KeyCode.Space) ? transform.up * jumpHeight : Vector3.zero;


        }
        //LinearVelocity.y = ninjaRB.velocity.y;
        //ninjaRB.velocity = LinearVelocity + jumpVelocity;

        float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 movDir = Quaternion.Euler(0f, TargetAngle, 0) * Vector3.forward;
        cont.Move(movDir.normalized * Time.deltaTime);
        //cont.Move(moveDirection * Time.deltaTime); //calcullate grav

        //velocity.y += gravity * Time.deltaTime;

        //cont.Move(velocity * Time.deltaTime); //apply grav to player
        ninjaRB.AddForce(movDir.normalized * moveSpeed, ForceMode.Impulse);
    }


    private void Idle()
    {
      
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        moveSpeed = 0 * SpeedModifier;//reset movespeed to stop sliding


    }
    private void Walk()
    {
        Debug.Log("Walk");
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        moveSpeed = walkSpeed * SpeedModifier;
    }
    private void Run()
    {
        Debug.Log("Run");
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        moveSpeed = runSpeed * SpeedModifier;
    }

    private void Jump()
    {
       
        ninjaRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        anim.SetBool("IsJumping", true);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag) //Good code for later
        {
            case "SpeedBoost":
                SpeedModifier = 25f;
                break;
            case "SpeedDown":
                SpeedModifier = 0.5f;
                break;
            case "Ground":
                SpeedModifier = 1;
                jumpHeight = 10;
                break;
            case "JumpPad":
                jumpHeight = 30;
                break;
        }
    }
    

}
