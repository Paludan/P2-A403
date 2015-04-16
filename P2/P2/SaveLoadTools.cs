﻿using System;
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
        enum DataType { String, INT };
        static string dir = Directory.GetCurrentDirectory();
        public static string path = dir + "\\SaveFiles";
        static string[] files = Directory.GetFiles(path, "*.eqsave");
        static int i = files.Length + 1;
        /// <summary>
        /// Saves a list of DataPoints to a numbered savefile
        /// </summary>
        /// <param name="CurrentDataList">The list to be saved</param>
        public static void save(List<DataPoint> CurrentDataList)
        {
            DataToSerialize SerializedData = new DataToSerialize();
            SerializedData.DataList[0] = CurrentDataList;
            Serializer DataSerializer = new Serializer();
            DataSerializer.SerializeObject(path + "SaveData" + i + ".eqsave", SerializedData);
        }
        /// <summary>
        /// Saves a list of lists of DataPoints to a numbered savefile
        /// </summary>
        /// <param name="CurrentDataList">The list of lists to be saved</param>
        public static void save(List<List<DataPoint>> CurrentDataList)
        {
            DataToSerialize SerializedData = new DataToSerialize();
            SerializedData.DataList = CurrentDataList;
            Serializer DataSerializer = new Serializer();
            DataSerializer.SerializeObject(path + "SaveData" + i + ".eqsave", SerializedData);
        }
        /// <summary>
        /// Loads a specific savefile and returns the stored data
        /// </summary>
        /// <param name="fileName">Name of the Savefile to be loaded</param>
        public static List<List<DataPoint>> load(string fileName)
        {
            List<List<DataPoint>> tempDataList = new List<List<DataPoint>>();
            DataToSerialize SerializedData = new DataToSerialize();
            Serializer DataSerializer = new Serializer();
            SerializedData = DataSerializer.DeSerializeObject(path + fileName + ".eqsave");
            tempDataList = SerializedData.DataList;
            return tempDataList;
        }
    }
}
