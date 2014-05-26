using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    /// <summary>
    /// classe qui gère un device d'eye tracking
    /// </summary>
    public abstract class QueryHandlerAbstract
    {
        protected EventManager eventManager;

        public EventManager EventManager
        {
            get { return eventManager; }
            set { eventManager = value; }
        }

        public QueryHandlerAbstract(EventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        public abstract void close();
    }
}
