using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    //This abstract class presents tools to save and load a project from a file
    public static class SaveLoadTools
    {
        //This method takes in the current list of data and saves it in the same folder as the program
        public static void save(List<DataPoint> CurrentDataList)
        {
            DataToSerialize SerializedData = new DataToSerialize();
            SerializedData.DataList = CurrentDataList;
            Serializer DataSerializer = new Serializer();
            DataSerializer.SerializeObject("SavedData.txt", SerializedData);
        }
        //This method loads data from the harddrive and returns it to the caller
        public static List<DataPoint> load()
        {
            List<DataPoint> tempDataList = new List<DataPoint>();
            DataToSerialize SerializedData = new DataToSerialize();
            Serializer DataSerializer = new Serializer();
            SerializedData = DataSerializer.DeSerializeObject("SavedData.txt");
            tempDataList = SerializedData.DataList;
            return tempDataList;
        }
    }
}
