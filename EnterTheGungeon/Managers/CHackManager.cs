using EnterTheGungeon.Controllers;
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
        public CPlayerController _playerController;

        private bool _showWindow = true;
        private bool _isInvulerable = false;
        private int x { get; set; }

        public void Start()
        {
            _playerController = this.gameObject.AddComponent<CPlayerController>();
        }
        
        public void Update()
        {

        }

        void OnGUI()
        {
            if(_showWindow)
            {
                DrawHackMenu();
            }
        }

        void DrawHackMenu()
        {
            if(_showWindow)
            {
                GUI.Box(new Rect(10, 10, 300, 300), "EnterTheGungeon Mono (v0.0.1)");

                // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
                if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
                {
                    x++;
                }

                GUI.Button(new Rect(20, 70, 80, 20), $"Number: {x}");

                if (GUI.Toggle(new Rect(30, 100, 80, 20), _isInvulerable, "Invulnerable"))
                {
                    _playerController.SetInvulnerable();
                }

                //GUI.Label(new Rect(40, 130, 80, 20), _playerController._gameManager.NumberOfLivingPlayers.ToString());
                GUI.Button(new Rect(50, 160, 80, 20), $"Number");
            }
        }
    }
}
