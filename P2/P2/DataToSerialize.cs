using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace P2
{
    [Serializable]
    // This class contains a list of DataPoints and implements ISerializable.
    public class DataToSerialize : ISerializable
    {
        public List<DataPoint> DataList = new List<DataPoint>();
        //DataList.Add is used to make sure that the DataList always contains at least one element.
        public DataToSerialize()
        {
            DataList.Add(new DataPoint());
        }
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
