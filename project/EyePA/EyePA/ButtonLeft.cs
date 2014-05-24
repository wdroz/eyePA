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
    /// Bouton qui permet de se déplacer à gauche
    /// </summary>
    public class ButtonLeft : ButtonView
    {

        private ListViewImage listViewImage;
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="btn">Bouton WPF sur lequel on se base</param>
        /// <param name="lv">ListViewImage sur lequelle on va appliquer un scroll à gauche</param>
        public ButtonLeft(Button btn, ListViewImage lv) : base(btn) 
        {
            this.listViewImage = lv;
        }
        public override void addKey(System.Windows.Input.KeyEventArgs e)
        {
            this.listViewImage.scrollLeft();
        }
    }
}
