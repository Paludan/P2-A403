using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class yAxis : AbstractAxis
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.yAxis"/> class.
		/// </summary>
		/// <param name="AxisName">Name of the y-axis.</param>
		/// <param name="gPanel">The <see cref="P2Graph.MasterGraphPanel"/> on which to draw the axis.</param>
		public yAxis (string AxisName, MasterGraphPanel gPanel)
			: base (AxisName, gPanel)
		{
		}

		/// <summary>
		/// Calculates the axis ends.
		/// </summary>
		protected override void CalculateAxisEnds ()
		{
			this._endsAt.RealX = _MGP.O.X;
			this._endsAt.RealY = _MGP.Height * (1 - Constants.endOffset);
		}

		/// <summary>
		/// Draws the arrow ends.
		/// </summary>
		/// <param name="g">The graphics component with which to draw.</param>
		protected override void DrawArrowEnds (Graphics g)
		{
			PointF[] pointList = new PointF[3] { new PointF(_endsAt.RealX, _endsAt.RealY - 15), 
				new PointF (_endsAt.RealX - 7, _endsAt.RealY),
				new PointF (_endsAt.RealX + 7, _endsAt.RealY)};

			g.FillPolygon (Brushes.Black, pointList);
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the axis with a specified Graphics object.
		/// </summary>
		/// <param name="painter">A graphics object to draw with.</param>
		public void Draw (Graphics painter)
		{
			GraphPoint GP = _beginsAt;

			DrawLine (_beginsAt, _endsAt, painter, Color.Black);
			DrawArrowEnds (painter);

			int dist = CalculateDistanceBetweenPartitions ();

			//Calculates the next partition and draws untill the last partition has been drawn
			for (int i = 0; i < _maxRange; i++) {
				GP = CalcNextPartition (GP);
				if (i % dist == 0) {
					DrawPartition (painter, GP, i + 1);
				}
			}
		}
		#endregion

		protected override GraphPoint CalcNextPartition (GraphPoint currentPoint)
		{
			currentPoint.RealY -= Constants.yPixelScale;

			return currentPoint;
		}

		protected override void DrawPartition (Graphics painter, GraphPoint centerPoint, int partitionNumber)
		{
			GraphPoint beginning = centerPoint, end = centerPoint;

			//Calculates the ends of the partition-line
			beginning.RealX -= 4;
			end.RealX += 4;

			DrawLine (beginning, end, painter, Color.Black);
			end.RealX -= Constants.partitionOffset;
			DrawNumber(painter, end, partitionNumber.ToString());
		}

		public void Scale ()
		{
			float PixelLengthOfAxis = this._beginsAt.RealY - this._endsAt.RealY;
			Constants.yPixelScale = PixelLengthOfAxis / (float) Math.Ceiling(CalculateAxisRange());
		}
	}
}

