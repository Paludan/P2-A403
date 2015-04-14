using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public abstract class AbstractAxis
	{
		protected string _name;
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name of the axis.</value>
		public string name
		{
			get { return _name; }
		}

		protected double _minRange;
		/// <summary>
		/// Gets or sets the minimum range of the axis.
		/// </summary>
		/// <value>The minimum range.</value>
		public double minRange
		{
			get { return _minRange; }
			set {
				if (value > this._maxRange || value < 0) {

				} else {
					_minRange = value;
				}
			}
		}

		protected MasterGraphPanel _MGP;

		protected double _maxRange;
		/// <summary>
		/// Gets or sets the max range of the axis.
		/// </summary>
		/// <value>The max range.</value>
		public double maxRange
		{
			get { return _maxRange; }
			set {
				if (value < this._minRange) {

				} else {
					_maxRange = value;
				}
			}
		}

		protected GraphPoint _beingsAt;
		/// <summary>
		/// Gets the <see cref="P2Graph.GraphPoint"/> where the axis begins.
		/// </summary>
		public GraphPoint beignsAt {
			get { return _beingsAt; }
		}

		/// <summary>
		/// Gets the <see cref="P2Graph.GraphPoint"/> where the axis ends.
		/// </summary>
		protected GraphPoint _endsAt;
		public GraphPoint endsAt {
			get { return _endsAt; }
		}

		protected float _pixelPartition;

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

			CalculateAxisEnds ();
		}

		/// <summary>
		/// Calculates the axis ends.
		/// </summary>
		protected abstract void CalculateAxisEnds();

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
		/// Draws the partition.
		/// </summary>
		/// <param name="painter">The graphics object with which to draw.</param>
		/// <param name="centerPoint">Center point of the partition.</param>
		protected void DrawPartition(Graphics painter, GraphPoint centerPoint){
			GraphPoint beginning = centerPoint, end = centerPoint;
			Font numberFont = new Font ("Arial", 14);

			//Calculates the ends of the partition-line
			if (this.GetType() == typeof(xAxis)) {
				beginning.Y -= 4;
				end.Y += 4;
				painter.DrawString(centerPoint.X.ToString(), numberFont, Brushes.Black, centerPoint.X, centerPoint.Y - 8);
			}
			else if (this.GetType() == typeof(yAxis)){
				beginning.X -= 4;
				end.Y += 4;
				painter.DrawString(centerPoint.Y.ToString(), numberFont, Brushes.Black, centerPoint.X - 8, centerPoint.Y);
			}

			DrawLine (beginning, end, painter, Color.DarkGray);
		}

		/// <summary>
		/// Calculates the next partition.
		/// </summary>
		/// <returns>The next partition.</returns>
		/// <param name="currentPoint">Current point.</param>
		protected GraphPoint CalcNextPartition(GraphPoint currentPoint){
			if (this.GetType() == typeof(xAxis)) {
				currentPoint.X += _pixelPartition;
			}
			else if (this.GetType() == typeof(yAxis)){
				currentPoint.Y += currentPoint.Y;
			}
			return currentPoint;
		}

		/// <summary>
		/// Scales the axis.
		/// </summary>
		public void ScaleAxis(){
			float PixelLengthOfAxis = 1;

			//Determines the lenght based on which axis is used
			if (this.GetType () == typeof(yAxis)) {
				PixelLengthOfAxis = _endsAt.Y - _beingsAt.Y;
				Constants.yPixelScale = PixelLengthOfAxis / (float) Math.Ceiling(CalculateAxisRange());
			} 
			else if (this.GetType () == typeof(xAxis)){
				PixelLengthOfAxis = _endsAt.X - _endsAt.Y;
				Constants.xPixelScale = PixelLengthOfAxis / (float) Math.Ceiling(CalculateAxisRange());
			}

		}

		/// <summary>
		/// Increases the range of the axis.
		/// </summary>
		/// <param name="rangeIncrease">Range increase.</param>
		public void IncreaseRange(double rangeIncrease){
			_maxRange += rangeIncrease;
			ScaleAxis();
		}

		/// <summary>
		/// Calculates the axis range.
		/// </summary>
		/// <returns>The axis range.</returns>
		protected double CalculateAxisRange(){
			return this._maxRange - this._minRange;
		}
	}
}

