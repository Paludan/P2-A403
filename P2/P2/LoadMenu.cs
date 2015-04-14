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

        public LoadMenu()
        {
            InitializeComponent();
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
                SaveLoadTools.load(chosenFile);
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
        /// Removes the path in the begining and datatype in the end of the strings before inserting them into the listbox
        /// </summary>
        private void LoadMenu_Load(object sender, EventArgs e)
        {
            if (Directory.GetFiles(@".\SaveFiles\").Length > 0)
            {
                string[] files = Directory.GetFiles(@".\SaveFiles\");
                foreach (string fileInDirectory in files)
                    if (fileInDirectory.EndsWith(".eqsave"))
                        listBox1.Items.Add(fileInDirectory.Remove(0, 12).Remove((fileInDirectory.Length - 20), 7));
            }
            if (listBox1.Items.Count == 0)
                listBox1.Items.Add("Der findes ingen gemte grafer");
        }
    }
}