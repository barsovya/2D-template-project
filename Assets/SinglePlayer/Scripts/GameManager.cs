using System;
using System.Collections.Generic;
using SinglePlayer.Scripts.Controllers;
using SinglePlayer.Scripts.Spawner;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SinglePlayer.Scripts
{
    /// <summary>
    /// This is the most silly implementation, but this is just for example!
    /// Don't ever do that.
    /// In a normal implementation, many modules would have to be created.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI Lives;
        [SerializeField] private PlayerController PlayerController;
        [SerializeField] private GameObject FinishPanel;
        [SerializeField] private EnemySpawner EnemySpawner;

        private void Awake()
        {
            PlayerController.LivesChanged += ((lives) => Lives.text = lives.ToString());
            PlayerController.LivesChanged += OnLivesChanged;

            EnemySpawner.EnemyWasCreated += (enemy) => enemy.ThrowWeapon.TookAttack += PlayerWasDamaged;
        }

        private void OnLivesChanged(int lives)
        {
            if (lives <= 0)
            {
                FinishPanel.SetActive(true);
            }
        }

        /// <summary>
        /// In normal implementation, the weapon creates ammunition, or checks for damage by raycast.
        /// It includes 'weaponId', 'ammoType' and more more.
        /// </summary>
        private void PlayerWasDamaged()
        {
            PlayerController.Lives -= 1;
        }

        public void Reset()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}