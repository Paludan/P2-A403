﻿using System;
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
        DataHandler simulationData;
        Model SimulationModel;
        bool running = false;
        Thread Simulation; //This variable may or may not be used in the final version.
        System.Timers.Timer timer;//There are other classes called Timer so we must specify the path when initializing.
        public DataPoint currentData = new DataPoint(0,0,0,0,0,0,false);
        double Scale = 1.0; // this variable will decide at what scale the time runs. by making this 2.0, the virtual time elapsed
                            // when calculating a new datapoint will be double the actual alapsed time.
        /*
         * With this property, the user of the class can specify the time interval between datapoints being taken.
         */
        public double interval
        {
            get { return timer.Interval; }
            set { timer.Interval = value;}
        }

        /*This is the constructor for the class. It initializes the datahandler, model and timer.
         */
        public Synthesis()
        {
            simulationData = new DataHandler();
            SimulationModel = new Model(currentData);
            timer = new System.Timers.Timer(500);

        }
        /*This function starts a new thread that runs the timer and controls the generation of data points
         */
        public void run()
        {
            timer.Start();
        }

        /*this method is invoked by the caller when the simulation needs to start.
         */
        public void start()
        {
            running = true;
            Simulation.Start();
        }

        /*
         * This method will add a new datapoint using the 
         */
        public void Update(double deltaTime){
            currentData.time+=interval;

            simulationData.addDataPoint( SimulationModel.calculateDataPoint(deltaTime) );
        }

        /*This method will stop or pause the simulation of this synthesis until it gets started again.
         */
        public void stop()
        {

        }

        /*
         * Not sure if this function will be in use yet.
         */
        public void search()
        {

        }

        /*
         * Not sure if this function will be in use yet.
         */
        public void fastforward()
        {

        }
    }
}
