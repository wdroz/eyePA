using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    interface Watchable
    {
        void startWatching(double x, double y);
        void stopWatching();
    }
}
