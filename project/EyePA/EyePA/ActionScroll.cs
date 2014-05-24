using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    /// <summary>
    /// Permet le contrôle d'une action "Scrollable".
    ///    -> permet de se déplacer dans un context.
    /// Un rectangle formé avec (x,y,w,h) définit la zone sur l'écran.
    /// </summary>
    public class ActionScroll : KeyAction, Scrollable
    {

        private Scrollable scrollable;

        public ActionScroll(double x, double y, double w, double h, Scrollable scrollable) : base(x, y, w, h)
        {
            this.scrollable = scrollable;
        }

        public void scrollAt(System.Drawing.Rectangle rect)
        {
            this.scrollable.scrollAt(rect);
        }

    }
}
