using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    //This class handles the time of the simulation and presents features to stop, fastforward and convert time from realtime to virtualtime
    public class Synthesis
    {
        private DataHandler simulationData;
        private Model SimulationModel;
        /* The constructor for TimeHandler
         * Variable
         * Variable
         * Output
         */
        public Synthesis()
        {
            simulationData = new DataHandler();
            SimulationModel = new Model();
        }

        public void start()
        {

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
