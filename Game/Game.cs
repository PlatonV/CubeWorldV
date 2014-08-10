using Math;
using Render;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPE;

namespace CubeWorldV.Game
{
    class Game : IKeyPressedEventListener
    {
        public bool IsPaused { get; private set; }

        View view = new View(new FloatRect(0, 0, GlobalResources.ScreenWidth, GlobalResources.ScreenHeight));

        Text GamePausedText = new Text("Game Paused", GlobalResources.ArialFont, 80);

        Decorator decorator = new Decorator();

        Ground ground;
        Player player;

        PhysicsEngine engine = new PhysicsEngine();

        PhysicsBody b;

        public Game()
        {
            EventDispatcher.RegisterKeyEventListener(this);

            GamePausedText.Position = new SFML.Window.Vector2f(GlobalResources.ScreenWidth / 2 - GamePausedText.GetLocalBounds().Width / 2, GlobalResources.ScreenHeight / 2 - GamePausedText.GetLocalBounds().Height / 2);
            GamePausedText.Color = SFML.Graphics.Color.White;

            player = new Player((int)GlobalResources.ScreenWidth/2-25, 500, new Render.Color(255, 0, 0));
            ground = new Ground();

            b = PhysicsBody.CreateBox(50);
            b.Move(new Vector2(200, 200));

            engine.AddBody(b);
        }

        internal void Update(float dt)
        {
            if (!IsPaused)
            {
                player.Update(dt);

                view.Move(new SFML.Window.Vector2f(player.Velocity.X * dt/10, 0));

                if (player.Position.X + 1400 > ground.Size)
                {
                    ground.AddChunk(20);
                }

                float h = ground.GetHeightAt(player.Position.X);
                if (player.Position.Y > h)
                {
                    player.Land(h);
                }

                decorator.Update(dt, view.Center.X - GlobalResources.ScreenWidth / 2);

                engine.Step(dt);
            }
        }

        internal void Draw(Render.Renderer renderer)
        {
            renderer.SetView(view);

            // Draw the background
            renderer.DrawGradientSquare(player.Position.X - GlobalResources.ScreenWidth/2, 0, GlobalResources.ScreenWidth + 200, GlobalResources.ScreenHeight,
                new SFML.Graphics.Color(2, 0, 50), new SFML.Graphics.Color(20, 2, 20));

            player.Draw(renderer);
            ground.Draw(renderer);

            renderer.SetView(Application.Window.DefaultView);

            decorator.Draw(renderer);

            renderer.DrawPolygon(b.GetPoints(), SFML.Graphics.Color.Black, SFML.Graphics.Color.White);

            if (IsPaused)
            {
                renderer.Draw(GamePausedText);
            }
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void NotifyKeyPressedEvent(SFML.Window.KeyEventArgs e)
        {
            if (e.Code == SFML.Window.Keyboard.Key.W || e.Code == SFML.Window.Keyboard.Key.Space)
            {
                player.Jump();
            }
        }
    }
}
