using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    class ActionZoom : KeyAction, Zoomable
    {
        private Zoomable zoomable;

        public ActionZoom(double x, double y, double w, double h, Zoomable zoomable) : base(x,y,w,h)
        {
            this.zoomable = zoomable;
        }

        public void zoomAt(System.Drawing.Rectangle rect)
        {
            this.zoomable.zoomAt(rect);
        }

        public void unzoomA()
        {
            this.zoomable.unzoomA();
        }
    }
}
