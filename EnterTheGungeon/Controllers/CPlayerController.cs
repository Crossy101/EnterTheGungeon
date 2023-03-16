using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnterTheGungeon.Controllers
{
    public class CPlayerController : MonoBehaviour
    {
        public PlayerController _player;
        public GameManager _gameManager;
        public HealthHaver _healthHaver;

        public void Start()
        {

        }

        public void Update()
        {
            if(GameManager.Instance != null)
            {
                _gameManager = GameManager.Instance;

                _player = _gameManager.PrimaryPlayer;

                _healthHaver = _player.healthHaver;
            }

            SetInvulnerable();

            Gun currentGun = _player.CurrentGun;

            currentGun.reloadTime = 0.0f;
            currentGun.InfiniteAmmo = true;
            currentGun.ClipShotsRemaining = int.MaxValue;
            currentGun.AppliesHoming = true;

            currentGun.RateOfFireMultiplierAdditionPerSecond = float.MaxValue;
            currentGun.GainsRateOfFireAsContinueAttack = true;
            currentGun.ContinueAttack(true);
        }

        public void SetInvulnerable() => _healthHaver.FullHeal();
    }
}
