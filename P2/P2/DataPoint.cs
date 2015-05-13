using System;
using System.Runtime.Serialization;

namespace P2
{
    [Serializable]
    // This struct contains the simulation data at a specific time
    public struct DataPoint : ISerializable
    {
        public double temperature, time, nAmmonia, nHydrogen, nNitrogen;
        public bool catalyst;
        /// <summary>
        /// Constructs a datapoint from a set of given variables
        /// </summary>
        public DataPoint(double ammonia, double hydrogen, double nitrogen, double inputTemperature, double inputTime, bool inputCatalyst)
        {
            this.nAmmonia = ammonia;
            this.nHydrogen = hydrogen;
            this.nNitrogen = nitrogen;
            this.temperature = inputTemperature;
            this.time = inputTime;
            this.catalyst = inputCatalyst;
        }
        // Is used to determine if data has been added to the datapoint
        public static DataPoint Default()
        {
            return new DataPoint();
        }
        
        // Constructs a copy of the given datapoint
        public DataPoint(DataPoint oldData)
        {
            this.nAmmonia = oldData.nAmmonia;
            this.nHydrogen = oldData.nHydrogen;
            this.nNitrogen = oldData.nNitrogen;
            this.temperature = oldData.temperature;
            this.time = oldData.time;
            this.catalyst = oldData.catalyst;
        }
        // Allows for easy printing of a datapoint
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6}", nAmmonia, nHydrogen, nNitrogen, temperature, time, catalyst);
        }
        #region ISerializable implementation

		/// <summary>
		/// Gets the object data.
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="context">Context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ammonia", this.nAmmonia);
            info.AddValue("Hydrogen", this.nHydrogen);
            info.AddValue("Nitrogen", this.nNitrogen);
            info.AddValue("Temperature", this.temperature);
            info.AddValue("Time", this.time);
            info.AddValue("Catalyst", this.catalyst);
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="P2.DataPoint"/> struct.
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="ctxt">Ctxt.</param>
        public DataPoint(SerializationInfo info, StreamingContext ctxt)
        {
            this.nAmmonia = (double)info.GetValue("Ammonia", typeof(double));
            this.nHydrogen = (double)info.GetValue("Hydrogen", typeof(double));
            this.nNitrogen = (double)info.GetValue("Nitrogen", typeof(double));
            this.temperature = (double)info.GetValue("Temperature", typeof(double));
            this.time = (double)info.GetValue("Time", typeof(double));
            this.catalyst = (bool)info.GetValue("Catalyst", typeof(bool));
        }

        #endregion


    }
}
