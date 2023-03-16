using EnterTheGungeon.Components;
using EnterTheGungeon.Controllers;
using EnterTheGungeon.Menus;
using EnterTheGungeon.Settings;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnterTheGungeon.Managers
{
    public class CHackManager : MonoBehaviour
    {
        public void Start()
        {
            ETGManager.PlayerComponent = this.gameObject.AddComponent<PlayerComponent>();
            ETGManager.AimbotComponent = this.gameObject.AddComponent<AimbotComponent>();
            ETGManager.ESPComponent = this.gameObject.AddComponent<ESPComponent>();

            ETGManager.PlayerMenu = this.gameObject.AddComponent<PlayerMenu>();

            StartCoroutine(GetLatestGameManager());
        }
        
        public void Update()
        {

        }

        public IEnumerator GetLatestGameManager()
        {
            while(true)
            {
                if(GameManager.Instance != null)
                {
                    ETGManager.GameManager = GameManager.Instance;
                    ETGManager.PlayerController = ETGManager.GameManager.PrimaryPlayer;
                }

                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
