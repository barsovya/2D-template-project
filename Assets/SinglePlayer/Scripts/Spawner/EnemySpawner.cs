using System;
using System.Collections;
using System.Collections.Generic;
using SinglePlayer.Scripts.Controllers;
using Unity.Mathematics;
using UnityEngine;
using Utilities;
using Utilities.Bootstrapper;
using Utilities.Interfaces;
using Random = UnityEngine.Random;

namespace SinglePlayer.Scripts.Spawner
{
    /// <summary>
    /// Very conditional spawner, incomplete implementation.
    /// </summary>
    [Serializable]
    public class EnemySpawner : GenericFactory<EnemyController>, IInitializable, IBootstrapComponent
    {
        public bool BootstrapPriority { get; } = false;
        public Action<EnemyController> EnemyWasCreated;

        private const float DelayBetweenCreation = 4f;
        [SerializeField] private List<Transform> SpawnPoints = new List<Transform>();
        [SerializeField] private Transform Parent;
        private Coroutine SpawnCoroutine;

        private void Awake()
        {
            AtStartup.AddToInitializationOrder(this);
        }

        public void Initialization()
        {
            if (SpawnCoroutine != null)
                StopCoroutine(SpawnCoroutine);

            SpawnCoroutine = StartCoroutine(nameof(Spawn));
        }

        private IEnumerator Spawn()
        {
            if (SpawnPoints.Count <= 0)
                throw new NullReferenceException();

            while (true)
            {
                Transform randomPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
                EnemyController enemyController = CreateInstance(randomPoint.position, quaternion.identity, Parent);
                enemyController.Initialization();
                EnemyWasCreated?.Invoke(enemyController);

                yield return new WaitForSeconds(DelayBetweenCreation);
            }
        }
    }
}