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
        private ListView listView;
        private BigImageView bigImageView;
        public MainWindow()
        {
            InitializeComponent();

            formInit();
        }

        public void formInit()
        {
            Config config = Config.getInstance();
            folder = config.DefaultPath;
          
            updateFolder();
        }

        public void updateFolder()
        {
            this.listView = new ListViewImage(folder, this.GUIListView);
            ImageView iv = (ImageView)listView.getListView.ElementAt(0);
            this.bigImageView = new BigImageView(iv, GUIBigPicture);
            listView.renderUI();
            bigImageView.renderUI();
        }

        private void GUIBtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            this.folder = "C:\\images2";
            this.updateFolder();
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
                imv.startWatching(0, 0);
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
    }
}
