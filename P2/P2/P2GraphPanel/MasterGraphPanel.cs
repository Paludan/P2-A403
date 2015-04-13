using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class MasterGraphPanel : Panel
	{
		//Variables
		private List<Graph> graphList = new List<Graph>();
		private xAxis X;
		private yAxis Y;
		private Graphics _g;

		/* The constructor for the MasterGraphPanel
		 */
		public MasterGraphPanel ()
		{
			CreateGraphicsUnit ();
		}

		/* Automatically invoced on creation; creates a Graphics unit on the panel
		 */
		private void CreateGraphicsUnit(){
			_g = this.CreateGraphics ();
		}

		/* A function that creates and fills the name of the x- and y-axis
		 * xName: the name of the x-axis
		 * yName: the name of the y-axis
		 */
		public void createAxis(string xName, string yName){
			X = new xAxis (xName, this);
			Y = new yAxis (yName, this);
		}

		/* Adds a graph to the panel
		 * addedGraph: The graph being added to the panel
		 * name: the name of the graph
		 */
		public void addGraph(List<GraphPoint> addedGraph, string name, Color colOfGraph){
			Graph newGraph = new Graph (name, colOfGraph, this);
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

		/* Draws all the objects added to the panel
		 */
		public void Draw ()
		{
			this.BackColor = Color.LightGray;
			X.Draw (_g);
			Y.Draw (_g);
			foreach (var graph in graphList) {
				graph.Draw (_g);
			}
		}
	}
}

