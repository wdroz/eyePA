using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyePA
{
    /// <summary>
    /// Permet le contrôle d'une action "Activable".
    ///   -> s'active quand l'utilisateur appuis sur la touche d'activation ('A' par défaut).
    /// Un rectangle formé avec (x,y,w,h) définit la zone sur l'écran.
    /// </summary>
    public class ActionActivate : KeyAction, Activable
    {

        private Activable activable;
        public ActionActivate(double x, double y, double w, double h, Activable activable) : base(x, y, w, h)
        {
            this.activable = activable;
        }

        override public void addKey(KeyEventArgs e)
        {
            this.activable.addKey(e);
        }
    }
}
