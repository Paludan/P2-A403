using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class MasterGraphPanel : Panel
	{
		private List<Graph> graphList = new List<Graph> ();
		private List<IDrawable> otherObjects = new List<IDrawable> ();
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
			ScaleAxis ();
			graphList.ForEach (graph => graph.Update ());
			otherObjects.ForEach (drawable => drawable.Update ());
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
		public void AddGraph(Graph addedGraph){
			if (graphList.Count + 1 > 5) {
				throw new TooManyGraphsException ();
			} else {
				graphList.Add (addedGraph);
			}
		}

		public void AddDrawable(IDrawable drawableObject){
			otherObjects.Add (drawableObject);
		}

		public void SetActive(bool activeness, int index){
			if (index < graphList.Count)
				graphList [index].isActive = activeness;
			else
				throw new IndexOutOfRangeException ("The index of the selected graph is out of range!");
		}

		/* Draws all the names of the graphs in the graphlist
		 */
		private void DrawLegends(Graphics g){
			int width = this.Width - 100;

			for (int i = 0; i < graphList.Count; i++) {
				SolidBrush drawPen = new SolidBrush(graphList[i].color);
				PointF drawPoint = new PointF (width + 5, 2);

				g.DrawRectangle (new Pen (graphList[i].color, 1), width, 0, 80, 20);
				g.DrawString (graphList[i].name, Constants.GraphFont, drawPen, drawPoint);   
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
					if (graph.isActive) {
						graph.Draw (g);
					}
				}
			}
			if (otherObjects.Count > 0) {
				foreach (var drawable in otherObjects) {
					drawable.Draw (g);
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
		/// <summary>
		/// Fully paints the panel, including axes and graphs.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event.</param>
		public void EventHandler_RePaint( object sender, PaintEventArgs e ){
			Graphics g = e.Graphics;

			this.UpdateMGP();

			this.Draw (g);
		}

		/// <summary>
		/// Update-event, invoked when adding point to a graph.
		/// </summary>
		/// <param name="sender">The graph, whivh invokes the event.</param>
		/// <param name="e">Event-information.</param>
		public void EventHandler_UpdatePanel( object sender, PaintEventArgs e ){
			Graphics g = e.Graphics;
			var graph = sender.GetType();

//			if (graph.largestX >= this.xMaxRange) {
//				this.xMaxRange = (int)Math.Ceiling (graph.largestX + 10);
//				this.EventHandler_RePaint (sender, e);
//			} else if (graph.largestY >= this.yMaxRange) {
//				this.yMaxRange = (int)Math.Ceiling (graph.largestY + 10);
//				this.EventHandler_UpdatePanel (sender, e);
//			} else {
//				graph.DrawLastLine (g);
//			}
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

