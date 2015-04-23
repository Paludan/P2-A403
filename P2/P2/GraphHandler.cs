using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using P2Graph;

namespace P2
{
	public enum graph {temperature, pressure, ammonia, hydrogen, nitrogen}

    public class GraphHandler
    {
        public MasterGraphPanel _graphPanel;
        Graph _temperature;
        Graph _pressure;
        Graph _pAmmonia;
        Graph _pHydrogen;
        Graph _pNitrogen;

        public GraphHandler(MasterGraphPanel graphArea)
        {
            _graphPanel = graphArea;
            InitGraphs();
        }

		/// <summary>
		/// Initialized the graphs.
		/// </summary>
        private void InitGraphs()
        {
            _temperature = new Graph("Temperatur", Color.Red);
            _pressure = new Graph("Tryk", Color.Yellow);
            _pAmmonia = new Graph("Ammoniak", Color.Black);
            _pHydrogen = new Graph("Hydrogen", Color.Blue);
            _pNitrogen = new Graph("Nitrogen", Color.Green);

            _graphPanel.AddGraph(_temperature);
            _graphPanel.AddGraph(_pressure);
            _graphPanel.AddGraph(_pAmmonia);
            _graphPanel.AddGraph(_pHydrogen);
            _graphPanel.AddGraph(_pNitrogen);
        }

		/// <summary>
		/// Changes the color of the selected graph.
		/// </summary>
		/// <param name="col">Color.</param>
		/// <param name="enumGraph">Enum graph.</param>
		public void ChangeGraphColor(Color col, graph enumGraph){
			switch (enumGraph) {
			case graph.ammonia:
				if (col == Color.Transparent) {
					_pAmmonia.isActive = false;
				} else {
					_pAmmonia.color = col;
					_pAmmonia.isActive = true;
				}
				break;
			case graph.hydrogen:
				if (col == Color.Transparent) {
					_pHydrogen.isActive = false;
				} else {
					_pHydrogen.color = col;
					_pHydrogen.isActive = true;
				}
				break;
			case graph.nitrogen:
				if (col == Color.Transparent) {
					_pNitrogen.isActive = false;
				} else {
					_pNitrogen.color = col;
					_pNitrogen.isActive = true;
				}
				break;
			case graph.pressure:
				if (col == Color.Transparent) {
					_pressure.isActive = false;
				} else {
					_pressure.color = col;
					_pressure.isActive = true;
				}
				break;
			case graph.temperature:
				if (col == Color.Transparent) {
					_temperature.isActive = false;
				} else {
					_temperature.color = col;
					_temperature.isActive = true;
				}
				break;
			default:
				throw new IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Update the graphs with new date.
		/// </summary>
		/// <param name="data">Datapoint to update with.</param>
        public void Update(DataPoint data)
        {
            _pressure.AddAndDraw(data.time, data.pressure);
            _pAmmonia.AddAndDraw(data.time, data.nAmmonia);
            _temperature.AddAndDraw(data.time, data.temperature);
            _pHydrogen.AddAndDraw(data.time, data.nHydrogen);
            _pNitrogen.AddAndDraw(data.time, data.nNitrogen);
        }
    }
}