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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hProject = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.hParameters = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.hTimeControl = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.timeMultiplier = new System.Windows.Forms.Button();
            this.hTime = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(10, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 510);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 20);
            this.panel2.TabIndex = 1;
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
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Save);
            this.panel3.Controls.Add(this.Load);
            this.panel3.Location = new System.Drawing.Point(920, 550);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 120);
            this.panel3.TabIndex = 4;
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
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(920, 160);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(330, 370);
            this.panel4.TabIndex = 6;
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
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.hTime);
            this.panel5.Controls.Add(this.timeMultiplier);
            this.panel5.Controls.Add(this.stop);
            this.panel5.Controls.Add(this.start);
            this.panel5.Location = new System.Drawing.Point(920, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(330, 120);
            this.panel5.TabIndex = 8;
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
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(12, 550);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(898, 119);
            this.panel6.TabIndex = 10;
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
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(130, 25);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(70, 25);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
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
            // hTime
            // 
            this.hTime.AutoSize = true;
            this.hTime.Location = new System.Drawing.Point(90, 85);
            this.hTime.Name = "hTime";
            this.hTime.Size = new System.Drawing.Size(31, 13);
            this.hTime.TabIndex = 3;
            this.hTime.Text = "Tid =";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 4;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.hTimeControl);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.hParameters);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.hProject);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GUI";
            this.Text = "GUI";
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label hProject;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label hParameters;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label hTimeControl;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button timeMultiplier;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label hTime;
        private System.Windows.Forms.TextBox textBox1;
    }
}