using UnityEngine;

namespace Pellegrin.Characters
{
    /// <summary>
    /// A simple Input controller for detecting player actions.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class PlayerController : CharacterController
    {
        private const int SPEED_DIVISOR = 10;  //TODO understand this better to rename appropriately

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

        private Rigidbody rb;


        void Start()
        {
            rb = transform.GetComponent<Rigidbody>();
        }
        

        void Update()
        {
        }

        void FixedUpdate()
        {
            HandleMove();
        }

        void HandleMove()
        {
            if (canMove)
            {
                var speed = walkSpeed;

                // detect input movement
                var moveHorizontal = Input.GetAxis("Horizontal");
                var moveVertical = Input.GetAxis("Vertical");
                IsMoving = moveHorizontal != 0 || moveVertical != 0;

                IsRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                if(IsRunning)
                {
                    speed = runSpeed;
                }

                // rotate the character
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                Vector3 rot = movement * (speed / SPEED_DIVISOR);

                if (movement != Vector3.zero)
                {
                    var newRotation = Quaternion.LookRotation(rot);
                    rb.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, 360f);
                }
                

                // move the character
                movement *= (speed / SPEED_DIVISOR);

                var characterMovement = transform.position + movement;
                rb.MovePosition(characterMovement);

            }
        }
    }
}
