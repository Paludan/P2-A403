using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public struct GraphPoint : IDrawable
	{
		#region Members
		private float _panelX;
		private float _xCoord;
		private float _panelY;
		private float _yCoord;
		private Color _color;
		private MasterGraphPanel _MGP;

		/// <summary>
		/// Gets or sets the x-coordinate with respect to the panel.
		/// </summary>
		/// <value>The panel x-value.</value>
		public float RealX {
			get { return _panelX; }
			set { _panelX = value; }
		}
		/// <summary>
		/// Gets the x coordinate with respect to the drawn coordinate-system.
		/// </summary>
		/// <value>The x coordinate.</value>
		public float xCoord {
			get { return _xCoord; }
		}

		/// <summary>
		/// Gets or sets the y-coordinate with respect to the panel.
		/// </summary>
		/// <value>The panel y-value.</value>
		public float RealY {
			get { return _panelY; }
			set { _panelY = value; }
		}
		/// <summary>
		/// Gets y-coordinate with respect to the drawn coordinate-system.
		/// </summary>
		/// <value>The y-coordinate.</value>
		public float yCoord {
			get { return _yCoord; }
		}

		/// <summary>
		/// Sets the color.
		/// </summary>
		/// <value>The color.</value>
		public Color color {
			set { _color = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct with specified color.
		/// </summary>
		/// <param name="PF">The PointF struct to copy.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		/// <param name="col">Color of the point.</param>
		public GraphPoint (PointF PF, MasterGraphPanel gPanel, Color col)
			: this(PF.X, PF.Y, gPanel, col)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct with default color DarkGray.
		/// </summary>
		/// <param name="PF">PointF struct to copy.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		public GraphPoint (PointF PF, MasterGraphPanel gPanel)
			: this(PF.X, PF.Y, gPanel)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct with default color DarkGray.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		public GraphPoint (double x, double y, MasterGraphPanel gPanel)
			: this (x, y, gPanel, Color.DarkGray)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.GraphPoint"/> struct with specified color.
		/// </summary>
		/// <param name="x">The x-coordinate.</param>
		/// <param name="y">The y-coordinate.</param>
		/// <param name="gPanel">The panel on which to draw the point.</param>
		/// <param name="col">Color of the point.</param>
		public GraphPoint (double x, double y, MasterGraphPanel gPanel, Color col){
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

			_color = col;
		}

		#endregion

		#region Point Conversions
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
		#endregion

		#region IDrawable implementation
		/// <summary>
		/// Draw the point to the panel.
		/// </summary>
		/// <param name="painter">A graphics object to paint with.</param>
		public void Draw (Graphics painter)
		{
			RectangleF pointCentre = new RectangleF (_panelX - 2.5f, _panelY - 2.5f, 5, 5);
			painter.FillEllipse (new SolidBrush(_color), pointCentre);
		}

		/// <summary>
		/// Update this instance of graphpoint.
		/// </summary>
		public void Update(){
			_panelX = ConvertToPanelX (_xCoord);
			_panelY = ConvertToPanelY (_yCoord);
		}
		#endregion

		#region Typecasts
		/// <param name="GP">Implicitly converts from a PointF to a GraphPoint</param>
		static public implicit operator PointF(GraphPoint GP){
			return new PointF(GP._panelX, GP._panelY);
		}
		#endregion
	}
}

