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
        public double temperature, pressure, time;
        private double _nAmmonia, _nHydrogen, _nNitrogen;
        public bool catalyst;
        public DataPoint(double ammonia, double hydrogen, double nitrogen, double inputTemperature, double inputPressure, double inputTime, bool inputCatalyst)
        {
            this._nAmmonia = ammonia;
            this._nHydrogen = hydrogen;
            this._nNitrogen = nitrogen;
            this.temperature = inputTemperature;
            this.pressure = inputPressure;
            this.time = inputTime;
            this.catalyst = inputCatalyst;
        }
        public double nAmmonia
        {
            get { return _nAmmonia; }
            set { if (value < 4000) { _nAmmonia = value; };}
        }
        public double nHydrogen
        {
            get { return _nHydrogen; }
            set { if (value < 4000) { _nAmmonia = value; };}
        }
        public double nNitrogen
        {
            get { return _nNitrogen; }
            set { if (value < 4000) { _nAmmonia = value; };}
        }
        public DataPoint(DataPoint oldData)
        {
            this._nAmmonia = oldData.nAmmonia;
            this._nHydrogen = oldData.nHydrogen;
            this._nNitrogen = oldData.nNitrogen;
            this.temperature = oldData.temperature;
            this.pressure = oldData.pressure;
            this.time = oldData.time;
            this.catalyst = oldData.catalyst;
        }

        #region ISerializable implementation

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ammonia", this._nAmmonia);
            info.AddValue("Hydrogen", this._nHydrogen);
            info.AddValue("Nitrogen", this._nNitrogen);
            info.AddValue("Temperature", this.temperature);
            info.AddValue("Pressure", this.pressure);
            info.AddValue("Time", this.time);
            info.AddValue("Catalyst", this.catalyst);
        }
        public DataPoint(SerializationInfo info, StreamingContext ctxt)
        {
            this._nAmmonia = (double)info.GetValue("Ammonia", typeof(double));
            this._nHydrogen = (double)info.GetValue("Hydrogen", typeof(double));
            this._nNitrogen = (double)info.GetValue("Nitrogen", typeof(double));
            this.temperature = (double)info.GetValue("Temperature", typeof(double));
            this.pressure = (double)info.GetValue("Pressure", typeof(double));
            this.time = (double)info.GetValue("Time", typeof(double));
            this.catalyst = (bool)info.GetValue("Catalyst", typeof(bool));
        }

        #endregion


    }
}
