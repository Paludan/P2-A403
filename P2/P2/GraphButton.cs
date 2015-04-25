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
        GraphHandler _gh;
		GraphButton[] _otherButtons;
		int _no;
		public int number{
			get { return _no; }
		}

		public GraphButton(GraphHandler gh, GraphButton[] ob)
			: base()
        {
			this._gh = gh;
			initializeContextMenu();
            this.ContextMenu = cm;
            this.Click += GraphButton_Click;
			this._otherButtons = ob;
			for (int i = 0; i < _otherButtons.Length; i++) {
				if (_otherButtons [i] != null && i != this._no) {
					_otherButtons [i].Click += this.OtherButtonSelected;
				}
			}
        }

        void GraphButton_Click(object sender, EventArgs e)
        {
			_gh.ShowGraphPanel();
        }

        private void initializeContextMenu()
        {
			MenuItem nitrogen = new MenuItem("Nitrogen");
			MenuItem hydrogen = new MenuItem("Hydrogen");
			MenuItem ammonia = new MenuItem("Ammoniak");
			MenuItem temperature = new MenuItem("Temperatur");
			MenuItem grafer = new MenuItem ("Grafer");

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
			cm.MenuItems.Add (grafer);
			cm.MenuItems.Add("Luk graf");

			cm.MenuItems[cm.MenuItems.Count-1].Click += Close_Click;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            _gh.HideGraphPanel();
            this.Dispose();
        }

		private void OtherButtonSelected(object sender, EventArgs e){
			_gh.HideGraphPanel();
			_gh.isActive = false;
		}

		public void ButtonCreated(GraphButton gp){
			gp.Click += OtherButtonSelected;
		}

		public void AssignToClose(EventHandler onClose){
			int lastIndex = cm.MenuItems.Count - 1;
			this.cm.MenuItems [lastIndex].Click += onClose;
		}
    }
}
