using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace P2
{
    /// <summary>
    /// This class handles the time of the simulation and presents features to stop, 
    /// fastforward and convert time from realtime to virtualtime fisk
    /// </summary>
    public class Synthesis
    {
        DataHandler simulationData;
        Model SimulationModel;
        bool running = false;
        public System.Timers.Timer timer;//There are other classes called Timer so we must specify the path when initializing.
        public DataPoint currentData = new DataPoint(0,0,0,0,0,0,false);
        double _scale = 1.0; // this variable will decide at what scale the time runs. by making this 2.0, the virtual time elapsed
                            // when calculating a new datapoint will be double the actual alapsed time.

        /// <summary>
        /// With this property, the user of the class can specify the time interval between datapoints being taken.
        /// </summary>
        public double interval
        {
            get { return timer.Interval; }
            set { timer.Interval = value/_scale;}
        }

        public double Scale
        {
            get { return _scale; }
            set { if (value != 0) { _scale = value; } }
        }

        public double Time
        {
            get { return currentData.time; }
        }

        /// <summary>
        /// This is the constructor for the class. It initializes the datahandler, model and timer.
        /// </summary>
        public Synthesis()
        {
            simulationData = new DataHandler();
            SimulationModel = new Model(currentData);
            timer = new System.Timers.Timer(500);
            timer.Elapsed += this.Update;
        }
        /*This function starts a new thread that runs the timer and controls the generation of data points
         */
        /// <summary>
        /// This function starts a new thread that runs the timer and controls the generation of data points
        /// </summary>
        private void run()
        {
            if (!timer.Enabled && running)
            {
                timer.Start();
            }
        }

        /// <summary>
        /// this method is invoked by the caller when the simulation needs to start.
        /// </summary>
        public void start()
        {
            running = true;
            timer.Start();
        }

        /// <summary>
        /// This method will add a new datapoint using the
        /// </summary>
        /// <param name="source">The object that invoked the event</param>
        /// <param name="e">arguments dunno</param>
        public void Update(Object source, ElapsedEventArgs e)
        {
            if(running)
            currentData.time+=interval;
            
            simulationData.addDataPoint( SimulationModel.calculateDataPoint(interval) );
        }

        /// <summary>
        /// This method will stop or pause the simulation of this synthesis until it gets started again.
        /// </summary>
        public void stop()
        {
            timer.Stop();
        }
    }
}
