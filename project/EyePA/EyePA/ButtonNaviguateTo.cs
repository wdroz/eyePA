using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EyePA
{
    /// <summary>
    /// Bouton raccourci qui permet d'acceder rapidement à un dossier spécifique
    /// </summary>
    public class ButtonNaviguateTo : ButtonView
    {
        private String rep;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="btn">Bouton WPF sur lequel on se base</param>
        /// <param name="rep">Lieu sur le système de fichier</param>
        public ButtonNaviguateTo(Button btn, String rep) : base(btn)
        {
            this.rep = rep;
        }

        public override void addKey(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Config.getInstance().KeyActivation)
            {
                //TODO faire action
            }
        }
    }
}
