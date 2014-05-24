using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyePA
{
    /// <summary>
    /// Interface définit l'action à faire lors de l'activation
    /// </summary>
    public interface Activable
    {
        void addKey(KeyEventArgs e);
    }
}
