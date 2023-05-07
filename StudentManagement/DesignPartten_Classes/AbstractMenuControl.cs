using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.DesignPartten_Classes
{
   public abstract class AbstractMenuControl
    {       
       protected MenuInterface menu;       
       public abstract int DisplayMenu();
       public abstract string SelectMenuItem();
       public abstract void PerformTask();
       

    }
}
