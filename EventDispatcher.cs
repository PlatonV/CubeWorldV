using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV
{
    static class EventDispatcher
    {
        internal static List<IKeyPressedEventListener> KeyPressedListeners = new List<IKeyPressedEventListener>();
        internal static List<IKeyReleasedEventListener> KeyReleasedListeners = new List<IKeyReleasedEventListener>();

        internal static void RegisterKeyEventListener(IKeyPressedEventListener listener)
        {
            KeyPressedListeners.Add(listener);
        }

        internal static void DispatchKeyPressedEvent(KeyEventArgs e)
        {
            for (int i = 0; i < KeyPressedListeners.Count; i++)
            {
                KeyPressedListeners[i].NotifyKeyPressedEvent(e);
            }
        }

        internal static void DIspatchKeyReleasedEvent(KeyEventArgs e)
        {
            for (int i = 0; i < KeyReleasedListeners.Count; i++)
            {
                KeyReleasedListeners[i].NotifyKeyReleasedEvent(e);
            }
        }
    }
}
