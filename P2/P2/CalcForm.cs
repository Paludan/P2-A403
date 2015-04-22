﻿using System;
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
		private const double preExpontentialFactor = 884900000000000;
		private const double volume = 50000; // liter

		private Synthesis _synth;

		public CalcForm(Synthesis synth)
        {
			this._synth = synth;

            InitializeComponent();

			this.cm.MenuItems[0].Click +=  menuItem1_ItemClick;
			this.cm.MenuItems[1].Click +=  menuItem2_ItemClick;
			this.cm.MenuItems[2].Click +=  menuItem3_ItemClick;
        }

		public void UpdateData(){
			this.temperature.Text = _synth.currentData.temperature.ToString();
			this.molarmassNitrogen.Text = _synth.currentData.nNitrogen.ToString();
			this.gasConst.Text = gasConstant.ToString ();
			this.Volume.Text = volume.ToString ();
			this.partialpressure.Text = ((_synth.currentData.nNitrogen * _synth.currentData.temperature * gasConstant)
				/ volume).ToString ();
		}

		private void menuItem1_ItemClick (object sender, System.EventArgs e)
		{	
			this.temperature.Text = _synth.currentData.temperature.ToString();
			this.molarmassNitrogen.Text = _synth.currentData.nNitrogen.ToString();
			this.gasConst.Text = gasConstant.ToString ();
			this.Volume.Text = volume.ToString ();
			this.partialpressure.Text = ((_synth.currentData.nNitrogen * _synth.currentData.temperature * gasConstant)
			/ volume).ToString ();
		}
    
		private void menuItem2_ItemClick (object sender, System.EventArgs e)
		{	
			this.temperature.Text = _synth.currentData.temperature.ToString();
			this.molarmassNitrogen.Text = _synth.currentData.nHydrogen.ToString();
			this.gasConst.Text = gasConstant.ToString ();
			this.Volume.Text = volume.ToString ();
			this.partialpressure.Text = ((_synth.currentData.nHydrogen * _synth.currentData.temperature * gasConstant)
			/ volume).ToString ();
		}

		private void menuItem3_ItemClick (object sender, System.EventArgs e)
		{	
			this.temperature.Text = _synth.currentData.temperature.ToString();
			this.molarmassNitrogen.Text = _synth.currentData.nAmmonia.ToString();
			this.gasConst.Text = gasConstant.ToString ();
			this.Volume.Text = volume.ToString ();
			this.partialpressure.Text = ((_synth.currentData.nAmmonia * _synth.currentData.temperature * gasConstant)
			/ volume).ToString ();
		}
	}
}
