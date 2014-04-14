using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyePA
{
    public class ActionActivate : KeyAction, Activable
    {

        private Activable activable;
        public ActionActivate(double x, double y, double w, double h, Activable activable) : base(x, y, w, h)
        {
            this.activable = activable;
        }

        override public void addKey(KeyEventArgs e)
        {
            this.activable.addKey(e);
        }
    }
}
