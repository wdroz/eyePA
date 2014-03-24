using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    abstract class KeyAction
    {

        private double x;
        private double y;
        private double w;
        private double h;

        public KeyAction(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public bool isForMe(double x, double y)
        {
            if (x >= this.x && x <= this.x + this.w)
                if (y >= this.y && y <= this.y + this.h)
                    return true;

            return false;
        }
    }
}
