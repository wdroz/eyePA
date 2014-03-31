using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EyePA
{
    public abstract class ButtonView : View, Activable, Watchable
    {

        private Button btn;

        public ButtonView(Button btn)
        {
            this.btn = btn;
        }

        public override FrameworkElement renderUI()
        {
            return null;
        }

        public virtual void startWatching(System.Drawing.Rectangle rectangle)
        {

            this.btn.Background = Brushes.Orange;
        }

        public virtual void stopWatching()
        {
            this.btn.Background = Brushes.LightGray;
        }

        public abstract void addKey(System.Windows.Input.KeyEventArgs e);
    }
}
