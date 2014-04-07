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
        private Point lastPoint;

        public void setImageView(ImageView imv)
        {
            this.imageView = imv;
        }

        public BigImageView(ImageView imageView, Canvas cv)
        {
            this.imageView = imageView;
            this.canvas = cv;
            this.lastPoint = new Point();
            this.lastPoint.X = 99999;
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

            Matrix m = canvas.Background.Transform.Value;

            Point p = new Point(rect.X + rect.Width/2, rect.Y + rect.Height/2);
            lastPoint = p;
           

            m = canvas.Background.Transform.Value;
            m.ScaleAtPrepend(1.1, 1.1, p.X, p.Y);

            canvas.Background.Transform = new MatrixTransform(m);

        }

        public void unzoomA()
        {

            if (lastPoint.X != 99999)
            {
                Matrix m = canvas.Background.Transform.Value;



                m = canvas.Background.Transform.Value;
                m.ScaleAtPrepend(1 / 1.1, 1 / 1.1, lastPoint.X, lastPoint.Y);


                canvas.Background.Transform = new MatrixTransform(m);
            }
        }
    }
}
