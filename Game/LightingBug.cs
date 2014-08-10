using Math;
using Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV.Game
{
    class LightingBug
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }

        private Light light;
        private float intensity;

        public LightingBug(int x, int y, float vx, float vy, float i)
        {
            Position = new Vector2(x, y);

            Random r = new Random();

            Velocity = new Vector2(vx, vy);
            Velocity = Vector2.Divide(Velocity, 15); 

            intensity = i;

            light = new Light(Position.X, Position.Y, intensity, new Color(255, 255, 0, 255));

            c = (int)Position.X;
        }

        private int c = 0;

        Random r = new Random();

        internal void Update(float dt, float offset)
        {
            if (c > r.Next(1000, 7000))
            {
                Vector2 where = new Vector2(r.Next((int)Position.X - 50, (int)Position.X + 50), r.Next((int)Position.Y - 50, (int)Position.Y + 50));

                Velocity = (where - Position);
                Velocity.Normalize();

                c = 0;
            }
            if (Position.Y < 480)
            {
                Velocity.Y = 1;
            }
            if (Position.Y > 800)
            {
                Velocity.Y = -1;
            }
            c++;

            Position += Vector2.Divide(Velocity, r.Next(1,5));

            intensity = intensity + (float)System.Math.Cos(c/10) * 100;

            light.Intensity = intensity;

            light.Position = new Vector2(Position.X - offset, Position.Y);
        }

        internal void Draw(Render.Renderer renderer)
        {
            renderer.DrawLight(light);
        }
    }
}
