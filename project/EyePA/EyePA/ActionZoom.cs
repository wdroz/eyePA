using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    /// <summary>
    /// Permet le contrôle d'une action "Zoomable".
    ///    -> Permet de zoomer et dézoomer
    /// Un rectangle formé avec (x,y,w,h) définit la zone sur l'écran.
    /// </summary>
    public class ActionZoom : KeyAction, Zoomable
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

        public void unzoomAt(System.Drawing.Rectangle rect)
        {
            this.zoomable.unzoomAt(rect);
        }
    }
}
