namespace Encrypted_Chat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.Sendbutton = new System.Windows.Forms.Button();
            this.radioCBC = new System.Windows.Forms.RadioButton();
            this.radioECB = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.EncTypeBox = new System.Windows.Forms.GroupBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.selectedFile = new System.Windows.Forms.TextBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.FileProgressBar = new System.Windows.Forms.ProgressBar();
            this.txtNazwa = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.EncTypeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(50, 71);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(244, 31);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(365, 71);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(85, 31);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "5008";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(50, 510);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(470, 146);
            this.txtMessage.TabIndex = 2;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(50, 135);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(624, 331);
            this.txtStatus.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(530, 64);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 38);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Sendbutton
            // 
            this.Sendbutton.Location = new System.Drawing.Point(530, 592);
            this.Sendbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(146, 67);
            this.Sendbutton.TabIndex = 5;
            this.Sendbutton.Text = "Send";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // radioCBC
            // 
            this.radioCBC.AutoSize = true;
            this.radioCBC.Location = new System.Drawing.Point(76, 37);
            this.radioCBC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioCBC.Name = "radioCBC";
            this.radioCBC.Size = new System.Drawing.Size(72, 29);
            this.radioCBC.TabIndex = 6;
            this.radioCBC.TabStop = true;
            this.radioCBC.Text = "OCB";
            this.radioCBC.UseVisualStyleBackColor = true;
            // 
            // radioECB
            // 
            this.radioECB.AutoSize = true;
            this.radioECB.Location = new System.Drawing.Point(9, 37);
            this.radioECB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioECB.Name = "radioECB";
            this.radioECB.Size = new System.Drawing.Size(67, 29);
            this.radioECB.TabIndex = 7;
            this.radioECB.TabStop = true;
            this.radioECB.Text = "ECB";
            this.radioECB.UseVisualStyleBackColor = true;
            this.radioECB.CheckedChanged += new System.EventHandler(this.radioECB_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // EncTypeBox
            // 
            this.EncTypeBox.Controls.Add(this.radioECB);
            this.EncTypeBox.Controls.Add(this.radioCBC);
            this.EncTypeBox.Location = new System.Drawing.Point(530, 510);
            this.EncTypeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EncTypeBox.Name = "EncTypeBox";
            this.EncTypeBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EncTypeBox.Size = new System.Drawing.Size(146, 72);
            this.EncTypeBox.TabIndex = 8;
            this.EncTypeBox.TabStop = false;
            this.EncTypeBox.Text = "Encoding Type";
            this.EncTypeBox.Enter += new System.EventHandler(this.EncTypeBox_Enter);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(289, 693);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(107, 38);
            this.btnSelectFile.TabIndex = 9;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectedFile
            // 
            this.selectedFile.Location = new System.Drawing.Point(50, 742);
            this.selectedFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.selectedFile.Name = "selectedFile";
            this.selectedFile.Size = new System.Drawing.Size(624, 31);
            this.selectedFile.TabIndex = 10;
            this.selectedFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.selectedFile.TextChanged += new System.EventHandler(this.selectedFile_TextChanged);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // FileProgressBar
            // 
            this.FileProgressBar.Location = new System.Drawing.Point(129, 810);
            this.FileProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileProgressBar.Name = "FileProgressBar";
            this.FileProgressBar.Size = new System.Drawing.Size(461, 38);
            this.FileProgressBar.TabIndex = 11;
            this.FileProgressBar.Click += new System.EventHandler(this.FileProgressBar_Click);
            // 
            // txtNazwa
            // 
            this.txtNazwa.Location = new System.Drawing.Point(50, 14);
            this.txtNazwa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNazwa.Name = "txtNazwa";
            this.txtNazwa.Size = new System.Drawing.Size(244, 31);
            this.txtNazwa.TabIndex = 12;
            this.txtNazwa.Text = "Nazwa";
            this.txtNazwa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(365, 14);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(244, 31);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 868);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtNazwa);
            this.Controls.Add(this.FileProgressBar);
            this.Controls.Add(this.selectedFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.EncTypeBox);
            this.Controls.Add(this.Sendbutton);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAddress);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.EncTypeBox.ResumeLayout(false);
            this.EncTypeBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtAddress;
        private TextBox txtPort;
        private TextBox txtMessage;
        private TextBox txtStatus;
        private Button btnStart;
        private Button Sendbutton;
        private RadioButton radioCBC;
        private RadioButton radioECB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private GroupBox EncTypeBox;
        private Button btnSelectFile;
        private TextBox selectedFile;
        private ProgressBar FileProgressBar;
        private TextBox txtNazwa;
        private TextBox txtPassword;
    }
}