using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    /// <summary>
    /// Permet le contrôle d'une action "Watchable".
    ///    -> Qui régagit lorsqu'on le regarde.
    /// Un rectangle formé avec (x,y,w,h) définit la zone sur l'écran.
    /// </summary>
    public class ActionWatch : KeyAction
    {

        private Watchable watchable;

        public ActionWatch(double x, double y, double w, double h, Watchable watchable) : base(x,y,w,h)
        {
            this.watchable = watchable;
        }

        public override void actionIfForMe()
        {
            watchable.startWatching(this.lastRect);
        }

        public override void actionIfNotForMe()
        {
            watchable.stopWatching();
        }

    }
}
