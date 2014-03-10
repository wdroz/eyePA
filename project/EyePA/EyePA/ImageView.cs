using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EyePA
{
    public class ImageView : View
    {

        private Image image;
        private String url;

        public Image Image
        {
            get { return image; }
        }

        public ImageView(String url)
        {
            this.url = url;
            this.image = new Image();
            this.image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(url));
            
        }

        public override void render()
        {
            
        }

        public void renderTo(Image img)
        {
            img.Source = image.Source;
        }
    }
}
