using System.IO;

namespace P2
{
    class Program
    {
        public static void Main()
        {
            Directory.CreateDirectory( Directory.GetCurrentDirectory() + "\\SimData" ); //create a directory for saved files.
            GUI gui = new GUI();
            gui.ShowDialog();
        }
    }
}
