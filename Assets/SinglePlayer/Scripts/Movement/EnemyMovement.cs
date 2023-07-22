using System;
using UnityEngine;

namespace SinglePlayer.Scripts.Movement
{
    [Serializable]
    public class EnemyMovement : MovementBehaviour
    {
        private protected void FixedUpdate()
        {
            LinearMovement();
        }

        private void LinearMovement()
        {
            Move(Vector2.down);
        }
    }
}