using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.Command
{
    /// <summary>
    /// Command for exiting the application.
    /// </summary>
    public class ExitCommand : ICommand
    {
        RenderWindow w;

        public ExitCommand(RenderWindow window)
        {
            w = window;
        }


        public bool CanExecute()
        {
          //  if (ScreenManager.ScreenManager.CurrentScreen.Name != "GameScreen")
            {
                return true;
            }
            return false;
        }

        public int Execute()
        {
            if(CanExecute())
            {
                w.Close();

                return 1;
            }
            return 0;
        }
    }
}
