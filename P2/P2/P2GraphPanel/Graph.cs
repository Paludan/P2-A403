using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace P2Graph
{
	public class Graph : IDrawable
	{
		private List<GraphPoint> points = new List<GraphPoint>();

		/// <summary>
		/// Gets the name of the graph.
		/// </summary>
		private string _name;
		public string name{
			get { return _name; }
		}

		private MasterGraphPanel _master;
		public MasterGraphPanel MGP {
			set { _master = value; }
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
		/// Gets the largest x-value of the graph.
		/// </summary>
		/// <value>The largest x-value.</value>
		public float largestX{
			get { return points[points.Count - 1].xCoord; }
		}
		public float largestY{
			get { return points.Max (point => point.yCoord); }
		}

		private bool _isActive = false;
		public bool isActive{
			get { return _isActive; }
			set { _isActive = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.Graph"/> class with specified color.
		/// </summary>
		/// <param name="Name">Name of the graph.</param>
		/// <param name="c">Color of the graph.</param>
		public Graph (string Name, Color c, MasterGraphPanel gPanel)
		{
			this._name = Name;
			this._colorOfGraph = c;
			this._master = gPanel;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.Graph"/> class with unspecifed color, default is black.
		/// </summary>
		/// <param name="Name">Name of the graph.</param>
		public Graph (string Name, MasterGraphPanel gPanel)
			: this(Name, Color.Black, gPanel)
		{
		}

		/// <summary>
		/// Adds a point to the graph.
		/// </summary>
		/// <param name="nextPoint">Next point of the graph.</param>
		public void addPoint(GraphPoint nextPoint){
			points.Add (nextPoint);
		}

		/// <summary>
		/// Adds a point and draws it.
		/// </summary>
		/// <param name="X">x-coordinate.</param>
		/// <param name="Y">y-coordinate.</param>
		public void AddAndDraw(double X, double Y){
			points.Add (new GraphPoint(X, Y, _master));
			_master.Paint += new PaintEventHandler (_master.EventHandler_UpdatePanel);
		}

		/// <summary>
		/// Draws a line between the two last points.
		/// </summary>
		/// <param name="painter">Painter.</param>
		public void DrawLastLine(Graphics painter){
			painter.DrawLine (new Pen (_colorOfGraph, 1), points [points.Count - 2], points [points.Count - 1]); 
		}

		public void Update(){
			foreach (GraphPoint GP in points) {
				GP.Update ();
			}
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the graph with the specified .
		/// </summary>
		/// <param name="painter">The graphics-object used to paint with.</param>
		public void Draw(Graphics painter){
			foreach (var GP in points) {
				GP.Draw (painter);
			}

			var PFArr = points.Select(GP => new PointF(GP.RealX, GP.RealY)).ToArray();

			painter.DrawLines (new Pen (_colorOfGraph, 1), PFArr);
		}
		#endregion
	}
}