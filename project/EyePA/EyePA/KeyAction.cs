using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyePA
{
    /// <summary>
    /// super classe des actions associté à des touches
    /// </summary>
    public abstract class KeyAction
    {

        private double x;
        private double y;
        private double w;
        private double h;

        protected Rectangle rectangle;
        protected Rectangle lastRect;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="w">width</param>
        /// <param name="h">height</param>
        public KeyAction(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            this.rectangle = new Rectangle((int)x, (int)y, (int)w, (int)h);
            this.lastRect = new Rectangle((int)x, (int)y, (int)w, (int)h);
        }
        /// <summary>
        /// Démarre l'action si cela nous concerne
        /// </summary>
        /// <param name="rect"></param>
        public void runAction(Rectangle rect)
        {
            this.lastRect.X = rect.X;
            this.lastRect.Y = rect.Y;
            this.lastRect.Width = rect.Width;
            this.lastRect.Height = rect.Height;
            actionIfForMe();
        }

        /// <summary>
        /// Permet de connaître l'intersection entre la zone de la keyAction et celle du regarde de l'utilisateur
        /// </summary>
        /// <param name="rect">Zone du regard</param>
        /// <returns>la surface normalisé -> (0 si pas d'intersection, 1 si l'intersection comprend complétement l'élément)</returns>
        public double giveInterception(Rectangle rect)
        {
            Rectangle rectIntersection = Rectangle.Intersect(rect, this.rectangle);
            if (rectIntersection.IsEmpty || (rectIntersection.Width == 0) || (rectIntersection.Height == 0))
            {
                return 0;
            }
            return (this.rectangle.Width * this.rectangle.Height) / (rectIntersection.Width * rectIntersection.Height);
        }
        [Obsolete("isForMe is deprecated, please use giveInterception with runAction instead.")]
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

        /// <summary>
        /// Définit qu'est-ce qu'il faut faire si l'action est pour ce contrôle
        /// </summary>
        public virtual void actionIfForMe()
        {

        }
        /// <summary>
        /// Définit qu'est-ce qu'il faut faire si l'action n'est pas pour ce contrôle
        /// </summary>
        public virtual void actionIfNotForMe()
        {

        }

        public virtual void addKey(KeyEventArgs e)
        {

        }
    }
}
