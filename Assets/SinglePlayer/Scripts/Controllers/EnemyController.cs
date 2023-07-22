using System;
using SinglePlayer.Scripts.Movement;
using SinglePlayer.Scripts.Weapon;
using UnityEngine;

namespace SinglePlayer.Scripts.Controllers
{
    [Serializable]
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(ThrowWeapon))]
    public class EnemyController : UnitController
    {
        private EnemyMovement EnemyMovement;
        public ThrowWeapon ThrowWeapon { get; private set; }

        public override void LinkingNecessaryComponents()
        {
            base.LinkingNecessaryComponents();

            EnemyMovement = GetComponent<EnemyMovement>();
            ThrowWeapon = GetComponent<ThrowWeapon>();
        }

        public override void Initialization()
        {
            base.Initialization();

            EnemyMovement.Initialization();
            ThrowWeapon.Initialization();
        }
    }
}