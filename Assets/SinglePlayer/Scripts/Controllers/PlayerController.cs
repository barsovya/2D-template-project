using System;
using SinglePlayer.Scripts.Movement;
using UnityEngine;

namespace SinglePlayer.Scripts.Controllers
{
    [Serializable]
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : UnitController
    {
        private CharacterMovement CharacterMovement;

        public override void LinkingNecessaryComponents()
        {
            base.LinkingNecessaryComponents();

            CharacterMovement = GetComponent<CharacterMovement>();
        }

        public override void Initialization()
        {
            base.Initialization();

            CharacterMovement.Initialization();
        }
    }
}