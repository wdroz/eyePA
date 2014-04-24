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

        public void setImageView(ImageView imv)
        {
            this.imageView = imv;
        }

        public BigImageView(ImageView imageView, Canvas cv, Label zoomFactor)
        {
            this.imageView = imageView;
            this.canvas = cv;
            this.lastPoint = null;
            this.zoomMemory = new Stack<Brush>();
            this.zoomFactor = zoomFactor;
            this.zoomValue = 1.0f;
            this.zoomMaxValue = 10;
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
                this.zoomFactor.Content = "" + zoomValue;
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
                    this.zoomFactor.Content = "" + this.zoomValue;
                }
            }
        }
    }
}
