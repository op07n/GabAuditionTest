namespace GabAuditionTest
{
    partial class frmMain
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
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbAlternate = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.cbSamplerate = new System.Windows.Forms.ComboBox();
            this.cbWaveType = new System.Windows.Forms.ComboBox();
            this.txtRelease = new System.Windows.Forms.MaskedTextBox();
            this.txtSustain = new System.Windows.Forms.MaskedTextBox();
            this.txtAttack = new System.Windows.Forms.MaskedTextBox();
            this.tbAmp = new System.Windows.Forms.TrackBar();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(272, 423);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Start !";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudMin);
            this.groupBox1.Controls.Add(this.nudMax);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Octaves";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(219, 58);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "0 Hz";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(219, 21);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(29, 13);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "0 Hz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbAmp);
            this.groupBox2.Controls.Add(this.rbAlternate);
            this.groupBox2.Controls.Add(this.rbBoth);
            this.groupBox2.Controls.Add(this.rbRight);
            this.groupBox2.Controls.Add(this.rbLeft);
            this.groupBox2.Location = new System.Drawing.Point(21, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 145);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Volume";
            // 
            // rbAlternate
            // 
            this.rbAlternate.AutoSize = true;
            this.rbAlternate.Location = new System.Drawing.Point(151, 60);
            this.rbAlternate.Name = "rbAlternate";
            this.rbAlternate.Size = new System.Drawing.Size(93, 17);
            this.rbAlternate.TabIndex = 3;
            this.rbAlternate.Text = "Left, then right";
            this.rbAlternate.UseVisualStyleBackColor = true;
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Checked = true;
            this.rbBoth.Location = new System.Drawing.Point(31, 60);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(80, 17);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Left && Right";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(151, 28);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(68, 17);
            this.rbRight.TabIndex = 1;
            this.rbRight.Text = "Right ear";
            this.rbRight.UseVisualStyleBackColor = true;
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.Location = new System.Drawing.Point(31, 28);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(61, 17);
            this.rbLeft.TabIndex = 0;
            this.rbLeft.Text = "Left ear";
            this.rbLeft.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtRelease);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtSustain);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtAttack);
            this.groupBox3.Location = new System.Drawing.Point(21, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 137);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Notes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Release:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Sustain:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Attack:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cbWaveType);
            this.groupBox4.Location = new System.Drawing.Point(214, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(133, 63);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Wave type";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbSamplerate);
            this.groupBox5.Location = new System.Drawing.Point(214, 189);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(132, 67);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Samplerate (Hz)";
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Checked = global::GabAuditionTest.Properties.Settings.Default.setSavFil;
            this.chkSave.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::GabAuditionTest.Properties.Settings.Default, "setSavFil", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSave.Location = new System.Drawing.Point(21, 423);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(167, 17);
            this.chkSave.TabIndex = 8;
            this.chkSave.Text = "Save generated sounds to file";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // cbSamplerate
            // 
            this.cbSamplerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSamplerate.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GabAuditionTest.Properties.Settings.Default, "setSmpRat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbSamplerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSamplerate.FormattingEnabled = true;
            this.cbSamplerate.Items.AddRange(new object[] {
            "8000",
            "11025",
            "16000",
            "22050",
            "32000",
            "44100",
            "48000",
            "96000",
            "192000"});
            this.cbSamplerate.Location = new System.Drawing.Point(21, 25);
            this.cbSamplerate.Name = "cbSamplerate";
            this.cbSamplerate.Size = new System.Drawing.Size(92, 21);
            this.cbSamplerate.TabIndex = 0;
            this.cbSamplerate.Text = global::GabAuditionTest.Properties.Settings.Default.setSmpRat;
            // 
            // cbWaveType
            // 
            this.cbWaveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWaveType.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GabAuditionTest.Properties.Settings.Default, "setWavTyp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbWaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaveType.FormattingEnabled = true;
            this.cbWaveType.Items.AddRange(new object[] {
            "Sine",
            "Square",
            "Sawtooth",
            "Triangle"});
            this.cbWaveType.Location = new System.Drawing.Point(21, 29);
            this.cbWaveType.Name = "cbWaveType";
            this.cbWaveType.Size = new System.Drawing.Size(92, 21);
            this.cbWaveType.TabIndex = 0;
            this.cbWaveType.Text = global::GabAuditionTest.Properties.Settings.Default.setWavTyp;
            // 
            // txtRelease
            // 
            this.txtRelease.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GabAuditionTest.Properties.Settings.Default, "setNotRel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtRelease.Location = new System.Drawing.Point(75, 91);
            this.txtRelease.Mask = "999999 ms";
            this.txtRelease.Name = "txtRelease";
            this.txtRelease.PromptChar = ' ';
            this.txtRelease.Size = new System.Drawing.Size(89, 20);
            this.txtRelease.TabIndex = 4;
            this.txtRelease.Text = global::GabAuditionTest.Properties.Settings.Default.setNotRel;
            // 
            // txtSustain
            // 
            this.txtSustain.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GabAuditionTest.Properties.Settings.Default, "setNotSus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSustain.Location = new System.Drawing.Point(75, 57);
            this.txtSustain.Mask = "999999 ms";
            this.txtSustain.Name = "txtSustain";
            this.txtSustain.PromptChar = ' ';
            this.txtSustain.Size = new System.Drawing.Size(89, 20);
            this.txtSustain.TabIndex = 2;
            this.txtSustain.Text = global::GabAuditionTest.Properties.Settings.Default.setNotSus;
            // 
            // txtAttack
            // 
            this.txtAttack.Culture = new System.Globalization.CultureInfo("");
            this.txtAttack.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GabAuditionTest.Properties.Settings.Default, "setNotAtt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAttack.Location = new System.Drawing.Point(75, 23);
            this.txtAttack.Mask = "999999 ms";
            this.txtAttack.Name = "txtAttack";
            this.txtAttack.PromptChar = ' ';
            this.txtAttack.Size = new System.Drawing.Size(89, 20);
            this.txtAttack.TabIndex = 0;
            this.txtAttack.Text = global::GabAuditionTest.Properties.Settings.Default.setNotAtt;
            // 
            // tbAmp
            // 
            this.tbAmp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAmp.AutoSize = false;
            this.tbAmp.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GabAuditionTest.Properties.Settings.Default, "setOutVol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAmp.LargeChange = 10;
            this.tbAmp.Location = new System.Drawing.Point(75, 100);
            this.tbAmp.Maximum = 100;
            this.tbAmp.Name = "tbAmp";
            this.tbAmp.Size = new System.Drawing.Size(245, 31);
            this.tbAmp.TabIndex = 4;
            this.tbAmp.TickFrequency = 10;
            this.tbAmp.Value = global::GabAuditionTest.Properties.Settings.Default.setOutVol;
            // 
            // nudMin
            // 
            this.nudMin.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GabAuditionTest.Properties.Settings.Default, "setOctFrom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudMin.Location = new System.Drawing.Point(75, 19);
            this.nudMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(120, 20);
            this.nudMin.TabIndex = 1;
            this.nudMin.Value = global::GabAuditionTest.Properties.Settings.Default.setOctFrom;
            this.nudMin.ValueChanged += new System.EventHandler(this.nudMin_ValueChanged);
            // 
            // nudMax
            // 
            this.nudMax.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GabAuditionTest.Properties.Settings.Default, "setOctTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudMax.Location = new System.Drawing.Point(75, 56);
            this.nudMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(120, 20);
            this.nudMax.TabIndex = 2;
            this.nudMax.Value = global::GabAuditionTest.Properties.Settings.Default.setOctTo;
            this.nudMax.ValueChanged += new System.EventHandler(this.nudMax_ValueChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 458);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTest);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(375, 351);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GabAuditionTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbAmp;
        private System.Windows.Forms.RadioButton rbAlternate;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.RadioButton rbLeft;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtRelease;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtSustain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtAttack;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbWaveType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbSamplerate;
        private System.Windows.Forms.CheckBox chkSave;

    }
}

