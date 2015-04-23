using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2
{
    public partial class CalcForm : Form
    {
		ContextMenu cm = new ContextMenu();

		private const double gasConstant = 8.3145;
		private const double preExpontentialFactor = 1;
		private const double volume = 50000; // liter
        private const double entalpi = -91800;
        private const double entropi = -198.05;

		private Synthesis _synth;

		public CalcForm(Synthesis synth)
        {
			this._synth = synth;

            /* for test!!! slet senere */
            _synth.currentData.temperature = 500;
            _synth.currentData.nHydrogen = 232;
            _synth.currentData.nNitrogen = 343;
            _synth.currentData.nAmmonia = 212;

            InitializeComponent();
            UpdateData();
            setupContextMenu();

            this.idealGasTitle.ContextMenu = cm;
        }

		public void UpdateData(){


            setupStartIdealGasLaw();
            calcEquiFrac();
            calcRRConst();
        
		}

        private void setupContextMenu()
        {
            cm.MenuItems.Add("Nitrogen");
            cm.MenuItems.Add("Hydrogen");
            cm.MenuItems.Add("Ammoniak");

            cm.MenuItems[0].Click += menuItem1_ItemClick;
            cm.MenuItems[1].Click += menuItem2_ItemClick;
            cm.MenuItems[2].Click += menuItem3_ItemClick;
        }

        private void setupStartIdealGasLaw()
        {
            this.idealGasTitle.Text = "Idealgasligningen " + "(nitrogen)";
            this.temperature.Text = _synth.currentData.temperature.ToString();
            this.molarmass.Text = _synth.currentData.nNitrogen.ToString();
            this.gasConst.Text = gasConstant.ToString();
            this.Volume.Text = volume.ToString();
            this.partialpressure.Text = ((_synth.currentData.nNitrogen * _synth.currentData.temperature * gasConstant)
                / volume).ToString("#.##");
        }

        private void calcEquiFrac()
        {
            this.equiFracResult.Text = string.Format("{0:N7}", (Math.Pow(((this._synth.currentData.nAmmonia * this._synth.currentData.temperature * gasConstant)
        / volume), 2) / (Math.Pow(((this._synth.currentData.nNitrogen * this._synth.currentData.temperature * gasConstant)
        / volume), 2) * Math.Pow(((this._synth.currentData.nHydrogen * this._synth.currentData.temperature * gasConstant)
        / volume), 2))));

            this.equiTitle.Text = "Ligevægtsbrøken: " + "Y = " + string.Format("{0:N7}", (Math.Pow(Math.E, -(entalpi
                    / (this._synth.currentData.temperature * gasConstant)) + (entropi / gasConstant))));

            this.pAmmoniaEqui.Text = string.Format("{0:N3}", Math.Pow(((this._synth.currentData.nAmmonia * this._synth.currentData.temperature * gasConstant)
                    / volume), 2));

            this.pNitrogenEqui.Text = string.Format("{0:N3}", Math.Pow(((this._synth.currentData.nNitrogen * this._synth.currentData.temperature * gasConstant)
                   / volume), 2));

            this.pHydrogenEqui.Text = string.Format("{0:N3}", (Math.Pow(((this._synth.currentData.nHydrogen * this._synth.currentData.temperature * gasConstant)
                    / volume), 2)));
        }

        private void calcRRConst()
        {
            this.preExponentialFactor.Text = preExpontentialFactor.ToString();
            this.activationEnergy.Text = (this._synth.currentData.catalyst == true) ? 60.ToString() : 1100.ToString();
            this.gasConstRR.Text = gasConstant.ToString();
            this.temperatureRR.Text = this._synth.currentData.temperature.ToString();
            this.RRConst.Text = string.Format("{0:N7}", preExpontentialFactor
                    * Math.Pow(Math.E, ((this._synth.currentData.catalyst == true) ? 60 : 1100)
                    / (gasConstant * this._synth.currentData.temperature)));  
        }

		private void menuItem1_ItemClick (object sender, System.EventArgs e)
		{
            this.idealGasTitle.Text = "Idealgasligningen " + "(nitrogen)";
            this.temperature.Text = _synth.currentData.temperature.ToString("#.##");
            this.molarmass.Text = _synth.currentData.nNitrogen.ToString("#.##");
            this.gasConst.Text = gasConstant.ToString("#.##");
            this.Volume.Text = volume.ToString("#.##");
			this.partialpressure.Text = ((_synth.currentData.nNitrogen * _synth.currentData.temperature * gasConstant)
            / volume).ToString("#.##");
		}
    
		private void menuItem2_ItemClick (object sender, System.EventArgs e)
		{
            this.idealGasTitle.Text = "Idealgasligningen " + "(hydrogen)";
            this.temperature.Text = _synth.currentData.temperature.ToString("#.##");
            this.molarmass.Text = _synth.currentData.nHydrogen.ToString("#.##");
			this.gasConst.Text = gasConstant.ToString ("#.##");
			this.Volume.Text = volume.ToString ("#.##");
			this.partialpressure.Text = ((_synth.currentData.nHydrogen * _synth.currentData.temperature * gasConstant)
			/ volume).ToString ("#.##");
		}

		private void menuItem3_ItemClick (object sender, System.EventArgs e)
		{
            this.idealGasTitle.Text = "Idealgasligningen " + "(ammoniak)";
            this.temperature.Text = _synth.currentData.temperature.ToString("#.##");
			this.molarmass.Text = _synth.currentData.nAmmonia.ToString("#.##");
            this.gasConst.Text = gasConstant.ToString("#.##");
            this.Volume.Text = volume.ToString("#.##");
			this.partialpressure.Text = ((_synth.currentData.nAmmonia * _synth.currentData.temperature * gasConstant)
            / volume).ToString("#.##");
		}
	}
}
