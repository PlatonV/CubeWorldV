using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render;

namespace CubeWorldV.Game
{
    class Decorator
    {
        List<Light> lights = new List<Light>();

        List<LightingBug> bugs = new List<LightingBug>();

        public Decorator()
        {
            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {
                lights.Add(new Light(
                    r.Next(0, (int)GlobalResources.ScreenWidth),
                    r.Next(0, (int)GlobalResources.ScreenHeight-500),
                    r.Next(500,5000), new Color(255,255,255,255)));
            }

            for (int i = 0; i < 20; i++)
            {
                bugs.Add(new LightingBug(r.Next(0, 20000), r.Next((int)GlobalResources.ScreenHeight - 600, (int)GlobalResources.ScreenHeight - 300),
                    r.Next(-10,10), r.Next(-10,10), r.Next(6000,12000)));
            }
        }

        internal void Update(float dt, float offset)
        {
            foreach (var b in bugs)
            {
                b.Update(dt, offset);
            }
        }

        internal void Draw(Render.Renderer renderer)
        {
        /*    foreach (var v in lights)
            {
                renderer.DrawLight(v);
            }*/

            foreach (var b in bugs)
            {
                b.Draw(renderer);
            }
        }
    }
}
