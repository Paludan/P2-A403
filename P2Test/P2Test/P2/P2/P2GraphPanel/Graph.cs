using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace P2Graph
{
	/// <summary>
	/// Graph containing points, can by drawn to a <see cref="P2Graph.MasterGraphPanel"/>.
	/// </summary>
	public class Graph : IDrawable
	{
		#region Properties
		private List<GraphPoint> points = new List<GraphPoint>();
		private string _name;
		private MasterGraphPanel _master;
		private Color _colorOfGraph;
		private bool _isActive = false;

		/// <summary>
		/// Gets the name of the graph.
		/// </summary>
		/// <value>The name.</value>
		public string name{
			get { return _name; }
		}

		/// <summary>
		/// Sets the reference to the MasterGraphPanel.
		/// </summary>
		/// <value>The MG.</value>
		public MasterGraphPanel MGP {
			set { _master = value; }
		}

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public Color color {
			get { return _colorOfGraph; }
			set { _colorOfGraph = value; }
		}

		/// <summary>
		/// Gets the largest x-value of the graph.
		/// </summary>
		/// <value>The largest x-value.</value>
		public float largestX{
			get { 
				if (points.Count > 0)
					return points.Max (point => point.xCoord);
				else
					return 1;
			}
		}

		/// <summary>
		/// Gets the largest y-value of the graph.
		/// </summary>
		/// <value>The largest y-value.</value>
		public float largestY{
			get {
				if (points.Count > 0)
					return points.Max (point => point.yCoord);
				else
					return 1;
			} 
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="P2Graph.Graph"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool isActive{
			get { return _isActive; }
			set { _isActive = value; }
		}
		#endregion

		#region Setup
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
		#endregion

		#region Controls
		/// <summary>
		/// Adds a point to the graph.
		/// </summary>
		/// <param name="nextPoint">Next point of the graph.</param>
		public void AddPoint(double X, double Y){
			points.Add (new GraphPoint(X, Y, _master, this._colorOfGraph));
		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update(){
			GraphPoint temp;

			for (int i = 0; i < points.Count; i++) {
				temp = points [i];
				temp.Update ();
				points [i] = temp;
			}
		}
		#endregion
        
		#region Draw-methods
		/// <summary>
		/// Draw the graph.
		/// </summary>
		/// <param name="painter">The graphics-object used to paint with.</param>
		public void Draw(Graphics painter){
			if (points.Count > 0) {
				foreach (var GP in points) {
					GP.Draw (painter);
				}

				var PFArr = points.Select (GP => new PointF (GP.RealX, GP.RealY)).ToArray ();
                if(PFArr.Length > 1)
				    painter.DrawLines (new Pen (_colorOfGraph, 1), PFArr);
			}
		}

		/// <summary>
		/// Draws a line between the two last points.
		/// </summary>
		/// <param name="painter">Painter.</param>
		public void DrawLastLine(Graphics painter){
			points [points.Count - 1].Draw (painter);
            if(points.Count > 1)
			    painter.DrawLine (new Pen (_colorOfGraph, 1), points [points.Count - 2], points [points.Count - 1]); 
		}

		/// <summary>
		/// Adds a point and draws it, if the ranges of the axis allows it.
		/// </summary>
		/// <param name="X">x-coordinate.</param>
		/// <param name="Y">y-coordinate.</param>
		public void AddAndDraw(double X, double Y)
		{
			AddPoint (X, Y);
			bool invalidated = false;

			if (X > _master.xMaxRange || Y > _master.yMaxRange) {
				invalidated = true;
			}

			if (invalidated) {
				_master.Invalidate ();
			} else {
				_master.UpdateGraph (this);
			}
		}
		#endregion
	}
}