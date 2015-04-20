using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using P2Graph;

namespace P2
{
    //This class presents tools to take a snapshot of the graph at a current time and save it as a .png-file
    public class Snapshot
    {
        public void saveToImage(MasterGraphPanel PaneltoPNG)
        {
            Bitmap tempBitmap = new Bitmap(PaneltoPNG.ClientSize.Width, PaneltoPNG.ClientSize.Height);
            PaneltoPNG.DrawToBitmap(tempBitmap, PaneltoPNG.ClientRectangle);
            tempBitmap.Save(SaveLoadTools.path + "Graf.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
