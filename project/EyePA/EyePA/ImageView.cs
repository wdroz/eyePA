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
    /// <summary>
    /// Définit une image miniature.
    /// </summary>
    public class ImageView : View, Watchable, Activable
    {

        private Image image;
        private String url;
        private bool isSelected;
        private BigImageView bigImageView;
        private bool isOnBigPicture;

        public Image Image
        {
            get { return image; }
        }

        /// <summary>
        /// Informe que celle-ci est l'image qui est entrain d'être utilisé par la BigImageView
        /// </summary>
        public void select()
        {
            isOnBigPicture = true;
            this.image.Effect = new DropShadowEffect
            {
                Color = new Color { A = 255, R = 255, G = 100, B = 100 },
                Direction = 320,
                ShadowDepth = 25,
                Opacity = 0.7
            };
        }

        /// <summary>
        /// Informe que l'image n'est pas sélectionnée
        /// </summary>
        public void unselect()
        {
            isOnBigPicture = false;
            stopWatching();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="url">chemin de l'image source</param>
        /// <param name="bigImageView"></param>
        public ImageView(String url, BigImageView bigImageView)
        {
            this.url = url;
            this.image = new Image();
            this.image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(url));
            this.isSelected = false;
            this.isOnBigPicture = false;
            this.bigImageView = bigImageView;
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
            this.image.Margin = new System.Windows.Thickness(10,0,10,0);
            return this.image;
        }

        public void renderTo(Image img)
        {
            img.Source = image.Source;
        }

        public void startWatching(System.Drawing.Rectangle rectangle)
        {
            isSelected = true;
            if (!isOnBigPicture)
            {
                this.image.Effect = new DropShadowEffect
                {
                    Color = new Color { A = 255, R = 255, G = 255, B = 0 },
                    Direction = 320,
                    ShadowDepth = 25,
                    Opacity = 0.7
                };
            }
        }

        public void stopWatching()
        {
            
            if (!isOnBigPicture)
            {
                isSelected = false;
                try
                {
                    this.image.Effect = new DropShadowEffect
                    {

                    };
                }
                catch (Exception) { }
            }
        }

        public void addKey(System.Windows.Input.KeyEventArgs e)
        {
            System.Console.WriteLine("ImageView add key");

            if (e.Key == Config.getInstance().KeyActivation)
            {
                this.bigImageView.setImageView(this);
                this.bigImageView.renderUI();
            }
        }
    }
}
