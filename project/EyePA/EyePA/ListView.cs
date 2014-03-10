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
        private System.Windows.Controls.ListView GUIListView;

        public ListView()
        {
            listView = new List<View>();
        }

        public ListView(System.Windows.Controls.ListView listView1)
        {
            this.GUIListView = listView1;
        }

        public void addView(View v)
        {
            listView.Add(v);
        }

        public override void render()
        {
            
        }
    }
}
