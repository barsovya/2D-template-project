using System;
using UnityEngine;
using Utilities.Interfaces;

namespace Utilities.Containers
{
    [RequireComponent(typeof(GameObject))]
    [Serializable]
    public class GameObjectLinkingContainer : LinkingBehavior
    {
        private GameObject Target;

        public override void LinkingNecessaryComponents()
        {
            if (Target == null)
                Target = GetComponentInChildren<Transform>().gameObject;
        }

        public override void Initialization()
        {
            base.Initialization();
        }

        public void SetActive(bool value)
        {
            if (Target.activeSelf != value)
            {
                Target.SetActive(value);
            }
        }
    }
}