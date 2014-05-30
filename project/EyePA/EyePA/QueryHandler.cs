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
    /// <summary>
    /// Query handler pour tobii rex
    /// </summary>
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
                System.Console.Out.WriteLine("W : {0}\tH:{1}", w,h);
                Application.Current.Dispatcher.Invoke(new Action(() => { this.EventManager.newQuery(new Rectangle((int)x,(int)y,(int)w,(int)h)); }));
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