using Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV.Game
{
    class Ground
    {
        public float Size { get; set; }

        List<Vector2> GroundPoints = new List<Vector2>();

        Random r = new Random();

        private int dif = 15;

        public Ground()
        {
            GroundPoints.Add(new Vector2(0, GlobalResources.ScreenHeight - GlobalResources.ScreenHeight/5 + r.Next(-5, 5)));

            for (int i = 1; i < 50; i++)
            {
                GroundPoints.Add(new Vector2(i * 50, GroundPoints[i-1].Y + r.Next(-dif,dif)));
            }

            Size = GroundPoints.Count * 50;
        }

        internal void AddChunk(int size)
        {
            for (int i = 0; i < size; i++)
            {
                float x = GroundPoints.Last<Vector2>().X + 50;
                float y = GroundPoints.Last<Vector2>().Y + r.Next(-dif, dif);
                GroundPoints.Add(new Vector2(x, y));
            }

            Size = GroundPoints.Count * 50;
        }

        public List<Vector2> GetPoints()
        {
            return GroundPoints;
        }

        internal void Draw(Render.Renderer renderer)
        {
            List<Vector2> quad = new List<Vector2>();

            for (int i = 1; i < GroundPoints.Count; i++)
            {
                quad.Clear();
                quad.Add(GroundPoints[i - 1]);
                quad.Add(GroundPoints[i]);
                quad.Add(new Vector2(GroundPoints[i].X, GlobalResources.ScreenHeight));
                quad.Add(new Vector2(GroundPoints[i-1].X, GlobalResources.ScreenHeight));
                renderer.DrawGradientPolygon(quad, new SFML.Graphics.Color(0, 20, 20), new SFML.Graphics.Color(20, 15, 5));
            }
        }

        internal float GetHeightAt(float x)
        {
            float h = 0;

            float dif = x - GroundPoints[0].X;

            float r = 60 / dif;

            float p = GroundPoints[(int)x/50].Y / GroundPoints[(int)x/50+1].Y;

            h= GroundPoints[(int)x / 50].Y + r * p - 50;

            return h;
        }
    }
}
