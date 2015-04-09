﻿namespace P2
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
            this.pSimulationArea = new System.Windows.Forms.Panel();
            this.pGraphArea = new System.Windows.Forms.Panel();
            this.lTemperature = new System.Windows.Forms.Label();
            this.lNH3 = new System.Windows.Forms.Label();
            this.lH2 = new System.Windows.Forms.Label();
            this.lN2 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pColourDescription = new System.Windows.Forms.Panel();
            this.hColour = new System.Windows.Forms.Label();
            this.hVariable = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pTabs = new System.Windows.Forms.Panel();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.pProjectHandling = new System.Windows.Forms.Panel();
            this.hProject = new System.Windows.Forms.Label();
            this.pParameters = new System.Windows.Forms.Panel();
            this.hScrollBarTemperature = new System.Windows.Forms.HScrollBar();
            this.hScrollBarNH3 = new System.Windows.Forms.HScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hScrollBarH2 = new System.Windows.Forms.HScrollBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.hScrollBarN2 = new System.Windows.Forms.HScrollBar();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.hParameters = new System.Windows.Forms.Label();
            this.pTimeControl = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lTime = new System.Windows.Forms.Label();
            this.timeMultiplier = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.hTimeControl = new System.Windows.Forms.Label();
            this.pInfoBox = new System.Windows.Forms.Panel();
            this.hInfoBox = new System.Windows.Forms.Label();
            this.hVariabelControl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab1 = new System.Windows.Forms.Button();
            this.Tab2 = new System.Windows.Forms.Button();
            this.pSimulationArea.SuspendLayout();
            this.pColourDescription.SuspendLayout();
            this.pTabs.SuspendLayout();
            this.pProjectHandling.SuspendLayout();
            this.pParameters.SuspendLayout();
            this.pTimeControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pSimulationArea
            // 
            this.pSimulationArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSimulationArea.Controls.Add(this.pGraphArea);
            this.pSimulationArea.Location = new System.Drawing.Point(10, 20);
            this.pSimulationArea.Name = "pSimulationArea";
            this.pSimulationArea.Size = new System.Drawing.Size(630, 510);
            this.pSimulationArea.TabIndex = 0;
            // 
            // pGraphArea
            // 
            this.pGraphArea.Location = new System.Drawing.Point(5, 5);
            this.pGraphArea.Name = "pGraphArea";
            this.pGraphArea.Size = new System.Drawing.Size(620, 500);
            this.pGraphArea.TabIndex = 1;
            // 
            // lTemperature
            // 
            this.lTemperature.AutoSize = true;
            this.lTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTemperature.Location = new System.Drawing.Point(19, 250);
            this.lTemperature.Name = "lTemperature";
            this.lTemperature.Size = new System.Drawing.Size(91, 20);
            this.lTemperature.TabIndex = 9;
            this.lTemperature.Text = "Temperatur";
            // 
            // lNH3
            // 
            this.lNH3.AutoSize = true;
            this.lNH3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNH3.Location = new System.Drawing.Point(49, 190);
            this.lNH3.Name = "lNH3";
            this.lNH3.Size = new System.Drawing.Size(37, 20);
            this.lNH3.TabIndex = 8;
            this.lNH3.Text = "NH₃";
            // 
            // lH2
            // 
            this.lH2.AutoSize = true;
            this.lH2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lH2.Location = new System.Drawing.Point(55, 130);
            this.lH2.Name = "lH2";
            this.lH2.Size = new System.Drawing.Size(26, 20);
            this.lH2.TabIndex = 7;
            this.lH2.Text = "H₂";
            // 
            // lN2
            // 
            this.lN2.AutoSize = true;
            this.lN2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lN2.Location = new System.Drawing.Point(55, 70);
            this.lN2.Name = "lN2";
            this.lN2.Size = new System.Drawing.Size(25, 20);
            this.lN2.TabIndex = 6;
            this.lN2.Text = "N₂";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Usynlig",
            "Blå",
            "Grøn",
            "Gul",
            "Rød",
            "Laksefarvet"});
            this.comboBox4.Location = new System.Drawing.Point(145, 252);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(110, 21);
            this.comboBox4.TabIndex = 5;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Usynlig",
            "Blå",
            "Grøn",
            "Gul",
            "Rød",
            "Laksefarvet"});
            this.comboBox3.Location = new System.Drawing.Point(145, 192);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(110, 21);
            this.comboBox3.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Usynlig",
            "Blå",
            "Grøn",
            "Gul",
            "Rød",
            "Laksefarvet"});
            this.comboBox2.Location = new System.Drawing.Point(145, 132);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(110, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // pColourDescription
            // 
            this.pColourDescription.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pColourDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pColourDescription.Controls.Add(this.label1);
            this.pColourDescription.Controls.Add(this.hVariabelControl);
            this.pColourDescription.Controls.Add(this.hColour);
            this.pColourDescription.Controls.Add(this.hVariable);
            this.pColourDescription.Location = new System.Drawing.Point(3, 9);
            this.pColourDescription.Name = "pColourDescription";
            this.pColourDescription.Size = new System.Drawing.Size(591, 25);
            this.pColourDescription.TabIndex = 2;
            // 
            // hColour
            // 
            this.hColour.AutoSize = true;
            this.hColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hColour.Location = new System.Drawing.Point(177, 4);
            this.hColour.Name = "hColour";
            this.hColour.Size = new System.Drawing.Size(39, 13);
            this.hColour.TabIndex = 1;
            this.hColour.Text = "Farve";
            // 
            // hVariable
            // 
            this.hVariable.AutoSize = true;
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
            "Usynlig",
            "Blå",
            "Grøn",
            "Gul",
            "Rød",
            "Laksefarvet"});
            this.comboBox1.Location = new System.Drawing.Point(145, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // pTabs
            // 
            this.pTabs.Controls.Add(this.Tab2);
            this.pTabs.Controls.Add(this.Tab1);
            this.pTabs.Location = new System.Drawing.Point(10, 0);
            this.pTabs.Name = "pTabs";
            this.pTabs.Size = new System.Drawing.Size(630, 20);
            this.pTabs.TabIndex = 1;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(40, 25);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(70, 25);
            this.Save.TabIndex = 2;
            this.Save.Text = "Gem";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(40, 70);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(70, 25);
            this.Load.TabIndex = 3;
            this.Load.Text = "Indlæs";
            this.Load.UseVisualStyleBackColor = true;
            // 
            // pProjectHandling
            // 
            this.pProjectHandling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pProjectHandling.Controls.Add(this.Save);
            this.pProjectHandling.Controls.Add(this.Load);
            this.pProjectHandling.Location = new System.Drawing.Point(1100, 550);
            this.pProjectHandling.Name = "pProjectHandling";
            this.pProjectHandling.Size = new System.Drawing.Size(150, 120);
            this.pProjectHandling.TabIndex = 4;
            // 
            // hProject
            // 
            this.hProject.AutoSize = true;
            this.hProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hProject.Location = new System.Drawing.Point(1110, 540);
            this.hProject.Name = "hProject";
            this.hProject.Size = new System.Drawing.Size(107, 13);
            this.hProject.TabIndex = 5;
            this.hProject.Text = "Projekthåndtering";
            // 
            // pParameters
            // 
            this.pParameters.BackColor = System.Drawing.SystemColors.Control;
            this.pParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pParameters.Controls.Add(this.lTemperature);
            this.pParameters.Controls.Add(this.hScrollBarTemperature);
            this.pParameters.Controls.Add(this.comboBox1);
            this.pParameters.Controls.Add(this.lNH3);
            this.pParameters.Controls.Add(this.pColourDescription);
            this.pParameters.Controls.Add(this.hScrollBarNH3);
            this.pParameters.Controls.Add(this.textBox1);
            this.pParameters.Controls.Add(this.lH2);
            this.pParameters.Controls.Add(this.comboBox2);
            this.pParameters.Controls.Add(this.hScrollBarH2);
            this.pParameters.Controls.Add(this.textBox2);
            this.pParameters.Controls.Add(this.lN2);
            this.pParameters.Controls.Add(this.comboBox3);
            this.pParameters.Controls.Add(this.hScrollBarN2);
            this.pParameters.Controls.Add(this.textBox3);
            this.pParameters.Controls.Add(this.textBox4);
            this.pParameters.Controls.Add(this.comboBox4);
            this.pParameters.Location = new System.Drawing.Point(650, 210);
            this.pParameters.Name = "pParameters";
            this.pParameters.Size = new System.Drawing.Size(604, 320);
            this.pParameters.TabIndex = 6;
            // 
            // hScrollBarTemperature
            // 
            this.hScrollBarTemperature.Location = new System.Drawing.Point(290, 256);
            this.hScrollBarTemperature.Name = "hScrollBarTemperature";
            this.hScrollBarTemperature.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarTemperature.TabIndex = 17;
            // 
            // hScrollBarNH3
            // 
            this.hScrollBarNH3.Location = new System.Drawing.Point(290, 196);
            this.hScrollBarNH3.Name = "hScrollBarNH3";
            this.hScrollBarNH3.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarNH3.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(515, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // hScrollBarH2
            // 
            this.hScrollBarH2.Location = new System.Drawing.Point(290, 136);
            this.hScrollBarH2.Name = "hScrollBarH2";
            this.hScrollBarH2.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarH2.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(515, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "0";
            // 
            // hScrollBarN2
            // 
            this.hScrollBarN2.Location = new System.Drawing.Point(290, 72);
            this.hScrollBarN2.Name = "hScrollBarN2";
            this.hScrollBarN2.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarN2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(515, 193);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(515, 253);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(70, 20);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "0";
            // 
            // hParameters
            // 
            this.hParameters.AutoSize = true;
            this.hParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hParameters.Location = new System.Drawing.Point(660, 200);
            this.hParameters.Name = "hParameters";
            this.hParameters.Size = new System.Drawing.Size(64, 13);
            this.hParameters.TabIndex = 7;
            this.hParameters.Text = "Parametre";
            // 
            // pTimeControl
            // 
            this.pTimeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTimeControl.Controls.Add(this.numericUpDown1);
            this.pTimeControl.Controls.Add(this.lTime);
            this.pTimeControl.Controls.Add(this.timeMultiplier);
            this.pTimeControl.Controls.Add(this.stop);
            this.pTimeControl.Controls.Add(this.start);
            this.pTimeControl.Location = new System.Drawing.Point(650, 20);
            this.pTimeControl.Name = "pTimeControl";
            this.pTimeControl.Size = new System.Drawing.Size(600, 170);
            this.pTimeControl.TabIndex = 8;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(243, 104);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(198, 106);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(22, 13);
            this.lTime.TabIndex = 3;
            this.lTime.Text = "Tid";
            // 
            // timeMultiplier
            // 
            this.timeMultiplier.Location = new System.Drawing.Point(470, 40);
            this.timeMultiplier.Name = "timeMultiplier";
            this.timeMultiplier.Size = new System.Drawing.Size(70, 25);
            this.timeMultiplier.TabIndex = 2;
            this.timeMultiplier.Text = "x1";
            this.timeMultiplier.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(265, 40);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(70, 25);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(60, 40);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(70, 25);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            // 
            // hTimeControl
            // 
            this.hTimeControl.AutoSize = true;
            this.hTimeControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTimeControl.Location = new System.Drawing.Point(660, 9);
            this.hTimeControl.Name = "hTimeControl";
            this.hTimeControl.Size = new System.Drawing.Size(70, 13);
            this.hTimeControl.TabIndex = 9;
            this.hTimeControl.Text = "Tidskontrol";
            // 
            // pInfoBox
            // 
            this.pInfoBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInfoBox.Location = new System.Drawing.Point(12, 550);
            this.pInfoBox.Name = "pInfoBox";
            this.pInfoBox.Size = new System.Drawing.Size(1075, 119);
            this.pInfoBox.TabIndex = 10;
            // 
            // hInfoBox
            // 
            this.hInfoBox.AutoSize = true;
            this.hInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hInfoBox.Location = new System.Drawing.Point(20, 540);
            this.hInfoBox.Name = "hInfoBox";
            this.hInfoBox.Size = new System.Drawing.Size(66, 13);
            this.hInfoBox.TabIndex = 11;
            this.hInfoBox.Text = "Vejledning";
            // 
            // hVariabelControl
            // 
            this.hVariabelControl.AutoSize = true;
            this.hVariabelControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hVariabelControl.Location = new System.Drawing.Point(352, 4);
            this.hVariabelControl.Name = "hVariabelControl";
            this.hVariabelControl.Size = new System.Drawing.Size(92, 13);
            this.hVariabelControl.TabIndex = 2;
            this.hVariabelControl.Text = "Ændre variabel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Variabelværdi";
            // 
            // Tab1
            // 
            this.Tab1.Location = new System.Drawing.Point(0, 0);
            this.Tab1.Name = "Tab1";
            this.Tab1.Size = new System.Drawing.Size(75, 20);
            this.Tab1.TabIndex = 0;
            this.Tab1.Text = "Graph1";
            this.Tab1.UseVisualStyleBackColor = true;
            // 
            // Tab2
            // 
            this.Tab2.Location = new System.Drawing.Point(75, 0);
            this.Tab2.Name = "Tab2";
            this.Tab2.Size = new System.Drawing.Size(75, 20);
            this.Tab2.TabIndex = 1;
            this.Tab2.Text = "Graph2";
            this.Tab2.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.hInfoBox);
            this.Controls.Add(this.pInfoBox);
            this.Controls.Add(this.hTimeControl);
            this.Controls.Add(this.pTimeControl);
            this.Controls.Add(this.hParameters);
            this.Controls.Add(this.pParameters);
            this.Controls.Add(this.hProject);
            this.Controls.Add(this.pProjectHandling);
            this.Controls.Add(this.pTabs);
            this.Controls.Add(this.pSimulationArea);
            this.Name = "GUI";
            this.Text = "GUI";
            this.pSimulationArea.ResumeLayout(false);
            this.pColourDescription.ResumeLayout(false);
            this.pColourDescription.PerformLayout();
            this.pTabs.ResumeLayout(false);
            this.pProjectHandling.ResumeLayout(false);
            this.pParameters.ResumeLayout(false);
            this.pParameters.PerformLayout();
            this.pTimeControl.ResumeLayout(false);
            this.pTimeControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pSimulationArea;
        private System.Windows.Forms.Panel pTabs;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Panel pProjectHandling;
        private System.Windows.Forms.Label hProject;
        private System.Windows.Forms.Panel pParameters;
        private System.Windows.Forms.Label hParameters;
        private System.Windows.Forms.Panel pTimeControl;
        private System.Windows.Forms.Label hTimeControl;
        private System.Windows.Forms.Panel pInfoBox;
        private System.Windows.Forms.Button timeMultiplier;
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
        private System.Windows.Forms.Panel pGraphArea;
        private System.Windows.Forms.Label hInfoBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label hColour;
        private System.Windows.Forms.Label hVariable;
        private System.Windows.Forms.HScrollBar hScrollBarTemperature;
        private System.Windows.Forms.HScrollBar hScrollBarNH3;
        private System.Windows.Forms.HScrollBar hScrollBarH2;
        private System.Windows.Forms.HScrollBar hScrollBarN2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hVariabelControl;
        private System.Windows.Forms.Button Tab1;
        private System.Windows.Forms.Button Tab2;
    }
}