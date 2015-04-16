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
        public static void Main()
        {
            string dir = Directory.GetCurrentDirectory() + "\\SaveFiles";
            Directory.CreateDirectory(dir + "\\SaveFiles");
            GUI gui = new GUI();
            gui.ShowDialog();
            
        }
    }
}
