using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace P2
{
    //This class handles the time of the simulation and presents features to stop, fastforward and convert time from realtime to virtualtime
    /* The constructor for TimeHandler
     * Variable
     * Variable
     * Output
     */
    public class Synthesis
    {
        private DataHandler simulationData;
        private Model SimulationModel;
        bool catalyst;
        Thread Simulation;

        public Synthesis(double iTemperature, double nHydrogen, double nNitrogen, double nAmmonia, bool catalyst, double time, double volume)
        {
            simulationData = new DataHandler();
            SimulationModel = new Model(iTemperature, nHydrogen, nNitrogen, nAmmonia, catalyst, time, volume);
            Simulation = new Thread(run);

        }

        public void run()
        {

        }

        public void start()
        {
            Simulation.Start();
        }

        public void stop()
        {

        }

        public void search()
        {

        }

        public void fastforward()
        {

        }
    }
}
