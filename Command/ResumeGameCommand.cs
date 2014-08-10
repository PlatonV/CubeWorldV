using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.Command
{
    class ResumeGameCommand : ICommand
    {
        private Game.Game g;

        public ResumeGameCommand(Game.Game game)
        {
            g = game;
        }

        public bool CanExecute()
        {
            if (g.IsPaused)
            {
                return true;
            }
            return false;
        }

        public int Execute()
        {
            if (CanExecute())
            {
                g.Resume();

                return 1;
            }
            return 0;
        }
    }
}
