using System;
using UnityEngine;

namespace SinglePlayer.Scripts.Movement
{
    [Serializable]
    public class CharacterMovement : MovementBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        [SerializeField] private float Speed = 30f;

        private protected void FixedUpdate()
        {
            MoveRelativeToInput();
        }

        /// <summary>
        /// The input description should definitely be implemented in a separate module,
        /// but an example it is integrated into the controller.
        /// Integration should include subscribing to the events of the main input module.
        /// </summary>
        private void MoveRelativeToInput()
        {
            Move((Input.GetAxisRaw(HorizontalAxis) * transform.right + Input.GetAxisRaw(VerticalAxis) * transform.up) *
                 Speed);
        }
    }
}





