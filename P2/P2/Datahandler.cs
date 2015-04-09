﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace P2
{
    //This class contains the data, and allows access to all or parts of it as graph-points, arrays of graph-points or individual structs.
    public class DataHandler
    {
        List<DataPoint> simulationData = new List<DataPoint>();
        List<DataPoint[]> oldData = new List<DataPoint[]>();
        /* The constructor for DataHandler
         * Variable
         * Variable
         * Output
         */
        public DataHandler()
        {
        }

        //adds the input DataPoint to the current simulation list.
        public void addDataPoint(DataPoint input)
        {
            simulationData.Add(input);
        }
            Point tempPoint = new Point(0,0);

        //Reverts to the specified time or the closest datapoint before, moves the skipped datapoints into an array in oldData, and finally returns the new current datapoint.
        public DataPoint revert(decimal time)
        {
            //code
            return simulationData.ElementAtOrDefault(simulationData.Count - 1);
        }

        //returns the full DataPoint struct from the requested time.
        public DataPoint getDataPoint(decimal time)
        {
            DataPoint tempDP = new DataPoint();

            return tempDP;
        }

        //Returns an array containing all DataPoint structs within the requested timespan, inclusive.
        public DataPoint[] getArray(decimal fromTime, decimal toTime)
        {
            DataPoint[] DPArray = null;

            return DPArray;
        }

        //Returns a list containing all DataPoints of the current timeline.
        public List<DataPoint> Data
        {
            get
            {
                return simulationData;
            }
        }

        //returns a list of arrays, where each array is an alternate timeline
        public List<DataPoint[]> OldData
        {
            get
            {
                return oldData;
            }
        }
    }
}
