using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;

    [SerializeField] Vector2 hurtKick = new Vector2 (1f,1f);

    Vector2 moveInput;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    Health myHealth;

    bool isAlive = true;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myHealth = GetComponent<Health>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        Jump();
        FlipSprite();
        TakeDamage();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            var otherX = collision.transform.position.x;
            var selfX = myRigidBody.transform.position.x;
            var kickDirection = Mathf.Sign(selfX - otherX);
            hurtKick = new Vector2(kickDirection * hurtKick.x, hurtKick.y );
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

    void TakeDamage()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            myRigidBody.velocity += hurtKick;
            myHealth.ApplyDamage(1);
            if (myHealth.GetHealth() <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isAlive = false;
        myAnimator.SetTrigger("IsDying");
    }
}
