using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyePA
{
    public interface Activable
    {
        void addKey(KeyEventArgs e);
    }
}
