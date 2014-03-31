using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyePA
{
    abstract class KeyAction
    {

        private double x;
        private double y;
        private double w;
        private double h;

        protected Rectangle rectangle;
        protected Rectangle lastRect;

        public KeyAction(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            this.rectangle = new Rectangle((int)x, (int)y, (int)w, (int)h);
            this.lastRect = new Rectangle((int)x, (int)y, (int)w, (int)h);
        }

        public bool isForMe(Rectangle rect)
        {
            if(rect.IntersectsWith(this.rectangle))
            {
                this.lastRect.X = rect.X;
                this.lastRect.Y = rect.Y;
                this.lastRect.Width = rect.Width;
                this.lastRect.Height = rect.Height;
                actionIfForMe();
                return true;
            }
            actionIfNotForMe();
            return false;
        }

        public virtual void actionIfForMe()
        {

        }

        public virtual void actionIfNotForMe()
        {

        }

        public virtual void addKey(KeyEventArgs e)
        {

        }
    }
}
