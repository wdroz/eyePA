using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyePA
{
    /// <summary>
    /// Classe composite qui permet de gérer dans autre View
    /// </summary>
    public abstract class ListView : View
    {

        protected List<View> listView;
        protected System.Windows.Controls.ListView GUIListView;

        public List<View> getListView
        {
            get {return listView;}
        }

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

        public override FrameworkElement renderUI()
        {
            return null;
        }
    }
}
