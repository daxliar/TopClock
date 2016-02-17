namespace TopClock
{
    partial class TopClockForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopClockForm));
            this.g_timer = new System.Windows.Forms.Timer(this.components);
            this.g_timeLabel = new System.Windows.Forms.Label();
            this.g_btnPlusH = new System.Windows.Forms.Button();
            this.g_btnMinusH = new System.Windows.Forms.Button();
            this.g_mainPanel = new System.Windows.Forms.Panel();
            this.g_cbxStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.g_cmbUpdateTime = new System.Windows.Forms.ComboBox();
            this.g_btnReset = new System.Windows.Forms.Button();
            this.g_btnMinusM = new System.Windows.Forms.Button();
            this.g_btnPlusM = new System.Windows.Forms.Button();
            this.g_mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // g_timeLabel
            // 
            this.g_timeLabel.AutoSize = true;
            this.g_timeLabel.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_timeLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.g_timeLabel.Location = new System.Drawing.Point(10, 38);
            this.g_timeLabel.Name = "g_timeLabel";
            this.g_timeLabel.Size = new System.Drawing.Size(302, 97);
            this.g_timeLabel.TabIndex = 0;
            this.g_timeLabel.Text = "00:00";
            this.g_timeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.g_timeLabel_MouseDown);
            this.g_timeLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.g_timeLabel_MouseUp);
            // 
            // g_btnPlusH
            // 
            this.g_btnPlusH.Location = new System.Drawing.Point(36, 12);
            this.g_btnPlusH.Name = "g_btnPlusH";
            this.g_btnPlusH.Size = new System.Drawing.Size(95, 23);
            this.g_btnPlusH.TabIndex = 1;
            this.g_btnPlusH.Text = "+";
            this.g_btnPlusH.UseVisualStyleBackColor = true;
            this.g_btnPlusH.Click += new System.EventHandler(this.g_btnPlusH_Click);
            // 
            // g_btnMinusH
            // 
            this.g_btnMinusH.Location = new System.Drawing.Point(36, 138);
            this.g_btnMinusH.Name = "g_btnMinusH";
            this.g_btnMinusH.Size = new System.Drawing.Size(95, 23);
            this.g_btnMinusH.TabIndex = 2;
            this.g_btnMinusH.Text = "-";
            this.g_btnMinusH.UseVisualStyleBackColor = true;
            this.g_btnMinusH.Click += new System.EventHandler(this.g_btnMinusH_Click);
            // 
            // g_mainPanel
            // 
            this.g_mainPanel.Controls.Add(this.g_cbxStart);
            this.g_mainPanel.Controls.Add(this.label1);
            this.g_mainPanel.Controls.Add(this.g_cmbUpdateTime);
            this.g_mainPanel.Controls.Add(this.g_btnReset);
            this.g_mainPanel.Controls.Add(this.g_timeLabel);
            this.g_mainPanel.Controls.Add(this.g_btnMinusM);
            this.g_mainPanel.Controls.Add(this.g_btnPlusM);
            this.g_mainPanel.Controls.Add(this.g_btnMinusH);
            this.g_mainPanel.Controls.Add(this.g_btnPlusH);
            this.g_mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g_mainPanel.Location = new System.Drawing.Point(0, 0);
            this.g_mainPanel.Name = "g_mainPanel";
            this.g_mainPanel.Size = new System.Drawing.Size(321, 303);
            this.g_mainPanel.TabIndex = 3;
            // 
            // g_cbxStart
            // 
            this.g_cbxStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.g_cbxStart.Location = new System.Drawing.Point(36, 183);
            this.g_cbxStart.Name = "g_cbxStart";
            this.g_cbxStart.Size = new System.Drawing.Size(249, 30);
            this.g_cbxStart.TabIndex = 9;
            this.g_cbxStart.Text = "Click to &START";
            this.g_cbxStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.g_cbxStart.UseVisualStyleBackColor = true;
            this.g_cbxStart.CheckedChanged += new System.EventHandler(this.g_cbxStart_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Update every (minutes):";
            // 
            // g_cmbUpdateTime
            // 
            this.g_cmbUpdateTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.g_cmbUpdateTime.FormattingEnabled = true;
            this.g_cmbUpdateTime.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "15",
            "30",
            "60"});
            this.g_cmbUpdateTime.Location = new System.Drawing.Point(203, 258);
            this.g_cmbUpdateTime.Name = "g_cmbUpdateTime";
            this.g_cmbUpdateTime.Size = new System.Drawing.Size(82, 24);
            this.g_cmbUpdateTime.TabIndex = 7;
            // 
            // g_btnReset
            // 
            this.g_btnReset.Location = new System.Drawing.Point(36, 219);
            this.g_btnReset.Name = "g_btnReset";
            this.g_btnReset.Size = new System.Drawing.Size(249, 30);
            this.g_btnReset.TabIndex = 6;
            this.g_btnReset.Text = "&Reset";
            this.g_btnReset.UseVisualStyleBackColor = true;
            this.g_btnReset.Click += new System.EventHandler(this.g_btnReset_Click);
            // 
            // g_btnMinusM
            // 
            this.g_btnMinusM.Location = new System.Drawing.Point(190, 139);
            this.g_btnMinusM.Name = "g_btnMinusM";
            this.g_btnMinusM.Size = new System.Drawing.Size(95, 23);
            this.g_btnMinusM.TabIndex = 3;
            this.g_btnMinusM.Text = "-";
            this.g_btnMinusM.UseVisualStyleBackColor = true;
            this.g_btnMinusM.Click += new System.EventHandler(this.g_btnMinusM_Click);
            // 
            // g_btnPlusM
            // 
            this.g_btnPlusM.Location = new System.Drawing.Point(190, 13);
            this.g_btnPlusM.Name = "g_btnPlusM";
            this.g_btnPlusM.Size = new System.Drawing.Size(95, 23);
            this.g_btnPlusM.TabIndex = 4;
            this.g_btnPlusM.Text = "+";
            this.g_btnPlusM.UseVisualStyleBackColor = true;
            this.g_btnPlusM.Click += new System.EventHandler(this.g_btnPlusM_Click);
            // 
            // TopClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 303);
            this.Controls.Add(this.g_mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TopClockForm";
            this.Text = "TopClock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TopClockForm_FormClosing);
            this.g_mainPanel.ResumeLayout(false);
            this.g_mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer g_timer;
        private System.Windows.Forms.Label g_timeLabel;
        private System.Windows.Forms.Button g_btnPlusH;
        private System.Windows.Forms.Button g_btnMinusH;
        private System.Windows.Forms.Panel g_mainPanel;
        private System.Windows.Forms.Button g_btnMinusM;
        private System.Windows.Forms.Button g_btnPlusM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox g_cmbUpdateTime;
        private System.Windows.Forms.Button g_btnReset;
        private System.Windows.Forms.CheckBox g_cbxStart;
    }
}

