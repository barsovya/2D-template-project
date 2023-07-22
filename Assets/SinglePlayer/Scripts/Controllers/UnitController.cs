using System;
using SinglePlayer.Scripts.Damage;
using UnityEngine;
using Utilities.Bootstrapper;
using Utilities.Interfaces;

namespace SinglePlayer.Scripts.Controllers
{
    [Serializable]
    public abstract class UnitController : LinkingBehavior, IBootstrapComponent
    {
        public bool BootstrapPriority { get; private set; } = false;

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

        private protected virtual void Awake()
        {
            AtStartup.AddToInitializationOrder(this);
        }

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