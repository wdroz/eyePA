using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EyePA
{
    /// <summary>
    /// Bouton qui permet de quitter l'application
    /// </summary>
    public class ButtonQuit : ButtonView
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="btn">Bouton WPF sur lequel on se base</param>
        public ButtonQuit(Button btn) : base(btn) { }
        public override void addKey(System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Config.getInstance().KeyActivation)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
