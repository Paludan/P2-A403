using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class MasterGraphPanel : Panel
	{
		private List<Graph> graphList = new List<Graph>();
		private xAxis X;
		private yAxis Y;
		private Graphics _g;
		private PointF _O;
		/// <summary>
		/// Gets the (0, 0)-coordinate.
		/// </summary>
		public PointF O {
			get { return _O; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.MasterGraphPanel"/> class.
		/// </summary>
		public MasterGraphPanel ()
		{
			CreateGraphicsUnit ();
			CalculateOrego ();
		}

		/// <summary>
		/// Creates the graphics unit, automatically invoked on creation.
		/// </summary>
		private void CreateGraphicsUnit(){
			_g = this.CreateGraphics ();
		}

		/// <summary>
		/// Calculates the orego.
		/// </summary>
		private void CalculateOrego(){
			this._O = new PointF (this.Width * Constants.xOffset, this.Height * (1 - Constants.yOffset));
		}

		/// <summary>
		/// Creates the x- and y-axis with given parameters.
		/// </summary>
		/// <param name="xName">Name of the x-axis.</param>
		/// <param name="yName">Name of the y-axis.</param>
		public void createAxis(string xName, string yName){
			X = new xAxis (xName, this);
			Y = new yAxis (yName, this);
		}

		/// <summary>
		/// Adds a graph with a specified color.
		/// </summary>
		/// <param name="addedGraph">A list of <see cref="P2Graph.GraphPoint"/> /> .</param>
		/// <param name="name">The name of the graph</param>
		/// <param name="colOfGraph">Color of the graph</param>
		public void addGraph(List<GraphPoint> addedGraph, string name, Color colOfGraph){
			Graph newGraph = new Graph (name, colOfGraph);
			foreach (GraphPoint GP in addedGraph) {
				newGraph.addPoint (GP);
			}
			graphList.Add (newGraph);
		}

		/* Draws all the names of the graphs in the graphlist
		 */
		private void DrawLegends(){
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Draw the MasterGraphPanel with all it's components.
		/// </summary>
		/// <param name="g">The graphics component generated on creationg.</param>
		public void Draw (Graphics g)
		{
			this._g = g;

			this.BackColor = Color.LightGray;
			X.Draw (_g);
			Y.Draw (_g);
			if (graphList.Count > 0) {
				foreach (var graph in graphList) {
					graph.Draw (_g);
				}
			}
		}
	}
}

