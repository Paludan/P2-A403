using System;

namespace AmmoniaTest
{
	public class AmmoniaCalc
	{
		private double _nitrogen;
		private double _hydrogen;
		private double _ammonia;
		private double _RRConst;

		private double a;
		private double b;
		private double c;
		private double d;
		private double e;

		private double p1;
		private double p2;
		private double p3;
		private double p4;
		private double p5;
		private double p6;

		public AmmoniaCalc ()
		{
		}

		public double solveQuadricEquation(double nit, double hyd, double amm, double rr){
			_nitrogen = nit;
			_hydrogen = hyd;
			_ammonia = amm;
			_RRConst = rr;

			Initialize ();

			double solution = findSolution ();

			return solution;
		}

		private void Initialize(){
			AssignABCDEvalues ();
			P1 ();
			P2 ();
			P3 ();
			P4 ();
			P5 ();
			P6 ();
		}

		private void AssignABCDEvalues(){
			a = 27 * _RRConst;
			Console.WriteLine ("a: " + a);
			b = -_RRConst * (27 * _hydrogen + 27 * _nitrogen);
			Console.WriteLine ("b: " + b);
			c = (_RRConst * (9*Math.Pow(_hydrogen, 2) + 27*_hydrogen*_nitrogen)+1);
			Console.WriteLine ("c: " + c.ToString("E"));
			d = (_RRConst*(-Math.Pow(_hydrogen, 3) - 9*Math.Pow(_hydrogen,2)*_nitrogen)+4*_ammonia);
			Console.WriteLine ("d: " + d.ToString("E"));
			e = _RRConst * Math.Pow (_hydrogen, 3) * _nitrogen - _ammonia;
			Console.WriteLine ("e: " + e.ToString("G"));
		}

		private void P1(){
			p1 = (2*Math.Pow(c, 3)) - (9*b*c*d) + (27*a*Math.Pow(d, 2)) + (27*Math.Pow(b, 2)*e) - (72*a*c*e);
			Console.WriteLine ("p1: " + p1.ToString("E"));
		}

		private void P2(){
			p2 = p1 + Math.Sqrt(-4*Math.Pow(Math.Pow(c, 2) - 3*b*d + 12*a*e, 3)+Math.Pow(p1, 2));
			Console.WriteLine ("p2: " + p2.ToString("E"));
		}

		private void P3(){
			double crt = Math.Pow(p2 / 2, 1f/3f);
			double upper = Math.Pow (c, 2) - 3 * b * d + 12 * a * e;

			p3 = (upper / (3 * a * crt)) + (crt / (3 * a));
			Console.WriteLine ("p3: " + p3);
		}

		private void P4(){
			double first = Math.Pow(b, 2) / (4 * Math.Pow(a, 2));
			double second = (2 * c) / (3 * a);

			p4 = Math.Sqrt(first - second + p3);
			Console.WriteLine ("p4: " + p4);
		}

		private void P5(){
			double first = Math.Pow(b, 2) / (2 * Math.Pow(a, 2));
			double second = (4 * c) / (3 * a);

			p5 = first - second - p3;
			Console.WriteLine ("p5: " + p5);
		}

		private void P6(){
			double upperFirst = (Math.Pow(b, 3) / Math.Pow(a, 3));
			double upperSevond = (4 * b * c) / Math.Pow (a, 2);
			double upperLast = (8 * d) / a;

			p6 = (-upperFirst + upperSevond - upperLast) / (4 * p4);
			Console.WriteLine ("p6: " + p6);
		}

		private double findSolution(){
			double first = b / (4 * a);
			double second = p4 / 2;
			double[] solutions = new double[4];
			double result = 0;

			double sqrt = Math.Sqrt (p5 - p6) / 2;
			solutions[0] = firstSolution (first, second, sqrt);
			solutions[1] = secondSolution (first, second, sqrt);

			sqrt = Math.Sqrt (p5 + p6) / 2;
			solutions[2] = thirdSolution (first, second, sqrt);
			solutions[3] = fourthSolution (first, second, sqrt);

			foreach (var solution in solutions) {
				if (!double.IsNaN (solution) && Math.Ceiling(solution) < _nitrogen) {
					result = solution;
				}
			}

			return result;
		}

		private double firstSolution(double first, double second, double third){
			return (-first - second - third);
		}

		private double secondSolution(double first, double second, double third){
			return(-first -second + third);
		}

		private double thirdSolution(double first, double second, double third){
			return (-first + second - third);
		}

		private double fourthSolution(double first, double second, double third){
			return (-first + second + third);
		}
	}
}

