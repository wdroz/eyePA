using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tobii.EyeX.Client;

namespace EyePA
{
    public class QueryHandler : QueryHandlerAbstract
    {
        private InteractionSystem _system;
        private InteractionContext _context;

        public QueryHandler(EventManager eventManager) : base(eventManager)
        {

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
                //BeginInvoke(new Action<Rectangle>(HandleQueryOnUiThread), new Rectangle((int)x, (int)y, (int)w, (int)h));
                //BeginInvoke(new Action<Rectangle>(this.eventManager.newQuery), new Rectangle(x,y,w,h)));
                Application.Current.Dispatcher.Invoke(new Action(() => { this.eventManager.newQuery(new Rectangle((int)x,(int)y,(int)w,(int)h)); }));
                //this.eventManager.newQuery(x, y);
            }
        }

        public override void close()
        {
            _context.DisableConnection();
            _context.Dispose();
            _system.Dispose();
        }
    }
}