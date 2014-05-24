using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    /// <summary>
    /// Interface définit l'action à faire lors de d'un scroll
    /// </summary>
    public interface Scrollable
    {
        void scrollAt(System.Drawing.Rectangle rect);
    }
}
