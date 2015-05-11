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
		/* constant values that are used for calculations in the class methods */
		private const double gasConstant = 8.314472;
        private const double gasConstantCal = 1.987;
        private const double preExpontentialFactor = 884900000000000;
        private const double volume = 50000; //         liter
        private const double entalpi = -91800; //       J/mol
        private const double entropi = -198.05; //      J/(mol*kelvin)
        private const double EaCatalyst = 55000; //     J/mol
        private const double EaNoCatalyst = 120000; //  J/mol

		private Synthesis _synth;
		ContextMenu cm = new ContextMenu();

		/// <summary>
		/// Initializes a new instance of the <see cref="P2.CalcForm"/> class.
		/// </summary>
		/// <param name="synth">Synth.</param>
		public CalcForm(Synthesis synth)
		{
	    	this._synth = synth;

	    	InitializeComponent();
	    	UpdateData();
	    	setupContextMenu();

	    	this.idealGasTitle.ContextMenu = cm;
		}

		/// <summary>
		/// Updates the data.
		/// </summary>
		public void UpdateData()
		{
	   		setupStartIdealGasLaw();
	    	calcEquiConst();
	    	calcEquiFrac();
	    	calcRRConst();
		}

		/// <summary>
		/// Setups the context menu.
		/// </summary>
		private void setupContextMenu()
		{
	    	cm.MenuItems.Add("Nitrogen");
	    	cm.MenuItems.Add("Hydrogen");
	    	cm.MenuItems.Add("Ammoniak");
	    
	    	cm.MenuItems[0].Click += menuItem1_ItemClick;
	    	cm.MenuItems[1].Click += menuItem2_ItemClick;
	    	cm.MenuItems[2].Click += menuItem3_ItemClick;
		}

		/// <summary>
		/// Setups the start ideal gas law.
		/// </summary>
		private void setupStartIdealGasLaw()
		{
	    	this.idealGasTitle.Text = "Idealgasligningen " + "(nitrogen)";
	    	this.temperature.Text = _synth.currentData.temperature.ToString();
	    	this.molarmass.Text = _synth.currentData.nNitrogen.ToString();
	    	this.gasConst.Text = gasConstant.ToString();
	    	this.Volume.Text = volume.ToString();
	    	this.partialpressure.Text = ((_synth.currentData.nNitrogen * _synth.currentData.temperature * gasConstant)
				/volume).ToString("#.##");
		}

		/// <summary>
		/// Calculates the equi const.
		/// </summary>
		private void calcEquiConst()
		{
	    	this.entalpiLabel.Text = CalcForm.entalpi.ToString();
	    	this.entropiLabel.Text = CalcForm.entropi.ToString();
	    	this.temperatureEqui.Text = this._synth.currentData.temperature.ToString();
	    	this.gasConstEqui.Text = CalcForm.gasConstant.ToString();
	    	this.gasConstEqui2.Text = CalcForm.gasConstant.ToString();
	    	this.equiConst.Text = String.Format("{0:N4}", Math.Pow(Math.E, -(CalcForm.entalpi 
				/ (this._synth.currentData.temperature * CalcForm.gasConstant)) + (CalcForm.entropi / CalcForm.gasConstant)));
		}

		/// <summary>
		/// Calculates the equi frac.
		/// </summary>
		private void calcEquiFrac()
		{
	    	this.equiFracResult.Text = string.Format("{0:N7}", (Math.Pow(((this._synth.currentData.nAmmonia * 
	    	this._synth.currentData.temperature * gasConstant)
				/ volume), 2) / (Math.Pow(((this._synth.currentData.nNitrogen * this._synth.currentData.temperature * gasConstant)
				/ volume), 2) * Math.Pow(((this._synth.currentData.nHydrogen * this._synth.currentData.temperature * gasConstant)
				/ volume), 2))));

	    	this.equiTitle.Text = "Ligevægtsbrøken: " + "Y = " + string.Format("{0:N4}", (Math.Pow(Math.E, -(entalpi
				/ (this._synth.currentData.temperature * gasConstant)) + (entropi / gasConstant))));

	    	this.pAmmoniaEqui.Text = string.Format("{0:N3}", Math.Pow(((this._synth.currentData.nAmmonia 
				* this._synth.currentData.temperature * gasConstant)
				/ volume), 2));

	    	this.pNitrogenEqui.Text = string.Format("{0:N3}", Math.Pow(((this._synth.currentData.nNitrogen 
				* this._synth.currentData.temperature * gasConstant)
				/ volume), 2));

	    	this.pHydrogenEqui.Text = string.Format("{0:N3}", (Math.Pow(((this._synth.currentData.nHydrogen 
				* this._synth.currentData.temperature * gasConstant) / volume), 2)));
		}

		/// <summary>
		/// Calculates the RR const.
		/// </summary>
		private void calcRRConst()
		{
	   		this.preExponentialFactor.Text = string.Format("{0:E2}", preExpontentialFactor);
	    	this.activationEnergy.Text = (this._synth.currentData.catalyst == true) ? EaCatalyst.ToString() : EaNoCatalyst.ToString();
	    	this.gasConstRR.Text = gasConstantCal.ToString();
	    	this.temperatureRR.Text = this._synth.currentData.temperature.ToString();
	    	this.RRConst.Text = string.Format("{0:N7}", preExpontentialFactor
				* Math.Pow(Math.E, -((this._synth.currentData.catalyst == true) ? EaCatalyst : EaNoCatalyst)
				/ (gasConstantCal * this._synth.currentData.temperature)));  
		}

		/// <summary>
		/// MenuItem1 eventhandler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
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
    
		/// <summary>
		/// MenuItem2 eventhandler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
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

		/// <summary>
		/// MenuItem3 eventhandler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
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