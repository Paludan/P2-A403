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
			set { _X = value; }
		}
		private float _Y;
		/// <summary>
		/// Gets or sets the y-coordinate of the point.
		/// </summary>
		/// <value>The y-value of the coordinate.</value>
		public float Y {
			get { return (_Y - _MGP.O.Y) / Constants.yPixelScale; }
			set { _Y = _MGP.O.Y - (value * Constants.yPixelScale);}
		}
		public float RealY {
			get { return _Y; }
			set { _Y = value; }
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
			this._X = _MGP.O.X + (float) (x * Constants.xPixelScale);
			this._Y = _MGP.O.Y + (float) (y * Constants.yPixelScale);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct.
		/// </summary>
		/// <param name="PF">The PointF struct to copy.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		public GraphPoint (PointF PF, MasterGraphPanel gPanel)
		{
			this._MGP = gPanel;
			this._X = PF.X;
			this._Y = PF.Y;
		}

		public void Draw (Graphics painter, Brush col)
		{
			RectangleF pointCentre = new RectangleF (_X, _Y, 5, 5);
			painter.FillEllipse (col, pointCentre);
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the point to the panel specified in the constructor.
		/// </summary>
		/// <param name="painter">A graphics object to paint with.</param>
		public void Draw (Graphics painter)
		{
			RectangleF pointCentre = new RectangleF (_X, _Y, 5, 5);
			painter.FillEllipse (Brushes.Blue, pointCentre);
		}
		#endregion

		#region Typecasts
		/// <param name="GP">Implicifly converts from a PointF to a GraphPoint</param>
		static public implicit operator PointF(GraphPoint GP){
			return new PointF(GP._X, GP._Y);
		}
		#endregion
	}
}

