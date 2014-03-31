﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyePA
{
    class KeyHandler
    {

        private EventManager eventManager;

        public KeyHandler(EventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        public void addKey(KeyEventArgs e)
        {
            this.eventManager.newKey(e);
        }
    }
}
