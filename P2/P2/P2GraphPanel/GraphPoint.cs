using System;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public struct GraphPoint : IDrawable
	{
		//Do something to convert points
		private const float yOffset = 0.90f;
		private const float xOffset = 0.10f;

		public float X;
		public float Y;
		private MasterGraphPanel _MGP;

		/* Constructor for the GraphPoint-struct
		 * x: The X-value of the point
		 * y: The Y-value of the point
		 */
		public GraphPoint (double x, double y, MasterGraphPanel gPanel)
		{
			this.X = (float) x;
			this.Y = (float) y;
			this._MGP = gPanel;
		}

		/* A method to draw the point to a panelq
		 * drawingPanel: the panel being drawn to
		 * painter: the Graphics object, that does the actual drawing
		 */
		public void Draw (Graphics painter)
		{
			RectangleF pointCentre = new RectangleF (X, Y, 3, 3);
			painter.DrawEllipse (new Pen(Brushes.Blue, 2), pointCentre);
		}

		static public implicit operator PointF(GraphPoint GP){
			return new PointF(GP.X, GP.Y);
		}
	}
}

