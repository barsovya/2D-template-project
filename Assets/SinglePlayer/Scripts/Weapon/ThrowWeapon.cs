using System;
using SinglePlayer.Scripts.Damage;
using UnityEngine;

namespace SinglePlayer.Scripts.Weapon
{
    [Serializable]
    public class ThrowWeapon : UnitWeapon
    {
        private protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Wall wall))
            {
                TryToAttack();
                Destroy(gameObject);
            }
        }
    }
}