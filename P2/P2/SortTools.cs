using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    static class SortTools
    {
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
            DataPoint tempDP = new DataPoint();

            //exception handling
            if (list.Count == 0) { throw new InvalidOperationException("MergeSearch: List is empty. Run the simulation before trying to access data."); }
            else if (list.ElementAt(max).time < timeToFind) { System.Windows.Forms.MessageBox.Show("Tiden er højere end det sidste DataPoint"); return list.ElementAt(max); }
            else if (list.ElementAt(0).time > timeToFind) { System.Windows.Forms.MessageBox.Show("Tiden er lavere end det tidligste DataPoint"); return list.ElementAt(0); }

            //searching for a DP with the exact time
            tempDP = list.Find(x => x.time == timeToFind);
            if (!(tempDP.Equals(DataPoint.Default()))) { return tempDP; }

            //searching for closest above
            for (int y = 0; y < max; y++)
            {
                if (list.ElementAt(y).time < timeToFind && list.ElementAt(y + 1).time >= timeToFind) { return list.ElementAt(y + 1); }
            }
            System.Windows.Forms.MessageBox.Show("Error: Search failed. (SortTools.byTime)"); //If you reach this code, you're going to have a bad time.
            return tempDP;                                                                               //but hey, it keeps the IDE happy =)
        }

        /* Takes a DP list and a time double. Searches the list for a DP with the timestamp = time and returns its number in the list, or the closest after.
         * list - the list to be searched
         * timeToFind the time of the DP you wish the locate
         * use this to extract a DP by their placement in the list*/
        /// <summary>
        /// Use this to find a DP's placement in the list using the time variable. Defaults to closest DP after.
        /// </summary>
        /// <param name="list">DP list to search</param>
        /// <param name="timeToFind">time to search for</param>
        /// <returns>int of DP's location in the list</returns>
        public static int IDbyTime(List<DataPoint> list, double timeToFind)
        {
            int max = list.Count - 1;
            int i = max;
            int ID = -1;
            DataPoint tempDP = new DataPoint();

            //exception handling
            if (list.Count == 0) { throw new InvalidOperationException("MergeSearch: List is empty. Run the simulation before trying to access data."); }
            else if (list.ElementAt(max).time < timeToFind) { System.Windows.Forms.MessageBox.Show("Tiden er højere end det sidste DataPoint"); return max; }
            else if (list.ElementAt(0).time > timeToFind) { System.Windows.Forms.MessageBox.Show("Tiden er lavere end det tidligste DataPoint"); return 0; }

            //searching for DP with exact time
            ID = list.FindIndex(x => x.time == timeToFind);
            if (tempDP.temperature != 0) { return ID; }

            //searching for closest above
            for (int y = 0; y < max; y++)
            {
                if (list.ElementAt(y).time < timeToFind && list.ElementAt(y + 1).time >= timeToFind) { return y+1; }
            }
            System.Windows.Forms.MessageBox.Show("Error: Search failed. (SortTools.byTime)");
            return ID;
        }
    }
}
