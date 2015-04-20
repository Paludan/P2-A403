using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using P2Graph;

namespace P2
{
    //This abstract class presents tools to save and load a project from a file, and to load a text file
    public static class SaveLoadTools
    {
        static string dir = Directory.GetCurrentDirectory();
        public static string path = dir + "\\Simulation Data";
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

        /// <summary>
        /// Loads helpText into a string array. Loads from (program directory)/vejledning.txt
        /// </summary>
        /// <param name="input">The *.txt file to be read</param>
        /// <returns>String array containing loaded file, or null if file doesn't exist</returns>
        public static String[] loadText(string input)
        {
            if (File.Exists(path + input))
            {
                String[] helpText = File.ReadAllLines(path + input);
                return helpText;
            }
            else { return null; }
        }
        /// <summary>
        /// This method presents tools to take a snapshot of the graph at a current time and save it as a .png-file
        /// </summary>
        /// <param name="PaneltoPNG"></param>
        public static void saveToImage(MasterGraphPanel PaneltoPNG)
        {
            Bitmap tempBitmap = new Bitmap(PaneltoPNG.ClientSize.Width, PaneltoPNG.ClientSize.Height);
            PaneltoPNG.DrawToBitmap(tempBitmap, PaneltoPNG.ClientRectangle);
            tempBitmap.Save(@"Simulation Data\Simulation graf.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
