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
        Synthesis synth;
        double tempDouble;

        public GUI()
        {
            InitializeComponent();
            synth = new Synthesis();
        }

        /// <summary>
        /// Makes sure only positive integers can be inserted into a textbox
        /// If e.handled is set to true the key pressed is cancelled
        /// </summary>
        /// <param name="e">The key pressed when typing in the textbox</param>
        private void intTextbox(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                e.Handled = e.KeyChar != (char)Keys.Back;
        }
        
        /// <summary>
        /// Makes sure a number have been inserted and that it is not larger than the max input
        /// Removes unwanted zeroes
        /// Changes the state of the scrollbar depending on the integer in the textbox
        /// </summary>
        /// <param name="textBox">The textbox which information is to be handled</param>
        /// <param name="hScrollBar">The scrollbar which is to be controlled</param>
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

        /// <summary>
        /// Makes sure no more than one instance of a form is open
        /// </summary>
        /// <param name="FormType">The type of the form to restrict the amount of</param>
        /// <returns>Returns the type of the form or null if the form is not open</returns>
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        /// <summary>
        /// Inserts the value of the scrollBar into the corresponting textbox
        /// Sends the value to be calculated when the scrollbar is dropped
        /// </summary>
        /// <param name="textBox">The textbox to have the value inserted</param>
        /// <param name="hScrollBar">The scrollbar where the value is taken</param>
        /// <param name="e">Used to make sure the scrolling have ended</param>
        private void scrollEnd(TextBox textBox, ScrollBar hScrollBar, ScrollEventArgs e)
        {
            textBox.Text = hScrollBar.Value.ToString();
            if (e.Type == ScrollEventType.EndScroll)
            {
                //Send value to calculation
            }
        }

        /// <summary>
        /// Creates an instance of the loadMenu if an instance is not present and displays it
        /// </summary>
        private void Load_Click(object sender, EventArgs e)
        {
            if ((IsFormAlreadyOpen(typeof(LoadMenu))) == null)
            {
                LoadMenu loadMenu = new LoadMenu();
                loadMenu.Show();
            }
        }

        /// <summary>
        /// Saves the current state of the graph
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
            //SaveLoadTools.save();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            intTextbox(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            intTextbox(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            intTextbox(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            intTextbox(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox1, hScrollBarN2);
            if (Double.TryParse(textBox1.Text, out tempDouble))
            {
                synth.currentData.nNitrogen = tempDouble;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox2, hScrollBarH2);
            if (Double.TryParse(textBox1.Text, out tempDouble))
            {
                synth.currentData.nHydrogen = tempDouble;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox3, hScrollBarNH3);
            if (Double.TryParse(textBox1.Text, out tempDouble))
            {
                synth.currentData.nAmmonia = tempDouble;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox4, hScrollBarTemperature);
            if (Double.TryParse(textBox1.Text, out tempDouble))
            {
                synth.currentData.temperature = tempDouble;
            }
        }

        private void hScrollBarN2_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox1, hScrollBarN2, e);
        }

        private void hScrollBarH2_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox2, hScrollBarH2, e);
        }

        private void hScrollBarNH3_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox3, hScrollBarNH3, e);
        }

        private void hScrollBarTemperature_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox4, hScrollBarTemperature, e);
        }

        private void start_Click(object sender, EventArgs e)
        {
            synth.start();
            synth.timer.Elapsed += changecolor;
        }
        Random rand = new Random();
        public void changecolor(Object source,  System.Timers.ElapsedEventArgs e)
        {
            this.BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }

        private void stop_Click(object sender, EventArgs e)
        {
            synth.stop();
        }
    }
}
