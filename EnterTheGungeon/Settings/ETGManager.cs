using EnterTheGungeon.Components;
using EnterTheGungeon.Controllers;
using EnterTheGungeon.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnterTheGungeon.Settings
{
    public static class ETGManager
    {
        //Main Game Variables
        public static GameManager GameManager { get; set; }
        public static PlayerController PlayerController { get; set; }

        //Hack Components
        public static PlayerComponent PlayerComponent { get; set; }
        public static AimbotComponent AimbotComponent { get; set; }
        public static ESPComponent ESPComponent { get; set; }

        //GUI Components
        public static PlayerMenu PlayerMenu { get; set; }

        public static int x = 0;
    }
}
