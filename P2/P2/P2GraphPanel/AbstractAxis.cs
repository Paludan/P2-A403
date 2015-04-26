using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public abstract class AbstractAxis
	{
		#region Properties
		protected string _name;
		protected int _minRange;
		protected int _maxRange;
		protected GraphPoint _beginsAt;
		protected GraphPoint _endsAt;
		protected MasterGraphPanel _MGP;

		/// <summary>
		/// Gets and sets the name.
		/// </summary>
		/// <value>The name of the axis.</value>
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the minimum range of the axis.
		/// </summary>
		/// <value>The minimum range.</value>
		public int minRange
		{
			get { return _minRange; }
			set {
				if (value > this._maxRange || value < 0) {

				} else {
					_minRange = value;
				}
			}
		}
			
		/// <summary>
		/// Gets or sets the max range of the axis.
		/// </summary>
		/// <value>The max range.</value>
		public int maxRange
		{
			get { return _maxRange; }
			set {
				if (value < this._minRange) {

				} else {
					_maxRange = value;
				}
			}
		}
			
		/// <summary>
		/// Gets the <see cref="P2Graph.GraphPoint"/> where the axis begins.
		/// </summary>
		public GraphPoint beginsAt {
			get { return _beginsAt; }
		}

		/// <summary>
		/// Gets the <see cref="P2Graph.GraphPoint"/> where the axis ends.
		/// </summary>
		public GraphPoint endsAt {
			get { return _endsAt; }
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.AbstractAxis"/> class.
		/// </summary>
		/// <param name="axisName">Axis name.</param>
		/// <param name="gPanel">The panel on which to draw the axis.</param>
		protected AbstractAxis (string axisName, MasterGraphPanel gPanel)
		{
			this._name = axisName;
			this._minRange = 0;
			this._maxRange = 1;
			this._MGP = gPanel;

			this._beginsAt = new GraphPoint (0, 0, _MGP);
			this._endsAt = new GraphPoint (0, 0, _MGP);

			CalculateAxisEnds ();
		}

		#region Calculations
		/// <summary>
		/// Calculates the axis ends.
		/// </summary>
		protected abstract void CalculateAxisEnds();

		/// <summary>
		/// Calculates the next partition.
		/// </summary>
		/// <returns>The next partition.</returns>
		/// <param name="currentPoint">Current point.</param>
		protected abstract GraphPoint CalcNextPartition (GraphPoint currentPoint);

		/// <summary>
		/// Calculates the axis range.
		/// </summary>
		/// <returns>The axis range.</returns>
		protected double CalculateAxisRange(){
			return this._maxRange - this._minRange;
		}

		/// <summary>
		/// Calculates distance between the partitions.
		/// </summary>
		/// <returns>The distance.</returns>
		protected int CalculateDistanceBetweenPartitions(){
			return (_maxRange / Constants.maxNumberPartitions) + 1;
		}
		#endregion

		#region Draw-methods
		/// <summary>
		/// Draws the number.
		/// </summary>
		/// <param name="painter">Painter.</param>
		/// <param name="x">The x-coordinate.</param>
		/// <param name="y">The y-coordinate.</param>
		/// <param name="toDraw">The string to draw.</param>
		protected void DrawNumber(Graphics painter, float x, float y, string toDraw)
		{
			DrawNumber (painter, new GraphPoint (new PointF(x, y), _MGP), toDraw);
		}

		/// <summary>
		/// Draws a number to the panel.
		/// </summary>
		/// <param name="painter">Painter.</param>
		/// <param name="centerPoint">Center point of the string.</param>
		/// <param name="toDraw">The strinsg being drawn.</param>
		protected void DrawNumber(Graphics painter, GraphPoint centerPoint, string toDraw){
			Rectangle Rec= new Rectangle ((int) centerPoint.RealX+2, (int) centerPoint.RealY, 50, 20);
			Rec.X -= (Rec.Width / 2);
			Rec.Y -= (Rec.Height / 2);
			painter.DrawString(toDraw, Constants.GraphFont, Brushes.Black, Rec);
		}

        protected void DrawNumber(Graphics painter, GraphPoint centerPoint, string toDraw, StringFormat format)
        {
            Rectangle Rec = new Rectangle((int)centerPoint.RealX, (int)centerPoint.RealY+12, 20, 50);
            Rec.X -= (Rec.Width / 2);
            Rec.Y -= (Rec.Height / 2);
            painter.DrawString(toDraw, Constants.GraphFont, Brushes.Black, Rec, format);
        }

		/// <summary>
		/// Draws a line between two points.
		/// </summary>
		/// <param name="P1">The starting <see cref="P2Graph.GraphPoint"/> of the line.</param>
		/// <param name="P2">The ending <see cref="P2Graph.GraphPoint"/> of the line.</param>
		/// <param name="painter">The graphics object with which to draw.</param>
		/// <param name="col">Color of the graph</param>
		protected virtual void DrawLine(GraphPoint P1, GraphPoint P2, Graphics painter, Color col){
			painter.DrawLine (new Pen (col, 2), P1, P2);
		}

		/// <summary>
		/// Draws the arrow ends.
		/// </summary>
		/// <param name="g">The graphics component.</param>
		protected abstract void DrawArrowEnds(Graphics g);

		/// <summary>
		/// Draws the partition.
		/// </summary>
		/// <param name="painter">Graphics component.</param>
		/// <param name="centerPoint">Center point.</param>
		/// <param name="partitionNumber">Partition number.</param>
		protected abstract void DrawPartition (Graphics painter, GraphPoint centerPoint, int partitionNumber);
		#endregion
	}
}