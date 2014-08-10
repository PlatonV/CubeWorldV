using Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV.ScreenManager
{
    abstract class Screen : IKeyPressedEventListener
    {
        internal string Name { get; set; }

        internal Screen(string name)
        {
            Name = name;
        }

        internal abstract void Update(float dt);

        internal abstract void Draw(Renderer renderer);

        public abstract void NotifyKeyPressedEvent(SFML.Window.KeyEventArgs e);
    }
}
