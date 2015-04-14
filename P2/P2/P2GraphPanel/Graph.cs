using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class Graph : IDrawable
	{
		List<GraphPoint> points = new List<GraphPoint>();

		/// <summary>
		/// Gets the name of the graph.
		/// </summary>
		private string _name;
		public string name{
			get { return _name; }
		}

		/// <summary>
		/// Sets and gets the color of the graph.
		/// </summary>
		private Color _colorOfGraph;
		public Color color {
			get { return _colorOfGraph; }
			set { _colorOfGraph = value; }
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.Graph"/> class with specified color.
		/// </summary>
		/// <param name="Name">Name of the graph.</param>
		/// <param name="c">Color of the graph.</param>
		public Graph (string Name, Color c)
		{
			this._name = Name;
			this._colorOfGraph = c;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.Graph"/> class with unspecifed color, default is black.
		/// </summary>
		/// <param name="Name">Name of the graph.</param>
		public Graph (string Name)
			: this(Name, Color.Black)
		{
		}

		/// <summary>
		/// Adds a point to the graph.
		/// </summary>
		/// <param name="nextPoint">Next point of the graph.</param>
		public void addPoint(GraphPoint nextPoint){
			points.Add (nextPoint);
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the graph with the specified .
		/// </summary>
		/// <param name="painter">The graphics-object used to paint with.</param>
		public void Draw(Graphics painter){
			for (int i = 0; i < points.Count - 1; i++) {
				points[i].Draw(painter);
				painter.DrawLine (new Pen (Brushes.Blue, 2), points [i], points [i + 1]);
			}
		}
		#endregion
	}
}