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
        /* Takes a DP list and a time double. Searches the list for a DP with the timestamp = time and returns it, or the closest after.
         * list - the list to be searched
         * timeToFind the time of the DP you wish the locate
         * use this to extract specific, already-known DP's*/
        /// <summary>
        /// Use to extract a DP from a list or array, specified by it's time variable, or the closest DP after
        /// </summary>
        /// <param name="list">list to be searched</param>
        /// <param name="timeToFind">time as search parameter</param>
        /// <returns>DataPoint struct</returns>
        public static DataPoint byTime(List<DataPoint> list, double timeToFind)
        {
            int max = list.Count - 1;
            int i = max;
            DataPoint tempDP = list.ElementAt(max);
            bool foundDP = false;

            //exception handling
            if (list.Count == 0) { throw new InvalidOperationException("MergeSearch: List is empty. Run the simulation before trying to access data."); }
            else if (tempDP.time < timeToFind) { System.Windows.Forms.MessageBox.Show("Tiden er højere end det sidste DataPoint"); return list.ElementAt(max); }
            else if (list.ElementAt(0).time > timeToFind) { System.Windows.Forms.MessageBox.Show("Tiden er lavere end det tidligste DataPoint"); return list.ElementAt(0); }

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

        /* Takes a DP list and a time double. Searches the list for a DP with the timestamp = time and returns its number in the list, or the closest after.
         * list - the list to be searched
         * timeToFind the time of the DP you wish the locate
         * use this to extract a DP by their placement in the list*/
        /// <summary>
        /// Use this to find a DP's placement in the list using the time variable
        /// </summary>
        /// <param name="list">DP list to search</param>
        /// <param name="timeToFind">time to search for</param>
        /// <returns>int of DP's location in the list</returns>
        public static int IDbyTime(List<DataPoint> list, double timeToFind)
        {
            int max = list.Count - 1;
            int i = max;
            DataPoint tempDP = list.ElementAt(max);
            int ID = -1;

            //exception handling
            if (list.Count == 0) { throw new InvalidOperationException("MergeSearch: List is empty. Run the simulation before trying to access data."); }
            else if (tempDP.time > timeToFind) { throw new MissingMemberException("MergeSearch.IDbyTime can only be used to access an existing datapoint, but has been used to access a non-existing future datapoint. Contact developers."); }

            do
            {
                tempDP = list.ElementAt(i);
                if (tempDP.time == timeToFind) { ID = i; }
                else if (tempDP.time > timeToFind) { i = i / 2; }
                else
                {
                    tempDP = list.ElementAt(i + 1);
                    if (tempDP.time >= timeToFind) { ID = i; }
                    i = i + (i / 2);
                }
            } while (ID == -1);

            return ID;
        }
    }
}
