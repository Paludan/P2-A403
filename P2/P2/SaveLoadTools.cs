﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using P2Graph;

namespace P2
{
    //This abstract class presents tools to save and load a project from a file, to load a text file, and to save the current graph to a PNG
    public static class SaveLoadTools
    {
        static string dir = Directory.GetCurrentDirectory();
        public static string path = dir + @"\SimData\";
        /// <summary>
        /// Saves a list of DataPoints to a numbered savefile
        /// </summary>
        /// <param name="CurrentDataList">The list to be saved</param>
        public static void save(List<DataPoint> CurrentDataList)
        {
            string[] files = Directory.GetFiles(path, "*.eqsave");
            int i = files.Length + 1;
            DataToSerialize SerializedData = new DataToSerialize();
            SerializedData.DataList = CurrentDataList;
            Serializer DataSerializer = new Serializer();
            DataSerializer.SerializeObject(@"SimData\SaveData" + i + ".eqsave", SerializedData);
        }
        
        /// <summary>
        /// Loads a specific savefile and returns the stored data
        /// </summary>
        /// <param name="fileName">Name of the Savefile to be loaded</param>
		public static List<DataPoint> load(string fileName)
		{
			DataToSerialize SerializedData = new DataToSerialize();
			Serializer DataSerializer = new Serializer();
			SerializedData = DataSerializer.DeSerializeObject(path + fileName);
			return SerializedData.DataList;
		}

        /// <summary>
        /// Loads helpText into a string array.
        /// </summary>
        /// <param name="input">The *.txt file to be read</param>
        /// <returns>String array containing loaded file, or null if file doesn't exist</returns>
        public static String[] loadText(string input)
        {
            if (File.Exists(path + input))
            {
                String[] helpText = File.ReadAllLines(path + input, Encoding.UTF7);
                return helpText;
            }
            else { return null; }
        }
        /// <summary>
        /// This method allows the user to take a snapshot of the graph at a current time and save it as a .png-file
        /// </summary>
        /// <param name="PaneltoPNG"></param>
        public static void saveToImage(MasterGraphPanel PaneltoPNG)
        {
            string[] files = Directory.GetFiles(path, "*.png");
            int i = files.Length + 1;
            Bitmap tempBitmap = new Bitmap(PaneltoPNG.ClientSize.Width, PaneltoPNG.ClientSize.Height);
            PaneltoPNG.DrawToBitmap(tempBitmap, PaneltoPNG.ClientRectangle);
            tempBitmap.Save(@"SimData\SimulationGraf" + i + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}