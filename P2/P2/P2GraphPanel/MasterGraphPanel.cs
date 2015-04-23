﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace P2Graph
{
	public class MasterGraphPanel : Panel
	{
		#region Properties
		public List<Graph> graphList = new List<Graph> ();
		private List<IDrawable> otherObjects = new List<IDrawable> ();
		private PointF _O;
		private xAxis X;
		private yAxis Y;
		private Graphics _g;

		/// <summary>
		/// Gets or sets the max range of x-axis.
		/// </summary>
		/// <value>The max range.</value>
		public int xMaxRange{
			get { return X.maxRange; }
			set { X.maxRange = value; }
		}

		/// <summary>
		/// Gets or sets the max range of y-axis.
		/// </summary>
		/// <value>The max range.</value>
		public int yMaxRange{
			get { return Y.maxRange; }
			set { Y.maxRange = value; }
		}

		/// <summary>
		/// Gets the (0, 0)-coordinate.
		/// </summary>
		public PointF O {
			get { return _O; }
		}
		#endregion

		#region Setup
		/// <summary>
		/// Initializes a new instance of the <see cref="P2Graph.MasterGraphPanel"/> class.
		/// </summary>
		public MasterGraphPanel ()
			: base ()
		{
			this.Size = new Size (620, 500);
			CalculateOrego ();
			CreateAxis("x-akse", "y-akse");
			_g = this.CreateGraphics ();
			X.Scale ();
			Y.Scale ();
		}

		/// <summary>
		/// Calculates the orego.
		/// </summary>
		private void CalculateOrego(){
			this._O = new PointF (this.Width * Constants.xOffset, this.Height * Constants.yOffset);
		}

		/// <summary>
		/// Creates the x- and y-axis.
		/// </summary>
		/// <param name="xName">Name of the x-axis.</param>
		/// <param name="yName">Name of the y-axis.</param>
		private void CreateAxis(string xName, string yName){
			if (xName.Length > 12 || yName.Length > 12) {
				throw new NameTooLongException ();
			} else {
				X = new xAxis (xName, this);
				Y = new yAxis (yName, this);
			}
		}
		#endregion

		#region Controls
		/// <summary>
		/// Updates the panel.
		/// </summary>
		public void UpdateMGP(){
			ScaleAxis ();
			graphList.ForEach (graph => graph.Update ());
			otherObjects.ForEach (drawable => drawable.Update ());
		}

		/// <summary>
		/// Adds a drawable to the MasterGraphPanel.
		/// </summary>
		/// <param name="drawableObject">Object implementing the IDrawable interface.</param>
		public void AddDrawable(IDrawable drawableObject){
			otherObjects.Add (drawableObject);
		}

		/// <summary>
		/// Scales the axis and redraws, if ranges have been changed.
		/// </summary>
		private void ScaleAxis(){
			bool updateAxis;

			updateAxis = CheckAxisRanges ();
			X.Scale ();
			Y.Scale ();

			if (updateAxis) {
				this.Invalidate ();
			}
		}

		/// <summary>
		/// Checks the axis ranges and scales if nessasary.
		/// </summary>
		/// <returns><c>true</c>, if axis ranges was changed, <c>false</c> otherwise.</returns>
		private bool CheckAxisRanges(){
			bool axisChanged = false;

			foreach (var item in graphList) {
				double xMax = item.largestX, yMax = item.largestY;

				if (this.xMaxRange < xMax) {
					this.xMaxRange = (int) Math.Ceiling(xMax + 2);
					axisChanged = true;
				}

				if (this.yMaxRange < yMax) {
					this.yMaxRange = (int) Math.Ceiling(yMax + 2);
					axisChanged = true;
				}
			}

			return axisChanged;
		}

		/// <summary>
		/// Changes the axis names.
		/// </summary>
		/// <param name="xName">X-axis name.</param>
		/// <param name="yName">Y-axis name.</param>
		public void ChangeAxisNames(string xName, string yName){
			if (xName.Length > 12 || yName.Length > 12) {
				throw new NameTooLongException ();
			} else {
				X.name = xName;
				Y.name = yName;
			}
		}

		/// <summary>
		/// Adds the graph to the Panel.
		/// </summary>
		/// <param name="addedGraph">Added graph.</param>
		public void AddGraph(Graph addedGraph){
			if (graphList.Count + 1 > 5) {
				throw new TooManyGraphsException ();
			} else {
				addedGraph.MGP = this;
				graphList.Add (addedGraph);
			}
		}
		#endregion

		#region Draw-methods
		/// <summary>
		/// Paints the active content in the GraphPanel.
		/// </summary>
		public void PaintContent(){
			this.UpdateMGP ();
			this.Draw (_g);
		}

		/// <summary>
		/// Delegate method for the invalidate event.
		/// </summary>
		/// <param name="sender">Not used.</param>
		/// <param name="e">Not used.</param>
		public void OnInvalidateEvent(object sender, PaintEventArgs e){
			this.BackColor = Color.WhiteSmoke;
			this.UpdateMGP ();

			X.Draw (_g);
			Y.Draw (_g);
		}

		/// <summary>
		/// Updates the displayed graph by drawing last point.
		/// </summary>
		/// <param name="updateGraph">The graph being updated.</param>
		public void UpdateGraph (Graph updateGraph){
			if (updateGraph.isActive) {
				updateGraph.DrawLastLine (_g);
			}
		}

		/// <summary>
		/// Draw the MasterGraphPanel with all it's components.
		/// </summary>
		/// <param name="g">The graphics component.</param>
		private void Draw (Graphics g)
		{
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
		/// Scales and draws the legends on the panel.
		/// </summary>
		/// <param name="g">The graphics component.</param>
		private void DrawLegends(Graphics g){
			int width = this.Width - 100;
			Font legendFont = new Font("Microsoft Sans Serif", 30);
			while (80 < System.Windows.Forms.TextRenderer.MeasureText("Temperatur", new Font(legendFont.FontFamily,
				legendFont.Size, legendFont.Style)).Width)
				legendFont = new Font(legendFont.FontFamily, legendFont.Size - 0.01f, legendFont.Style);

			for (int i = 0; i < graphList.Count; i++) {
				if (graphList [i].isActive) {
					SolidBrush drawPen = new SolidBrush (graphList [i].color);
					PointF drawPoint = new PointF (width + 5, 2);

					g.DrawRectangle (new Pen (graphList [i].color, 1), width, 0, 80, 20);
					g.DrawString (graphList [i].name, legendFont, drawPen, drawPoint);   
					width -= 100;
				}
			}
		}
		#endregion
	}
}