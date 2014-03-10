using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    public class ListView : View
    {

        private List<View> listView;

        public ListView()
        {
            listView = new List<View>();
        }

        public void addView(View v)
        {
            listView.Add(v);
        }
    }
}
