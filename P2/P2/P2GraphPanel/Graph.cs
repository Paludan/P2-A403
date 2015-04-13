using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class Graph : IDrawable
	{
		List<GraphPoint> points = new List<GraphPoint>();
		//Name property
		private string _name;
		public string name{
			get { return _name; }
		}
		//Color property.
		private Color _colorOfGraph;
		public Color color {
			get { return _colorOfGraph; }
			set { _colorOfGraph = value; }
		}
		private MasterGraphPanel _MGP; 

		/* Constructor for the Graph-class
		 * Name: The name of the graph
		 * c: the desired color of the graph
		 */
		public Graph (string Name, Color c, MasterGraphPanel gPanel)
		{
			this._name = Name;
			this._colorOfGraph = c;
			this._MGP = gPanel;
		}
		/* Constructor for the Graph-class with no color specified
		 * Name: The name of the graph
		 */
		public Graph (string Name, MasterGraphPanel gPanel)
			: this(Name, Color.Black, gPanel)
		{
		}

		/* A function that lets the user add a point to the graph
		 * nextPoint: the point to be added
		 */
		public void addPoint(GraphPoint nextPoint){
			points.Add (nextPoint);
		}

		#region IDrawable implementation
		public void Draw(Graphics painter){
			for (int i = 0; i < points.Count - 1; i++) {
				points[i].Draw(painter);
				painter.DrawLine (new Pen (Brushes.Blue, 2), points [i], points [i + 1]);
			}
		}
		#endregion
	}
}