using System;
using System.Runtime.Serialization;

namespace Equilator
{
	public struct DataPoint : ISerializable
	{
		double nAmmonia, nHydrogen, nNitrogen, pressure, time;
		bool catalyst;

		public DataPoint(double ammonia, double hydrogen, double nitrogen, double inputPressure, double inputTime, bool inputCatalyst){
			this.nAmmonia = ammonia;
			this.nHydrogen = hydrogen;
			this.nNitrogen = nitrogen;
			this.pressure = inputPressure;
			this.time = inputTime;
			this.catalyst = inputCatalyst;
		}

		#region ISerializable implementation

		public void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException ();
		}

		#endregion


	}
}

