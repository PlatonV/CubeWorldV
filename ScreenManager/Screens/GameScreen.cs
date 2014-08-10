using CubeWorldV.Command;
using CubeWorldV.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ScreenManager.Screens
{
    class GameScreen : Screen
    {
        Game.Game game = new Game.Game();

        public GameScreen()
            : base("GameScreen")
        {
        }

        internal override void Update(float dt)
        {
            game.Update(dt);
        }

        internal override void Draw(Render.Renderer renderer)
        {
            game.Draw(renderer);
        }

        public override void NotifyKeyPressedEvent(SFML.Window.KeyEventArgs e)
        {
            switch (e.Code)
            {
                case SFML.Window.Keyboard.Key.P:
                    if (!game.IsPaused)
                    {
                        (new PauseGameCommand(game)).Execute();
                    }
                    else
                    {
                        (new ResumeGameCommand(game)).Execute();
                    }
                    break;
            }
        }
    }
}
