using CubeWorldV.ParticleEngine.Emitters;
using CubeWorldV.Menu;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ScreenManager.Screens
{
    class MainMenuScreen : Screen
    {
        Text MainMenuText = new Text("Main Menu", GlobalResources.ArialFont, 80);

        Menu.Menu menu = new Menu.Menu();
        MenuRenderer menuRenderer;

        GlobalEmitter particleEmitter = new GlobalEmitter((int)Application.Window.Size.X, (int)Application.Window.Size.Y, 50);

        public MainMenuScreen()
            : base("MainMenuScreen")
        {
            MainMenuText.Position = new SFML.Window.Vector2f(200, 200);
            MainMenuText.Color = SFML.Graphics.Color.White;

            menu.AddItem(new MenuItem("New Game"));
            menu.AddItem(new MenuItem("Options"));
            menu.AddItem(new MenuItem("Exit"));

            menuRenderer = new MenuRenderer(menu, 200, 300, 70);
        }

        internal override void Update(float dt)
        {
            particleEmitter.Update(dt);
        }

        internal override void Draw(Render.Renderer renderer)
        {
            renderer.DrawGradientSquare(0, 0, Application.Window.Size.X, Application.Window.Size.Y, new Color(5, 0, 100), new Color(30, 5, 30));

            renderer.Draw(MainMenuText);

            menuRenderer.Draw(renderer);

            for (int i = 0; i < particleEmitter.Particles.Count; i++)
            {
                renderer.DrawSquare(particleEmitter.Particles[i].Position.X,
                    particleEmitter.Particles[i].Position.Y,
                    (float)((new Random()).Next(1, 3))/100,
                    Color.White, Color.White);
            }
        }

        public override void NotifyKeyPressedEvent(SFML.Window.KeyEventArgs e)
        {
            switch (e.Code)
            {
                case SFML.Window.Keyboard.Key.W:
                    menu.SelectUp();
                    break;
                case SFML.Window.Keyboard.Key.Up:
                    menu.SelectUp();
                    break;
                case SFML.Window.Keyboard.Key.S:
                    menu.SelectDown();
                    break;
                case SFML.Window.Keyboard.Key.Down:
                    menu.SelectDown();
                    break;
                case SFML.Window.Keyboard.Key.Return:
                    ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.GoToScreen("GameScreen");
                    break;
            }
        }
    }
}
