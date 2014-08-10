using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV
{
    static class GlobalResources
    {
        public static Font ArialFont { get; set; }

        public static uint ScreenWidth { get; set; }

        public static uint ScreenHeight { get; set; }

        internal static void Load()
        {
            ArialFont = ResourceManager.LoadFont();
        }

        public static float Gravity = 0.98f;
    }
}
