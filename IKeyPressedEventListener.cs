using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV
{
    interface IKeyPressedEventListener
    {
        void NotifyKeyPressedEvent(SFML.Window.KeyEventArgs e);
    }
}
