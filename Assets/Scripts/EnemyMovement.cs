using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    [SerializeField] List<Transform> patrolPoints;
    private float leftMostX;
    private float rightMostX;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        FindLeftRightPoints();
    }

    void Update()
    {
        WalkToPatrolPoints();
    }

    void WalkToPatrolPoints()
    {
        if (patrolPoints.Count == 0) {return;}

        myRigidBody.velocity = new Vector2 (moveSpeed,0f);
        myAnimator.SetBool("IsWalking",true);


        if (myRigidBody.position.x >= rightMostX)
        {
            moveSpeed = -Mathf.Abs(moveSpeed);
            FlipEnemyFacing();
        }else if (myRigidBody.position.x < leftMostX)
        {
            moveSpeed = Mathf.Abs(moveSpeed);
            FlipEnemyFacing();
        }

    }

    private void FindLeftRightPoints()
    {
        if (patrolPoints.Count == 0) {return;}
        rightMostX = patrolPoints.Max(p => p.position.x);
        leftMostX = patrolPoints.Min(p => p.position.x);
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
