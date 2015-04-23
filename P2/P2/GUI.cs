using System;
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
        Button[] buttons = new Button[8];
        int graphTaps = 0;
                
        public GUI()
        {
            InitializeComponent();
            synth = new Synthesis(pGraphArea);
            helper = new helpTextController();
            Control.CheckForIllegalCrossThreadCalls = false;
            startUpTaps();
            startUpInfo();
            correctTextSize();
        }

        #region Startup
        /// <summary>
        /// Creates the initial taps
        /// </summary>
        private void startUpTaps()
        {
            buttons[graphTaps] = new Button();
            buttons[graphTaps].Location = new Point(0, 0);
            insertButtonText(buttons[graphTaps]);
            buttons[graphTaps].Click += chooseGraph;
            this.pTabs.Controls.Add(buttons[graphTaps++]);
            buttons[7] = new Button();
            buttons[7].Location = new Point(75, 0);
            buttons[7].Text = "Tilføj graf";
            buttons[7].Click += addGraph_Click;
            this.pTabs.Controls.Add(buttons[7]);
        }

        /// <summary>
        /// Creates the initial text for the infobox
        /// </summary>
        private void startUpInfo()
        {
            pInfoBox.Controls.Add(new Label());
            String[] helpText = helper.Next();
            updateHelpText(helpText[0], helpText[1]);
        }
        #endregion

        #region Support functions
        /// <summary>
        /// Calls the autoScaleText function for every label and textBox in the form
        /// </summary>
        private void correctTextSize()
        {
            foreach (Control formItem in this.Controls)
            {
                if (formItem.GetType() == typeof(Panel))
                    foreach (Control item in formItem.Controls)
                        autoScaleText(item);
                else if (formItem.GetType() == typeof(Label) || formItem.GetType() == typeof(CheckBox))
                    autoScaleText(formItem);
            }

			//Eventhandling til pGraphArea
			this.pGraphArea.Paint += pGraphArea.OnInvalidateEvent;
			this.pGraphArea.Invalidate();
        }

        /// <summary>
        /// Reduces the size of a labels text to the point where it fits in the label
        /// </summary>
        /// <param name="label">The label which text is to be resized</param>
        private void autoScaleText(Control label)
        {
            while (label.Width < System.Windows.Forms.TextRenderer.MeasureText(label.Text, new Font(label.Font.FontFamily,
                   label.Font.Size, label.Font.Style)).Width ||
                   label.Height < System.Windows.Forms.TextRenderer.MeasureText(label.Text, new Font(label.Font.FontFamily,
                   label.Font.Size, label.Font.Style)).Height)
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - 0.01f, label.Font.Style);
        }

        /// <summary>
        /// Writes the text of the button taps with variating spacing depending on the text size
        /// </summary>
        /// <param name="button">Is the button where the text is to be written in</param>
        private void insertButtonText(Button button)
        {
            int spaces = ((int)((75 / ((double)TextRenderer.MeasureText("Graf 1      [X]", new Font(button.Font.FontFamily, button.Font.Size, button.Font.Style)).Width)) * 15) - 10);
            string space = "";
            space = space.PadRight(spaces);
            button.Text = "Graf " + (graphTaps + 1) + space + "[x]";
        }
                
        /// <summary>
        /// Makes sure only positive integers can be inserted into a textbox
        /// If e.handled is set to true the key pressed is cancelled
        /// </summary>
        /// <param name="e">The key pressed when typing in the textbox</param>
        private void intTextbox(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '.')
                e.Handled = e.KeyChar != (char)Keys.Back;
        }

        /// <summary>
        /// Stop the user from entering text if the synthesis is running
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Returns true if the synthesis is not running</returns>
        private bool denyTextWhenSynthRun(KeyPressEventArgs e)
        {
            if (synth.running)
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Makes sure a number have been inserted and that it is not larger than the max input
        /// Removes unwanted zeroes
        /// Changes the state of the scrollbar depending on the double in the textbox
        /// </summary>
        /// <param name="textBox">The textbox which information is to be handled</param>
        /// <param name="hScrollBar">The scrollbar which is to be controlled</param>
        private void textChanged(TextBox textBox, HScrollBar hScrollBar)
        {
            if (!textBox.Text.Equals("") && double.Parse(textBox.Text) != 0)
            {
                textBox.Text = textBox.Text.ToString().TrimStart('0');
                if (double.Parse(textBox.Text) <= hScrollBar.Maximum)
                    hScrollBar.Value = (int) double.Parse(textBox.Text);
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
        /// </summary>
        /// <param name="textBox">The textbox to have the value inserted</param>
        /// <param name="hScrollBar">The scrollbar where the value is taken</param>
        private void scrollEnd(TextBox textBox, ScrollBar hScrollBar)
        {
            textBox.Text = hScrollBar.Value.ToString();
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
            helpText.Font = new Font("Microsoft Sans Serif", 30);
            helpText.Text = "NU: " + currentHelp + "\n\nNÆSTE: " + nextHelp;
            pInfoBox.Controls.Add(helpText);
            autoScaleText(helpText);
        }
        #endregion

        #region Event functions
        #region Click events
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
        /// Opens an instance of the calcForm if one is not open
        /// </summary>
        private void OpenCalc_Click(object sender, EventArgs e)
        {
            if ((IsFormAlreadyOpen(typeof(CalcForm))) == null)
            {
				CalcForm calcForm = new CalcForm(synth);
				calcForm.UpdateData ();
                calcForm.Show();
            }
        }

        /// <summary>
        /// Saves the current state of the graph
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
            SaveLoadTools.save(synth.Datapoints);
        }

        /// <summary>
        /// Starts the synthesis and disables the scrollbars
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            synth.start();
            synth.timer.Elapsed += Update;
            hScrollBarNH3.Enabled = false;
            hScrollBarH2.Enabled = false;
            hScrollBarN2.Enabled = false;
            hScrollBarTemperature.Enabled = false;
        }

        /// <summary>
        /// Stops the synthesis and enables the scrollbars
        /// </summary>
        private void stop_Click(object sender, EventArgs e)
        {
            synth.stop();
            hScrollBarNH3.Enabled = true;
            hScrollBarH2.Enabled = true;
            hScrollBarN2.Enabled = true;
            hScrollBarTemperature.Enabled = true;
        }

        /// <summary>
        /// If the addButton is pressed and the location is not too much to the right then it creates a new graph tap
        /// </summary>
        private void addGraph_Click(object sender, EventArgs e)
        {
            if (buttons[7].Location.X <= 450)
            {
                buttons[7].Location = new Point((buttons[7].Location.X + 75), 0);
                if (graphTaps <= 7)
                {
                    buttons[graphTaps] = new Button();
                    buttons[graphTaps].Location = new Point((graphTaps * 75), 0);
                    insertButtonText(buttons[graphTaps]);
                    buttons[graphTaps].Click += chooseGraph;
                    this.pTabs.Controls.Add(buttons[graphTaps++]);
                }
            }
        }

        /// <summary>
        /// Saves the current graph to a .png file
        /// </summary>
        private void saveGraph_Click(object sender, EventArgs e)
        {
            SaveLoadTools.saveToImage(pGraphArea);
        }

        /// <summary>
        /// Switches the current text in the infobox
        /// </summary>
        private void FurtherInfoBox_Click(object sender, EventArgs e)
        {
            String[] helpText = helper.Next();
            updateHelpText(helpText[0], helpText[1]);
        }
        #endregion

        /// <summary>
        /// If the selected reaction rate multiplier is changed then the new selected value is send to the synthesis
        /// </summary>
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            synth.Scale = (double)int.Parse(comboBox5.SelectedItem.ToString().TrimStart('x'));
        }

        /// <summary>
        /// Makes sure the user cant change the variable when the synthesis is runnning
        /// </summary>
        /// <param name="e">The numericUpDown1's keyPress event parameters</param>
        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            denyTextWhenSynthRun(e);
        }

        /// <summary>
        /// Makes sure user can only input doubles in the text boxes and not when synthesis is runnning
        /// </summary>
        #region textBox_KeyPress
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(denyTextWhenSynthRun(e))
                intTextbox(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (denyTextWhenSynthRun(e))
                intTextbox(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (denyTextWhenSynthRun(e))
                intTextbox(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (denyTextWhenSynthRun(e))
                intTextbox(e);
        }
        #endregion

        /// <summary>
        /// Changes the value of the corresponding scrollbar and the textbox
        /// Sends the value to the synthesis if it is not running
        /// </summary>
        #region textBox_TextChanged
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox1, hScrollBarN2);
            if (!synth.running && Double.TryParse(textBox1.Text, out tempDouble))
                synth.currentData.nNitrogen = tempDouble;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox2, hScrollBarH2);
            if (!synth.running && Double.TryParse(textBox2.Text, out tempDouble))
                synth.currentData.nHydrogen = tempDouble;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox3, hScrollBarNH3);
            if (!synth.running && Double.TryParse(textBox3.Text, out tempDouble))
                synth.currentData.nAmmonia = tempDouble;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textChanged(textBox4, hScrollBarTemperature);
            if (!synth.running && Double.TryParse(textBox4.Text, out tempDouble))
                synth.currentData.temperature = tempDouble;
        }
        #endregion

        /// <summary>
        /// Changes the text of the corresponding textBox
        /// </summary>
        #region scrollbar_Scroll
        private void hScrollBarN2_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox1, hScrollBarN2);
        }

        private void hScrollBarH2_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox2, hScrollBarH2);
        }

        private void hScrollBarNH3_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox3, hScrollBarNH3);
        }

        private void hScrollBarTemperature_Scroll(object sender, ScrollEventArgs e)
        {
            scrollEnd(textBox4, hScrollBarTemperature);
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void Update(Object source,  System.Timers.ElapsedEventArgs e)
        {
            numericUpDown1.Value = (decimal)synth.Time;

            textBox1.Text = synth.currentData.nNitrogen.ToString();
            textBox2.Text = synth.currentData.nHydrogen.ToString();
            textBox3.Text = synth.currentData.nAmmonia.ToString();
            textBox4.Text = synth.currentData.temperature.ToString();
        }
        
        /// <summary>
        /// If the button is pushed the curser and forms x-value is saved to two integers
        /// It is then checked if the location is within the area where the close "button" is
        /// and if that is the case it removes the button furthest to the right and moves the addButton
        /// 
        /// else stuff happens
        /// 
        /// </summary>
        private void chooseGraph(object sender, EventArgs e)
        {
            int X = Cursor.Position.X,
                Sx = this.Location.X;
            if ((55 + X - Sx) % 75 <= 65 && (55 + X - Sx) % 75 >= 52 && graphTaps >= 0)
            {
                this.pTabs.Controls.Remove(buttons[--graphTaps]);
                buttons[7].Location = new Point(buttons[7].Location.X - 75, 0);
            }
            else
            {

            }
        }
        
        /// <summary>
        /// If checkbox is checked the calculations is made with catalyst
        /// If it is not checked the calculations is made without catalyst
        /// </summary>
        private void checkBoxCatalyst_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCatalyst.Checked)
            {
                //Model.calculateActivationEnergy(true);
            }   
            else
            {
                //Model.calculateActivationEnergy(false);
            }
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
