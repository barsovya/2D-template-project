using System;
using UnityEngine;
using Utilities.Interfaces;

namespace Utilities.Containers
{
    /// <summary>
    /// Contract with all native Unity objects.
    /// </summary>
    [Serializable]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rigidbody2DLinkingContainer : LinkingBehavior
    {
        private Rigidbody2D Target;

        public override void LinkingNecessaryComponents()
        {
            Target = GetComponent<Rigidbody2D>();
        }

        public override void Initialization()
        {
            base.Initialization();
        }

        public void SetVelocity(Vector2 velocity)
        {
            Target.velocity = velocity;
        }
    }
}