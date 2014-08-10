using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ScreenManager.Screens
{
    class StartupScreen : Screen
    {
        public StartupScreen()
            : base("StartupScreen")
        {

        }

        internal override void Update(float dt)
        {
            
        }

        internal override void Draw(Render.Renderer renderer)
        {
            
        }

        public override void NotifyKeyPressedEvent(SFML.Window.KeyEventArgs e)
        {
            Skip();
        }

        private static void Skip()
        {
            ScreenManager.GoToScreen("MainMenuScreen");
        }
    }
}
