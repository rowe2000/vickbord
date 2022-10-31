namespace TicApp
{
    partial class MainForm
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
            this.connectButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.gotoButton = new System.Windows.Forms.Button();
            this.gotoGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.speedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.positionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.varsLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resetPosButton = new System.Windows.Forms.Button();
            this.positionLabel = new System.Windows.Forms.Label();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.jogRigthCheckBox = new System.Windows.Forms.CheckBox();
            this.jogSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.jogLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.energizeButton = new System.Windows.Forms.Button();
            this.gotoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jogSpeedNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.connectButton.Location = new System.Drawing.Point(30, 48);
            this.connectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(150, 44);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.OnConnectClick);
            // 
            // buttonHome
            // 
            this.homeButton.Location = new System.Drawing.Point(800, 27);
            this.homeButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(188, 44);
            this.homeButton.TabIndex = 1;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.OnHome_Click);
            // 
            // buttonGoto
            // 
            this.gotoButton.Location = new System.Drawing.Point(12, 31);
            this.gotoButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gotoButton.Name = "gotoButton";
            this.gotoButton.Size = new System.Drawing.Size(150, 44);
            this.gotoButton.TabIndex = 2;
            this.gotoButton.Text = "Run";
            this.gotoButton.UseVisualStyleBackColor = true;
            this.gotoButton.Click += new System.EventHandler(this.OnGoto_Click);
            // 
            // groupBoxGOTO
            // 
            this.gotoGroupBox.Controls.Add(this.label2);
            this.gotoGroupBox.Controls.Add(this.label1);
            this.gotoGroupBox.Controls.Add(this.speedNumericUpDown);
            this.gotoGroupBox.Controls.Add(this.positionNumericUpDown);
            this.gotoGroupBox.Controls.Add(this.gotoButton);
            this.gotoGroupBox.Location = new System.Drawing.Point(30, 148);
            this.gotoGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gotoGroupBox.Name = "gotoGroupBox";
            this.gotoGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gotoGroupBox.Size = new System.Drawing.Size(450, 138);
            this.gotoGroupBox.TabIndex = 3;
            this.gotoGroupBox.TabStop = false;
            this.gotoGroupBox.Text = "Goto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Position";
            // 
            // numericUpDownSpeed
            // 
            this.speedNumericUpDown.Location = new System.Drawing.Point(286, 81);
            this.speedNumericUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.speedNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.speedNumericUpDown.Name = "speedNumericUpDown";
            this.speedNumericUpDown.Size = new System.Drawing.Size(150, 31);
            this.speedNumericUpDown.TabIndex = 5;
            this.speedNumericUpDown.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // numericUpDownPosition
            // 
            this.positionNumericUpDown.Location = new System.Drawing.Point(288, 31);
            this.positionNumericUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.positionNumericUpDown.Maximum = new decimal(new int[] {
            4600,
            0,
            0,
            0});
            this.positionNumericUpDown.Minimum = new decimal(new int[] {
            4600,
            0,
            0,
            -2147483648});
            this.positionNumericUpDown.Name = "positionNumericUpDown";
            this.positionNumericUpDown.Size = new System.Drawing.Size(150, 31);
            this.positionNumericUpDown.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.varsLabel);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Location = new System.Drawing.Point(30, 312);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(992, 804);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // labelVars
            // 
            this.varsLabel.Location = new System.Drawing.Point(16, 35);
            this.varsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.varsLabel.Name = "varsLabel";
            this.varsLabel.Size = new System.Drawing.Size(352, 763);
            this.varsLabel.TabIndex = 1;
            this.varsLabel.Text = "Vars";
            // 
            // labelStatus
            // 
            this.statusLabel.Location = new System.Drawing.Point(368, 31);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(614, 306);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resetPosButton);
            this.groupBox2.Controls.Add(this.positionLabel);
            this.groupBox2.Location = new System.Drawing.Point(428, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(360, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position";
            // 
            // resetPosButton
            // 
            this.resetPosButton.Location = new System.Drawing.Point(160, 37);
            this.resetPosButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resetPosButton.Name = "resetPosButton";
            this.resetPosButton.Size = new System.Drawing.Size(188, 44);
            this.resetPosButton.TabIndex = 2;
            this.resetPosButton.Text = "Reset";
            this.resetPosButton.UseVisualStyleBackColor = true;
            this.resetPosButton.Click += new System.EventHandler(this.OnResetPositionButton_Click);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(34, 44);
            this.positionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(24, 25);
            this.positionLabel.TabIndex = 0;
            this.positionLabel.Text = "0";
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(38, 44);
            this.connectionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(43, 25);
            this.connectionLabel.TabIndex = 0;
            this.connectionLabel.Text = "No";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.connectionLabel);
            this.groupBox3.Location = new System.Drawing.Point(192, 23);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(190, 92);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.jogRigthCheckBox);
            this.groupBox5.Controls.Add(this.jogSpeedNumericUpDown);
            this.groupBox5.Controls.Add(this.jogLeftCheckBox);
            this.groupBox5.Location = new System.Drawing.Point(590, 146);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox5.Size = new System.Drawing.Size(430, 154);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Jog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Speed";
            // 
            // jogRigthCheckBox
            // 
            this.jogRigthCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.jogRigthCheckBox.Location = new System.Drawing.Point(232, 40);
            this.jogRigthCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.jogRigthCheckBox.Name = "jogRigthCheckBox";
            this.jogRigthCheckBox.Size = new System.Drawing.Size(160, 44);
            this.jogRigthCheckBox.TabIndex = 7;
            this.jogRigthCheckBox.Text = "--->";
            this.jogRigthCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jogRigthCheckBox.UseVisualStyleBackColor = true;
            this.jogRigthCheckBox.CheckedChanged += new System.EventHandler(this.OnJogRight_CheckedChanged);
            // 
            // jogSpeedNumericUpDown
            // 
            this.jogSpeedNumericUpDown.Location = new System.Drawing.Point(232, 96);
            this.jogSpeedNumericUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.jogSpeedNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.jogSpeedNumericUpDown.Name = "jogSpeedNumericUpDown";
            this.jogSpeedNumericUpDown.Size = new System.Drawing.Size(150, 31);
            this.jogSpeedNumericUpDown.TabIndex = 8;
            this.jogSpeedNumericUpDown.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // jogLeftCheckBox
            // 
            this.jogLeftCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.jogLeftCheckBox.Location = new System.Drawing.Point(46, 40);
            this.jogLeftCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.jogLeftCheckBox.Name = "jogLeftCheckBox";
            this.jogLeftCheckBox.Size = new System.Drawing.Size(160, 44);
            this.jogLeftCheckBox.TabIndex = 6;
            this.jogLeftCheckBox.Text = "<---";
            this.jogLeftCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jogLeftCheckBox.UseVisualStyleBackColor = true;
            this.jogLeftCheckBox.CheckedChanged += new System.EventHandler(this.OnJogLeft_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // buttonEnergize
            // 
            this.energizeButton.Location = new System.Drawing.Point(800, 83);
            this.energizeButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.energizeButton.Name = "energizeButton";
            this.energizeButton.Size = new System.Drawing.Size(188, 44);
            this.energizeButton.TabIndex = 6;
            this.energizeButton.Text = "Deenergize";
            this.energizeButton.UseVisualStyleBackColor = true;
            this.energizeButton.Click += new System.EventHandler(this.OnEnergize_ButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 1138);
            this.Controls.Add(this.energizeButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gotoGroupBox);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.connectButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gotoGroupBox.ResumeLayout(false);
            this.gotoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jogSpeedNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button gotoButton;
        private System.Windows.Forms.GroupBox gotoGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown speedNumericUpDown;
        private System.Windows.Forms.NumericUpDown positionNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox jogRigthCheckBox;
        private System.Windows.Forms.CheckBox jogLeftCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown jogSpeedNumericUpDown;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label varsLabel;
        private System.Windows.Forms.Button energizeButton;
        private System.Windows.Forms.Button resetPosButton;
    }
}

