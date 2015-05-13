using System.Drawing;

namespace P2Graph
{
	/// <summary>
	/// IDrawable interface, can be added and drawn to <see cref="P2Graph.MasterGraphPanel"/> .
	/// </summary>
	public interface IDrawable
	{
		/// <summary>
		/// Draw the object to the <see cref="P2Graph.MasterGraphPanel"/> .
		/// </summary>
		/// <param name="painter">Graphics component.</param>
		void Draw(Graphics painter);

		/// <summary>
		/// Update this instance by scaling it to the axis.
		/// </summary>
		void Update();
	}
}

