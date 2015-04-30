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

        /// <summary>
        /// Instantiates a new object of the GraphHandler class
        /// </summary>
        /// <param name="graphArea">A reference to the <see cref="P2Graph.MasterGraphPanel"/>, which the GraphHandler controls</param>
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
			_graphPanel.AddGraph (_pNitrogen);
        }
		#endregion

		#region Graph-options
		/// <summary>
		/// Change the state of the ammonia-graph
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ChangeAmmoniaState(object sender, EventArgs e){
            if (_pAmmonia.isActive)
                _pAmmonia.isActive = false;
            else
            {
                _pAmmonia.isActive = true;
            }

			SetAxisPartial ();
		}

        /// <summary>
        /// Change the color of the ammonia-graph and redraws the graph
        /// </summary>
        /// <param name="col">The desired color</param>
		public void ChangeAmmoniaColor(Color col){
			_pAmmonia.color = col;
			InvalidatePanel ();
		}

        /// <summary>
        /// Changes state of the hydrogen-graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public void ChangeHydrogenState(object sender, EventArgs e){
			if (_pHydrogen.isActive)
				_pHydrogen.isActive = false;
			else
				_pHydrogen.isActive = true;

			SetAxisPartial ();
		}

        /// <summary>
        /// Change the color of the hydrogen-graph
        /// </summary>
        /// <param name="col">The desired color</param>
		public void ChangeHydrogenColor(Color col){
			_pHydrogen.color = col;
			InvalidatePanel ();
		}

        /// <summary>
        /// Changes state of the Nitrogen-graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public void ChangeNitrogenState(object sender, EventArgs e){
			if (_pNitrogen.isActive)
				_pNitrogen.isActive = false;
			else
				_pNitrogen.isActive = true;

			SetAxisPartial ();
		}

        /// <summary>
        /// Changes color of the nitrogen-graph
        /// </summary>
        /// <param name="col">The desired color</param>
		public void ChangeNitrogenColor(Color col){
			_pNitrogen.color = col;
			InvalidatePanel ();
		}

        /// <summary>
        /// Changes names of the axis to fit the solution-graphs
        /// </summary>
		private void SetAxisPartial(){
			_graphPanel.ChangeAxisNames ("Tid", "Stofmængde");

            _temperature.isActive = false;
            _pressure.isActive = false;

			_graphPanel.Refresh ();
		}

        /// <summary>
        /// Changes the state of the temperature-graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public void ChangeTemperatureState(object sender, EventArgs e){
			if (_temperature.isActive)
				_temperature.isActive = false;
			else
				_temperature.isActive = true;

			SetAxisTemperature ();
		}

        /// <summary>
        /// Changes color of the temperature graph
        /// </summary>
        /// <param name="col"></param>
		public void ChangeTemperatureColor(Color col){
			_temperature.color = col;
			InvalidatePanel ();
		}
		
	    /// <summary>
	    /// Changes the names of the axis to fit the temperature-graph
	    /// </summary>
		private void SetAxisTemperature(){
			_graphPanel.ChangeAxisNames ("Tid", "Temperatur");

            _pAmmonia.isActive = false;
            _pNitrogen.isActive = false;
            _pHydrogen.isActive = false;

			_graphPanel.Refresh ();
		}

        /// <summary>
        /// Redraws the panel and it's content
        /// </summary>
		private void InvalidatePanel(){
		    _graphPanel.Refresh ();
		}
		#endregion

		/// <summary>
		/// Update the graphs with new date.
		/// </summary>
		/// <param name="data">Datapoint to update with.</param>
        public void Update(DataPoint data)
        {
            if (this.isActive)
            {
                _pAmmonia.AddAndDraw(data.time, data.nAmmonia);
                _temperature.AddAndDraw(data.time, data.temperature);
                _pHydrogen.AddAndDraw(data.time, data.nHydrogen);
                _pNitrogen.AddAndDraw(data.time, data.nNitrogen);
            }
            else
            {
                _pAmmonia.AddPoint(data.time, data.nAmmonia);
                _temperature.AddPoint(data.time, data.temperature);
                _pHydrogen.AddPoint(data.time, data.nHydrogen);
                _pNitrogen.AddPoint(data.time, data.nNitrogen);
            }
			
        }

        /// <summary>
        /// Clones this instance of the GraphHandler
        /// </summary>
        /// <returns>A clone of this GraphHandler</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}