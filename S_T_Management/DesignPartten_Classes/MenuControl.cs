using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.DesignPartten_Classes
{
    class MenuControl  : AbstractMenuControl
    {
        protected MenuInterface menu;
            
        public MenuControl(MenuInterface _mennu)
        {
            menu = _mennu;
        }
        public override void DisplayMenu()
        {
            menu.DisplayMenu();
        }
        public override void PerformTask()
        {
            menu.PerformTask();
        }
        public override string SelectMenuItem()
        {
            return menu.SelectMenuItem();
        }
    }
}
