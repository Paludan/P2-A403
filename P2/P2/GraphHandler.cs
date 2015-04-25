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

	public class GraphHandler : ICloneable
    {
		#region Setup
        private MasterGraphPanel _graphPanel;
		public MasterGraphPanel graphPanel {
			set { _graphPanel = value; }
		}
        Graph _temperature;
        Graph _pressure;
        Graph _pAmmonia;
        Graph _pHydrogen;
        Graph _pNitrogen;
		bool _isActive;
		public bool isActive {
			get { return _isActive; }
			set { _isActive = value; }
		}

        public GraphHandler(MasterGraphPanel graphArea)
        {
            _graphPanel = graphArea;
			InitializeGraphArea (graphArea);
            InitGraphs();
        }

		private void InitializeGraphArea(MasterGraphPanel MGP){
			this._graphPanel = MGP;
			MGP.BackColor = System.Drawing.Color.WhiteSmoke;
			MGP.Location = new System.Drawing.Point(0, 0);
			MGP.Name = "GraphArea";
			MGP.Size = new System.Drawing.Size(630, 510);
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
			_graphPanel.AddGraph (_pNitrogen);
        }
		#endregion

		#region Graph-options
		/// <summary>
		/// Changes the axis and hides temperature and preesure graphs
		/// </summary>
		public void ChangeAmmoniaState(object sender, EventArgs e){
			if (_pAmmonia.isActive)
				_pAmmonia.isActive = false;
			else
				_pAmmonia.isActive = true;

			SetAxisPartial ();
		}

		public void ChangeAmmoniaColor(Color col){
			_pAmmonia.color = col;
			CheckInvalidate ();
		}

		public void ChangeHydrogenState(object sender, EventArgs e){
			if (_pHydrogen.isActive)
				_pHydrogen.isActive = false;
			else
				_pHydrogen.isActive = true;

			SetAxisPartial ();
		}

		public void ChangeHydrogenColor(Color col){
			_pHydrogen.color = col;
			CheckInvalidate ();
		}

		public void ChangeNitrogenState(object sender, EventArgs e){
			if (_pNitrogen.isActive)
				_pNitrogen.isActive = false;
			else
				_pNitrogen.isActive = true;

			SetAxisPartial ();
		}

		public void ChangeNitrogenColor(Color col){
			_pNitrogen.color = col;
			CheckInvalidate ();
		}

		private void SetAxisPartial(){
			_graphPanel.ChangeAxisNames ("Tid", "Stofmængde");
			_graphPanel.Invalidate ();
		}

		public void ChangeTemperatureState(object sender, EventArgs e){
			if (_temperature.isActive)
				_temperature.isActive = false;
			else
				_temperature.isActive = true;

			SetAxisTemperature ();
		}

		public void ChangeTemperatureColor(Color col){
			_temperature.color = col;
			CheckInvalidate ();
		}
			
		private void SetAxisTemperature(){
			_graphPanel.ChangeAxisNames ("Tid", "Temperatur");
			_graphPanel.Invalidate ();
		}

		private void CheckInvalidate(){
			if (this.isActive) {
				_graphPanel.Invalidate ();
			}
		}
		#endregion

		/// <summary>
		/// Update the graphs with new date.
		/// </summary>
		/// <param name="data">Datapoint to update with.</param>
        public void Update(DataPoint data)
        {
			if (isActive) {
				_pressure.AddAndDraw (data.time, data.pressure);
				_pAmmonia.AddAndDraw (data.time, data.nAmmonia);
				_temperature.AddAndDraw (data.time, data.temperature);
				_pHydrogen.AddAndDraw (data.time, data.nHydrogen);
				_pNitrogen.AddAndDraw (data.time, data.nNitrogen);
			} else {
				_pressure.AddPoint (data.time, data.pressure);
				_pAmmonia.AddPoint (data.time, data.nAmmonia);
				_temperature.AddPoint (data.time, data.temperature);
				_pHydrogen.AddPoint (data.time, data.nHydrogen);
				_pNitrogen.AddPoint (data.time, data.nNitrogen);
			}
        }

		public void ShowGraphPanel(){
			_graphPanel.Invalidate ();
			_graphPanel.Show ();
		}

		public void HideGraphPanel(){
			_graphPanel.Hide ();
		}

		#region ICloneable implementation

		public object Clone ()
		{
			return (GraphHandler) this.MemberwiseClone();
		}

		#endregion
    }
}