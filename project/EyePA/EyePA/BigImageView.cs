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
        private double speedScroll;
        private double zoomForce;
        private double srcReference;
        private double zoomMaxValueReference;
        private double coefImageSizeZoom;

        private void reset()
        {
            this.lastPoint = null;
            this.zoomValue = 1.0f;
            this.zoomFactor.Content = string.Format("{0:0.00}", zoomValue);
            this.zoomMemory.Clear();
            //this.imageView.select();
        }

        private void setZoomMaxValue(ImageView imv)
        {
            if (imv != null)
            {
                double taille = imv.Image.Source.Height * imv.Image.Source.Width;
                if (taille > srcReference)
                {
                    zoomMaxValue = zoomMaxValueReference + Math.Log10(taille - srcReference) * coefImageSizeZoom;
                }
                else
                {
                    zoomMaxValue = zoomMaxValueReference;
                }
            }
        }

        public void setImageView(ImageView imv)
        {
            this.imageView.unselect();
            this.imageView = imv;
            this.reset();
            setZoomMaxValue(imv);
        }

        public BigImageView(ImageView imageView, Canvas cv, Label zoomFactor)
        {
            this.imageView = imageView;
            this.canvas = cv;
            
            this.zoomMemory = new Stack<Brush>();
            this.zoomFactor = zoomFactor;
            this.zoomMaxValueReference = 10.0;
            this.srcReference = 1920 * 1080;
            this.speedScroll = 0.1;
            this.zoomForce = 1.015;
            this.coefImageSizeZoom = 3;
            this.reset();
            setZoomMaxValue(imageView);
            
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
            
            if (zoomValue*this.zoomForce < zoomMaxValue)
            {
                this.zoomValue *= this.zoomForce;
                Matrix m = canvas.Background.Transform.Value;
                Point absolutePos = canvas.PointToScreen(new System.Windows.Point(0, 0));
                //on se positionne au centre de l'image
                absolutePos.X += canvas.Width / 2;
                absolutePos.Y += canvas.Height / 2;
                //Si on veut le vecteur AB, il faut faire OB - OA
                double x = (absolutePos.X) - (rect.X + rect.Width / 2);
                double y = (absolutePos.Y) - (rect.Y + rect.Height / 2);

                //on normalise le vecteur AB
                double norme = Math.Sqrt(x * x + y * y);
                double xNormalized = x / norme;
                double yNormalized = y / norme;
                //on effectue une tranlation avec speedScroll qui va donner la vitesse du scroll
                m.Translate(xNormalized * speedScroll + x * speedScroll, yNormalized * speedScroll + y * speedScroll);
                m.Scale(this.zoomForce, this.zoomForce);
                canvas.Background.Transform = new MatrixTransform(m);
                this.zoomFactor.Content = string.Format("{0:0.00}", zoomValue);
            }
        }

        public void unzoomAt(System.Drawing.Rectangle rect)
        {
            if (this.zoomValue > 1.01f)
            {
                this.zoomValue *= 1 / this.zoomForce;
                Matrix m = canvas.Background.Transform.Value;
                Point absolutePos = canvas.PointToScreen(new System.Windows.Point(0, 0));
                //on se positionne au centre de l'image
                absolutePos.X += canvas.Width / 2;
                absolutePos.Y += canvas.Height / 2;
                //Si on veut le vecteur AB, il faut faire OB - OA
                double x = absolutePos.X - (rect.X + rect.Width / 2);
                double y = absolutePos.Y - (rect.Y + rect.Height / 2);

                //on normalise le vecteur AB
                double norme = Math.Sqrt(x * x + y * y);
                double xNormalized = x / norme;
                double yNormalized = y / norme;

                //on effectue une tranlation avec speedScroll qui va donner la vitesse du scroll
                m.Scale(1/this.zoomForce, 1/this.zoomForce);
                m.Translate(xNormalized * speedScroll + x * speedScroll, yNormalized * speedScroll + y * speedScroll);
                
                canvas.Background.Transform = new MatrixTransform(m);
                this.zoomFactor.Content = string.Format("{0:0.00}", zoomValue);
            }
        }

        public void scrollAt(System.Drawing.Rectangle rect)
        {
            Matrix m = canvas.Background.Transform.Value;
            Point absolutePos = canvas.PointToScreen(new System.Windows.Point(0, 0));
            //on se positionne au centre de l'image
            absolutePos.X += canvas.Width / 2;
            absolutePos.Y += canvas.Height / 2;
            //Si on veut le vecteur AB, il faut faire OB - OA
            double x = absolutePos.X - (rect.X + rect.Width/2);
            double y = absolutePos.Y - (rect.Y + rect.Height/2);
            
            //on normalise le vecteur AB
            double norme = Math.Sqrt(x*x + y*y);
            double xNormalized = x/norme;
            double yNormalized = y/norme;
            
            //on effectue une tranlation avec speedScroll qui va donner la vitesse du scroll
            m.Translate(xNormalized * speedScroll + x * speedScroll, yNormalized * speedScroll + y * speedScroll);
            canvas.Background.Transform = new MatrixTransform(m);
        }
    }
}
