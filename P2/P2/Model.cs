using System;

namespace P2
{
    public class AmmoniaModel
    {
        /* the following 8 variables are constants that cannot be regulated */
        private double gasConstant = 8.314472;
        private double gasConstantCal = 1.987;
        private double preExpontentialFactor = 884900000000000; //very large number
        private double volume = 50000; //         liter
        private double EaCatalyst = 60000; //     J/mol
        private double EaNoCatalyst = 120000; //  J/mol

        DataPoint currentState = new DataPoint();

        public double Ammonia { set { currentState.nAmmonia = (double)value; } }
        public double Hydrogen { set { currentState.nHydrogen = (double)value; } }
        public double Nitrogen { set { currentState.nNitrogen = (double)value; } }
        public double Temperature { set { currentState.temperature = (double)value; } }
        public bool Catalyst { set { currentState.catalyst = value; } }
        double nextPAmmonia = 0;

        public AmmoniaModel(DataPoint InitData)
        {
            currentState = InitData;
        }

        /// <summary>
        /// This method fetches the current DataPoint without updating it.
        /// </summary>
        /// <returns></returns>
        public DataPoint Fetch()
        {
            return currentState;
        }

        /// <summary>
        /// This method simulates the difference between the current data and the data
        /// after the specified deltatime has passed. The method then sets current data equals to the new data and returns it.
        /// </summary>
        /// <param name="deltaTime">The time that is simulated form the old datapoint to the new</param>
        /// <returns></returns>
        public DataPoint Update(double deltaTime)
        {
            DataPoint NextState;
            CalculateNextState(deltaTime, out NextState);
            currentState = NextState;
            return currentState;
        }

        /// <summary>
        /// This method calculates the new state of the current data after the specified time has passed.
        /// </summary>
        /// <param name="deltaTime">Specified time that passes</param>
        /// <param name="nextState">An out parameter that represents the state of the 
        /// simulation after the specified time has passed</param>
        private void CalculateNextState(double deltaTime, out DataPoint nextState)
        {
            nextState = new DataPoint();

            double pNitrogen = CalculatePartialPressure(currentState.nNitrogen);
            double pHydrogen = CalculatePartialPressure(currentState.nHydrogen);
            double pAmmonia = CalculatePartialPressure(currentState.nAmmonia);

			//Calculate Reactionrate constant
            double rateConstant;
            if (currentState.catalyst)
                rateConstant = CalculateRateConstant(EaCatalyst);
            else
                rateConstant = CalculateRateConstant(EaNoCatalyst);

            double nextPNitrogen = CalculateNextPartialPressureFirstOrder(pNitrogen, rateConstant, deltaTime);
            if (pAmmonia > 0)
                nextPAmmonia = CalculateNextPartialPressureZerothOrder(pAmmonia, rateConstant, deltaTime);
            double nextPHydrogen = pHydrogen - (3 * (pNitrogen - nextPNitrogen));
            double tempAmmonia = nextPAmmonia;
            if (tempAmmonia < 0)
            {
                tempAmmonia = 0;
                nextPAmmonia = 0;
            }
            if (nextPHydrogen > 0 && nextPNitrogen > 0)
                CalculateAmmoniaProduction(ref nextPAmmonia, pNitrogen, nextPNitrogen);
            else
            {
                nextPNitrogen = pNitrogen;
                nextPHydrogen = pHydrogen;
            }
            if (nextPAmmonia > 0)
                CalculateReactantProduction(tempAmmonia, ref nextPNitrogen, ref nextPHydrogen, pAmmonia);
            else
                nextPAmmonia = pAmmonia;

            nextState.nAmmonia = (double)CalculateMolarAmount(nextPAmmonia);
            nextState.nHydrogen = (double)CalculateMolarAmount(nextPHydrogen);
            nextState.nNitrogen = (double)CalculateMolarAmount(nextPNitrogen);
            nextState.temperature = currentState.temperature;
            nextState.catalyst = currentState.catalyst;
            nextState.time = currentState.time + deltaTime;
        }
        /// <summary>
        /// This method calculates the resulting changes in partial pressure for the product in the simulation
        /// </summary>
        /// <param name="nextPAmmonia">the initially calculated value of the next partial pressure of ammonia</param>
        /// <param name="pNitrogen">the current partial pressure of nitrogen</param>
        /// <param name="nextPNitrogen">the initially calculated value of the next partial pressure of nitrogen</param>
        private void CalculateAmmoniaProduction(ref double nextPAmmonia, double pNitrogen, double nextPNitrogen)
        {
            nextPAmmonia = nextPAmmonia + (2 * (pNitrogen - nextPNitrogen));
        }

        /// <summary>
        /// This method calculates the resulting changes in partial pressure for the reactants in the simulation.
        /// This calculation is to be made after the initial changes calculation, where the fact that all changes on one side of the equation
        /// will result in equivalent changes on the other side is ignored.
        /// </summary>
        /// <param name="nextPAmmonia"> the initially calculated value of the next partial pressure of ammonia</param>
        /// <param name="nextPNitrogen">the initially calculated value of the next partial pressure of nitrogen</param>
        /// <param name="nextPHydrogen">the initially calculated value of the next partial pressure of hydrogen</param>
        /// <param name="pAmmonia">the previous partial pressure of ammonia</param>
        private void CalculateReactantProduction(double nextPAmmonia, ref double nextPNitrogen, ref double nextPHydrogen,
                                                 double pAmmonia)
        {
            double tempNitrogen = nextPNitrogen;
            double tempHydrogen = nextPHydrogen;
            nextPNitrogen = tempNitrogen + (0.5 * (pAmmonia - nextPAmmonia));
            nextPHydrogen = tempHydrogen + (1.5 * (pAmmonia - nextPAmmonia));
        }

        /// <summary>
        /// This method calculates the the next partial pressure of a substance, that decays at first order.
        /// </summary>
        /// <param name="pSubstance">The partial preassure of the substance being calculated on</param>
        /// <param name="rateConstant">The rate constant of the reaction</param>
        /// <param name="deltaTime"> The time that has passed since the initial conditions for this calculation</param>
        /// <returns></returns>
        private double CalculateNextPartialPressureFirstOrder(double pSubstance, double rateConstant, double deltaTime)
        {
			return pSubstance * Math.Pow(Math.E, (double)(-rateConstant * deltaTime));
        }

        /// <summary>
        /// This method calculates the the next partial pressure of a substance, that decays at zeroth order.
        /// </summary>
        /// <param name="pSubstance">The partial preassure of the substance being calculated on</param>
        /// <param name="rateConstant">The rate constant of the reaction</param>
        /// <param name="deltaTime">The time that has passed since the initial conditions for this calculation</param>
        /// <returns></returns>
        private double CalculateNextPartialPressureZerothOrder(double pSubstance, double rateConstant, double deltaTime)
        {
            return (double)((-rateConstant * Math.Pow(currentState.temperature, 1.2) * deltaTime + pSubstance));
        }

        /// <summary>
        /// This method calculates the rate constant for the current simulation.
        /// </summary>
        /// <param name="Ea">The current activation energy</param>
        /// <returns></returns>
        private double CalculateRateConstant(double Ea)
        {
            return preExpontentialFactor * Math.Pow(Math.E, (double)(-Ea / (gasConstantCal * currentState.temperature)));
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
