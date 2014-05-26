using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TETCSharpClient;

namespace EyePA
{
    class QueryHandlerTribe : QueryHandlerAbstract, IGazeListener 
    {
        public QueryHandlerTribe(EventManager eventManager)
            : base(eventManager)
        {
            GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);

            // Register this class for events
            GazeManager.Instance.AddGazeListener(this);
            
        }
        public override void close()
        {
            GazeManager.Instance.Deactivate();
        }

        public void OnGazeUpdate(TETCSharpClient.Data.GazeData gazeData)
        {
            double x, y, w, h;
            x = gazeData.SmoothedCoordinates.X - 50;
            y = gazeData.SmoothedCoordinates.Y - 50;
            w = gazeData.SmoothedCoordinates.X + 50;
            h = gazeData.SmoothedCoordinates.Y + 50;
            Application.Current.Dispatcher.Invoke(new Action(() => { this.EventManager.newQuery(new Rectangle((int)x, (int)y, (int)w, (int)h)); }));
        }
    }
}
