using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV.Menu
{
    class MenuItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; private set; }

        public MenuItem(string name)
        {
            Name = name;
        }

        public void Select()
        {
            IsSelected = true;
        }

        public void UnSelect()
        {
            IsSelected = false;
        }
    }
}
