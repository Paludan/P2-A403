using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace P2
{
    public partial class LoadMenu : Form
    {
        string chosenFile;
        private Synthesis _synth;
        
        public LoadMenu(Synthesis synth)
        {
            InitializeComponent();
            _synth = synth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (chosenFile != null && chosenFile != "Der findes ingen gemte grafer")
            {
                _synth.Datapoints = SaveLoadTools.load(chosenFile);
                this.Close();
            }
        }

        /// <summary>
        /// Copies the string of the selected item to the string chosenFile
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenFile = listBox1.SelectedItem.ToString();
        }

        /// <summary>
        /// Inserts the names of the save files in the listbox as strings
        /// Informs user that no files exists if that is the case
        /// </summary>
        private void LoadMenu_Load(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(SaveLoadTools.path);
            if (Directory.GetFiles(SaveLoadTools.path).Length > 0)
            {
                FileInfo[] files = dinfo.GetFiles("*.eqsave");
                foreach (FileInfo file in files)
                        listBox1.Items.Add(file.Name);
            }
            if (listBox1.Items.Count == 0)
                listBox1.Items.Add("Der findes ingen gemte grafer");
        }
    }
}