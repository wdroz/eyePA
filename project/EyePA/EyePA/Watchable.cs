using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    public interface Watchable
    {
        void startWatching(Rectangle rectangle);
        void stopWatching();
    }
}
