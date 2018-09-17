using System;
using UnityEngine;

namespace Pellegrin.Characters
{
    /// <summary>
    /// The character controller used to update an Animator.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class UnitController : MonoBehaviour
    {

        private const int SPEED_DIVISOR = 10;  //TODO understand this better to rename appropriately, originally came from playerController, check if can be eliminated

        /// <summary>
        /// The sprite manager this controller updates.
        /// </summary>
        public Animator modelAnimator;

        /// <summary>
        /// A character's walking speed.
        /// </summary>
        public float walkSpeed = 2f;
        /// <summary>
        /// A character's running speed.
        /// </summary>
        public float runSpeed = 3f;

        /// <summary>
        /// Determines if this character can move.
        /// </summary>
        public bool canMove = true;

        /// <summary>
        /// Gets or sets whether a character is moving in the current frame.
        /// </summary>
        private bool isMoving;
        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
            set
            {
                isMoving = value;
                modelAnimator.SetBool("IsMoving", value);
            }
        }
        /// <summary>
        /// Gets or sets whether a character is running in the current frame.
        /// </summary>
        private bool isRunning;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
                modelAnimator.SetBool("IsRunning", value);
            }
        }

        protected Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


        void FixedUpdate()
        {
            //TODO should this only be inherited, and not used?
        }


        //Override if needing to find a movement direction
        virtual protected Vector3 FindMoveDirection()
        {
            IsMoving = false;
            IsRunning = false;
            return Vector3.zero;
        }

        protected void RotateToFacing(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                var newRotation = Quaternion.LookRotation(direction);
                rb.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, 360f);
            }
        }

        virtual protected float GetSpeed()
        {
            return walkSpeed;
        }

        virtual protected void MoveInDirection(Vector3 direction, float speed)
        {
            var movement = direction * (speed / SPEED_DIVISOR);
            var characterMovement = movement + transform.position;

            rb.MovePosition(characterMovement);
        }


    }
}
