using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2
{
    class GraphPage : TabPage
    {
        private GraphHandler _gh;
        /// <summary>
        /// Sets the GraphHandler and initializes a new ContextMenu from it
        /// </summary>
        public GraphHandler gh
        {
            set { _gh = value; InitializeContextMenu(); }
        }

        P2Graph.MasterGraphPanel _mgp;

        /// <summary>
        /// Instantiates a new <see cref="P2.GraphPage"/>
        /// </summary>
        /// <param name="mgp">The Graph being displayed in the window</param>
        public GraphPage(P2Graph.MasterGraphPanel mgp)
            : base()
        {
            _mgp = mgp;
            this.Controls.Add(_mgp);
            this.Click += Clicked;
            this.Leave += PageLeft;
        }

        /// <summary>
        /// Initializes the ContextMenu of the page
        /// </summary>
        private void InitializeContextMenu()
        {
            this.ContextMenu = GenerateContextMenu();
        }

        /// <summary>
        /// Used to generate the content of the ContextMenu
        /// </summary>
        /// <returns></returns>
        private ContextMenu GenerateContextMenu()
        {
            ContextMenu cm = new ContextMenu();

            MenuItem nitrogen = new MenuItem("Nitrogen");
            MenuItem hydrogen = new MenuItem("Hydrogen");
            MenuItem ammonia = new MenuItem("Ammoniak");
            MenuItem temperature = new MenuItem("Temperatur");
            MenuItem grafer = new MenuItem("Grafer");

            nitrogen.Checked = false;
            hydrogen.Checked = false;
            ammonia.Checked = false;
            temperature.Checked = false;

            nitrogen.Click += _gh.ChangeNitrogenState;
            hydrogen.Click += _gh.ChangeHydrogenState;
            ammonia.Click += _gh.ChangeAmmoniaState;
            temperature.Click += _gh.ChangeTemperatureState;

            grafer.MenuItems.Add(nitrogen);
            grafer.MenuItems.Add(hydrogen);
            grafer.MenuItems.Add(ammonia);
            grafer.MenuItems.Add(temperature);
            cm.MenuItems.Add(grafer);
            cm.MenuItems.Add("Luk graf");

            cm.MenuItems[cm.MenuItems.Count - 1].Click += Close_Click;

            return cm;
        }

        /// <summary>
        /// Close event for the ContextMenu
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void Close_Click(object sender, EventArgs e)
        {
            TabControl tc = this.Parent as TabControl;
            tc.TabPages.Remove(this);
        }

        /// <summary>
        /// Displays the graph when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clicked(object sender, EventArgs e)
        {
            this._gh.isActive = true;
        }

        /// <summary>
        /// Hides graph when leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageLeft(object sender, EventArgs e)
        {
            this._gh.isActive = false;
        }

        public void AddToClose(EventHandler onClose)
        {
            int indexOfClose = this.ContextMenu.MenuItems.Count - 1;

            this.ContextMenu.MenuItems[indexOfClose].Click += onClose;
        }
    }
}
