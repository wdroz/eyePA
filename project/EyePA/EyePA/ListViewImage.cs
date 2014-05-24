using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EyePA
{
    /// <summary>
    /// Classe qui gère les petites images dans la liste et qui connaît la BigPicture
    /// -> Responsable de connaître quelle petite image est sélectionné
    /// </summary>
    public class ListViewImage : ListView, Watchable, Activable
    {
        private System.Windows.Controls.ListView GUIListView;
        private TextBlock GUICurrentID;
        private int currentId;
        private int nbFiles;
        private String filePath;
        private BigImageView bigImageView;
        private ImageView lastSelectedImage;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="filePath">chemin du repertoire afficher</param>
        /// <param name="listView1">élément WPF pour contenir les petites images</param>
        /// <param name="bigImageView"></param>
        /// <param name="GUICurrentID">label qui va contenir l'indice de l'image regardé</param>
        public ListViewImage(String filePath, System.Windows.Controls.ListView listView1, BigImageView bigImageView, TextBlock GUICurrentID) : base()
        {
            this.GUICurrentID = GUICurrentID;
            this.GUIListView = listView1;
            this.filePath = filePath;
            this.bigImageView = bigImageView;
            this.lastSelectedImage = null;
            this.nbFiles = 0;
            currentId = 1;
            updateListView();
        }
        /// <summary>
        /// Permet d'afficher les images suivantes à gauche
        /// </summary>
        public void scrollLeft()
        {
            if (currentId > 0)
            {
                currentId--;
            }
            GUIListView.ScrollIntoView(listView.ElementAt(currentId).renderUI());
        }
        /// <summary>
        /// Permet d'afficher les images suivantes à droite
        /// </summary>
        public void scrollRight()
        {
            if(currentId < (listView.Count-1))
            {
                currentId++;
            }
            GUIListView.ScrollIntoView(listView.ElementAt(currentId).renderUI());
        }

        /// <summary>
        /// Permet de mettre à jour la liste view
        /// </summary>
        public void updateListView()
        {
           String[] files = Directory.GetFiles(filePath, "*.*");
           foreach(String file in files)
           {
               System.Console.WriteLine("file : " + file);
               ImageView mv = new ImageView(file, bigImageView);
               this.addView(mv);
           }

           this.nbFiles = files.Length;
           this.GUICurrentID.Text = currentId + "/" + nbFiles;

        }

        public override FrameworkElement renderUI()
        {
            this.GUIListView.Items.Clear();
            foreach(View v in listView)
            {
                this.GUIListView.Items.Add(v.renderUI());
            }
            return this.GUIListView;
        }

        public BigImageView BigImageView
        {
            get { return this.bigImageView; }
            set { this.bigImageView = value; }
        }


        public void startWatching(System.Drawing.Rectangle rectangle)
        {
            //throw new NotImplementedException();
           // System.Console.WriteLine("WE ARE LOOKING LIST VIEW");
            double newX = 0;
            double newY = 0;
            try
            {
                double w = Config.getInstance().ImagesW;
                double h = Config.getInstance().ImagesH;
                int i = 0;
                System.Drawing.Rectangle imageRect = new System.Drawing.Rectangle(0,0,0,0);
                System.Drawing.Rectangle intersectionRect = new System.Drawing.Rectangle(0, 0, 0, 0);
                ImageView selectedImage = null;
                //TODO faire que ça marche...
                Point absolutePos = this.GUIListView.PointToScreen(new System.Windows.Point(0, 0));
                //Point absolutePos = new Point(200, 730);
                foreach (ImageView mv in listView)
                {
                    //Point absolutePos = new Point(0, 0);
                    //var posMW = Application.Current.MainWindow.PointToScreen(new System.Windows.Point(0, 0));
                   // absolutePos = new System.Windows.Point(absolutePos.X - posMW.X, absolutePos.Y - posMW.Y);
                    absolutePos = mv.Image.PointToScreen(new System.Windows.Point(0, 0));
                    imageRect.X = (int)absolutePos.X;
                    imageRect.Y = (int)absolutePos.Y;
                    imageRect.Width = (int)mv.Image.Width;
                    imageRect.Height = (int)mv.Image.Height;
                    newX = absolutePos.X; //+ (i * w);
                    newY = absolutePos.Y; //+ (i * h);
                    if(imageRect.IntersectsWith(rectangle))
                    {
                        //mv.startWatching(rectangle);
                        System.Drawing.Rectangle r1 = new System.Drawing.Rectangle(imageRect.X, imageRect.Y, imageRect.Width, imageRect.Height);

                        r1.Intersect(rectangle);
                        if(r1.Width*r1.Height > intersectionRect.Width*intersectionRect.Height)
                        {
                            intersectionRect.X = imageRect.X;
                            intersectionRect.Y = imageRect.Y;
                            intersectionRect.Width = imageRect.Width;
                            intersectionRect.Height = imageRect.Height;
                            selectedImage = mv;
                            currentId = i;
                        }

                        
                    }
                    else
                    {
                        mv.stopWatching();
                    }
                    i++;
                }
                if (selectedImage != null)
                {
                    foreach (ImageView mv in listView)
                    {
                        if (mv.Equals(selectedImage))
                        {
                            this.lastSelectedImage = mv;
                            mv.startWatching(rectangle);
                            //Si on veut activer le changement instant
                            //this.GUIListView.SelectedItem = mv.Image;
                        }
                        else
                        {
                            mv.stopWatching();
                        }
                    }
                    this.GUICurrentID.Text = (currentId+1) + "/" + nbFiles;
                }
            }
            catch(Exception e)
            {
                //TODO résoudre quand ça vient ici...
                System.Console.WriteLine(e);
            }
        }

        public void stopWatching()
        {
            //throw new NotImplementedException();
            //System.Console.WriteLine("WE ARE STOPPING LOOKING LIST VIEW");
            foreach (ImageView mv in listView)
            {
                mv.stopWatching();
            }
        }

        public void addKey(System.Windows.Input.KeyEventArgs e)
        {

            System.Console.WriteLine("ListViewImage add key");

            if(lastSelectedImage != null)
            {
                lastSelectedImage.addKey(e);
            }
        }
    }
}
