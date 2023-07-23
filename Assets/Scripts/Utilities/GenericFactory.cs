using System;
using UnityEngine;
using Utilities.Interfaces;

namespace Utilities
{
    [Serializable]
    public abstract class GenericFactory<T> : MonoBehaviour where T : Component, IInitializable
    {
        [SerializeField] private protected T Prefab;

        public T CreateInstance(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return Instantiate(Prefab, position, rotation, parent);
        }
    }
}