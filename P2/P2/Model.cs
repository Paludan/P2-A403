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
        /* The constructor for Model
         * Variable
         * Variable
         * Output
         */
        public Model(double iTemperature, double nHydrogen, double nNitrogen, double nAmmonia, bool catalyst, double time, double volume)
        {

        }

        private double calculatePartialPressure(double temperature, double nSubstance, double Volume)
        {
            double pSubstance = 0;


            return pSubstance;
        }

        private double calculateEquillibriumConstant(double temperature)
        {
            double equiConst = 0;

            return equiConst;
        }

        private double calculateAmmoniaAtEquillibrium(double nHydrogen, double nNitrogen, double EquillibriumConstant)
        {
            double nAmmonia = 0;

            return nAmmonia;
        }

        private double calculateActivationEnergy(bool catalyst)
        {
            double activationEnergy = 0;

            return activationEnergy;
        }

        private double calculateReactionRateConstant(double temperature, double activationEnergy)
        {
            double RRConst = 0;

            return RRConst;
        }

        private double calculateActualPartialPressure(double RRConst)
        {
            double nAmmonia = 0;

            return nAmmonia;
        }

        private double calculateActualPressure(double pAmmonia, double pNitrogen, double pHydrogen)
        {
            double pressure = 0;

            return pressure;
        }

        private bool isAtEquillibrium(double pAmmonia)
        {
            bool atEquillibrium = false;

            return atEquillibrium;
        }

        private DataPoint saveToStruct()
        {
            DataPoint tempDP = new DataPoint();

            return tempDP;
        }
    }
}
