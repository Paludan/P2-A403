using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{

    //This class runs the simulation and presents results
    public class Model
    {
		private const double gasConstant = 8.3145;
        private const double preExpontentialFaktor = 8.849;//* Math.Pow (10, 14);


		private DataPoint currentState = new DataPoint (); //wut

        /* The constructor for Model
         * Variable
         * Variable
         * Output
         */
        public Model(double iTemperature, double nHydrogen, double nNitrogen, double nAmmonia, bool catalyst, double time, double volume)
        {

        }

        private double calculatePartialPressure(double temperature, double nSubstance, double volume)
        {
			double partialPressure = (nSubstance * gasConstant * temperature) / volume;

			return partialPressure;
        }

        private double calculateEquillibriumConstant(double temperature)
        {
			double equiConst = Math.Pow(Math.E, -((-91.8 * 1000)/ (temperature * 8.314472)) + (-198.05/8.314472));

            return equiConst;
        }

		/* Er usikker om dette er gjort rigtigt */
        private double calculateAmmoniaAtEquillibrium(double nHydrogen, double nNitrogen, double equiConst)
        {
			double nAmmonia = equiConst * Math.Pow(nHydrogen, 3) * nNitrogen;
		
			return Math.Sqrt(nAmmonia);
        }

        private double calculateActivationEnergy(bool catalyst)
        {
			double activationEnergy = 0;

			if (catalyst)
				activationEnergy = 60;
			else if (!catalyst) // can also be written as else instead of else if (...)
				activationEnergy = 1100;

            return activationEnergy;
        }

        private double calculateReactionRateConstant(double temperature, double activationEnergy)
        {
			double RRConst = preExpontentialFaktor * Math.Pow(Math.E, -(activationEnergy/(gasConstant*temperature)));

            return RRConst;
        }

        private double calculateActualPartialPressure(double RRConst)
        {
            double nAmmonia = 0;

            return nAmmonia;
        }

        private double calculateActualPressure(double pAmmonia, double pNitrogen, double pHydrogen)
        {
			double pressure = pAmmonia + pNitrogen + pHydrogen;

            return pressure;
        }

		/* Er usikker om dette er gjort rigtigt */
		private bool isAtEquillibrium(double pAmmonia, double pNitrogen, double pHydrogen, double equiConst)
        {
            bool atEquillibrium = false;
			double equiFrac = Math.Pow(pAmmonia,2) / (pNitrogen * Math.Pow(pHydrogen, 3));

			if (equiFrac.Equals (equiConst))
				atEquillibrium = true;
				
            return atEquillibrium;
        }

		private void UpdateCurrentState ()
		{
			// Herinde opdatere datapointet currentState
		}

		private void updateReagent ()
		{

			//lav som properties
		}


		public DataPoint runSimulation ()
        {
            DataPoint tempDP = new DataPoint();

            return tempDP;
        }
    }
}
