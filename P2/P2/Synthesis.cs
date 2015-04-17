using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using P2Graph;

namespace P2
{
    /// <summary>
    /// This class handles the time of the simulation and presents features to stop, 
    /// fastforward and convert time from realtime to virtualtime fisk
    /// </summary>
    public class Synthesis
    {
        MasterGraphPanel _graphPanel;
        DataHandler simulationData;
        Model SimulationModel;
        public bool running = false, selected = true;
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
            set { timer.Interval = value; }
        }

        /// <summary>
        /// The scale at which the simulation should run. By making this value 2, the simulation will run at 2x real time.
        /// Any operation trying to set this property to 0 will be ignored.
        /// </summary>
        public double Scale
        {
            get { return _scale; }
            set { if (value != 0) { _scale = value;} }
        }

        /// <summary>
        /// The time that has elapsed in the simulation. 
        /// Setting this property will cause the simulation to either return to an earlier datapoint,
        /// or fast-forward the simulation to a later time.
        /// </summary>
        public double Time
        {
            get { return currentData.time; }
            set
            {
                if (value >= 0)
                {
                    if (value > Time)
                    {
                        FastForward(value);
                    }
                    else
                    {
                        currentData = simulationData.getDataPoint(value);
                    }
                }
            }
        }

        public List<DataPoint> Datapoints{
            get { return simulationData.SimulationData; }
        }

        public MasterGraphPanel GraphPanel
        {
            get { return _graphPanel; }
        }

        /// <summary>
        /// This is the constructor for the class. It initializes the datahandler, model and timer.
        /// </summary>
        public Synthesis(MasterGraphPanel graphPanel)
        {
            simulationData = new DataHandler();
            SimulationModel = new Model(currentData);
            timer = new System.Timers.Timer(100);
            timer.Elapsed += this.OnElapsed;
            
            _graphPanel = graphPanel;
            //_graphPanel.AddGraph();
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
        private void OnElapsed(Object source, ElapsedEventArgs e)
        {
            if (running)
            {
                Update();
            }
        }

        /// <summary>
        /// This method adds a new datapoint using the Simulation model and the datahandler. 
        /// </summary>
        private void Update()
        {
            currentData.time += interval * Scale;
            simulationData.addDataPoint(SimulationModel.calculateDataPoint(interval * Scale));
            if (selected)
            {

            }
        }

        /// <summary>
        /// This method will stop or pause the simulation of this synthesis until it gets started again.
        /// </summary>
        public void stop()
        {
            timer.Stop();
        }

        /// <summary>
        /// This method will be called if we try to set the simulation to a time later than the time it had already processed.
        /// It does the same as
        /// </summary>
        /// <param name="time"></param>
        public void FastForward(double time)
        {
            running = false;
            while (Time < time)
            {
                Update();
            }
        }
    }
}
