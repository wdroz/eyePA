using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyePA
{
    /// <summary>
    /// Les views sont les sous-éléments visuel de base
    /// </summary>
    public abstract class View
    {
        /// <summary>
        /// Retourne la représentation WPF de l'élément
        /// </summary>
        /// <returns>FrameworkElement</returns>
        public abstract FrameworkElement renderUI();
    }
}
