﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyePA
{
    class ButtonView : View, Activable, Watchable
    {
        public override FrameworkElement renderUI()
        {
            return null;
        }

        public void startWatching(double x, double y)
        {
            throw new NotImplementedException();
        }

        public void stopWatching()
        {
            throw new NotImplementedException();
        }
    }
}
