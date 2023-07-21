using System;
using UnityEngine;
using Utilities.Containers;
using Utilities.Interfaces;

namespace SinglePlayer.Scripts.Movement
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody2DLinkingContainer))]
    public abstract class MovementBehaviour : LinkingBehavior
    {
        private Rigidbody2DLinkingContainer PhysicalRigidbody;
        public bool CanMove { get; private protected set; } = true;

        public override void LinkingNecessaryComponents()
        {
            PhysicalRigidbody = GetComponent<Rigidbody2DLinkingContainer>();
        }

        public override void Initialization()
        {
            base.Initialization();

            PhysicalRigidbody.Initialization();
        }

        public virtual void Move(Vector2 velocity)
        {
            if (!CanMove) return;
            PhysicalRigidbody.SetVelocity(velocity);
        }
    }
}