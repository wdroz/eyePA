using System;
using System.Collections.Generic;
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
        
        public void newQuery(double x, double y)
        {
            //System.Console.WriteLine("X : " + x + "\tY : " + y);
            foreach(KeyAction ka in this.myKeyActions)
            {
                if(ka.isForMe(x,y))
                {
                    System.Console.WriteLine("!!!!!! OBJET TROUVE !!!!!!!!!!");
                }
            }
        }    
    }
}
