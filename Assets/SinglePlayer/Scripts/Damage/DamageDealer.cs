using System;
using SinglePlayer.Scripts.Damage.Interfaces;
using Utilities.Interfaces;

namespace SinglePlayer.Scripts.Damage
{
    /// <summary>
    /// Simplified implementation.
    /// </summary>
    [Serializable]
    public class DamageDealer : IDamageable, IInitializable
    {
        public Action<int> DamageHasReceived;

        public DamageDealer()
        {
            Initialization();
        }

        public void TakeDamage(int damage)
        {
            DamageHasReceived?.Invoke(damage);
        }

        public void Initialization()
        {
        }
    }
}