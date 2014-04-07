using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EyePA
{
    public class ButtonRight : ButtonView
    {
        private ListViewImage listViewImage;

        public ButtonRight(Button btn, ListViewImage lv) : base(btn) 
        {
            this.listViewImage = lv;
        }
        public override void addKey(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.A)
            {
                this.listViewImage.scrollRight();
            }
        }
    }
}