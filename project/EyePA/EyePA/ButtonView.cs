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
    /// <summary>
    /// Super classe des Boutons pour les eyes tracking.
    ///  -> réagit quand on le regarde -> Watchable
    ///  -> s'active sur demande -> Activable
    /// </summary>
    public abstract class ButtonView : View, Activable, Watchable
    {

        private Button btn;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="btn">Bouton WPF sur lequel on se base</param>
        public ButtonView(Button btn)
        {
            this.btn = btn;
        }

        public override FrameworkElement renderUI()
        {
            return null;
        }

        public virtual void startWatching(System.Drawing.Rectangle rectangle)
        {

            this.btn.Background = Brushes.Orange;
        }

        public virtual void stopWatching()
        {
            this.btn.Background = Brushes.LightGray;
        }

        public abstract void addKey(System.Windows.Input.KeyEventArgs e);
    }
}
