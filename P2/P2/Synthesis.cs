﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using P2Graph;

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
        DataHandler simulationDataHandler;
        AmmoniaModel SimulationModel;
        public bool running = false, selected = true;
        System.Timers.Timer timer;//There are other classes calling timer so we must specify the path when initializing.
        public DataPoint currentData = new DataPoint(0,0,0,0,0,false);
        int _scale = 1; // This variable decides the speed of the simulation, the higher a number the faster the simulation runs.

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
        public int Scale
        {
            get { return _scale; }
            set { if (value != 0) { _scale = value;} }
        }

        /// <summary>
        /// The time that has elapsed in the simulation. 
        /// Setting this property will cause the simulation to fast-forward the simulation to a later time.
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
                }
            }
        }
        public DataHandler dh
        {
            get { return simulationDataHandler; }
        }

        /// <summary>
        /// This property gives access to the list of datapoints
        /// </summary>
        public List<DataPoint> Datapoints{
            get { return simulationDataHandler.SimulationData; }
            set { simulationDataHandler.SimulationData = value;  }
        }
        public DataPoint CurrentData
        {
            set { currentData = value; }
        }
        /// <summary>
        /// This is the constructor for the class. It initializes the datahandler, model and timer.
        /// </summary>
        public Synthesis(MasterGraphPanel graphPanel)
        {
            simulationDataHandler = new DataHandler();
            SimulationModel = new AmmoniaModel(currentData);
            timer = new System.Timers.Timer(100);
            timer.Elapsed += this.OnElapsed;
			graphHandlers.Add(new GraphHandler(graphPanel));
        }

        /// <summary>
        /// This method is invoked by the caller when the simulation needs to start.
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
        /// This Method sets the data from the GUI input to the Simulation model.
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
            for (int i = 0; i < _scale; i++)
            {
                currentData.time += interval;
                simulationDataHandler.addDataPoint( SimulationModel.Update(interval / 1000) );
            }
            currentData = simulationDataHandler.SimulationData.Last();

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
        /// This method will stop or pause the simulation of the synthesis.
        /// </summary>
        public void stop()
        {
            running = false;
        }

        /// <summary>
        /// This method will be called if we try to set the simulation to a time later than the time it had already processed.
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
