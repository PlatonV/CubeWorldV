using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.Command
{
    class PauseGameCommand : ICommand
    {
        private Game.Game g;

        public PauseGameCommand(Game.Game game)
        {
            g = game;
        }
        public bool CanExecute()
        {
            if (!g.IsPaused)
            {
                return true;
            }
            return false;
        }

        public int Execute()
        {
            if (CanExecute())
            {
                g.Pause();

                return 1;
            }
            return 0;
        }
    }
}
