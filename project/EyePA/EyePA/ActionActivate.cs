using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    class ActionActivate : KeyAction, Activable
    {
        public ActionActivate(double x, double y, double w, double h) : base(x, y, w, h)
        {

        }
    }
}
