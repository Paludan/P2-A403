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
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) || e.KeyChar == '.')
                e.Handled = e.KeyChar != (char)Keys.Back;
        }

        private void hScrollBarN2_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = hScrollBarN2.Value.ToString();
        }

        private void hScrollBarH2_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = hScrollBarH2.Value.ToString();
        }

        private void hScrollBarNH3_Scroll(object sender, ScrollEventArgs e)
        {
            textBox3.Text = hScrollBarNH3.Value.ToString();
        }

        private void hScrollBarTemperature_Scroll(object sender, ScrollEventArgs e)
        {
            textBox4.Text = hScrollBarTemperature.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox1, hScrollBarN2);
        }
      
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox2, hScrollBarH2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox3, hScrollBarNH3);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox4, hScrollBarTemperature);
        }

        // Handles the value of a textbox
        // Makes sure a number is inserted and that it is not larger than the max input
        // Changes the value of the scrollbar of the textbox
        private void textChanged(TextBox textBox, HScrollBar hScrollBar)
        {
            if (!textBox.Text.Equals("") && int.Parse(textBox.Text) != 0)
            {
                textBox.Text = textBox.Text.ToString().TrimStart('0');
                if (int.Parse(textBox.Text) <= hScrollBar.Maximum)
                    hScrollBar.Value = int.Parse(textBox.Text);
                else
                {
                    hScrollBar.Value = hScrollBar.Maximum;
                    textBox.Text = hScrollBar.Maximum.ToString();
                }
            }
            else
            {
                hScrollBar.Value = 0;
                textBox.Text = "0";
            }
        }
    }
}
