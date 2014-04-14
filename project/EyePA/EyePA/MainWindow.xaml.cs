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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EyePA
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private String folder;
        private ListViewImage listView;
        private BigImageView bigImageView;
        private EventManager eventManager;
        private QueryHandlerAbstract queryHandler;
        private KeyHandler keyHandler;
        public MainWindow()
        {
            InitializeComponent();

            formInit();
        }

        public void formInit()
        {
            this.ResizeMode = ResizeMode.NoResize;
            Config config = Config.getInstance();
            folder = config.DefaultPath;
          
            updateFolder();
        }

        public void updateFolder()
        {
            this.bigImageView = new BigImageView(null, GUIBigPicture);

            this.listView = new ListViewImage(folder, this.GUIListView, this.bigImageView, GUICurrentID);
            ImageView iv = (ImageView)listView.getListView.ElementAt(0);

            this.bigImageView.ImageView = iv;

            listView.renderUI();
            bigImageView.renderUI();
            this.GUIFolderPath.Content = folder;

        }

        private void GUIBtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void changeDirectory()
        {
            this.folder = "C:\\images3";
            this.updateFolder();
            this.eventManager.reset();
            this.register();
        }

        private void GUIListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int m = GUIListView.SelectedIndex;
                foreach(View toto in listView.getListView)
                {
                    ImageView img = (ImageView)toto;
                    img.stopWatching();
                }
                
                ImageView imv = (ImageView)listView.getListView.ElementAt(m);
                imv.startWatching(new System.Drawing.Rectangle(0,0,0,0));
                bigImageView.setImageView(imv);
                this.bigImageView.renderUI();
            }
            catch
            {
                // crash si on change de rép
            }
            
        }

        private void GUIBtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            eventManager = new EventManager();
            queryHandler = new QueryHandler(eventManager);
            keyHandler = new KeyHandler(eventManager);
            
            register();
        }

        private void register()
        {
            //TODO encapsuler les actions dans les interfaces

            registerWatchable(listView, GUIListView);
            registerActivable(listView, GUIListView);


            ButtonQuit bq = new ButtonQuit(GUIBtnQuit);
            registerWatchable(bq, GUIBtnQuit);
            registerActivable(bq, GUIBtnQuit);

            ButtonRight br = new ButtonRight(GUIBtnRight, listView);
            registerWatchable(br, GUIBtnRight);
            registerActivable(br, GUIBtnRight);

            ButtonLeft bl = new ButtonLeft(GUIBtnLeft, listView);
            registerWatchable(bl, GUIBtnLeft);
            registerActivable(bl, GUIBtnLeft);


            ButtonChangeDirectory bcd = new ButtonChangeDirectory(GUIBtnBrowse, this);
            registerWatchable(bcd, GUIBtnBrowse);
            registerActivable(bcd, GUIBtnBrowse);

            registerZoomable(bigImageView, GUIBigPicture);
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

    }
}
