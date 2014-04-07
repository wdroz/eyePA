using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            Point p = new Point(rect.X, rect.Y);
            Point absolutePos = canvas.PointToScreen(new System.Windows.Point(0, 0));

            Matrix m = canvas.RenderTransform.Value;
            m.OffsetX = absolutePos.X + (p.X - 0);
            m.OffsetY = absolutePos.Y + (p.Y - 0);

            canvas.RenderTransform = new MatrixTransform(m);
        }

        public void unzoomA()
        {
            throw new NotImplementedException();
        }
    }
}
