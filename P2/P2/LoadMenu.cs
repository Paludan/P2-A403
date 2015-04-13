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
        public LoadMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosenFile = listBox1.SelectedItem.ToString();
            //SaveLoadTools.load(chosenFile);
        }

        private void LoadMenu_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@".\SaveFiles\");
            foreach (string fileInDirectory in files)
            {
                listBox1.Items.Add(fileInDirectory);
            }
        }
    }
}

/* 
            if (Directory.GetFiles(@".\SaveFiles\") == null)
            {
                
            }
            else
                for (int i = 0; i < 5; i++)
                    listBox1.Items.Add("Cake number " + (i+1));
*/