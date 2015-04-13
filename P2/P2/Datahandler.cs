using System;
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

        /* adds the input DataPoint to the current simulation list.
         * input - the DataPoint to be added
         * No output*/
        public void addDataPoint(DataPoint input)
        {
            simulationData.Add(input);
        }

        /* Reverts to the specified time or the closest datapoint after, moves the skipped datapoints into an array in oldData
         * removing them from the list, and finally returns the new current datapoint.
         * time - the desired time to revert the simulation to
         * Expected to return the DataPoint with the requested timestamp, or the closest after.*/
        public DataPoint revert(double time)
        {
            DataPoint tempDP = new DataPoint();
            bool foundDP = false;
            int max = simulationData.Count - 1;
            int i = max;
            int revertDP = 0;
            tempDP = simulationData.ElementAt(i);

            //exception handling
            if (simulationData.Count == 0) { throw new InvalidOperationException("No simulation data available. Run the simulation before trying to access data."); }
            else if (tempDP.time > time) { throw new MissingMemberException("DataHandler.revert can only be used to jump to an earlier datapoint, but has been used to access a non-existing future datapoint. Contact developers."); }

            //MergeSort-inspired search. MergeSearch?
            do
            {
                tempDP = simulationData.ElementAt(i);
                if (tempDP.time == time) { foundDP = true; revertDP = i; }
                else if (tempDP.time > time) { i = i / 2; }
                else
                {
                    tempDP = simulationData.ElementAt(i + 1);
                    if (tempDP.time >= time) { foundDP = true; revertDP = i; }
                    i = i + (i / 2);
                }
            } while (!foundDP);

            DataPoint[] tempArr = new DataPoint[max - revertDP];
            for (int x = revertDP + 1; x <= max; x++)
            {
                tempArr[x - revertDP + 1] = simulationData.ElementAt(revertDP + 1);
                simulationData.RemoveAt(revertDP + 1);
            }
            oldData.Add(tempArr);
            return tempDP;
        }

        /* returns the full DataPoint struct with the requested time, or the closest after.
         * time - the time for which data is desired
         * Expected to return the DataPoint with the requested time, or the closest after.*/
        public DataPoint getDataPoint(double time)
        {
            return MergeSearch.byTime(simulationData, time);
        }

        /* Returns a list containing all DataPoint structs within the requested timespan, inclusive.
         * In both cases it defaults to closest-after if not datapoint with the exact time is found.
         * fromTime - time of the earliest DataPoint desired
         * toTime . time of the latest DataPoint desired
         * Expected to return an array of DataPoints*/
        public List<DataPoint> getSpan(double fromTime, double toTime)
        {
            MergeSearch.IDbyTime(simulationData, fromTime);
            
            List<DataPoint> DPlist = null;

            return DPlist;
        }

        /*Returns a list containing all DataPoints of the current timeline.*/
        public List<DataPoint> SimulationData
        {
            get
            {
                return simulationData;
            }
        }

        /*returns a list of arrays, where each array is an alternate timeline*/
        public List<DataPoint[]> OldData
        {
            get
            {
                return oldData;
            }
        }
    }
}
