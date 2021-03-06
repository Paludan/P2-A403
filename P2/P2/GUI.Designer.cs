﻿using System.Windows.Forms;
using P2Graph;
using System.Drawing;

namespace P2
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lTemperature = new System.Windows.Forms.Label();
            this.lNH3 = new System.Windows.Forms.Label();
            this.lH2 = new System.Windows.Forms.Label();
            this.lN2 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pColourDescription = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.hVariabelControl = new System.Windows.Forms.Label();
            this.hColour = new System.Windows.Forms.Label();
            this.hVariable = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.pProjectHandling = new System.Windows.Forms.Panel();
            this.saveGraph = new System.Windows.Forms.Button();
            this.OpenCalc = new System.Windows.Forms.Button();
            this.hProject = new System.Windows.Forms.Label();
            this.pParameters = new System.Windows.Forms.Panel();
            this.hScrollBarN2 = new System.Windows.Forms.HScrollBar();
            this.hScrollBarTemperature = new System.Windows.Forms.HScrollBar();
            this.hScrollBarNH3 = new System.Windows.Forms.HScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hScrollBarH2 = new System.Windows.Forms.HScrollBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxCatalyst = new System.Windows.Forms.CheckBox();
            this.hParameters = new System.Windows.Forms.Label();
            this.pTimeControl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lTime = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.hTimeControl = new System.Windows.Forms.Label();
            this.pInfoBox = new System.Windows.Forms.Panel();
            this.FurtherInfoBox = new System.Windows.Forms.Button();
            this.hInfoBox = new System.Windows.Forms.Label();
            this.pTabs = new System.Windows.Forms.TabControl();
            this.pSimulationArea = new System.Windows.Forms.Panel();
            this.addGraph = new System.Windows.Forms.Button();
            this.pGraphArea = new P2Graph.MasterGraphPanel(628, 487);
            this.pColourDescription.SuspendLayout();
            this.pProjectHandling.SuspendLayout();
            this.pParameters.SuspendLayout();
            this.page1 = new GraphPage(pGraphArea);
            this.panel1.SuspendLayout();
            this.pTimeControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.pInfoBox.SuspendLayout();
            this.pTabs.SuspendLayout();
            this.page1.SuspendLayout();
            this.pSimulationArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // lTemperature
            // 
            this.lTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTemperature.Location = new System.Drawing.Point(9, 254);
            this.lTemperature.Name = "lTemperature";
            this.lTemperature.Size = new System.Drawing.Size(132, 17);
            this.lTemperature.TabIndex = 20;
            this.lTemperature.Text = "Temperatur (kelvin)";
            // 
            // lNH3
            // 
            this.lNH3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNH3.Location = new System.Drawing.Point(43, 195);
            this.lNH3.Name = "lNH3";
            this.lNH3.Size = new System.Drawing.Size(68, 17);
            this.lNH3.TabIndex = 21;
            this.lNH3.Text = "NH₃ (mol)";
            // 
            // lH2
            // 
            this.lH2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lH2.Location = new System.Drawing.Point(49, 133);
            this.lH2.Name = "lH2";
            this.lH2.Size = new System.Drawing.Size(58, 17);
            this.lH2.TabIndex = 22;
            this.lH2.Text = "H₂ (mol)";
            // 
            // lN2
            // 
            this.lN2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lN2.Location = new System.Drawing.Point(49, 70);
            this.lN2.Name = "lN2";
            this.lN2.Size = new System.Drawing.Size(58, 17);
            this.lN2.TabIndex = 23;
            this.lN2.Text = "N₂ (mol)";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            P2.colors.Rød,
            P2.colors.Grøn,
            P2.colors.Blå,
            P2.colors.Lilla,
            P2.colors.Sort});
            this.comboBox4.Location = new System.Drawing.Point(145, 252);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(110, 21);
            this.comboBox4.TabIndex = 5;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            P2.colors.Rød,
            P2.colors.Grøn,
            P2.colors.Blå,
            P2.colors.Lilla,
            P2.colors.Sort});
            this.comboBox3.Location = new System.Drawing.Point(145, 192);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(110, 21);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            P2.colors.Rød,
            P2.colors.Grøn,
            P2.colors.Blå,
            P2.colors.Lilla,
            P2.colors.Sort});
            this.comboBox2.Location = new System.Drawing.Point(145, 130);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(110, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // pColourDescription
            // 
            this.pColourDescription.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pColourDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pColourDescription.Controls.Add(this.label1);
            this.pColourDescription.Controls.Add(this.hVariabelControl);
            this.pColourDescription.Controls.Add(this.hColour);
            this.pColourDescription.Controls.Add(this.hVariable);
            this.pColourDescription.Location = new System.Drawing.Point(655, 190);
            this.pColourDescription.Name = "pColourDescription";
            this.pColourDescription.Size = new System.Drawing.Size(590, 25);
            this.pColourDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Variabelværdi";
            // 
            // hVariabelControl
            // 
            this.hVariabelControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hVariabelControl.Location = new System.Drawing.Point(352, 4);
            this.hVariabelControl.Name = "hVariabelControl";
            this.hVariabelControl.Size = new System.Drawing.Size(92, 13);
            this.hVariabelControl.TabIndex = 2;
            this.hVariabelControl.Text = "Ændre variabel";
            // 
            // hColour
            // 
            this.hColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hColour.Location = new System.Drawing.Point(177, 4);
            this.hColour.Name = "hColour";
            this.hColour.Size = new System.Drawing.Size(39, 13);
            this.hColour.TabIndex = 1;
            this.hColour.Text = "Farve";
            // 
            // hVariable
            // 
            this.hVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hVariable.Location = new System.Drawing.Point(35, 4);
            this.hVariable.Name = "hVariable";
            this.hVariable.Size = new System.Drawing.Size(53, 13);
            this.hVariable.TabIndex = 0;
            this.hVariable.Text = "Variabel";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            P2.colors.Rød,
            P2.colors.Grøn,
            P2.colors.Blå,
            P2.colors.Lilla,
            P2.colors.Sort});
            this.comboBox1.Location = new System.Drawing.Point(145, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(30, 25);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 25);
            this.Save.TabIndex = 2;
            this.Save.Text = "Gem";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(30, 70);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 25);
            this.LoadButton.TabIndex = 3;
            this.LoadButton.Text = "Indlæs";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.Load_Click);
            // 
            // pProjectHandling
            // 
            this.pProjectHandling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pProjectHandling.Controls.Add(this.saveGraph);
            this.pProjectHandling.Controls.Add(this.OpenCalc);
            this.pProjectHandling.Controls.Add(this.Save);
            this.pProjectHandling.Controls.Add(this.LoadButton);
            this.pProjectHandling.Location = new System.Drawing.Point(1000, 550);
            this.pProjectHandling.Name = "pProjectHandling";
            this.pProjectHandling.Size = new System.Drawing.Size(250, 120);
            this.pProjectHandling.TabIndex = 4;
            // 
            // saveGraph
            // 
            this.saveGraph.Location = new System.Drawing.Point(145, 70);
            this.saveGraph.Name = "saveGraph";
            this.saveGraph.Size = new System.Drawing.Size(75, 25);
            this.saveGraph.TabIndex = 5;
            this.saveGraph.Text = "Gem graf";
            this.saveGraph.UseVisualStyleBackColor = true;
            this.saveGraph.Click += new System.EventHandler(this.saveGraph_Click);
            // 
            // OpenCalc
            // 
            this.OpenCalc.Location = new System.Drawing.Point(145, 25);
            this.OpenCalc.Name = "OpenCalc";
            this.OpenCalc.Size = new System.Drawing.Size(75, 25);
            this.OpenCalc.TabIndex = 4;
            this.OpenCalc.Text = "Udregninger";
            this.OpenCalc.UseVisualStyleBackColor = true;
            this.OpenCalc.Click += new System.EventHandler(this.OpenCalc_Click);
            // 
            // hProject
            // 
            this.hProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hProject.Location = new System.Drawing.Point(1010, 535);
            this.hProject.Name = "hProject";
            this.hProject.Size = new System.Drawing.Size(140, 20);
            this.hProject.TabIndex = 5;
            this.hProject.Text = "Projekthåndtering";
            // 
            // pParameters
            // 
            this.pParameters.BackColor = System.Drawing.SystemColors.Control;
            this.pParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pParameters.Controls.Add(this.hScrollBarN2);
            this.pParameters.Controls.Add(this.lTemperature);
            this.pParameters.Controls.Add(this.hScrollBarTemperature);
            this.pParameters.Controls.Add(this.comboBox1);
            this.pParameters.Controls.Add(this.lNH3);
            this.pParameters.Controls.Add(this.hScrollBarNH3);
            this.pParameters.Controls.Add(this.textBox1);
            this.pParameters.Controls.Add(this.lH2);
            this.pParameters.Controls.Add(this.comboBox2);
            this.pParameters.Controls.Add(this.hScrollBarH2);
            this.pParameters.Controls.Add(this.textBox2);
            this.pParameters.Controls.Add(this.lN2);
            this.pParameters.Controls.Add(this.comboBox3);
            this.pParameters.Controls.Add(this.textBox3);
            this.pParameters.Controls.Add(this.textBox4);
            this.pParameters.Controls.Add(this.comboBox4);
            this.pParameters.Location = new System.Drawing.Point(650, 180);
            this.pParameters.Name = "pParameters";
            this.pParameters.Size = new System.Drawing.Size(600, 301);
            this.pParameters.TabIndex = 6;
            // 
            // hScrollBarN2
            // 
            this.hScrollBarN2.LargeChange = 1;
            this.hScrollBarN2.Location = new System.Drawing.Point(290, 69);
            this.hScrollBarN2.Maximum = 30000;
            this.hScrollBarN2.Name = "hScrollBarN2";
            this.hScrollBarN2.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarN2.TabIndex = 14;
            this.hScrollBarN2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarN2_Scroll);
            // 
            // hScrollBarTemperature
            // 
            this.hScrollBarTemperature.LargeChange = 1;
            this.hScrollBarTemperature.Location = new System.Drawing.Point(290, 256);
            this.hScrollBarTemperature.Maximum = 1000;
            this.hScrollBarTemperature.Name = "hScrollBarTemperature";
            this.hScrollBarTemperature.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarTemperature.TabIndex = 17;
            this.hScrollBarTemperature.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarTemperature_Scroll);
            // 
            // hScrollBarNH3
            // 
            this.hScrollBarNH3.LargeChange = 1;
            this.hScrollBarNH3.Location = new System.Drawing.Point(290, 196);
            this.hScrollBarNH3.Maximum = 65000;
            this.hScrollBarNH3.Name = "hScrollBarNH3";
            this.hScrollBarNH3.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarNH3.TabIndex = 16;
            this.hScrollBarNH3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarNH3_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(515, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // hScrollBarH2
            // 
            this.hScrollBarH2.LargeChange = 1;
            this.hScrollBarH2.Location = new System.Drawing.Point(290, 132);
            this.hScrollBarH2.Maximum = 65000;
            this.hScrollBarH2.Name = "hScrollBarH2";
            this.hScrollBarH2.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarH2.TabIndex = 15;
            this.hScrollBarH2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarH2_Scroll);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(515, 132);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "0";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(515, 194);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "0";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(515, 253);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(70, 20);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "0";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxCatalyst);
            this.panel1.Location = new System.Drawing.Point(650, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 50);
            this.panel1.TabIndex = 19;
            // 
            // checkBoxCatalyst
            // 
            this.checkBoxCatalyst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCatalyst.Location = new System.Drawing.Point(251, 15);
            this.checkBoxCatalyst.Name = "checkBoxCatalyst";
            this.checkBoxCatalyst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxCatalyst.Size = new System.Drawing.Size(98, 21);
            this.checkBoxCatalyst.TabIndex = 18;
            this.checkBoxCatalyst.Text = "Katalysator";
            this.checkBoxCatalyst.UseVisualStyleBackColor = true;
            this.checkBoxCatalyst.CheckedChanged += new System.EventHandler(this.checkBoxCatalyst_CheckedChanged);
            // 
            // hParameters
            // 
            this.hParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hParameters.Location = new System.Drawing.Point(660, 165);
            this.hParameters.Name = "hParameters";
            this.hParameters.Size = new System.Drawing.Size(85, 20);
            this.hParameters.TabIndex = 7;
            this.hParameters.Text = "Parametre";
            // 
            // pTimeControl
            // 
            this.pTimeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTimeControl.Controls.Add(this.label2);
            this.pTimeControl.Controls.Add(this.comboBox5);
            this.pTimeControl.Controls.Add(this.numericUpDown1);
            this.pTimeControl.Controls.Add(this.lTime);
            this.pTimeControl.Controls.Add(this.stop);
            this.pTimeControl.Controls.Add(this.start);
            this.pTimeControl.Location = new System.Drawing.Point(650, 20);
            this.pTimeControl.Name = "pTimeControl";
            this.pTimeControl.Size = new System.Drawing.Size(600, 140);
            this.pTimeControl.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hastighedsfaktor";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "x1",
            "x2",
            "x5",
            "x10",
            "x20",
            "x50",
            "x100",
            "x200",
            "x500",
            "x1000"});
            this.comboBox5.Location = new System.Drawing.Point(400, 30);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 5;
            this.comboBox5.Text = "x1";
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(400, 90);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
            // 
            // lTime
            // 
            this.lTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTime.Location = new System.Drawing.Point(350, 92);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(22, 13);
            this.lTime.TabIndex = 3;
            this.lTime.Text = "Tid";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(78, 86);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(70, 25);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(79, 27);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(70, 25);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // hTimeControl
            // 
            this.hTimeControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTimeControl.Location = new System.Drawing.Point(660, 5);
            this.hTimeControl.Name = "hTimeControl";
            this.hTimeControl.Size = new System.Drawing.Size(90, 20);
            this.hTimeControl.TabIndex = 9;
            this.hTimeControl.Text = "Tidskontrol";
            // 
            // pInfoBox
            // 
            this.pInfoBox.BackColor = System.Drawing.Color.Silver;
            this.pInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfoBox.Controls.Add(this.FurtherInfoBox);
            this.pInfoBox.Location = new System.Drawing.Point(12, 550);
            this.pInfoBox.Name = "pInfoBox";
            this.pInfoBox.Size = new System.Drawing.Size(977, 119);
            this.pInfoBox.TabIndex = 10;
            // 
            // FurtherInfoBox
            // 
            this.FurtherInfoBox.BackColor = System.Drawing.SystemColors.Control;
            this.FurtherInfoBox.Location = new System.Drawing.Point(875, 25);
            this.FurtherInfoBox.Name = "FurtherInfoBox";
            this.FurtherInfoBox.Size = new System.Drawing.Size(75, 25);
            this.FurtherInfoBox.TabIndex = 0;
            this.FurtherInfoBox.Text = "Videre";
            this.FurtherInfoBox.UseVisualStyleBackColor = false;
            this.FurtherInfoBox.Click += new System.EventHandler(this.FurtherInfoBox_Click);
            // 
            // hInfoBox
            // 
            this.hInfoBox.BackColor = System.Drawing.Color.Transparent;
            this.hInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hInfoBox.Location = new System.Drawing.Point(20, 535);
            this.hInfoBox.Name = "hInfoBox";
            this.hInfoBox.Size = new System.Drawing.Size(85, 20);
            this.hInfoBox.TabIndex = 11;
            this.hInfoBox.Text = "Vejledning";
            // 
            // pTabs
            // 
            this.pTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTabs.Location = new System.Drawing.Point(0, 0);
            this.pTabs.Name = "pTabs";
            this.pTabs.SelectedIndex = 0;
            this.pTabs.Size = new System.Drawing.Size(628, 508);
            this.pTabs.TabIndex = 20;
            //
            // page1
            // 
            this.page1.Controls.Add(this.pGraphArea);
            this.page1.Location = new System.Drawing.Point(4, 22);
            this.page1.Name = "page1";
            this.page1.Padding = new System.Windows.Forms.Padding(3);
            this.page1.Size = new System.Drawing.Size(620, 482);
            this.page1.TabIndex = 0;
            this.page1.Text = "Graf 1";
            this.page1.UseVisualStyleBackColor = true;
            // 
            // pSimulationArea
            // 
            this.pSimulationArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSimulationArea.Controls.Add(this.pTabs);
            this.pSimulationArea.Location = new System.Drawing.Point(10, 20);
            this.pSimulationArea.Name = "pSimulationArea";
            this.pSimulationArea.Size = new System.Drawing.Size(630, 510);
            this.pSimulationArea.TabIndex = 0;
            // 
            // addGraph
            // 
            this.addGraph.Location = new System.Drawing.Point(565, 20);
            this.addGraph.Name = "addGraph";
            this.addGraph.Size = new System.Drawing.Size(75, 23);
            this.addGraph.TabIndex = 20;
            this.addGraph.Text = "Tilføj Graf";
            this.addGraph.UseVisualStyleBackColor = true;
            this.addGraph.Click += new System.EventHandler(this.addGraph_Click);
            // 
            // GUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.addGraph);
            this.Controls.Add(this.hInfoBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pInfoBox);
            this.Controls.Add(this.hTimeControl);
            this.Controls.Add(this.pTimeControl);
            this.Controls.Add(this.pColourDescription);
            this.Controls.Add(this.hParameters);
            this.Controls.Add(this.pParameters);
            this.Controls.Add(this.hProject);
            this.Controls.Add(this.pProjectHandling);
            this.Controls.Add(this.pSimulationArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GUI";
            this.Text = "Ammoniak Syntese";
            this.pColourDescription.ResumeLayout(false);
            this.pProjectHandling.ResumeLayout(false);
            this.pParameters.ResumeLayout(false);
            this.pParameters.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pTimeControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.pInfoBox.ResumeLayout(false);
            this.pTabs.ResumeLayout(false);
            this.page1.ResumeLayout(false);
            this.pSimulationArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Panel pProjectHandling;
        private System.Windows.Forms.Label hProject;
        private System.Windows.Forms.Panel pParameters;
        private System.Windows.Forms.Label hParameters;
        private System.Windows.Forms.Panel pTimeControl;
        private System.Windows.Forms.Label hTimeControl;
        private System.Windows.Forms.Panel pInfoBox;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel pColourDescription;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lN2;
        private System.Windows.Forms.Label lNH3;
        private System.Windows.Forms.Label lH2;
        private System.Windows.Forms.Label lTemperature;
        private System.Windows.Forms.Label hInfoBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label hColour;
        private System.Windows.Forms.Label hVariable;
        private System.Windows.Forms.HScrollBar hScrollBarTemperature;
        private System.Windows.Forms.HScrollBar hScrollBarNH3;
        private System.Windows.Forms.HScrollBar hScrollBarH2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hVariabelControl;
        private System.Windows.Forms.CheckBox checkBoxCatalyst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hScrollBarN2;
        private TextBox textBox4;
        private Label label2;
        private ComboBox comboBox5;
        private Button OpenCalc;
        private Button saveGraph;
        private Button FurtherInfoBox;
        private TabControl pTabs;
        private GraphPage page1;
        private MasterGraphPanel pGraphArea;
        private Panel pSimulationArea;
        private Button addGraph;
    }
}