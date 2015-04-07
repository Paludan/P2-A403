using System;

namespace Equilator
{
	//This class runs the simulation and presents results
	public class Model
	{
		/* The constructor for Model
		 * Variable
		 * Variable
		 * Output
		 */
		public Model (double iTemperature, double nHydrogen, double nNitrogen, double nAmmonia, bool catalyst, double time, double volume)
		{

		}

		private double calculatePartialPressure(double temperature, double nSubstance, double Volume){
			double pSubstance;


			return pSubstance;
		}

		private double calculateEquillibriumConstant(double temperature){
			double equiConst;

			return equiConst;
		}

		private double calculateAmmoniaAtEquillibrium(double nHydrogen, double nNitrogen, double EquillibriumConstant){
			double nAmmonia;

			return nAmmonia;
		}

		private double calculateActivationEnergy(bool catalyst){
			double activationEnergy;

			return activationEnergy;
		}

		private double calculateReactionRateConstant(double temperature, double activationEnergy){
			double RRConst;

			return RRConst;
		}

		private double calculateActualPartialPressure(double RRConst){
			double nAmmonia;

			return nAmmonia;
		}

		private double calculateActualPressure(double pAmmonia, double pNitrogen, double pHydrogen){
			double pressure;

			return pressure;
		}

		private bool isAtEquillibrium(double pAmmonia){
			bool atEquillibrium;

			return atEquillibrium;
		}

		private DataPoint saveToStruct(){
			DataPoint tempDP;

			return tempDP;
		}
	}
}

