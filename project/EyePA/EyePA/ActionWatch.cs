using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    class ActionWatch : KeyAction, Watchable
    {

        public ActionWatch(double x, double y, double w, double h) : base(x,y,w,h)
        {

        }
        public void startWatching(double x, double y)
        {
            throw new NotImplementedException();
        }

        public void stopWatching()
        {
            throw new NotImplementedException();
        }

    }
}
