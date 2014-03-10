using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EyePA
{
    class BtnCanvasTest
    {
        public int x,y,w,h;
        private SolidColorBrush color;
        public BtnCanvasTest(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            this.color = Brushes.LightBlue;
        }

        public void render(Canvas cv)
        {
            Rectangle rect = new Rectangle();
            rect.Height = h;
            rect.Width = w;
            Canvas.SetLeft(rect, x);
            Canvas.SetRight(rect, y);

            rect.Stroke = this.color;
            rect.StrokeThickness = 2;

            cv.Children.Add(rect);
        }

        public void onClique()
        {
            this.color = Brushes.LightGreen;

        }
    }
}
