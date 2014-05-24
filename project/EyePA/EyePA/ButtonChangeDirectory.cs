using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EyePA
{
    /// <summary>
    /// Bouton qui permet de changer de repertoire
    /// </summary>
    class ButtonChangeDirectory : ButtonView
    {
        private MainWindow mw;
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="btn">Bouton WPF sur lequel on se base</param>
        /// <param name="mw">Fenêtre principale à appeler</param>
        public ButtonChangeDirectory(Button btn, MainWindow mw)
            : base(btn) 
        {
            this.mw = mw;
        }
        public override void addKey(System.Windows.Input.KeyEventArgs e)
        {
            mw.changeDirectory();
        }
    }
}
