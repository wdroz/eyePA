using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    public class ActionScroll : KeyAction, Scrollable
    {

        private Scrollable scrollable;

        public ActionScroll(double x, double y, double w, double h, Scrollable scrollable) : base(x, y, w, h)
        {
            this.scrollable = scrollable;
        }

        public void scrollAt(double x, double y)
        {
            this.scrollable.scrollAt(x, y);
        }
    }
}
