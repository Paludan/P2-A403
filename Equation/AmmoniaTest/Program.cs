using System;

namespace AmmoniaTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			AmmoniaCalc ac = new AmmoniaCalc ();

			double solution = ac.solveQuadricEquation (1898, 5694, 0, 0.05);
			Console.WriteLine ("\nSolution: " + solution);
            Console.ReadKey();
		}
	}
}
