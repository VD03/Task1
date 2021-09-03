using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMenu
{
   public class MenuItem
    {
        public int ID { get; set; }

        public string MenuName { get; set; }

        public int ParentID { get; set; }

        public bool IsHidden { get; set; }

        public string LinkUrl { get; set; }
    }
}
