using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace P2
{
    //This abstract class presents graph-drawing tools
    public static class GraphTools
    {
        private string title;
        private Point[] pointArray;
        private string xAxis;
        private string yAxis;
        //Windows-folket skal lige indtaste using ... til denne
        private Panel drawPanel;

        public GraphTools(string iTitle, Point[] iPointArray, string ixAxis, string iyAxis, Panel iDrawPanel)
        {
            this.title = iTitle;
            this.pointArray = iPointArray;
            this.xAxis = ixAxis;
            this.yAxis = iyAxis;
            this.drawPanel = iDrawPanel;
        }

        public static void drawGraph()
        {

        }

        public static void updateGraph()
        {

        }

        public static void zoom()
        {

        }
    }
}
