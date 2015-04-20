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
        public CalcForm()
        {
            InitializeComponent();
        }

		public void UpdateData(DataPoint updateData){
			this.temperature.Text = updateData.temperature.ToString ();
			this.molarmass.Text = updateData.nNitrogen.ToString ();
			this.partialpressure.Text = ((updateData.nNitrogen * updateData.temperature * double.Parse (this.gasConst.Text))
			/ double.Parse (this.Volume.Text)).ToString ();
		}
    }
}
