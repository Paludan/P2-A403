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
        public Model(decimal iTemperature, decimal nHydrogen, decimal nNitrogen, decimal nAmmonia, bool catalyst, decimal time, decimal volume)
        {

        }

        private decimal calculatePartialPressure(decimal temperature, decimal nSubstance, decimal volume)
        {
			decimal partialPressure = (nSubstance * gasConstant * temperature) / volume;

			return partialPressure;
        }

        private decimal calculateEquillibriumConstant(decimal temperature)
        {
			decimal equiConst = Math.Pow(Math.E, -((-91.8 * 1000)/ (temperature * 8.314472)) + (-198.05/8.314472));

            return equiConst;
        }

		/* Er usikker om dette er gjort rigtigt */
        private decimal calculateAmmoniaAtEquillibrium(decimal nHydrogen, decimal nNitrogen, decimal equiConst)
        {
			decimal nAmmonia = equiConst * Math.Pow(nHydrogen, 3) * nNitrogen;
		
			return Math.Sqrt(nAmmonia);
        }

        private decimal calculateActivationEnergy(bool catalyst)
        {
			decimal activationEnergy = 0;

			if (catalyst)
				activationEnergy = 60;
			else if (!catalyst) // can also be written as else instead of else if (...)
				activationEnergy = 1100;

            return activationEnergy;
        }

        private decimal calculateReactionRateConstant(decimal temperature, decimal activationEnergy)
        {
			decimal RRConst = preExpontentialFaktor * Math.Pow(Math.E, -(activationEnergy/(gasConstant*temperature)));

            return RRConst;
        }

        private decimal calculateActualPartialPressure(decimal RRConst)
        {
            decimal nAmmonia = 0;

            return nAmmonia;
        }

        private decimal calculateActualPressure(decimal pAmmonia, decimal pNitrogen, decimal pHydrogen)
        {
			decimal pressure = pAmmonia + pNitrogen + pHydrogen;

            return pressure;
        }

		/* Er usikker om dette er gjort rigtigt */
		private bool isAtEquillibrium(decimal pAmmonia, decimal pNitrogen, decimal pHydrogen, decimal equiConst)
        {
            bool atEquillibrium = false;
			decimal equiFrac = Math.Pow(pAmmonia,2) / (pNitrogen * Math.Pow(pHydrogen, 3));

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
