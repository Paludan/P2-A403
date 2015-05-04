using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    class LoadEventArgs : EventArgs
    {
        public List<DataPoint> loadedList;
        public LoadEventArgs(List<DataPoint> tempDataList)
        {
            loadedList = tempDataList;
        }
    }
}
