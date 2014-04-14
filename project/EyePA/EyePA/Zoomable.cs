using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    public interface Zoomable
    {
        void zoomAt(Rectangle rect);
        void unzoomA();
    }
}
