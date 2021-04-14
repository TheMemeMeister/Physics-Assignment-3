using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");

        if (forwardPressed || leftPressed || rightPressed || backPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if (runPressed && forwardPressed || runPressed && leftPressed || runPressed && rightPressed || runPressed && backPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if (jumpPressed && forwardPressed || jumpPressed && leftPressed || jumpPressed && rightPressed || jumpPressed && backPressed)
        {
            animator.SetBool("isJumping", true);
        }
        if (!runPressed)
        {
            animator.SetBool("isRunning", false);
        }
        if (!jumpPressed)
        {
            animator.SetBool("isJumping", false);
        }
        if (!forwardPressed && !leftPressed && !rightPressed && !backPressed)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }
}
