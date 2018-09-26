using System;
using UnityEngine;

namespace Pellegrin.Characters
{
    /// <summary>
    /// The character controller used to update an Animator.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))] //TODO refactor out to not need this
    [RequireComponent(typeof(Collider))] //TODO refactor out to not ned this
    public class UnitController : MonoBehaviour
    {

        private const int SPEED_DIVISOR = 10;  //TODO understand this better to rename appropriately, originally came from playerController, check if can be eliminated
        private const float COOLDOWN_DONE = 0f;

        /// <summary>
        /// The sprite manager this controller updates.
        /// </summary>
        public Animator modelAnimator;

        /// <summary>
        /// A character's walking speed.
        /// </summary>
        [SerializeField] float baseWalkSpeed = 2f;
        public float BaseWalkSpeed
        {
            get
            {
                return baseWalkSpeed;
            }
        }
        /// <summary>
        /// A character's running speed.
        /// </summary>
        [SerializeField] float baseRunSpeed = 3f;
        public float BaseRunSpeed
        {
            get
            {
                return baseRunSpeed;
            }
        }

        [SerializeField] WeaponConfig currentWeapon;
        public WeaponConfig MyCurrentWeapon
        {
            get
            {
                //Check/update for new weapon 
                currentWeapon = GetComponent<CanEquipWeapon>().EquippedWeapon;
                //TODO do I need to check for a weapon every time its used? will it ever change in mid-battle?
                return currentWeapon;
            }
        }

        /// <summary>
        /// Determines if this character can move.
        /// </summary>
        [SerializeField] bool canMove = true;
        public bool CanMove
        {
            get
            {
                return canMove;
            }
            set
            {
                canMove = value;
            }
        }

        [SerializeField] bool canAttack = true;
        public bool CanAttack
        {
            get
            {
                return canAttack;
            }
        }

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

        private bool attackStarted;
        public bool AttackStarted
        {
            get
            {
                return attackStarted;
            }
            set
            {
                attackStarted = value;
                modelAnimator.SetBool("AttackStarted", value);
            }
        }

        protected Rigidbody rb;

        protected float timeSinceLastWeaponAttack = 1.0f;

        void Start()
        {
            rb = GetComponent<Rigidbody>(); 
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
            return baseWalkSpeed;
        }

        virtual protected void MoveInDirection(Vector3 direction, float speed)
        {
            var movement = direction * (speed / SPEED_DIVISOR);
            var characterMovement = movement + transform.position;

            rb.MovePosition(characterMovement);
        }

        protected void AttackWithWeapon()
        {
            

            if (timeSinceLastWeaponAttack <= COOLDOWN_DONE)
            {
                timeSinceLastWeaponAttack = MyCurrentWeapon.GetTimeBetweenAttacks();
            }
            else
            {
                AttackStarted = false;
            }
        }

        protected void UpdateWeaponAttackTimer()
        {
            timeSinceLastWeaponAttack -= Time.deltaTime;

        }

        


    }
}
