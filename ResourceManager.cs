using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV
{
    static class ResourceManager
    {
        internal static Font LoadFont()
        {
            return new Font(@"data/fonts/arial.ttf");
        }
    }
}
