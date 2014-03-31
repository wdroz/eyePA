using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.EyeX.Client;

namespace EyePA
{
    class EventManager
    {

        private List<KeyAction> myKeyActions;

        public EventManager()
        {
            myKeyActions = new List<KeyAction>();
        }

        public void addKeyAction(KeyAction ka)
        {
            this.myKeyActions.Add(ka);
        }
        
        public void newQuery(Rectangle rect)
        {
            //System.Console.WriteLine("X : " + x + "\tY : " + y);
            foreach(KeyAction ka in this.myKeyActions)
            {
                if(ka.isForMe(rect))
                {
                    //System.Console.WriteLine("!!!!!! OBJET TROUVE !!!!!!!!!!");
                }
            }
        }    
    }
}
