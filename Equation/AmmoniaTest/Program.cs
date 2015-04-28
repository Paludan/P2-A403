using System;

namespace AmmoniaTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			AmmoniaCalc ac = new AmmoniaCalc ();

			double solution = ac.solveQuadricEquation (200, 200, 12, 0.25);
			Console.WriteLine ("\nSolution: " + solution);
		}
	}
}
