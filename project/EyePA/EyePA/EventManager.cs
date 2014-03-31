using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tobii.EyeX.Client;

namespace EyePA
{
    class EventManager
    {

        private List<KeyAction> myKeyActions;
        private List<ActionActivate> myActionsActivable;
        private KeyAction lastSelectedKeyAction;
        private ActionActivate lastActionActivable;

        public EventManager()
        {
            myKeyActions = new List<KeyAction>();
            myActionsActivable = new List<ActionActivate>();
            lastSelectedKeyAction = null;
            lastActionActivable = null;
        }

        public void addKeyAction(KeyAction ka)
        {
            this.myKeyActions.Add(ka);
        }

        public void addActivableKey(ActionActivate aa)
        {
            this.myActionsActivable.Add(aa);
        }
        
        public void newQuery(Rectangle rect)
        {
            //System.Console.WriteLine("X : " + x + "\tY : " + y);
            foreach(KeyAction ka in this.myKeyActions)
            {
                if(ka.isForMe(rect))
                {
                    //System.Console.WriteLine("!!!!!! OBJET TROUVE !!!!!!!!!!");
                    lastSelectedKeyAction = ka;
                }
            }

            foreach (ActionActivate aa in this.myActionsActivable)
            {
                if (aa.isForMe(rect))
                {
                    lastActionActivable = aa;
                }
            }
        }   
 
        public void newKey(KeyEventArgs e)
        {
            lastActionActivable.addKey(e);
        }

        public void reset()
        {
            this.lastSelectedKeyAction = null;
            this.lastActionActivable = null;
            this.myActionsActivable.Clear();
            this.myKeyActions.Clear();
        }
    }
}
