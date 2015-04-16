using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class MasterGraphPanel : Panel
	{
		private List<Graph> graphList = new List<Graph> ();
		private PointF _O;

		private xAxis X;
		public int xMaxRange{
			get { return X.maxRange; }
			set { X.maxRange = value; this.UpdateMGP (); }
		}

		private yAxis Y;
		public int yMaxRange{
			get { return Y.maxRange; }
			set { Y.maxRange = value; this.UpdateMGP (); }
		}

		/// <summary>
		/// Gets the (0, 0)-coordinate.
		/// </summary>
		public PointF O {
			get { return _O; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.MasterGraphPanel"/> class.
		/// </summary>
		public MasterGraphPanel ()
			: base ()
		{
			this.Size = new Size (620, 500);
			CalculateOrego ();
		}

		/// <summary>
		/// Calculates the orego.
		/// </summary>
		public void CalculateOrego(){
			this._O = new PointF (this.Width * Constants.xOffset, this.Height * Constants.yOffset);
		}

		/// <summary>
		/// Updates the panel.
		/// </summary>
		public void UpdateMGP(){
			CalculateOrego ();
			graphList.ForEach (graph => graph.Update ());
			X.Update ();
			Y.Update ();
			ScaleAxis ();
		}

		/// <summary>
		/// Creates the x- and y-axis with given parameters, also creates orego.
		/// </summary>
		/// <param name="xName">Name of the x-axis.</param>
		/// <param name="yName">Name of the y-axis.</param>
		public void CreateAxis(string xName, string yName){
			X = new xAxis (xName, this);
			Y = new yAxis (yName, this);
		}

		/// <summary>
		/// Adds a graph with a specified color.
		/// </summary>
		/// <param name="addedGraph">A list of <see cref="P2Graph.GraphPoint"/> /> .</param>
		/// <param name="name">The name of the graph</param>
		/// <param name="colOfGraph">Color of the graph</param>
		public void AddGraph(List<GraphPoint> addedGraph, string name, Color colOfGraph){
			Graph newGraph = new Graph (name, colOfGraph);

			if (graphList.Count + 1 > 5) {
				throw new TooManyGraphsException ();
			}

			X.maxRange = (int) Math.Ceiling(addedGraph [addedGraph.Count - 1].xCoord);

			foreach (GraphPoint GP in addedGraph) {
				newGraph.addPoint (GP);
			}
			graphList.Add (newGraph);
		}

		/* Draws all the names of the graphs in the graphlist
		 */
		private void DrawLegends(Graphics g){
			int width = this.Width - 100;

			for (int i = 0; i < graphList.Count; i++) {
				SolidBrush drawBrush = new SolidBrush(graphList[i].color);
				PointF drawPoint = new PointF (width + 5, 2);

				g.DrawRectangle (new Pen (graphList[i].color, 1), width, 0, 80, 20);
				g.DrawString (graphList[i].name, Constants.GraphFont, drawBrush, drawPoint);   
				width -= 100;	

			}
		}

		/// <summary>
		/// Draw the MasterGraphPanel with all it's components.
		/// </summary>
		/// <param name="g">The graphics component generated on creationg.</param>
		public void Draw (Graphics g)
		{
			ScaleAxis ();

			this.BackColor = Color.WhiteSmoke;
			X.Draw (g);
			Y.Draw (g);
			if (graphList.Count > 0) {
				foreach (var graph in graphList) {
					graph.Draw (g);
				}
			}
			DrawLegends (g);
		}

		/// <summary>
		/// Scales the axis.
		/// </summary>
		public void ScaleAxis(){
			X.Scale ();
			Y.Scale ();
		}

		#region EventHandling
		public void EventHandler_InitialPaint( object sender, PaintEventArgs e )
		{
//			MasterGraphPanel p = sender as MasterGraphPanel;
			Graphics g = e.Graphics;

			this.UpdateMGP();

			this.Draw (g);
		}
		#endregion
	}

	
	[Serializable]
	public class TooManyGraphsException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyException"/> class
		/// </summary>
		public TooManyGraphsException () : base ("There were too many graphs")
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public TooManyGraphsException (string message) : base (message)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public TooManyGraphsException (string message, Exception inner) : base (message, inner)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyException"/> class
		/// </summary>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <param name="info">The object that holds the serialized object data.</param>
		protected TooManyGraphsException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
		{
		}
	}
}

