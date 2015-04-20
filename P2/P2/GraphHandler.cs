﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using P2Graph;

namespace P2
{
    public class GraphHandler
    {
        public MasterGraphPanel _graphPanel;
        Graph _temperature;
        Graph _pressure;
        Graph _pAmmonia;
        Graph _pHydrogen;
        Graph _pNitrogen;



        public GraphHandler(MasterGraphPanel graphArea)
        {
            _graphPanel = graphArea;
            InitGraphs();
        }

        private void InitGraphs()
        {
            _temperature = new Graph("Temperatur", Color.Red);
            _pressure = new Graph("Tryk", Color.Yellow);
            _pAmmonia = new Graph("Ammoniak", Color.Black);
            _pHydrogen = new Graph("Hydrogen", Color.Blue);
            _pNitrogen = new Graph("Nitrogen", Color.Green);

            _graphPanel.AddGraph(_temperature);
            _graphPanel.AddGraph(_pressure);
            _graphPanel.AddGraph(_pAmmonia);
            _graphPanel.AddGraph(_pHydrogen);
            _graphPanel.AddGraph(_pNitrogen);
        }

        public void Update(DataPoint data)
        {
            _pressure.AddAndDraw(data.time, data.pressure);
            _pAmmonia.AddAndDraw(data.time, data.nAmmonia);
            _temperature.AddAndDraw(data.time, data.temperature);
            _pHydrogen.AddAndDraw(data.time, data.nHydrogen);
            _pNitrogen.AddAndDraw(data.time, data.nNitrogen);
        }

    }
}