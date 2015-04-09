using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace P2
{
    //This class handles the serialization and actual loading/saving of the data, and creates/overrides the savefile.
    class Serializer
    {
        public void SerializeObject(string filename, DataToSerialize objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }
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
