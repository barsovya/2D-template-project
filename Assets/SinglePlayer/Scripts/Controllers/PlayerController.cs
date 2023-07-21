using System;
using SinglePlayer.Scripts.Movement;
using UnityEngine;
using Utilities.Bootstrapper;
using Utilities.Interfaces;

namespace SinglePlayer.Scripts.Controllers
{
    [Serializable]
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : LinkingBehavior, IBootstrapComponent
    {
        public bool BootstrapPriority { get; private set; } = false;

        private CharacterMovement CharacterMovement;

        private void Awake()
        {
            AtStartup.AddToInitializationOrder(this);
        }

        public override void LinkingNecessaryComponents()
        {
            CharacterMovement = GetComponent<CharacterMovement>();
        }

        public override void Initialization()
        {
            base.Initialization();

            CharacterMovement.Initialization();
        }
    }
}