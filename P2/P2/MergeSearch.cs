using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    /*A mergesort inspired searching method*/
    static class MergeSearch
    {
        public MergeSearch()
        {
        }

        /* Takes a DP list and a time double. Searches the list for a DP with the timestamp = time and returns it, or the closest after.
         * list - the list to be searched
         * timeToFind the time of the DP you wish the locate
         * use this to extract specific, already-known DP's*/
        public static DataPoint byTime(List<DataPoint> list, double timeToFind)
        {
            int max = list.Count - 1;
            int i = max;
            DataPoint tempDP = list.ElementAt(max);
            bool foundDP = false;

            //exception handling
            if (list.Count == 0) { throw new InvalidOperationException("No simulation data available. Run the simulation before trying to access data."); }
            else if (tempDP.time > timeToFind) { throw new MissingMemberException("DataHandler.getDataPoint can only be used to access an existing datapoint, but has been used to access a non-existing future datapoint. Contact developers."); }

            do
            {
                tempDP = list.ElementAt(i);
                if (tempDP.time == timeToFind) { foundDP = true; }
                else if (tempDP.time > timeToFind) { i = i / 2; }
                else
                {
                    tempDP = list.ElementAt(i + 1);
                    if (tempDP.time >= timeToFind) { foundDP = true; }
                    i = i + (i / 2);
                }
            } while (!foundDP);

            return tempDP;
        }

        /*same as above, but this time using an array instead of a list*/
        public static DataPoint byTime(DataPoint[] list, double timeToFind)
        {
            int max = list.Length;
            int i = max;
            DataPoint tempDP = list.ElementAt(max);
            bool foundDP = false;

            //exception handling
            if (list.Length == 0) { throw new InvalidOperationException("No simulation data available. Run the simulation before trying to access data."); }
            else if (tempDP.time > timeToFind) { throw new MissingMemberException("DataHandler.getDataPoint can only be used to access an existing datapoint, but has been used to access a non-existing future datapoint. Contact developers."); }

            do
            {
                tempDP = list.ElementAt(i);
                if (tempDP.time == timeToFind) { foundDP = true; }
                else if (tempDP.time > timeToFind) { i = i / 2; }
                else
                {
                    tempDP = list.ElementAt(i + 1);
                    if (tempDP.time >= timeToFind) { foundDP = true; }
                    i = i + (i / 2);
                }
            } while (!foundDP);

            return tempDP;
        }
    }
}
