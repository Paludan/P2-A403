using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class yAxis : AbstractAxis, IDrawable
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
			this._beingsAt.X = _MGP.Height * Constants.yOffset;
			this._beingsAt.Y = _MGP.Width * Constants.yOffset;

			this._endsAt.X = _MGP.Height * Constants.endOffset;
			this._endsAt.Y = _MGP.Width * Constants.yOffset;
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the axis with a specified Graphics object.
		/// </summary>
		/// <param name="painter">A graphics object to draw with.</param>
		public void Draw (Graphics painter)
		{
			GraphPoint GP = _beingsAt;

			DrawLine (_beingsAt, _endsAt, painter, Color.Black);

			ScaleAxis ();
			//Calculates the next partition and draws untill the last partition has been drawn
			while (GP.Y <= _endsAt.Y) {
				GP = CalcNextPartition (GP);
				DrawPartition (painter, GP);
			}
		}
		#endregion
	}
}

