using System;
using SinglePlayer.Scripts.Damage;
using UnityEngine;
using Utilities.Interfaces;

namespace SinglePlayer.Scripts.Controllers
{
    [Serializable]
    public abstract class UnitController : LinkingBehavior
    {
        public Action<int> LivesChanged;

        [SerializeField] private int lives = 1;

        public int Lives
        {
            get { return lives; }
            set
            {
                lives = value;
                LivesChanged.Invoke(value);
            }
        }

        private DamageDealer DamageDealer = new DamageDealer();

        public override void LinkingNecessaryComponents()
        {
        }

        public override void Initialization()
        {
            base.Initialization();

            DamageDealer.Initialization();
        }
    }
}