﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class MasterGraphPanel : Panel
	{
		private List<Graph> graphList = new List<Graph>();

		private xAxis X;
		public double xMaxRange{
			get { return X.maxRange; }
			set { X.maxRange = value; }
		}

		private yAxis Y;
		public double yMaxRange{
			get { return Y.maxRange; }
			set { Y.maxRange = value; }
		}

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
			: base ()
		{
			CreateGraphicsUnit ();
			this.Size = new Size (620, 500);
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
		public void CalculateOrego(){
			this._O = new PointF (this.Width * Constants.xOffset, this.Height * Constants.yOffset);
		}

		public void UpdateMGP(){
			CalculateOrego ();
			X.Update ();
			Y.Update ();
			ScaleAxis ();
		}

		/// <summary>
		/// Creates the x- and y-axis with given parameters, also creates orego.
		/// </summary>
		/// <param name="xName">Name of the x-axis.</param>
		/// <param name="yName">Name of the y-axis.</param>
		public void CreateAxis(string xName, string yName){
			X = new xAxis (xName, this);
			Y = new yAxis (yName, this);
		}

		/// <summary>
		/// Adds a graph with a specified color.
		/// </summary>
		/// <param name="addedGraph">A list of <see cref="P2Graph.GraphPoint"/> /> .</param>
		/// <param name="name">The name of the graph</param>
		/// <param name="colOfGraph">Color of the graph</param>
		public void AddGraph(List<GraphPoint> addedGraph, string name, Color colOfGraph){
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
			ScaleAxis ();

			this.BackColor = Color.WhiteSmoke;
			X.Draw (_g);
			Y.Draw (_g);
			if (graphList.Count > 0) {
				foreach (var graph in graphList) {
					graph.Draw (_g);
				}
			}
		}

		/// <summary>
		/// Scales the axis.
		/// </summary>
		public void ScaleAxis(){
			X.Scale ();
			Y.Scale ();
		}
	}
}

