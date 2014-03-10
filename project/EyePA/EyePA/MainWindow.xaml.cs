﻿using System;
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
        private ImageView imageView;
        public MainWindow()
        {
            InitializeComponent();

            formInit();
        }

        public void formInit()
        {
            Config config = Config.getInstance();
            folder = config.DefaultPath;


            this.GUIFolderPath.Content = folder;
            this.listView = new ListView(this.GUIListView);
            String chemin = folder + "\\nwkl45v7.jpg";
            System.Console.WriteLine(chemin);
            imageView = new ImageView(chemin);
            this.imageView.renderTo(this.GUIImageTest);
        }

        
        
    }
}
