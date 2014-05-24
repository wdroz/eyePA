using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    /// <summary>
    /// Interface définit l'action à faire lorsque l'utilisateur regarde ou non l'objet
    /// </summary>
    public interface Watchable
    {
        /// <summary>
        /// Quand l'objet est regardé
        /// </summary>
        /// <param name="rectangle">Zone du regarde</param>
        void startWatching(Rectangle rectangle);
        /// <summary>
        /// Quand l'objet n'est plus regardé
        /// </summary>
        void stopWatching();
    }
}
