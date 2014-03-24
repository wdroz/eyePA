using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    class ActionWatch : KeyAction
    {

        private Watchable watchable;

        public ActionWatch(double x, double y, double w, double h, Watchable watchable) : base(x,y,w,h)
        {
            this.watchable = watchable;
        }

        public override void actionIfForMe()
        {
            watchable.startWatching(lastX, lastY);
        }

        public override void actionIfNotForMe()
        {
            watchable.stopWatching();
        }

    }
}
