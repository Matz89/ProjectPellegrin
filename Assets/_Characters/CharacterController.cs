using UnityEngine;

namespace Pellegrin.Characters
{
    /// <summary>
    /// The character controller used to update an Animator.
    /// </summary>
    public class CharacterController : MonoBehaviour
    {
        /// <summary>
        /// The sprite manager this controller updates.
        /// </summary>
        public Animator modelAnimator;

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
    }
}
