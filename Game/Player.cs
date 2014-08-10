using Math;
using Render;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV.Game
{
    class Player
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        public short Facing { get; set; }
        public bool OnGround { get; set; }

        private List<Vector2> points = new List<Vector2>();
        private Render.Color color;

        private const float maxSpeed = 7;

        public Player(int x, int y, Render.Color color)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2();

            points.Add(new Vector2(x, y));
            points.Add(new Vector2(x + 50, y));
            points.Add(new Vector2(x + 50, y + 50));
            points.Add(new Vector2(x, y + 50));

            this.color = color;
            Facing = 1;
        }

        public void Update(float dt)
        {
            Velocity.Y += GlobalResources.Gravity;

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                MoveRight();
            }
            else
            {
                if (Velocity.X > 0)
                {
                    Velocity.X /= 1.5f;
                }
            } 
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                MoveLeft();
            }
            else
            {
                if (Velocity.X < 0)
                {
                    Velocity.X /= 1.5f;
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.W) && !OnGround)
            {
                Velocity.Y -= 0.5f;
            }

            Position += Vector2.Multiply(Velocity, dt/10);
        }

        public void Draw(Renderer renderer)
        {
            if (Facing == 1)
            {
                points[0] = new Vector2(Position.X + Velocity.X, Position.Y);
                points[1] = new Vector2(Position.X + 50 + Velocity.X, Position.Y + Velocity.Y);
                points[2] = new Vector2(Position.X + 50, Position.Y + 50 + Velocity.Y);
                points[3] = new Vector2(Position.X, Position.Y + 50);
            }
            else
            {
                points[0] = new Vector2(Position.X + Velocity.X, Position.Y + Velocity.Y);
                points[1] = new Vector2(Position.X + 50 + Velocity.X, Position.Y);
                points[2] = new Vector2(Position.X + 50, Position.Y + 50);
                points[3] = new Vector2(Position.X, Position.Y + 50 + Velocity.Y);
            }

            renderer.DrawPolygon(points, SFML.Graphics.Color.Red);
        }

        internal void Land(float y)
        {
            Position.Y = y;

            Velocity = new Vector2(Velocity.X, 0);

            OnGround = true;
        }

        private void MoveLeft()
        {
            Facing = 0;
            if (OnGround)
            {
                if (Velocity.X > -maxSpeed)
                    Velocity.X-=0.6f;
            }
            else
            {
                if (Velocity.X > -maxSpeed)
                Velocity.X -= 0.3f;
            }
        }

        private void MoveRight()
        {
            Facing = 1;
            if (OnGround)
            {
                if (Velocity.X < maxSpeed)
                    Velocity.X+=0.6f;
            }
            else
            {
                if (Velocity.X < maxSpeed)
                Velocity.X += 0.3f;
            }
        }

        internal void Jump()
        {
            if (OnGround)
            {
                Position.Y -= 5;
                Velocity.Y -= 15;
                OnGround = false;
            }
        }
    }
}
