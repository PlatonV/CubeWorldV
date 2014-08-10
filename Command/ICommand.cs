using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.Command
{
    internal interface ICommand
    {
        bool CanExecute();

        int Execute();
    }
}
