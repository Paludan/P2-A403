using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public struct GraphPoint : IDrawable
	{
		private float _panelX;
		private float _xCoord;
		/// <summary>
		/// Gets the x-coordinate on the panel
		/// </summary>
		/// 
		public float RealX {
			get { return _panelX; }
			set { _panelX = value; _xCoord = ConvertToCoordinateX (value); }
		}
		public float xCoord {
			get { return _xCoord; }
		}

		private float _panelY;
		private float _yCoord;
		/// <summary>
		/// Gets or sets the y-coordinate of the point.
		/// </summary>
		/// <value>The y-value of the coordinate.</value>
		public float yCoord {
			get { return _yCoord; }
		}
		public float RealY {
			get { return _panelY; }
			set { _panelY = value; _yCoord = ConvertToCoordinateY (value); }
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
			if (gPanel == null) {
				throw new NullReferenceException ("Could not create GraphPoint without reference to a panel");
			} else {
				this._MGP = gPanel;
			}
			this._xCoord = (float) x;
			this._yCoord = (float) y;
			//Same as method ConvertToPanelX(x);
			_panelX = _MGP.O.X + (float)(x * Constants.xPixelScale);
			//Same as method ConvertToPanelY(y);
			_panelY = _MGP.O.Y - (float) (y * Constants.yPixelScale);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct.
		/// </summary>
		/// <param name="PF">The PointF struct to copy.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		public GraphPoint (PointF PF, MasterGraphPanel gPanel)
			: this(PF.X, PF.Y, gPanel)
		{
		}

		public void Draw (Graphics painter, Brush col)
		{
			RectangleF pointCentre = new RectangleF (_panelX, _panelY, 5, 5);
			painter.FillEllipse (col, pointCentre);
		}

		public void Update(){
			_panelX = ConvertToPanelX (_xCoord);
			_panelY = ConvertToPanelY (_yCoord);
		}

		/// <summary>
		/// Converts to graph-coordinate x.
		/// </summary>
		/// <returns>The graph-coordinate x.</returns>
		/// <param name="panelX">The panel-coordinate of x.</param>
		private float ConvertToCoordinateX(float panelX){
			return (panelX - _MGP.O.X) / Constants.xPixelScale;
		}

		/// <summary>
		/// Converts to graph-coordinate y.
		/// </summary>
		/// <returns>The to graph-coordinate y.</returns>
		/// <param name="panelY">The panel-coordinate of y.</param>
		private float ConvertToCoordinateY(float panelY){
			return -(panelY - _MGP.O.Y) / Constants.yPixelScale;
		}

		/// <summary>
		/// Converts to panel-coordinate x.
		/// </summary>
		/// <returns>The panel-coordinate of x.</returns>
		/// <param name="xCoordinate">The graph-coordinate of x.</param>
		private float ConvertToPanelX(float xCoordinate){
			return _MGP.O.X + (xCoordinate * Constants.xPixelScale);
		}

		/// <summary>
		/// Converts to panel-coordinate y.
		/// </summary>
		/// <returns>The to panel-coordinate of y.</returns>
		/// <param name="yCoordinate">The graph-coordinate of y.</param>
		private float ConvertToPanelY(float yCoordinate){
			return _MGP.O.Y - (yCoordinate * Constants.yPixelScale);
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the point to the panel specified in the constructor.
		/// </summary>
		/// <param name="painter">A graphics object to paint with.</param>
		public void Draw (Graphics painter)
		{
			RectangleF pointCentre = new RectangleF (_panelX, _panelY, 5, 5);
			painter.FillEllipse (Brushes.Blue, pointCentre);
		}
		#endregion

		#region Typecasts
		/// <param name="GP">Implicifly converts from a PointF to a GraphPoint</param>
		static public implicit operator PointF(GraphPoint GP){
			return new PointF(GP._panelX, GP._panelY);
		}
		#endregion
	}
}

