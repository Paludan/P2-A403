using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class xAxis : AbstractAxis, IDrawable
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
			this._beingsAt.X = _MGP.Height * Constants.xOffset;
			this._beingsAt.Y = _MGP.Width * Constants.xOffset;

			this._endsAt.X = _MGP.Height * Constants.xOffset;
			this._endsAt.Y = _MGP.Width * Constants.endOffset;
		}

		#region IDrawable implementation
		/// <summary>
		/// Draw the xAxis to a panel.
		/// </summary>
		/// <param name="painter">Graphics object from the panel on which to draw</param>
		public void Draw (Graphics painter)
		{
			GraphPoint GP = _beingsAt;

			DrawLine (_beingsAt, _endsAt, painter, Color.Black);

			ScaleAxis ();
			//Calculates the next partition and draws untill the last partition has been drawn
			while (GP.X <= _endsAt.X) {
				GP = CalcNextPartition (GP);
				DrawPartition (painter, GP);
			}
		}
		#endregion
	}
}

