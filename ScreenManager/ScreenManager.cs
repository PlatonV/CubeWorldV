using Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ScreenManager
{
    static class ScreenManager
    {
        public static Screen CurrentScreen;
        static List<Screen> screens = new List<Screen>();

        internal static void AddScreen(Screen screen)
        {
            screens.Add(screen);
            if (screens.Count == 1)
            {
                CurrentScreen = screen;
            }
        }

        internal static void GoToScreen(string name)
        {
            for (int i = 0; i < screens.Count; i++)
            {
                if (screens[i].Name == name)
                {
                    CurrentScreen = screens[i];
                }
            }
        }

        internal static void AlertKeyPressed(SFML.Window.KeyEventArgs e)
        {
            CurrentScreen.NotifyKeyPressedEvent(e);
        }

        internal static void Update(float dt)
        {
            CurrentScreen.Update(dt);
        }

        internal static void Draw(Renderer renderer)
        {
            CurrentScreen.Draw(renderer);
        }
    }
}
