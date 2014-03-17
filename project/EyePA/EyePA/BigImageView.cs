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
    class BigImageView : View, Scrollable, Zoomable
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

        public override FrameworkElement renderUI()
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = imageView.Image.Source;
            canvas.Background = ib;
            return canvas;
        }
    }
}
