using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyePA
{
    class ListViewImage : ListView, Watchable, Activable
    {
        private System.Windows.Controls.ListView GUIListView;
        private int currentId;
        private int nbFiles;
        private String filePath;
        private BigImageView bigImageView;
        private ImageView lastSelectedImage;

        public ListViewImage(String filePath, System.Windows.Controls.ListView listView1, BigImageView bigImageView) : base()
        {
            this.GUIListView = listView1;
            this.filePath = filePath;
            this.bigImageView = bigImageView;
            this.lastSelectedImage = null;
            currentId = 1;
            updateListView();
        }

        public void updateListView()
        {
           String[] files = Directory.GetFiles(filePath, "*.*");
           foreach(String file in files)
           {
               System.Console.WriteLine("file : " + file);
               ImageView mv = new ImageView(file, bigImageView);
               this.addView(mv);
           }
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
                }
            }
            catch(Exception e)
            {
                //TODO résoudre que ça vient ici...
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
