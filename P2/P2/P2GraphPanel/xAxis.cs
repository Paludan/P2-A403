using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class xAxis : AbstractAxis
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.xAxis"/> class.
		/// </summary>
		/// <param name="AxisName">The name of the x-axis.</param>
		/// <param name="gPanel">The <see cref="P2Graph.MasterGraphPanel"/> on which to draw the axis.</param>
		public xAxis (string AxisName, MasterGraphPanel gPanel)
			: base (AxisName, gPanel)
		{
		}

		/// <summary>
		/// Calculates the axis ends.
		/// </summary>
		protected override void CalculateAxisEnds ()
		{
			this._endsAt.RealX = _MGP.Width * Constants.endOffset;
			this._endsAt.RealY = _MGP.O.Y;
		}

		/// <summary>
		/// Draws the arrow ends.
		/// </summary>
		/// <param name="g">The graphics component to draw with.</param>
		protected override void DrawArrowEnds (Graphics g)
		{
			PointF[] pointList = new PointF[3] { new PointF(_endsAt.RealX + 15, _endsAt.RealY), 
												 new PointF (_endsAt.RealX, _endsAt.RealY - 7),
												 new PointF (_endsAt.RealX, _endsAt.RealY + 7)};

			g.FillPolygon (Brushes.Black, pointList);
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the xAxis to a panel.
		/// </summary>
		/// <param name="painter">Graphics object from the panel on which to draw</param>
		public void Draw (Graphics painter)
		{
			GraphPoint GP = _beginsAt;

			DrawLine (_beginsAt, _endsAt, painter, Color.Black);
			DrawArrowEnds (painter);

			int dist = CalculateDistanceBetweenPartitions();

			//Calculates the next partition and draws untill the last partition has been drawn
			for (int i = 0; i < _maxRange; i++) {
				GP = CalcNextPartition (GP);
				if (i % dist == 0) {
					DrawPartition (painter, GP, i + 1);
				}
			}
		}
		#endregion

		/// <summary>
		/// Calculates the next partition.
		/// </summary>
		/// <returns>The next partition.</returns>
		/// <param name="currentPoint">Current point.</param>
		protected override GraphPoint CalcNextPartition(GraphPoint currentPoint){
			currentPoint.RealX += Constants.xPixelScale;

			return currentPoint;
		}

		/// <summary>
		/// Draws the partition.
		/// </summary>
		/// <param name="painter">The graphics object with which to draw.</param>
		/// <param name="centerPoint">Center point of the partition.</param>
		protected override void DrawPartition(Graphics painter, GraphPoint centerPoint, int partitionNumber){
			GraphPoint beginning = centerPoint, end = centerPoint;

			//Calculates the ends of the partition-line
			beginning.RealY -= 4;
			end.RealY += 4;
			
			DrawLine (beginning, end, painter, Color.Black);
			end.RealY += Constants.partitionOffset;
			DrawNumber(painter, end, partitionNumber.ToString());
		}

		public void Scale ()
		{
			float PixelLengthOfAxis = this._endsAt.RealX - this._beginsAt.RealX;
			Constants.xPixelScale = PixelLengthOfAxis / (float) Math.Ceiling(CalculateAxisRange());
		}
	}
}

