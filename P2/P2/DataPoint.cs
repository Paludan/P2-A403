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
        decimal nAmmonia, nHydrogen, nNitrogen, pressure, time;
        bool catalyst;

        public DataPoint(decimal ammonia, decimal hydrogen, decimal nitrogen, decimal inputPressure, decimal inputTime, bool inputCatalyst)
        {
            this.nAmmonia = ammonia;
            this.nHydrogen = hydrogen;
            this.nNitrogen = nitrogen;
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
