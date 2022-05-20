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
            this.EncTypeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(35, 32);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(172, 23);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(258, 32);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(61, 23);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "5008";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(35, 306);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(330, 89);
            this.txtMessage.TabIndex = 2;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(35, 81);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(438, 200);
            this.txtStatus.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(370, 32);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Sendbutton
            // 
            this.Sendbutton.Location = new System.Drawing.Point(371, 355);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(102, 40);
            this.Sendbutton.TabIndex = 5;
            this.Sendbutton.Text = "Send";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // radioCBC
            // 
            this.radioCBC.AutoSize = true;
            this.radioCBC.Location = new System.Drawing.Point(53, 22);
            this.radioCBC.Name = "radioCBC";
            this.radioCBC.Size = new System.Drawing.Size(49, 19);
            this.radioCBC.TabIndex = 6;
            this.radioCBC.TabStop = true;
            this.radioCBC.Text = "OCB";
            this.radioCBC.UseVisualStyleBackColor = true;
            // 
            // radioECB
            // 
            this.radioECB.AutoSize = true;
            this.radioECB.Location = new System.Drawing.Point(6, 22);
            this.radioECB.Name = "radioECB";
            this.radioECB.Size = new System.Drawing.Size(46, 19);
            this.radioECB.TabIndex = 7;
            this.radioECB.TabStop = true;
            this.radioECB.Text = "ECB";
            this.radioECB.UseVisualStyleBackColor = true;
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
            this.EncTypeBox.Location = new System.Drawing.Point(371, 306);
            this.EncTypeBox.Name = "EncTypeBox";
            this.EncTypeBox.Size = new System.Drawing.Size(102, 43);
            this.EncTypeBox.TabIndex = 8;
            this.EncTypeBox.TabStop = false;
            this.EncTypeBox.Text = "Encoding Type";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(202, 416);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 9;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectedFile
            // 
            this.selectedFile.Location = new System.Drawing.Point(158, 445);
            this.selectedFile.Name = "selectedFile";
            this.selectedFile.Size = new System.Drawing.Size(172, 23);
            this.selectedFile.TabIndex = 10;
            this.selectedFile.Text = "{Selected File}";
            this.selectedFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 490);
            this.Controls.Add(this.selectedFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.EncTypeBox);
            this.Controls.Add(this.Sendbutton);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAddress);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private GroupBox EncTypeBox;
        private Button btnSelectFile;
        private TextBox selectedFile;
    }
}