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
        double tempDouble; // for temporary storage of floating point numbers
        
		/// <summary>
		/// Initializes a new instance of the <see cref="P2.GUI"/> class.
		/// </summary>
        public GUI()
        {
            InitializeComponent();
            synth = new Synthesis(pGraphArea);
			synth.Updated += Update;
            helper = new helpTextController();
            Control.CheckForIllegalCrossThreadCalls = false;
            startUpInfo();
            correctTextSize();
            
            this.pTabs.Controls.Add(this.page1);
			this.pTabs.Deselecting += DeactivatePage;
			this.pTabs.Selecting += ActivatePage;
            page1.gh = synth.graphHandlers[0];
			page1.gh.isActive = true;
        }

		private void ActivatePage(object sender, EventArgs e){
			var tc = sender as TabControl;
            if(tc.SelectedTab != null)
			    (tc.SelectedTab as GraphPage).Clicked ();
		}

		private void DeactivatePage(object sender, EventArgs e){
			var tc = sender as TabControl;
            if(tc.SelectedTab != null)
			    (tc.SelectedTab as GraphPage).PageLeft ();
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
        /// Makes sure only positive integers can be inserted into a textbox
        /// If e.handled is set to true the key pressed is cancelled
        /// </summary>
        /// <param name="e">The key pressed when typing in the textbox</param>
        private void doubleTextbox(KeyPressEventArgs e)
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
                if (double.Parse(textBox.Text) <= hScrollBar.Maximum && double.Parse(textBox.Text) >= hScrollBar.Minimum)
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

        /// <summary>
        /// Sends the color chosen for a specific curve to the graphHandler
        /// </summary>
        /// <param name="comboBox">The comboBox where a color is selected in</param>
        /// <param name="graphToDraw">The curve that is to be colored with the specified color</param>
        private void colorChoice(ComboBox comboBox, graph graphToDraw)
        {
            switch ((colors)comboBox.SelectedItem)
            {
                case colors.Rød:
                    ChangeGraphColor(Color.Red, graphToDraw);
                    break;
                case colors.Grøn:
                    ChangeGraphColor(Color.Green, graphToDraw);
                    break;
                case colors.Blå:
                    ChangeGraphColor(Color.Blue, graphToDraw);
                    break;
                case colors.Lilla:
                    ChangeGraphColor(Color.Purple, graphToDraw);
                    break;
                case colors.Sort:
                    ChangeGraphColor(Color.Black, graphToDraw);
                    break;
                case colors.Gennemsigtig:
                    ChangeGraphColor(Color.Transparent, graphToDraw);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Changes the values of the textBoxes to the current state of the synthesis
        /// </summary>
        public void Update()
        {
            numericUpDown1.Value = (decimal)synth.Time;

            textBox1.Text = synth.currentData.nNitrogen.ToString();
            textBox2.Text = synth.currentData.nHydrogen.ToString();
            textBox3.Text = synth.currentData.nAmmonia.ToString();
            textBox4.Text = synth.currentData.temperature.ToString();
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
        /// Saves the current graph to a .png file
        /// </summary>
        private void saveGraph_Click(object sender, EventArgs e)
        {
            SaveLoadTools.saveToImage((pTabs.SelectedTab as GraphPage).CurrentTab);
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
        /// Makes sure the user cant change the variable when the synthesis is runnning
        /// </summary>
        /// <param name="e">The numericUpDown1's keyPress event parameters</param>
        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            denyTextWhenSynthRun(e);
        }

        /// <summary>
        /// If the selected reaction rate multiplier is changed then the new selected value is send to the synthesis
        /// </summary>
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            synth.Scale = (double)int.Parse(comboBox5.SelectedItem.ToString().TrimStart('x'));
        }

        /// <summary>
        /// If checkbox is checked the calculations is made with catalyst
        /// If it is not checked the calculations is made without catalyst
        /// </summary>
        private void checkBoxCatalyst_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCatalyst.Checked)
            {
                synth.currentData.catalyst = true;
            }
            else
            {
                synth.currentData.catalyst = false;
            }
        }

        /// <summary>
        /// Changes the color of the corresponting curve to the color selected for the comboBox
        /// </summary>
        #region colorComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorChoice(comboBox1, graph.nitrogen);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorChoice(comboBox2, graph.hydrogen);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorChoice(comboBox3, graph.ammonia);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorChoice(comboBox4, graph.temperature);
        }
        #endregion

        /// <summary>
        /// Makes sure user can only input doubles in the text boxes and not when synthesis is runnning
        /// </summary>
        #region textBox_KeyPress
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(denyTextWhenSynthRun(e))
                doubleTextbox(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (denyTextWhenSynthRun(e))
                doubleTextbox(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (denyTextWhenSynthRun(e))
                doubleTextbox(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (denyTextWhenSynthRun(e))
                doubleTextbox(e);
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

		#region GraphTabs
        /// <summary>
        /// Creates tab and adds it to the tab panel
        /// </summary>
        private void addGraph_Click(object sender, EventArgs e)
        {
            if (pTabs.Controls.Count < 6)
            {
                GraphPage addThis = GenerateTabPage();

                //Lav funktion, der tager delegate og fjernes graphhandleren
                addThis.AddToClose(RemoveGHOnClose);

                pTabs.Controls.Add(addThis);
            }
        }

        /// <summary>
        /// Removes the graphHandler for the button
        /// </summary>
        private void RemoveGHOnClose(object sender, EventArgs e){
            if(pTabs.SelectedIndex >= 0)
                synth.graphHandlers.RemoveAt(pTabs.SelectedIndex);
        }

        /// <summary>
        /// Creates the tab with its own graphHandler and masterGraphPanel
        /// </summary>
        /// <returns>A new graphPage</returns>
        private GraphPage GenerateTabPage()
        {
			var mgp = new P2Graph.MasterGraphPanel(628, 487);
            GraphHandler newGH = new GraphHandler(mgp);
            GraphPage testPage = new GraphPage(mgp);
            testPage.gh = newGH;
            synth.graphHandlers.Add(newGH);
            testPage.Location = new System.Drawing.Point(4, 22);
            testPage.Name = "graphTab" + pTabs.Controls.Count + 1;
            testPage.Padding = new System.Windows.Forms.Padding(3);
            testPage.Size = new System.Drawing.Size(509, 384);
            testPage.Text = "Graf " + (pTabs.Controls.Count + 1);
            testPage.UseVisualStyleBackColor = true;

            return testPage;
        }

        /// <summary>
        /// Changes the color of the selected graph.
        /// </summary>
        /// <param name="col">Color.</param>
        /// <param name="enumGraph">Enum graph.</param>
        public void ChangeGraphColor(Color col, graph enumGraph)
        {
            switch (enumGraph)
            {
                case graph.ammonia:
                    synth.graphHandlers[pTabs.SelectedIndex].ChangeAmmoniaColor(col);
                    break;
                case graph.hydrogen:
                    synth.graphHandlers[pTabs.SelectedIndex].ChangeHydrogenColor(col);
                    break;
                case graph.nitrogen:
                    synth.graphHandlers[pTabs.SelectedIndex].ChangeNitrogenColor(col);
                    break;
                case graph.temperature:
                    synth.graphHandlers[pTabs.SelectedIndex].ChangeTemperatureColor(col);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
		#endregion
        #endregion
    }
}
