using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    public abstract class QueryHandlerAbstract
    {
        protected EventManager eventManager;

        public QueryHandlerAbstract(EventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        public abstract void close();
    }
}
