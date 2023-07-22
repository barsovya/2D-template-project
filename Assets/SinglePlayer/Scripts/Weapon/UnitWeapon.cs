using System;
using SinglePlayer.Scripts.Weapon.Interfaces;
using Utilities.Interfaces;

namespace SinglePlayer.Scripts.Weapon
{
    [Serializable]
    public abstract class UnitWeapon : LinkingBehavior, IAttacker
    {
        public bool CanAttack { get; private protected set; } = true;
        public Action TookAttack;

        public override void LinkingNecessaryComponents()
        {
        }

        public virtual void TryToAttack()
        {
            if (CanAttack)
            {
                Attack();
            }
        }

        private protected virtual void Attack()
        {
            TookAttack?.Invoke();
        }
    }
}