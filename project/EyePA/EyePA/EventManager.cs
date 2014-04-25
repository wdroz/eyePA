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
    public class EventManager
    {

        private List<KeyAction> myKeyActions;
        private List<ActionActivate> myActionsActivable;
        private KeyAction lastSelectedKeyAction;
        private ActionActivate lastActionActivable;
        private ActionZoom lastActionZoom;
        private Rectangle lastRectangle;
        private ActionScroll lastActionScroll;

        public EventManager()
        {
            myKeyActions = new List<KeyAction>();
            myActionsActivable = new List<ActionActivate>();
            lastSelectedKeyAction = null;
            lastActionActivable = null;
            lastActionZoom = null;
            lastRectangle = new Rectangle();
            lastActionScroll = null;
        }

        public void addKeyAction(KeyAction ka)
        {
            this.myKeyActions.Add(ka);
        }

        public void addActivableKey(ActionActivate aa)
        {
            this.myActionsActivable.Add(aa);
        }

        public void setZoomableKey(ActionZoom az)
        {
            this.lastActionZoom = az;
        }

        public void setScrollable(ActionScroll actionScroll)
        {
            this.lastActionScroll = actionScroll;
        }
        
        public void newQuery(Rectangle rect)
        {
            lastRectangle = rect;
            selectBestKeyAction<KeyAction>(rect, myKeyActions, ref lastSelectedKeyAction);
            selectBestKeyAction<ActionActivate>(rect, myActionsActivable, ref lastActionActivable);
        }

        private static void selectBestKeyAction<T>(Rectangle rect, List<T> actions, ref T last) where T : KeyAction
        {
            double max = 0;
            KeyAction selectedKeyAction = null;
            foreach (T ka in actions)
            {
                double intersection = ka.giveInterception(rect);
                if (intersection > max)
                {
                    max = intersection;
                    selectedKeyAction = ka;
                }
            }
            foreach (T ka in actions)
            {
                if (ka == selectedKeyAction)
                {
                    last = ka;
                    ka.runAction(rect);
                }
                else
                {
                    ka.actionIfNotForMe();
                }
            }
        }   
 
        public void newKey(KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.A)
            {
                lastActionActivable.addKey(e);
            }
            else if(e.Key == System.Windows.Input.Key.W)
            {
                if(lastActionZoom != null)
                {
                    lastActionZoom.zoomAt(lastRectangle);
                }
            }
            else if (e.Key == System.Windows.Input.Key.S)
            {
                if (lastActionZoom != null)
                {
                    lastActionZoom.unzoomA();
                }
            }
            else if (e.Key == System.Windows.Input.Key.E)
            {
                if (lastActionScroll != null)
                {
                    lastActionScroll.scrollAt(lastRectangle);
                }
            }
            
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
