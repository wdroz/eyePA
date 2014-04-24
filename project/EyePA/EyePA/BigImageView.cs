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
        private Nullable<Point> lastPoint;
        private Stack<Brush> zoomMemory;
        private Label zoomFactor;
        private double zoomValue;
        private double zoomMaxValue;

        private void reset()
        {
            this.lastPoint = null;
            this.zoomValue = 1.0f;
            this.zoomFactor.Content = string.Format("{0:0.00}", zoomValue);
            this.zoomMemory.Clear();
            //this.imageView.select();
        }

        public void setImageView(ImageView imv)
        {
            this.imageView.unselect();
            this.imageView = imv;
            this.reset();
        }

        public BigImageView(ImageView imageView, Canvas cv, Label zoomFactor)
        {
            this.imageView = imageView;
            this.canvas = cv;
            
            this.zoomMemory = new Stack<Brush>();
            this.zoomFactor = zoomFactor;
            
            this.zoomMaxValue = 10;
            this.reset();
            
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
            imageView.select();
            return canvas;
        }

        public void zoomAt(System.Drawing.Rectangle rect)
        {
            
            if (zoomValue*1.1 < zoomMaxValue)
            {
                zoomValue *= 1.1;
                zoomMemory.Push(canvas.Background.Clone());

                Matrix m = canvas.Background.Transform.Value;

                Point p = new Point(rect.X + rect.Width/2, rect.Y + rect.Height/2);
                lastPoint = p;
           

                m = canvas.Background.Transform.Value;
                m.ScaleAtPrepend(1.1, 1.1, p.X, p.Y);

                canvas.Background.Transform = new MatrixTransform(m);
                this.zoomFactor.Content = string.Format("{0:0.00}", zoomValue);
            }
        }

        public void unzoomA()
        {
            if (lastPoint != null)
            {

                if (zoomMemory.Count > 0)
                {
                    canvas.Background = zoomMemory.Pop();
                    this.zoomValue *= 1/1.1;
                    this.zoomFactor.Content = string.Format("{0:0.00}", zoomValue);
                }
            }
        }

        public void scrollAt(double x, double y)
        {
            //throw new NotImplementedException();
            //TODO faire un translation en partant du milieu vers en suivant le vector (a,b)*c
            this.canvas.Background.Transform.Value.Translate(x, y);
        }
    }
}
