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
    /// <summary>
    /// Classe qui gère les différents evenements
    /// </summary>
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
        /// <summary>
        /// Méthode qui est appelé par le device d'eyes tracking afin que celui-ci
        /// déclanche l'évenement adéquat en fonction.
        /// </summary>
        /// <param name="rect">Zone qui définit le regarde de l'utilisateur</param>
        public void newQuery(Rectangle rect)
        {
            lastRectangle = rect;
            selectBestKeyAction<KeyAction>(rect, myKeyActions, ref lastSelectedKeyAction);
            selectBestKeyAction<ActionActivate>(rect, myActionsActivable, ref lastActionActivable);
        }

        /// <summary>
        /// Sélectionne la meilleure KeyAction en fonction du regarde de l'utilisateur
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rect">Zone qui définit le regarde de l'utilisateur</param>
        /// <param name="actions">listes des KeyActions</param>
        /// <param name="last">va contenir le keyAction choisit</param>
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
 
        /// <summary>
        /// Méthode qui définit quelle action entreprendre (si besoin) en fonction
        /// de la touche appuyée par l'utilisateur
        /// </summary>
        /// <param name="e">touche enfoncée</param>
        public void newKey(KeyEventArgs e)
        {
            if (e.Key == Config.getInstance().KeyActivation)
            {
                lastActionActivable.addKey(e);
            }
            else if (e.Key == Config.getInstance().KeyZoom)
            {
                if(lastActionZoom != null)
                {
                    lastActionZoom.zoomAt(lastRectangle);
                }
            }
            else if (e.Key == Config.getInstance().KeyUnzoom)
            {
                if (lastActionZoom != null)
                {
                    lastActionZoom.unzoomAt(lastRectangle);
                }
            }
            else if (e.Key == Config.getInstance().KeyScroll)
            {
                if (lastActionScroll != null)
                {
                    lastActionScroll.scrollAt(lastRectangle);
                }
            }
            
        }
        /// <summary>
        /// Méthode qui permet, comme son nom l'indique, de remettre à zero l'instance.
        /// </summary>
        public void reset()
        {
            this.lastSelectedKeyAction = null;
            this.lastActionActivable = null;
            this.lastActionScroll = null;
            this.lastActionZoom = null;
            this.myActionsActivable.Clear();
            this.myKeyActions.Clear();
        }
    }
}
