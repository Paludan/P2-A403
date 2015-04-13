using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public abstract class AbstractAxis
	{
		/* Name property, allows the user to get the name of the object
		 */
		protected string _name;
		public string name
		{
			get { return _name; }
		}

		/* minRange property, allows user to see min range
		 * Allows user to set minRange as long as it's not higher than the maxRange or lower than 0
		 */
		protected double _minRange;
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

		/* maxRange property, allows user to see max range
		 * Allows the user to set the maxRange, as long as it's not lower than the minRange
		 */
		protected double _maxRange;
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

		/* A property for accessing beginning of the axis
		 */
		protected GraphPoint _beingsAt;
		public GraphPoint beignsAt {
			get { return _beingsAt; }
		}

		/* A property for accesseing the end of the axis
		 */
		protected GraphPoint _endsAt;
		public GraphPoint endsAt {
			get { return _endsAt; }
		}

		protected float _pixelPartition;

		/* Constructor of the class, also sets a default range from 0 to 1
		 * axisName: The name of the given axis
		 */
		public AbstractAxis (string axisName, MasterGraphPanel gPanel)
		{
			this._name = axisName;
			this._minRange = 0;
			this._maxRange = 1;
			this._MGP = gPanel;

			CalculateAxisEnds ();
		}

		protected abstract void CalculateAxisEnds();

		/* A method that draws a line between two points
		 * P1: The start of the line
		 * P2: The end of the line
		 * painter: the drawing object
		 */
		protected virtual void DrawLine(GraphPoint P1, GraphPoint P2, Graphics painter, Color col){
			painter.DrawLine (new Pen (col, 2), P1, P2);
		}

		/* A function that draws a line with a constant lenght from a centerpoint
		 * painter: The graphics object used to draw
		 * centerPoint: The centerpoint of the line
		 */
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

		/* A method that calculates the centerpoint of the next partition
		 * currentPoint: The current centerpoint of a partition
		 */
		protected GraphPoint CalcNextPartition(GraphPoint currentPoint){
			if (this.GetType() == typeof(xAxis)) {
				currentPoint.X += _pixelPartition;
			}
			else if (this.GetType() == typeof(yAxis)){
				currentPoint.Y += currentPoint.Y;
			}
			return currentPoint;
		}

		/* A method that scales the range parting of the axis
		 * 
		 */
		public void ScaleAxis(){
			float PixelLengthOfAxis = 1;

			//Determines the lenght based on which axis is used
			if (this.GetType () == typeof(yAxis)) {
				PixelLengthOfAxis = _endsAt.Y - _beingsAt.Y;
			} 
			else if (this.GetType () == typeof(xAxis)){
				PixelLengthOfAxis = _endsAt.X - _endsAt.Y;
			}

			_pixelPartition = PixelLengthOfAxis / (float) Math.Ceiling(CalculateAxisRange());
		}

		/* A method to increase the range of an axis and update _pixelPartition
		 * rangeIncrease: the factor to increase with
		 */
		public void IncreaseRange(double rangeIncrease){
			_maxRange += rangeIncrease;
			ScaleAxis();
		}

		protected double CalculateAxisRange(){
			return this._maxRange - this._minRange;
		}
	}
}

