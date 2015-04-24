using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P2Graph;

namespace P2
{
    class GraphButton : Button
    {
        ContextMenu cm = new ContextMenu();
        MasterGraphPanel chosenGraph;
        MenuItem nitrogen = new MenuItem("Nitrogen");
        MenuItem hydrogen = new MenuItem("Hydrogen");
        MenuItem ammonia = new MenuItem("Ammoniak");
        MenuItem temperature = new MenuItem("Temperatur");

        public GraphButton()
        {
            this.ContextMenu = cm;
            initializeContextMenu();
            this.Click += GraphButton_Click;
        }

        void GraphButton_Click(object sender, EventArgs e)
        {
            chosenGraph.Show();
        }

        private void initializeContextMenu()
        {
            nitrogen.Checked = false;
            hydrogen.Checked = false;
            ammonia.Checked = false;
            temperature.Checked = false;

            cm.MenuItems.Add(nitrogen);
            cm.MenuItems.Add(hydrogen);
            cm.MenuItems.Add(ammonia);
            cm.MenuItems.Add(temperature);
            cm.MenuItems.Add("Luk graf");

            cm.MenuItems[4].Click += Close_Click;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            chosenGraph.Dispose();
            this.Dispose();
        }
    }
}
