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
    /// Bouton qui permet d'effectuer un scroll à droite dans une listViewImage
    /// </summary>
    public class ButtonRight : ButtonView
    {
        private ListViewImage listViewImage;

        public ButtonRight(Button btn, ListViewImage lv) : base(btn) 
        {
            this.listViewImage = lv;
        }
        public override void addKey(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Config.getInstance().KeyActivation)
            {
                this.listViewImage.scrollRight();
            }
        }
    }
}