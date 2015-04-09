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
            this.pSimulationArea = new System.Windows.Forms.Panel();
            this.pCurveColours = new System.Windows.Forms.Panel();
            this.lN2 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pColourDescription = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pTabs = new System.Windows.Forms.Panel();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.pProjectHandling = new System.Windows.Forms.Panel();
            this.hProject = new System.Windows.Forms.Label();
            this.pParameters = new System.Windows.Forms.Panel();
            this.hParameters = new System.Windows.Forms.Label();
            this.pTimeControl = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lTime = new System.Windows.Forms.Label();
            this.timeMultiplier = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.hTimeControl = new System.Windows.Forms.Label();
            this.pInfoBox = new System.Windows.Forms.Panel();
            this.lH2 = new System.Windows.Forms.Label();
            this.lNH2 = new System.Windows.Forms.Label();
            this.lTemperature = new System.Windows.Forms.Label();
            this.pGraphArea = new System.Windows.Forms.Panel();
            this.hInfoBox = new System.Windows.Forms.Label();
            this.pSimulationArea.SuspendLayout();
            this.pCurveColours.SuspendLayout();
            this.pProjectHandling.SuspendLayout();
            this.pTimeControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pSimulationArea
            // 
            this.pSimulationArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSimulationArea.Controls.Add(this.pGraphArea);
            this.pSimulationArea.Controls.Add(this.pCurveColours);
            this.pSimulationArea.Location = new System.Drawing.Point(10, 20);
            this.pSimulationArea.Name = "pSimulationArea";
            this.pSimulationArea.Size = new System.Drawing.Size(900, 510);
            this.pSimulationArea.TabIndex = 0;
            // 
            // pCurveColours
            // 
            this.pCurveColours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCurveColours.Controls.Add(this.lTemperature);
            this.pCurveColours.Controls.Add(this.lNH2);
            this.pCurveColours.Controls.Add(this.lH2);
            this.pCurveColours.Controls.Add(this.lN2);
            this.pCurveColours.Controls.Add(this.comboBox4);
            this.pCurveColours.Controls.Add(this.comboBox3);
            this.pCurveColours.Controls.Add(this.comboBox2);
            this.pCurveColours.Controls.Add(this.pColourDescription);
            this.pCurveColours.Controls.Add(this.comboBox1);
            this.pCurveColours.Location = new System.Drawing.Point(630, 25);
            this.pCurveColours.Name = "pCurveColours";
            this.pCurveColours.Size = new System.Drawing.Size(250, 300);
            this.pCurveColours.TabIndex = 0;
            // 
            // lN2
            // 
            this.lN2.AutoSize = true;
            this.lN2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lN2.Location = new System.Drawing.Point(51, 31);
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
            this.comboBox4.Location = new System.Drawing.Point(125, 113);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(120, 21);
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
            this.comboBox3.Location = new System.Drawing.Point(125, 86);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(120, 21);
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
            this.comboBox2.Location = new System.Drawing.Point(125, 59);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(120, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // pColourDescription
            // 
            this.pColourDescription.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pColourDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pColourDescription.Location = new System.Drawing.Point(-1, -1);
            this.pColourDescription.Name = "pColourDescription";
            this.pColourDescription.Size = new System.Drawing.Size(250, 25);
            this.pColourDescription.TabIndex = 2;
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
            this.comboBox1.Location = new System.Drawing.Point(125, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // pTabs
            // 
            this.pTabs.Location = new System.Drawing.Point(10, 0);
            this.pTabs.Name = "pTabs";
            this.pTabs.Size = new System.Drawing.Size(900, 20);
            this.pTabs.TabIndex = 1;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(10, 25);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(70, 25);
            this.Save.TabIndex = 2;
            this.Save.Text = "Gem";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(10, 70);
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
            this.pProjectHandling.Location = new System.Drawing.Point(920, 550);
            this.pProjectHandling.Name = "pProjectHandling";
            this.pProjectHandling.Size = new System.Drawing.Size(330, 120);
            this.pProjectHandling.TabIndex = 4;
            // 
            // hProject
            // 
            this.hProject.AutoSize = true;
            this.hProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hProject.Location = new System.Drawing.Point(930, 540);
            this.hProject.Name = "hProject";
            this.hProject.Size = new System.Drawing.Size(107, 13);
            this.hProject.TabIndex = 5;
            this.hProject.Text = "Projekthåndtering";
            // 
            // pParameters
            // 
            this.pParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pParameters.Location = new System.Drawing.Point(920, 160);
            this.pParameters.Name = "pParameters";
            this.pParameters.Size = new System.Drawing.Size(330, 370);
            this.pParameters.TabIndex = 6;
            // 
            // hParameters
            // 
            this.hParameters.AutoSize = true;
            this.hParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hParameters.Location = new System.Drawing.Point(930, 150);
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
            this.pTimeControl.Location = new System.Drawing.Point(920, 20);
            this.pTimeControl.Name = "pTimeControl";
            this.pTimeControl.Size = new System.Drawing.Size(330, 120);
            this.pTimeControl.TabIndex = 8;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(130, 80);
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
            this.lTime.Location = new System.Drawing.Point(90, 85);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(31, 13);
            this.lTime.TabIndex = 3;
            this.lTime.Text = "Tid =";
            // 
            // timeMultiplier
            // 
            this.timeMultiplier.Location = new System.Drawing.Point(250, 25);
            this.timeMultiplier.Name = "timeMultiplier";
            this.timeMultiplier.Size = new System.Drawing.Size(70, 25);
            this.timeMultiplier.TabIndex = 2;
            this.timeMultiplier.Text = "x1";
            this.timeMultiplier.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(130, 25);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(70, 25);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(10, 25);
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
            this.hTimeControl.Location = new System.Drawing.Point(930, 10);
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
            this.pInfoBox.Size = new System.Drawing.Size(898, 119);
            this.pInfoBox.TabIndex = 10;
            // 
            // lH2
            // 
            this.lH2.AutoSize = true;
            this.lH2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lH2.Location = new System.Drawing.Point(51, 60);
            this.lH2.Name = "lH2";
            this.lH2.Size = new System.Drawing.Size(26, 20);
            this.lH2.TabIndex = 7;
            this.lH2.Text = "H₂";
            // 
            // lNH2
            // 
            this.lNH2.AutoSize = true;
            this.lNH2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNH2.Location = new System.Drawing.Point(45, 87);
            this.lNH2.Name = "lNH2";
            this.lNH2.Size = new System.Drawing.Size(37, 20);
            this.lNH2.TabIndex = 8;
            this.lNH2.Text = "NH₂";
            // 
            // lTemperature
            // 
            this.lTemperature.AutoSize = true;
            this.lTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTemperature.Location = new System.Drawing.Point(15, 114);
            this.lTemperature.Name = "lTemperature";
            this.lTemperature.Size = new System.Drawing.Size(91, 20);
            this.lTemperature.TabIndex = 9;
            this.lTemperature.Text = "Temperatur";
            // 
            // pGraphArea
            // 
            this.pGraphArea.Location = new System.Drawing.Point(3, 6);
            this.pGraphArea.Name = "pGraphArea";
            this.pGraphArea.Size = new System.Drawing.Size(621, 499);
            this.pGraphArea.TabIndex = 1;
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
            this.pCurveColours.ResumeLayout(false);
            this.pCurveColours.PerformLayout();
            this.pProjectHandling.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pCurveColours;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel pColourDescription;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lN2;
        private System.Windows.Forms.Label lNH2;
        private System.Windows.Forms.Label lH2;
        private System.Windows.Forms.Label lTemperature;
        private System.Windows.Forms.Panel pGraphArea;
        private System.Windows.Forms.Label hInfoBox;
    }
}