using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.EyeX.Client;

namespace EyePA
{
    class QueryHandler
    {
        private InteractionSystem _system;
        private InteractionContext _context;
        private EventManager eventManager;

        public QueryHandler(EventManager eventManager)
        {

            this.eventManager = eventManager;

            _system = InteractionSystem.Initialize(LogTarget.Trace);
            _context = new InteractionContext(false);
            _context.RegisterQueryHandlerForCurrentProcess(HandleQuery);
            _context.EnableConnection();
        }

        private void HandleQuery(InteractionQuery query)
        {
            var queryBounds = query.Bounds;
            double x, y, w, h;
            if (queryBounds.TryGetRectangularData(out x, out y, out w, out h))
            {
                this.eventManager.newQuery(x, y);
            }
        }
    }
}
