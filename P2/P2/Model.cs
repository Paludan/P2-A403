using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    class Model
    {
        /* the following 8 constant variables are constants that cannot be regulated */
        private double gasConstant = 8.314472;
        private double gasConstantCal = 1.987;
        private double preExpontentialFactor = 884900000000000;
        private double volume = 50000; //         liter
        private double entalpi = -91800; //       J/mol
        private double entropi = -198.05; //      J/(mol*kelvin)
        private double EaCatalyst = 60000; //     J/mol
        private double EaNoCatalyst = 120000; //  J/mol
        private double AmmoniaAtEQ;
        private AmmoniaCalc AC = new AmmoniaCalc();

        DataPoint currentState = new DataPoint();

        public double Ammonia { set { currentState.nAmmonia = (double)value; } }
        public double Hydrogen { set { currentState.nHydrogen = (double)value; } }
        public double Nitrogen { set { currentState.nNitrogen = (double)value; } }
        public double Temperature { set { currentState.temperature = (double)value; } }

        public Model(DataPoint InitData)
        {
            currentState = InitData;
            AmmoniaAtEQ = 0;
        }

        public DataPoint Fetch()
        {
            return currentState;
        }

        public DataPoint Update(double deltaTime)
        {
            DataPoint NextState;
            CalculateNextState(deltaTime, out NextState);
            //if (NextState.nHydrogen >= 0 && NextState.nNitrogen >= 0 && NextState.nAmmonia >= 0)
                currentState = NextState;
            return currentState;
        }

        private void CalculateNextState(double deltaTime, out DataPoint nextState)
        {
            nextState = new DataPoint();

            double pNitrogen = CalculatePartialPressure(currentState.nNitrogen);
            double pHydrogen = CalculatePartialPressure(currentState.nHydrogen);
            double pAmmonia = CalculatePartialPressure(currentState.nAmmonia);
            double Y = CalculateEquilibriumConstant();
            double rateConstant;
            if (!currentState.catalyst)
                rateConstant = CalculateRateConstant(EaCatalyst);
            else
                rateConstant = CalculateRateConstant(EaNoCatalyst);

            if (nextState.time == 1)
                AmmoniaAtEQ = AC.solveQuadricEquation(pNitrogen, pHydrogen, pAmmonia, rateConstant);

            double halfLife = CalculateHalfLife(rateConstant);
            double nextPNitrogen = CalculateNextPartialPressureFirstOrder(pNitrogen, rateConstant, deltaTime);
            double nextPAmmonia;
            if (pAmmonia > 0)
                nextPAmmonia = CalculateNextPartialPressureZerothOrder(pAmmonia, rateConstant, deltaTime);
            else
                nextPAmmonia = 0;

            double nextPHydrogen = pHydrogen - (3 * (pNitrogen - nextPNitrogen));
            CalculateChanges(ref nextPAmmonia, ref nextPNitrogen, ref nextPHydrogen, pAmmonia, pNitrogen, pHydrogen);

            nextState.nAmmonia = (double)CalculateMolarAmount(nextPAmmonia);
            nextState.nHydrogen = (double)CalculateMolarAmount(nextPHydrogen);
            nextState.nNitrogen = (double)CalculateMolarAmount(nextPNitrogen);
            nextState.temperature = currentState.temperature;
            nextState.catalyst = currentState.catalyst;
            nextState.time = currentState.time + deltaTime;
            /*if (AmmoniaAtEQ > pAmmonia)
                nextState = currentState; */
        }

        private void CalculateChanges(ref double nextPAmmonia, ref double nextPNitrogen, ref double nextPHydrogen,
                                          double pAmmonia, double pNitrogen, double pHydrogen)
        {
            double tempAmmonia = nextPAmmonia;
            double tempNitrogen = nextPNitrogen;
            double tempHydrogen = nextPHydrogen;
            nextPAmmonia = tempAmmonia + (2 * (pNitrogen - tempNitrogen));
            nextPNitrogen = tempNitrogen + (0.5 * (pAmmonia - tempAmmonia));
            nextPHydrogen = tempHydrogen + (1.5 * (pAmmonia - tempAmmonia));
        }

        private double CalculateNextPartialPressureFirstOrder(double pSubstance, double rateConstant, double deltaTime)
        {
            return pSubstance * Math.Pow(Math.E, (double)(-rateConstant * deltaTime));
        }

        private double CalculateNextPartialPressureZerothOrder(double pSubstance, double rateConstant, double deltaTime)
        {
            return (double)((-rateConstant * (currentState.temperature/28) * deltaTime + pSubstance));
        }

        private double CalculateHalfLife(double rateConstant)
        {
            return Math.Log(2, Math.E) / rateConstant;
        }

        private double CalculateRateConstant(double Ea)
        {
            return preExpontentialFactor * Math.Pow(Math.E, (double)(-Ea / (gasConstantCal * currentState.temperature)));
        }

        private bool CalculateEquilibrium(double Y, double pNitrogen, double pHydrogen, double pAmmonia)
        {
            if ((Math.Pow(pAmmonia, 2) / (pNitrogen * Math.Pow(pHydrogen, 3))) >= Y)
                return true;
            else
                return false;
        }

        private double CalculateEquilibriumConstant()
        {
            return Math.Pow(Math.E, (double)(-(entalpi / (gasConstant * currentState.temperature)) + entropi / gasConstant));
        }

        private double CalculatePartialPressure(double nSubstance)
        {
            return (nSubstance * gasConstant * currentState.temperature) / volume;
        }

        private double CalculateMolarAmount(double pSubstance)
        {
            return (pSubstance * volume) / (gasConstant * currentState.temperature);
        }
    }
}