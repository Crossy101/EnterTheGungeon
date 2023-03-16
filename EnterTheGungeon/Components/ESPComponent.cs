using Dungeonator;
using EnterTheGungeon.Settings;
using EnterTheGungeon.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine;

namespace EnterTheGungeon.Components
{
    public class ESPComponent : MonoBehaviour
    {
        public bool _drawEnemies = false;
        public bool _drawLineToEnemies = false;
        public bool _drawWeapons = false;

        public void Start()
        {
            
        }

        public void OnGUI()
        {
            if(_drawEnemies)
            {
                DrawEnemies();
            }

            if(_drawLineToEnemies)
            {
                DrawLinesToEnemies();
            }
        }

        public void DrawEnemies()
        {
            Vector2 boxSize = new Vector2 { x = 30, y = 30 };

            PlayerController playerController = ETGManager.PlayerController;
            RoomHandler.ActiveEnemyType enemyType = RoomHandler.ActiveEnemyType.RoomClear;

            foreach (var enemy in playerController.CurrentRoom.GetActiveEnemies(enemyType))
            {
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemy.Position);
                screenPosition.y = Screen.height - (screenPosition.y + 1f);
                if (screenPosition.z >= 1)
                {
                    DrawTool.DrawBox(screenPosition, boxSize, Color.red);
                }
            }
        }

        public void DrawLinesToEnemies()
        {
            PlayerController playerController = ETGManager.PlayerController;
            RoomHandler.ActiveEnemyType enemyType = RoomHandler.ActiveEnemyType.RoomClear;

            foreach (var enemy in playerController.CurrentRoom.GetActiveEnemies(enemyType))
            {
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemy.Position);
                screenPosition.y = Screen.height - (screenPosition.y + 1f);
                if (screenPosition.z >= 1)
                {
                    DrawTool.DrawLine(Input.mousePosition, enemy.Position, Color.green);
                }
            }
        }
    }
}
