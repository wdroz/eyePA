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

        public Naviguate()
        {
            InitializeComponent();
        }
    }
}
