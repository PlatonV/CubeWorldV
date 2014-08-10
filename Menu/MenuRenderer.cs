using Render;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.Menu
{
    class MenuRenderer
    {
        Menu mmenu;
        List<Text> texts = new List<Text>();

        private float X;
        private float Y;
        private uint Size;

        public MenuRenderer(Menu menu, float x, float y, uint size)
        {
            X = x;
            Y = y;
            Size = size;

            mmenu = menu;
            for (int i = 0; i < menu.Items.Count; i++)
            {
                texts.Add(new Text(menu.Items[i].Name, GlobalResources.ArialFont) { CharacterSize = size, Color = SFML.Graphics.Color.White, Position = new SFML.Window.Vector2f(x, y + i * (size + size / 4)) });
            }
        }

        public void Draw(Renderer renderer)
        {
            for (int i = 0; i < texts.Count; i++)
            {
                if (mmenu.Items[i].IsSelected)
                {
                    texts[i].Color = SFML.Graphics.Color.Yellow;

                    renderer.DrawSquare(X - 40, Y + i * (Size + Size / 4) + Size / 2, 20, SFML.Graphics.Color.Red, SFML.Graphics.Color.Yellow, (float)System.Math.Cos(Environment.TickCount * 0.001f));
                }
                else
                {
                    texts[i].Color = SFML.Graphics.Color.White;
                }
                renderer.Draw(texts[i]);
            }
        }
    }
}
