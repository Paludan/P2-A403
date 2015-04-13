using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P2
{
    //This abstract class presents tools to save and load a project from a file
    public static class SaveLoadTools
    {
        /// <summary>
        /// Saves a list of DataPoints to a file
        /// </summary>
        /// <param name="CurrentDataList">The list to be saved</param>
        public static void save(List<DataPoint> CurrentDataList)
        {
            DataToSerialize SerializedData = new DataToSerialize();
            SerializedData.DataListList[0] = CurrentDataList;
            Serializer DataSerializer = new Serializer(); 
            string[] files = Directory.GetFiles(@".\SaveFiles\", "*.txt");
            for (int i = 0; i < files.Length; i++)
            DataSerializer.SerializeObject("SavedDataList.txt", SerializedData);
        }
        /// <summary>
        /// Saves a list of lists of DataPoints to a file
        /// </summary>
        /// <param name="CurrentDataList">The list of lists to be saved</param>
        public static void save(List<List<DataPoint>> CurrentDataList)
        {
            DataToSerialize SerializedData = new DataToSerialize();
            SerializedData.DataListList = CurrentDataList;
            Serializer DataSerializer = new Serializer();
            DataSerializer.SerializeObject("SavedDataListList.txt", SerializedData);
        }
        /// <summary>
        /// Loads a list of DataPoints and returns it
        /// </summary>
        public static List<DataPoint> load()
        {
            List<DataPoint> tempDataList = new List<DataPoint>();
            DataToSerialize SerializedData = new DataToSerialize();
            Serializer DataSerializer = new Serializer();
            SerializedData = DataSerializer.DeSerializeObject("SavedDataList.txt");
            tempDataList = SerializedData.DataListList[0];
            return tempDataList;
        }
        /// <summary>
        /// Loads a list of lists of DataPoints and returns it
        /// </summary>
        public static List<List<DataPoint>> loadListList()
        {
            List<List<DataPoint>> tempDataList = new List<List<DataPoint>>();
            DataToSerialize SerializedData = new DataToSerialize();
            Serializer DataSerializer = new Serializer();
            SerializedData = DataSerializer.DeSerializeObject("SavedDataListList.txt");
            tempDataList = SerializedData.DataListList;
            return tempDataList;
        }
        
    }
}
