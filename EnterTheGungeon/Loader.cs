using EnterTheGungeon.Managers;
using UnityEngine;

namespace EnterTheGungeon
{
    public class Loader
    {
        public static void Init()
        {
            Loader.Load = new GameObject();
            Loader.Load.AddComponent<CHackManager>();
            Loader.Load.AddComponent<CLogManager>();
            Object.DontDestroyOnLoad(Loader.Load);
        }

        private static GameObject Load;
    }
}
