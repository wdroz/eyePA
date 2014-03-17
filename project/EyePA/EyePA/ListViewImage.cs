using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyePA
{
    class ListViewImage : ListView
    {
        private System.Windows.Controls.ListView GUIListView;
        private int currentId;
        private int nbFiles;
        private String filePath;

        public ListViewImage(String filePath, System.Windows.Controls.ListView listView1) : base()
        {
            this.GUIListView = listView1;
            this.filePath = filePath;
            currentId = 1;
            updateListView();
        }

        public void updateListView()
        {
           String[] files = Directory.GetFiles(filePath, "*.*");
           foreach(String file in files)
           {
               System.Console.WriteLine("file : " + file);
               ImageView mv = new ImageView(file);
               this.addView(mv);
           }
        }

        public override FrameworkElement renderUI()
        {
            this.GUIListView.Items.Clear();
            foreach(View v in listView)
            {
                this.GUIListView.Items.Add(v.renderUI());
            }
            return this.GUIListView;
        }
        
    }
}
