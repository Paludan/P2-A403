using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace P2
{
    [Serializable]
    // This class is used to serialize the list of DataPoints
    public class DataToSerialize : ISerializable
    {
        public List<DataPoint> DataList = new List<DataPoint>();
        public List<DataPoint> DataProperty
        {
            get { return this.DataList; }
            set { this.DataList = value; }
        }
        public DataToSerialize(){}
        #region ISerializable implementation
        public DataToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            this.DataList = (List<DataPoint>)info.GetValue("Data", typeof(List<DataPoint>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Data", this.DataList);
        }
        #endregion
    }
}
