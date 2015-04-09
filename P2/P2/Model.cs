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
        private const double preExpontentialFaktor = 8.849 * Math.Pow (10, 14);
		private const double volume = 50000; // liter
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
        private double calculateAmmoniaAtEquillibrium(double pHydrogen, double pNitrogen, double equiConst)
        {
			double pAmmonia = equiConst * Math.Pow(pHydrogen, 3) * pNitrogen;
		
			return Math.Sqrt(pAmmonia);
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

		private double calculateAmmoniaActualPartialPressure(double RRConst, double deltaTime)
        {
            double pAmmonia = 0;

			/* Beregner det aktuelle partialtryk, hvor tiden skal
			 * være med som en faktor, derfor er den tom lige nu
			 * da det er lidt kringlet
			 */

			pAmmonia = calculatePartialPressure (currentState.temperature, currentState.nAmmonia, volume) * Math.Pow(Math.E, (-RRConst * deltaTime));

			return pAmmonia;
        }
			
		private double calculateMolarAmount (double pReagent)
		{
			double molarAmount = (pReagent * volume) / (gasConstant * currentState.temperature);

			return molarAmount;
		}

        private double calculateActualPressure(double pAmmonia, double pNitrogen, double pHydrogen)
        {
			double pressure = pAmmonia + pNitrogen + pHydrogen;

            return pressure;
        }

		/* Er usikker om dette er gjort rigtigt */
		bool isAtEquillibrium(double pAmmonia, double pNitrogen, double pHydrogen, double equiConst)
        {
            bool atEquillibrium = false;
			double equiFrac = Math.Pow(pAmmonia,2) / (pNitrogen * Math.Pow(pHydrogen, 3));

			if (equiFrac.Equals (equiConst))
				atEquillibrium = true;
				
            return atEquillibrium;
        }


		public bool IsAtEquillibrium{

			get
			{
				return isAtEquillibrium (
					calculatePartialPressure(currentState.temperature, currentState.nAmmonia, volume), 
					calculatePartialPressure(currentState.temperature, currentState.nNitrogen, volume), 
					calculatePartialPressure(currentState.temperature, currentState.nHydrogen, volume), 
					calculateEquillibriumConstant(currentState.temperature));
			}
		}


		private void UpdateCurrentState (DataPoint currentState, double nAmmonia, double nHydrogen , double nNitrogen, double temperature, double actualPressure, double time, bool catalyst)
		{
			currentState (nAmmonia, nHydrogen, nNitrogen, temperature, actualPressure, time, catalyst);

		}

		private void updateReagent ()
		{

			//lav som properties
		}


		public DataPoint calculateDataPoint (double deltaTime)
        {
			DataPoint nextState = new DataPoint (currentState);

			double equiConst = 0, equiAmmonia = 0, 
			pHydrogen = calculatePartialPressure (currentState.temperature, currentState.nHydrogen, volume), 
			pNitrogen = calculatePartialPressure (currentState.temperature, currentState.nNitrogen, volume), 
			pAmmonia = 0;
		
			/* calculate the molar amounts */
			nextState.nHydrogen = calculateMolarAmount(pHydrogen);
			nextState.nNitrogen = calculateMolarAmount(pNitrogen);
		
			/* calculate equillibrium constant */
			equiConst = calculateEquillibriumConstant (currentState.temperature);

			/* calculate amount of ammonia */
			equiAmmonia = calculateAmmoniaAtEquillibrium (pHydrogen, pNitrogen, equiConst);

			pAmmonia = calculateAmmoniaActualPartialPressure (
				calculateReactionRateConstant (currentState.temperature, 
				calculateActivationEnergy (currentState.catalyst)), deltaTime);
					
			nextState.nAmmonia = calculateMolarAmount(pAmmonia);
		
			pAmmonia = calculatePartialPressure (currentState.temperature, equiAmmonia, volume);
		}
    }
}
