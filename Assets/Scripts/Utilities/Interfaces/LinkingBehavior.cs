using System;
using UnityEngine;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Implements a single initialization procedure.
    /// </summary>
    [Serializable]
    public abstract class LinkingBehavior : MonoBehaviour, IInitializable, ILinkingComponents
    {
        private protected bool IsInitialized = false;

        public abstract void LinkingNecessaryComponents();

        public virtual void Initialization()
        {
            if (IsInitialized) return;

            LinkingNecessaryComponents();
            IsInitialized = true;
        }
    }
}