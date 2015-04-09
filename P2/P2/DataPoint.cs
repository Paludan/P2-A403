using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace P2
{
    public struct DataPoint : ISerializable
    {
        public double nAmmonia, nHydrogen, nNitrogen, Temperature, pressure, time;
        public bool catalyst;

        public DataPoint(double ammonia, double hydrogen, double nitrogen, double inputTemperature, double inputPressure, double inputTime, bool inputCatalyst)
        {
            this.nAmmonia = ammonia;
            this.nHydrogen = hydrogen;
            this.nNitrogen = nitrogen;
            this.Temperature = inputTemperature;
            this.pressure = inputPressure;
            this.time = inputTime;
            this.catalyst = inputCatalyst;
        }

        #region ISerializable implementation

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
