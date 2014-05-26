using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EyePA
{
    /// <summary>
    /// Logique d'interaction pour Naviguate.xaml
    /// </summary>
    public partial class Naviguate : Window
    {

        private String previousRep;
        private EventManager eventManager;
        private QueryHandlerAbstract queryHandler;
        private KeyHandler keyHandler;
        private List<Button> listRep;

        public Naviguate(EventManager eventManager, QueryHandlerAbstract queryHandler, String folder)
        {
            InitializeComponent();

            this.previousRep = folder;

            this.eventManager = eventManager;
            this.queryHandler = queryHandler;
            this.keyHandler = new KeyHandler(eventManager);
            this.eventManager.reset();

            this.listRep = new List<Button>();
            foreach(string item in Config.getInstance().ListDossiers)
            {
                Button btn = new Button();
                btn.Width = 200;
                btn.Height = 30;
                btn.Margin = new System.Windows.Thickness(100, 100, 0, 0);
                btn.Content = item;
                this.listRep.Add(btn);
                this.GUIListRep.Children.Add(btn);
                //this.GUIListRep.Items.Add(btn);
            }

        }

        private void registerWatchable(Watchable w, FrameworkElement fe)
        {
            Point absolutePos = fe.PointToScreen(new System.Windows.Point(0, 0));
            ActionWatch aw = new ActionWatch(absolutePos.X, absolutePos.Y, fe.Width, fe.Height, w);
            this.eventManager.addKeyAction(aw);
        }

        private void registerActivable(Activable a, FrameworkElement fe)
        {
            Point absolutePos = fe.PointToScreen(new System.Windows.Point(0, 0));
            ActionActivate aa = new ActionActivate(absolutePos.X, absolutePos.Y, fe.Width, fe.Height, a);
            this.eventManager.addActivableKey(aa);
        }

        private void registerZoomable(Zoomable z, FrameworkElement fe)
        {
            Point absolutePos = fe.PointToScreen(new System.Windows.Point(0, 0));
            ActionZoom az = new ActionZoom(absolutePos.X, absolutePos.Y, fe.Width, fe.Height, z);
            this.eventManager.setZoomableKey(az);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            keyHandler.addKey(e);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            register();
        }

        private void register()
        {
            ButtonQuit bq = new ButtonQuit(GUIQuit);
            registerWatchable(bq, GUIQuit);
            registerActivable(bq, GUIQuit);

           

            foreach(Button btn in this.listRep)
            {
                ButtonNaviguateTo btnNaviguate = new ButtonNaviguateTo(btn, (string)btn.Content, this);
                registerWatchable(btnNaviguate, btn);
                registerActivable(btnNaviguate, btn);
            }

           

        }
    }
}
