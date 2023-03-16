using EnterTheGungeon.Enums;
using InControl;
using Mono.Security.X509.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine;
using Dungeonator;
using Steamworks;
using HutongGames.PlayMaker.Actions;
using EnterTheGungeon.Settings;

namespace EnterTheGungeon.Controllers
{
    public class AimbotComponent : MonoBehaviour
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public bool _aimbotEnabled = false;
        public AimbotSelectionPoint _aimbotSelectionPoint { get; set; }
        public IEnumerable<AIActor> _enemyActors { get; set; } = new List<AIActor>();

        private float _updateEnemyTimer = 0.5f;

        public void Start()
        {
            _aimbotSelectionPoint = AimbotSelectionPoint.ClosestToMouse;
        }

        public void Update()
        {
            if(_aimbotEnabled)
            {
                AIActor actorToAimFor = null;
                switch(_aimbotSelectionPoint)
                {
                    case AimbotSelectionPoint.ClosestToMouse:
                        actorToAimFor = GetClosestEnemyToMouse();
                        break;
                    case AimbotSelectionPoint.ClosestEnemy:
                        actorToAimFor = GetClosestEnemyToPlayer();
                        break;
                }

                if(actorToAimFor != null)
                {
                    Vector3 newMousePosition = Camera.main.WorldToScreenPoint(actorToAimFor.Position);
                    SetCursorPos((int)newMousePosition.x, (int)newMousePosition.y);
                }
            }
        }

        
        public AIActor GetClosestEnemyToPlayer() =>
            _enemyActors.OrderBy(actor => Vector3.Distance(actor.Position, GameManager.Instance.PrimaryPlayer.CenterPosition)).FirstOrDefault();

        public AIActor GetClosestEnemyToMouse() => 
            _enemyActors.OrderBy(actor => Vector3.Distance(actor.Position, Input.mousePosition)).FirstOrDefault();

        public List<AIActor> GetAllEnemies()
        {
            return ETGManager.PlayerController.CurrentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear);
        }
    }
}
