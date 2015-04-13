using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class yAxis : AbstractAxis, IDrawable
	{
		/* Constructor for the y-axis
		 * Sets the name by calling base-csontructor
		 */
		private const float yOffset = 0.10f;
		public yAxis (string AxisName, MasterGraphPanel gPanel)
			: base (AxisName, gPanel)
		{
		}

		/* A function to calculate and fill the beginning and ending points of the xAxis
		 * gPanel: The panel being drawn to
		 */
		protected override void CalculateAxisEnds ()
		{
			this._beingsAt.X = _MGP.Height * yOffset;
			this._beingsAt.Y = _MGP.Width * yOffset;

			this._endsAt.X = _MGP.Height * 0.95f;
			this._endsAt.Y = _MGP.Width * yOffset;
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
			while (GP.Y <= _endsAt.Y) {
				GP = CalcNextPartition (GP);
				DrawPartition (painter, GP);
			}
		}
		#endregion
	}
}

