using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EyePA
{
    class ButtonChangeDirectory : ButtonView
    {
        private MainWindow mw;

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
