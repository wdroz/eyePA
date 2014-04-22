using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EyePA
{
    public class ButtonNaviguateTo : ButtonView
    {
        private String rep;

        public ButtonNaviguateTo(Button btn, String rep) : base(btn)
        {
            this.rep = rep;
        }

        public override void addKey(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.A)
            {
                //TODO faire action
            }
        }
    }
}
