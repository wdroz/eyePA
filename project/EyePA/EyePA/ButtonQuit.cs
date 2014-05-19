using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EyePA
{
    public class ButtonQuit : ButtonView
    {
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
