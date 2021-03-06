﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace P2
{
    public partial class GUI : Form
    {
        Synthesis synth;
        helpTextController helper;
        double tempDouble;
        Button[] buttons = new Button[9];
        int graphTaps = 1;
                
        public GUI()
        {
            InitializeComponent();
            synth = new Synthesis(pGraphArea);
            helper = new helpTextController();
            Control.CheckForIllegalCrossThreadCalls = false;
            buttons[0] = new Button();
            buttons[0].Location = new Point(0, 0);
            buttons[0].Text = "Graf 1      [X]";
            buttons[0].Click += chooseGraph;
            this.pTabs.Controls.Add(buttons[0]);
            buttons[7] = new Button();
            buttons[7].Location = new Point(75, 0);
            buttons[7].Text = "Tilføj graf";
            buttons[7].Click += addGraph_Click;
            this.pTabs.Controls.Add(buttons[7]);
            buttons[8] = new Button();
            buttons[8].Location = new Point(875,15);
            buttons[8].Text = "Videre";
            buttons[8].Click += cycleHelp_Click;
            this.pInfoBox.Controls.Add(buttons[8]);
            buttons[8].BackColor = (Color.White);
            pInfoBox.Controls.Add(new Label());
            String[] helpText = helper.Next();
            updateHelpText(helpText[0], helpText[1]);

            //midlertidig graf
            this.pGraphArea.Paint += new PaintEventHandler(pGraphArea.EventHandler_RePaint);
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

        private void OpenCalc_Click(object sender, EventArgs e)
        {
            if ((IsFormAlreadyOpen(typeof(CalcForm))) == null)
            {
                CalcForm calcForm = new CalcForm();
				calcForm.UpdateData (synth.currentData);
                calcForm.Show();
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
            if (!synth.running && Double.TryParse(textBox1.Text, out tempDouble))
            {
                synth.currentData.nNitrogen = tempDouble;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox2, hScrollBarH2);
            if (!synth.running && Double.TryParse(textBox2.Text, out tempDouble))
            {
                synth.currentData.nHydrogen = tempDouble;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox3, hScrollBarNH3);
            if (!synth.running && Double.TryParse(textBox3.Text, out tempDouble))
            {
                synth.currentData.nAmmonia = tempDouble;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox4, hScrollBarTemperature);
            if (!synth.running && Double.TryParse(textBox4.Text, out tempDouble))
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
            synth.timer.Elapsed += Update;
        }

        Random rand = new Random();
        public void Update(Object source,  System.Timers.ElapsedEventArgs e)
        {
            //BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
            numericUpDown1.Value = (decimal)synth.Time/1000;

            textBox1.Text = synth.currentData.nNitrogen.ToString();
            textBox2.Text = synth.currentData.nHydrogen.ToString();
            textBox3.Text = synth.currentData.nAmmonia.ToString();
            textBox4.Text = synth.currentData.temperature.ToString();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            synth.stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!synth.running)
            {
                //synth.Time = (double) numericUpDown1.Value;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            synth.Scale = (double) int.Parse(comboBox5.SelectedItem.ToString().TrimStart('x'));
        }

        private void addGraph_Click(object sender, EventArgs e)
        {
            if (buttons[7].Location.X <= 450)
            {
                buttons[7].Location = new Point((buttons[7].Location.X + 75), 0);
                if (graphTaps <= 7)
                {
                    buttons[graphTaps] = new Button();
                    buttons[graphTaps].Location = new Point((graphTaps * 75), 0);
                    buttons[graphTaps].Text = "Graf " + (graphTaps + 1) + "     [X]";
                    buttons[graphTaps].Click += chooseGraph;
                    this.pTabs.Controls.Add(buttons[graphTaps++]);
                }
            }
        }

        private void chooseGraph(object sender, EventArgs e)
        {
            int X = Cursor.Position.X,
                Y = Cursor.Position.Y,
                Sx = this.Location.X,
                Sy = this.Location.Y;
            if ((55 + X - Sx) % 75 <= 65 && (55 + X - Sx) % 75 >= 52 && graphTaps >= 0)
            {
                this.pTabs.Controls.Remove(buttons[--graphTaps]);
                buttons[7].Location = new Point(buttons[7].Location.X - 75, 0);

            }
            else
            {

            }
        }


        private void cycleHelp_Click(object sender, EventArgs e)
        {
            String[] helpText = helper.Next();
            updateHelpText(helpText[0], helpText[1]);
        }

        /// <summary>
        /// Sets the text of the gray instructions panel at the bottom of the main GUI
        /// </summary>
        /// <param name="currentHelp">the topmost instruction, which will be preface with NU:</param>
        /// <param name="nextHelp">the bottom most instruction, which will be prefaced with NÆSTE:</param>
        public void updateHelpText(string currentHelp, string nextHelp)
        {
            pInfoBox.Controls.RemoveAt(1);
            Label helpText = new Label();
            helpText.Location = new Point(15, 15);
            helpText.Size = new Size(850, 100);
            helpText.Font = new Font("Microsoft Sans Serif", 11);
            helpText.Text = "NU: " + currentHelp + "\n\nNÆSTE: " + nextHelp;
            pInfoBox.Controls.Add(helpText);
        }

        private void saveGraph_Click(object sender, EventArgs e)
        {
            SaveLoadTools.saveToImage(pGraphArea);
        }
    }
}
