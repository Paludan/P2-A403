using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class xAxis : AbstractAxis, IDrawable
	{
		private const float xOffset = 0.10f;

		/* Constructor for the xAxis-class
		 * Sets the name of the x-axis by calling the base constructor
		 */
		public xAxis (string AxisName, MasterGraphPanel gPanel)
			: base (AxisName, gPanel)
		{
		}

		/* A function to calculate and fill the beginning and ending points of the xAxis
		 * gPanel: The panel being drawn to
		 */
		protected override void CalculateAxisEnds ()
		{
			this._beingsAt.X = _MGP.Height * xOffset;
			this._beingsAt.Y = _MGP.Width * xOffset;

			this._endsAt.X = _MGP.Height * xOffset;
			this._endsAt.Y = _MGP.Width * 0.95f;
		}

		#region IDrawable implementation
		/* Draws the axis to the panel, also draws name
		 * drawingPanel: the panel being drawn to
		 * painter: the graphics object doing the actual drawing
		 */
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

