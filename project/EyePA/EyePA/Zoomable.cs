using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    /// <summary>
    /// Interface définit l'action à faire lors d'un zoom/dezoom
    /// </summary>
    public interface Zoomable
    {
        /// <summary>
        /// Zoom sur une partie
        /// </summary>
        /// <param name="rect">Partie regardé par l'utilisateur</param>
        void zoomAt(Rectangle rect);
        /// <summary>
        /// Dezoom sur une partie
        /// </summary>
        /// <param name="rect">Partie regardé par l'utilisateur</param>
        void unzoomAt(Rectangle rect);
    }
}
