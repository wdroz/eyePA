using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EyePA
{
    public class ButtonLeft : ButtonView
    {

        private ListViewImage listViewImage;

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
