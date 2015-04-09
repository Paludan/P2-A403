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
        /* The constructor for DataHandler
         * Variable
         * Variable
         * Output
         */
        public DataHandler()
        {
        }

        //returns a single x/y coordinate; x is the time (from input), y is the requested value at the specified time.
        public Point getPoint(string yAxis, decimal time)
        {
            Point tempPoint = new Point(0,0);

            return tempPoint;
        }

        //returns the full DataPoint struct from the requested time.
        public DataPoint getStruct(decimal time)
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

        //Returns a list containing all DataPoints. Intended for saving/backups.
        public List<DataPoint> getAll()
        {
            return simulationData;
        }
    }
}
