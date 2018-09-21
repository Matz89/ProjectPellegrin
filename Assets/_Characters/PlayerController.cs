using System;
using UnityEngine;
using Pellegrin.Characters;

/// <summary>
/// A simple Input controller for detecting player actions.
/// </summary>
 
public class PlayerController : UnitController
{
        

    void Start()
    {
        //TODO check if were okay with doing this, try not to inherrit this class?
        //base.Start();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        //Check move direction
        Vector3 moveDirection = FindMoveDirection();

        //rotate to move direction
        RotateToFacing(moveDirection);

        //get rate speed
        float speed = GetSpeed();

        //Move in direction at speed
        MoveInDirection(moveDirection, speed);
    }

    protected override Vector3 FindMoveDirection()
    {
        var moveHorizontal = 0f;
        var moveVertical = 0f;

        if (canMove) //TODO decide if required for class?  should we check super is unit can move?
        {
            // detect input movement
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            IsMoving = moveHorizontal != 0 || moveVertical != 0;

        }

        return new Vector3(moveHorizontal, 0, moveVertical);
    }

    protected override float GetSpeed()
    {

        //check if Running
        IsRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if(IsRunning)
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

}
