using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;

    Vector2 moveInput;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    bool isAlive = true;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        Jump();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            myRigidBody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool isMovingX = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        bool isRunningOnGround = isMovingX && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        myAnimator.SetBool("IsRunning",isRunningOnGround);
        
    }

    void Jump()
    {
        bool isAirborne = !myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        bool isMovingUp = myRigidBody.velocity.y > Mathf.Epsilon && isAirborne;
        bool isMovingDown = myRigidBody.velocity.y < Mathf.Epsilon && isAirborne;
        
        myAnimator.SetBool("IsJumpingUp",isMovingUp);
        myAnimator.SetBool("IsJumpingDown",isMovingDown);
        
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
        
    }
}
