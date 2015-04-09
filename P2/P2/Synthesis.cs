using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

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
        bool catalyst, running = true;
        Thread Simulation;
        System.Timers.Timer timer;

        public double interval
        {
            get { return timer.Interval; }
            set { timer.Interval = value;}
        }

        public Synthesis(double iTemperature, double nHydrogen, double nNitrogen, double nAmmonia, bool catalyst, double time, double volume)
        {
            simulationData = new DataHandler();
            SimulationModel = new Model(iTemperature, nHydrogen, nNitrogen, nAmmonia, catalyst, time, volume);
            timer = new System.Timers.Timer(500);

        }

        public void run()
        {
            Timer
            while (running)
            {

            }
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
