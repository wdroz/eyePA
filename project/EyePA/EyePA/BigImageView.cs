using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace EyePA
{
    public class BigImageView : View, Scrollable, Zoomable
    {

        private ImageView imageView;
        private Canvas canvas;

        public void setImageView(ImageView imv)
        {
            this.imageView = imv;
        }

        public BigImageView(ImageView imageView, Canvas cv)
        {
            this.imageView = imageView;
            this.canvas = cv;
        }

        public ImageView ImageView
        {
            get { return imageView; }
            set { this.imageView = value; }
        }

        public override FrameworkElement renderUI()
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = imageView.Image.Source;
            canvas.Background = ib;
            return canvas;
        }

        public void zoomAt(System.Drawing.Rectangle rect)
        {
            //System.Console.WriteLine("ZOOM");

            //start = canvas.PointToScreen(new System.Windows.Point(0, 0));
            //origin.X = canvas.RenderTransform.Value.OffsetX;
            //origin.Y = canvas.RenderTransform.Value.OffsetY;

            //Point p = new Point(rect.X, rect.Y);

            Matrix m = canvas.Background.Transform.Value;
            //m.OffsetX = origin.X + (p.X - start.X);
            //m.OffsetY = origin.Y + (p.Y - start.Y);

            //canvas.RenderTransform = new MatrixTransform(m);

            Point p = new Point(rect.X, rect.Y);
            //Point absolutePos = canvas.PointToScreen(new System.Windows.Point(0, 0));
            //Matrix m = canvas.RenderTransform.Value;
            //m.OffsetX = absolutePos.X + (p.X - 1000);
            //m.OffsetY = absolutePos.Y + (p.Y - 1000);

            //canvas.RenderTransform = new MatrixTransform(m);

            m = canvas.Background.Transform.Value;
            m.ScaleAtPrepend(1.1, 1.1, p.X, p.Y);


            canvas.Background.Transform = new MatrixTransform(m);

            

            //canvas.Clip = new RectangleGeometry(new Rect(0,0,922,490));


        }

        public void unzoomA()
        {
            throw new NotImplementedException();
        }
    }
}
