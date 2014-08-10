using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV.Menu
{
    class Menu
    {
        public int SelectedIndex { get; private set; }

        public List<MenuItem> Items = new List<MenuItem>();
        MenuItem SelectedItem;

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
            if (Items.Count == 1)
            {
                Items[0].Select();
                SelectedItem = item;
            }
        }

        public void SelectDown()
        {
            if (SelectedIndex < Items.Count - 1)
            {
                SelectedItem.UnSelect();
                SelectedItem = Items[++SelectedIndex];
                SelectedItem.Select();
            }
            else
            {
                SelectedItem.UnSelect();
                SelectedItem = Items[0];
                SelectedItem.Select();
                SelectedIndex = 0;
            }
        }

        public void SelectUp()
        {
            if (SelectedIndex > 0)
            {
                SelectedItem.UnSelect();
                SelectedItem = Items[--SelectedIndex];
                SelectedItem.Select();
            }
            else
            {
                SelectedItem.UnSelect();
                SelectedItem = Items[Items.Count - 1];
                SelectedItem.Select();
                SelectedIndex = Items.Count - 1;
            }
        }
    }
}
