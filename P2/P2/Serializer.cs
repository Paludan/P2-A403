using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace P2
{
    //This class handles the serialization and actual loading/saving of the data, and creates/overrides the savefile.
    class Serializer
    {
        /// <summary>
        /// This method creates a file with the given filename and writes the objectToSerialize to the file.
        /// </summary>
        /// <param name="filename">The name of the file to be written </param>
        /// <param name="objectToSerialize">The objet to be written to the file, in this case a class containing a list of DataPoints</param>
        
        
        public void SerializeObject(string filename, DataToSerialize objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }
        /// <summary>
        /// This method opens a file with the given filename, and reads it into a DataToSerialize class. Which contains a list of DataPoints
        /// </summary>
        /// <param name="filename">The name of the file to be loaded</param>
        /// <returns></returns>
        public DataToSerialize DeSerializeObject(string filename)
        {
            DataToSerialize objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (DataToSerialize)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}
