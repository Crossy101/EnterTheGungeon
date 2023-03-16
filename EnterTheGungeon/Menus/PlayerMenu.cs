using Dungeonator;
using EnterTheGungeon.Controllers;
using EnterTheGungeon.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace EnterTheGungeon.Menus
{
    public class PlayerMenu : BaseMenu
    {
        public override void Update()
        {
            if(Input.GetKeyDown(KeyCode.F1)) 
            {
                _showWindow = !_showWindow;
            }
        }

        public override void OnGUI()
        {
            if (_showWindow)
            {
                GUI.Box(new Rect(10, 10, 300, 300), "EnterTheGungeon Mono (v0.0.1)");

                // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
                if (GUI.Button(new Rect(20, 40, 120, 20), ETGManager.PlayerComponent._isInvulerable ? "Disable Invulerable" : "Enable Invulerable"))
                {
                    ETGManager.PlayerComponent._isInvulerable = !ETGManager.PlayerComponent._isInvulerable;
                }

                // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
                if (GUI.Button(new Rect(20, 70, 120, 20), ETGManager.AimbotComponent._aimbotEnabled ? "Disable Aimbot" : "Enable Aimbot"))
                {
                    ETGManager.AimbotComponent._aimbotEnabled = !ETGManager.AimbotComponent._aimbotEnabled;
                }

                // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
                if (GUI.Button(new Rect(20, 100, 120, 20), ETGManager.ESPComponent._drawEnemies ? "Disable ESP" : "Enable ESP"))
                {
                    ETGManager.ESPComponent._drawEnemies = !ETGManager.ESPComponent._drawEnemies;
                }

                // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
                if (GUI.Button(new Rect(20, 130, 120, 20), ETGManager.ESPComponent._drawLineToEnemies ? "Disable Lines" : "Enable Lines"))
                {
                    ETGManager.ESPComponent._drawLineToEnemies = !ETGManager.ESPComponent._drawLineToEnemies;
                }

                GUI.Button(new Rect(20, 160, 120, 20), $"Enemies Alive: {ETGManager.PlayerController.CurrentRoom.GetActiveEnemiesCount(RoomHandler.ActiveEnemyType.RoomClear)}");
                GUI.Button(new Rect(20, 160, 120, 20), $"Mouse Position: {Input.mousePosition.ToString()}");
            }
        }
    }
}
