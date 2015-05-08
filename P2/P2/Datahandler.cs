using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace P2
{
    //This class contains the data for the simulation, and allows access to all or parts of it as individual structs or lists of structs.
    public class DataHandler
    {
        List<DataPoint> simulationData = new List<DataPoint>();
        List<List<DataPoint>> oldData = new List<List<DataPoint>>();

        /* The constructor for DataHandler
         * Variable
         * Variable
         * Output
         */
        public DataHandler()
        {
        }

        /// <summary>
        /// adds the input DataPoint to the current simulation list
        /// </summary>
        /// <param name="input">the DataPoint struct to be added</param>
        public void addDataPoint(DataPoint input)
        {
            simulationData.Add(input);
        }

        /// <summary>
        /// reverts to the specified time or the closest datapoint after and moves the skipped datapoints into an array in oldData removing them from the list
        /// </summary>
        /// <param name="time">the desired time to revert the simulation to</param>
        public void revertTo(double time)
        {
            List<DataPoint> tempList = new List<DataPoint>();
            int revertTo = SortTools.IDbyTime(simulationData, time);
            for (int i = simulationData.Count - revertTo - 1; i < simulationData.Count; i++)
            {
                tempList.Add(simulationData.ElementAt(revertTo + 1));
                simulationData.RemoveAt(revertTo + 1);
            }
            oldData.Add(tempList);
        }

        /// <summary>
        /// returns the full DataPoint struct with the requested time, or the closest after
        /// </summary>
        /// <param name="time">the time for which data is desired</param>
        /// <returns>returns a DataPoint struct</returns>
        public DataPoint getDataPoint(double time)
        {
            return SortTools.byTime(simulationData, time);
        }

        /// <summary>
        /// returns a list containing all DataPoint structs within the requested timespan, inclusive. Defaults to closest after.
        /// </summary>
        /// <param name="fromTime">time of the earliest DataPoint desired</param>
        /// <param name="toTime">time of the latest DataPoint desired</param>
        /// <returns>returns a list of DataPoints</returns>
        public List<DataPoint> getSpan(double fromTime, double toTime)
        {
            int startID, endID;
            startID = SortTools.IDbyTime(simulationData, fromTime);
            endID = SortTools.IDbyTime(simulationData, toTime);
            List<DataPoint> DPlist = new List<DataPoint>();
            for (int i = startID; i <= endID; i++)
            {
                DPlist.Add(simulationData.ElementAt(i));
            }
            return DPlist;
        }

        /// <summary>
        /// returns a list containing all DataPoints of the current timeline
        /// </summary>
        public List<DataPoint> SimulationData
        {
            get { return simulationData; }
            set { simulationData = value; }
        }

        /// <summary>
        /// returns a list of lists, where each list is an alternate timeline
        /// </summary>
        public List<List<DataPoint>> OldData
        {
            get
            {
                return oldData;
            }
        }

    }
}