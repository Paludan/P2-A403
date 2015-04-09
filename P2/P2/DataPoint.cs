using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace P2
{
    [Serializable]
    // This struct contains the simulation data at a specific time
    public struct DataPoint : ISerializable
    {
        public double nAmmonia, nHydrogen, nNitrogen, temperature, pressure, time;
        public bool catalyst;

        public DataPoint(double ammonia, double hydrogen, double nitrogen, double inputTemperature, double inputPressure, double inputTime, bool inputCatalyst)
        {
            this.nAmmonia = ammonia;
            this.nHydrogen = hydrogen;
            this.nNitrogen = nitrogen;
            this.temperature = inputTemperature;
            this.pressure = inputPressure;
            this.time = inputTime;
            this.catalyst = inputCatalyst;
        }
        public DataPoint(DataPoint oldData)
        {
            this.nAmmonia = oldData.nAmmonia;
            this.nHydrogen = oldData.nHydrogen;
            this.nNitrogen = oldData.nNitrogen;
            this.temperature = oldData.temperature;
            this.pressure = oldData.pressure;
            this.time = oldData.time;
            this.catalyst = oldData.catalyst;
        }

        #region ISerializable implementation

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ammonia", this.nAmmonia);
            info.AddValue("Hydrogen", this.nHydrogen);
            info.AddValue("Nitrogen", this.nNitrogen);
            info.AddValue("Temperature", this.temperature);
            info.AddValue("Pressure", this.pressure);
            info.AddValue("Time", this.time);
            info.AddValue("Catalyst", this.catalyst);
        }
        public DataPoint(SerializationInfo info, StreamingContext ctxt)
        {
            this.nAmmonia = (double)info.GetValue("Ammonia", typeof(double));
            this.nHydrogen = (double)info.GetValue("Hydrogen", typeof(double));
            this.nNitrogen = (double)info.GetValue("Nitrogen", typeof(double));
            this.temperature = (double)info.GetValue("Temperature", typeof(double));
            this.pressure = (double)info.GetValue("Pressure", typeof(double));
            this.time = (double)info.GetValue("Time", typeof(double));
            this.catalyst = (bool)info.GetValue("Catalyst", typeof(bool));
        }

        #endregion


    }
}
