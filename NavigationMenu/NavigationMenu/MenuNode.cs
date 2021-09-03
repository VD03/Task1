using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMenu
{
    public class MenuNode
    {
        public MenuItem ItemData { get; set; }
        public List<MenuNode> Children { get; set; }

        public MenuNode()
        {
            Children = new List<MenuNode>();
        }
    }
}
