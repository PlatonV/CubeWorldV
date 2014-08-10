using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV
{
    interface IKeyReleasedEventListener
    {
        void NotifyKeyReleasedEvent(SFML.Window.KeyEventArgs e);
    }
}
