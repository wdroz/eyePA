using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace EyePA
{
    public class ImageView : View, Watchable
    {

        private Image image;
        private String url;
        private bool isSelected;

        public Image Image
        {
            get { return image; }
        }

        public ImageView(String url)
        {
            this.url = url;
            this.image = new Image();
            this.image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(url));
            this.isSelected = false;
            
        }

        public DropShadowBitmapEffect createEffect()
        {

            //code de http://stackoverflow.com/questions/4022746/wpf-add-a-dropshadow-effect-to-an-element-from-code-behind et modifié
            //TODO remplacer ce code obsolète par autre chose
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();
            // Set the color of the shadow to Black.
            Color myShadowColor = new Color();
            myShadowColor.ScA = 1;
            myShadowColor.ScB = 0.05f;
            myShadowColor.ScG = 0.51f;
            myShadowColor.ScR = 0.92f;
            myDropShadowEffect.Color = myShadowColor;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = 320;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = 25;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = 1;
            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = 0.7;
            return myDropShadowEffect;
        }

        public override FrameworkElement renderUI()
        {
            this.image.Width = Config.getInstance().ImagesW;
            this.image.Height = Config.getInstance().ImagesH;
            return this.image;
        }

        public void renderTo(Image img)
        {
            img.Source = image.Source;
        }

        public void startWatching(double x, double y)
        {
            isSelected = true;
            this.image.BitmapEffect = createEffect();
        }

        public void stopWatching()
        {
            isSelected = false;
            this.image.BitmapEffect = null;
        }
    }
}
