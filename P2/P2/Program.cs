using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P2
{
    class Program
    {
        /// <summary>
        /// The program starts here.
        /// </summary>
        public static void Main()
        {
            Directory.CreateDirectory( Directory.GetCurrentDirectory() + "\\SimData" ); //create a directory for saved files.
            GUI gui = new GUI();
            gui.ShowDialog();
        }
    }
}
