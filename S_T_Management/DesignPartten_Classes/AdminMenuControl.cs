using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.DesignPartten_Classes
{
    public class AdminMenuControl:AbstractMenuControl
    {
        public AdminMenuControl(MenuInterface _mennu)
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
