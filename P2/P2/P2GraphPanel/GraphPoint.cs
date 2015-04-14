using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public struct GraphPoint : IDrawable
	{
		private float _X;
		/// <summary>
		/// Gets or sets the x-coordinate of the point.
		/// </summary>
		/// <value>The x-value of the coordinate.</value>
		public float X {
			get { return (_X - _MGP.O.X) / Constants.xPixelScale; }
			set { _X = _MGP.O.X + (value * Constants.xPixelScale); }
		}
		/// <summary>
		/// Gets the x-coordinate on the panel
		/// </summary>
		/// 
		public float RealX {
			get { return _X; }
		}
		private float _Y;
		/// <summary>
		/// Gets or sets the y-coordinate of the point.
		/// </summary>
		/// <value>The y-value of the coordinate.</value>
		public float Y {
			get { return (_Y - _MGP.O.Y) / Constants.yPixelScale; }
			set { _Y = _MGP.O.Y + (value * Constants.yPixelScale);}
		}
		public float RealY {
			get { return _Y; }
		}

		private MasterGraphPanel _MGP;

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		public GraphPoint (double x, double y, MasterGraphPanel gPanel)
		{
			this._MGP = gPanel;
			this._X = 1;
			this._Y = 1;
			X = (float) x;
			Y = (float) y;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct.
		/// </summary>
		/// <param name="PF">The PointF struct to copy.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		public GraphPoint (PointF PF, MasterGraphPanel gPanel){
			this._MGP = gPanel;
			this._X = 1;
			this._Y = 1;
			this.X = PF.X;
			this.Y = PF.Y;
		}

		/// <summary>
		/// Draw the point to the panel specified in the constructor.
		/// </summary>
		/// <param name="painter">A graphics object to paint with.</param>
		public void Draw (Graphics painter)
		{
			RectangleF pointCentre = new RectangleF (_X, _Y, 3, 3);
			painter.DrawEllipse (new Pen(Brushes.Blue, 2), pointCentre);
		}

		/// <param name="GP">Implicifly converts from a PointF to a GraphPoint</param>
		static public implicit operator PointF(GraphPoint GP){
			return new PointF(GP._X, GP._Y);
		}
	}
}

