using System;
using System.Collections.Generic;
using Cairo;

namespace Equilator
{
	//This class is used to convert from a list of DataPoints to single poiunts or arrays from to times
	public class DataHandler
	{
		List<DataPoint> simulationData = new List<DataPoint>();
		/* The constructor for DataHandler
		 * Variable
		 * Variable
		 * Output
		 */
		public DataHandler ()
		{
		}

		public Point toPoint(string yAxis, double time){
			Point tempPoint;

			return tempPoint;
		}

		public DataPoint toStruct(double time){
			DataPoint tempDP;

			return tempDP;
		}

		public DataPoint[] toArray(double fromTime, double toTime){
			DataPoint[] DPArray;

			return DPArray;
		}
	}
}

