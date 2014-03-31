using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyePA
{
    public class ButtonView : View, Activable, Watchable
    {
        public override FrameworkElement renderUI()
        {
            return null;
        }

        public void startWatching(System.Drawing.Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void stopWatching()
        {
            throw new NotImplementedException();
        }

        public void addKey(System.Windows.Input.KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
