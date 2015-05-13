using System;
using System.Collections.Generic;
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
        
		/// <summary>
		/// Initializes a new instance of the <see cref="P2.DataToSerialize"/> class.
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="ctxt">Ctxt.</param>
		public DataToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            this.DataList = (List<DataPoint>)info.GetValue("Data", typeof(List<DataPoint>));
        }

		/// <summary>
		/// Gets the object data.
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="ctxt">Ctxt.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Data", this.DataList);
        }

        #endregion
    }
}
