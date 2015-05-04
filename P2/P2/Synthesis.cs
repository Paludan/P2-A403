using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using P2Graph;
using System.Drawing;

namespace P2
{
    /// <summary>
    /// This class handles the time of the simulation and presents features to stop, 
    /// fastforward and convert time from realtime to virtualtime
    /// </summary>
    public class Synthesis
    {
        public List<GraphHandler> graphHandlers = new List<GraphHandler>();
        public delegate void UpdateEventHandler();
        public event UpdateEventHandler Updated; 
        DataHandler simulationData;
        Model SimulationModel;
        public bool running = false, selected = true; //not in use
        System.Timers.Timer timer;//There are other classes called Timer so we must specify the path when initializing.
        public DataPoint currentData = new DataPoint(0,0,0,0,0,false);
        double _scale = 1.0; // this variable will decide at what scale the time runs. by making this 2.0, the virtual time elapsed
                             // when calculating a new datapoint will be double the actual alapsed time.

        /// <summary>
        /// With this property, the user of the class can specify the time interval between datapoints being taken.
        /// </summary>
        public double interval
        {
            get { return timer.Interval; } //cannot be negative
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
                        simulationData.revertTo(value); //overflødigt
                    }
                }
            }
        }

        /// <summary>
        /// This property gives access to the 
        /// </summary>
        public List<DataPoint> Datapoints{
            get { return simulationData.SimulationData; }
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
			graphHandlers.Add(new GraphHandler(graphPanel));
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
            if (currentData.temperature != 0)
            {
                SetData();
                running = true;
                timer.Start();
            }
        }

        /// <summary>
        /// This Method set's the Data from the GUI input to the Simulation model.
        /// </summary>
        private void SetData()
        {
            SimulationModel.Ammonia = currentData.nAmmonia;
            SimulationModel.Hydrogen = currentData.nHydrogen;
            SimulationModel.Nitrogen = currentData.nNitrogen;
            SimulationModel.Temperature = currentData.temperature;
            SimulationModel.Catalyst = currentData.catalyst;
        }

        /// <summary>
        /// This method will run when the elapsed event is raised from the timer object. 
        /// If the simulation should be running the update function is called.
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
            simulationData.addDataPoint( SimulationModel.Update((interval * Scale) /1000 ) );
            currentData = simulationData.SimulationData.Last();
            if (selected && running)
            {
                this.stop();
                foreach (GraphHandler GH in graphHandlers)
                {
                    GH.Update(currentData);
                }
                if (Updated != null)
                {
                    Updated();
                }
                this.start();
            }
        }

        /// <summary>
        /// This method will stop or pause the simulation of this synthesis until it gets started again.
        /// </summary>
        public void stop()
        {
            //timer.Stop();
            running = false;
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
