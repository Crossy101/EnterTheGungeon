using EnterTheGungeon.Settings;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnterTheGungeon.Components
{
    public class PlayerComponent : MonoBehaviour
    {
        public bool _isInvulerable = false;

        public void Update()
        {
            if (_isInvulerable)
            {
                SetInvulnerable();
            }

            GameActor localPlayer = ETGManager.PlayerController.gameActor;

            Gun currentGun = localPlayer.CurrentGun;

            currentGun.reloadTime = 0.0f;
            currentGun.InfiniteAmmo = true;
            currentGun.ClipShotsRemaining = int.MaxValue;
        }

        public void SetInvulnerable() => ETGManager.PlayerController.healthHaver.FullHeal();
    }
}
