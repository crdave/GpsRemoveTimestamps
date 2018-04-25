namespace RemGpsTimes
{
    partial class Form1
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
            this.lstbxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.chkbxRemTimeHist = new System.Windows.Forms.CheckBox();
            this.chkbxKeepFileType = new System.Windows.Forms.CheckBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGpsBabelExeLoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstbxFiles
            // 
            this.lstbxFiles.AllowDrop = true;
            this.lstbxFiles.FormattingEnabled = true;
            this.lstbxFiles.Location = new System.Drawing.Point(56, 65);
            this.lstbxFiles.Name = "lstbxFiles";
            this.lstbxFiles.Size = new System.Drawing.Size(695, 277);
            this.lstbxFiles.TabIndex = 22;
            this.lstbxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstbxFiles_DragDrop);
            this.lstbxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstbxFiles_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Drag/Drop Gpx or Xml Files";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(713, 49);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "lblStatus";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Maroon;
            this.lblError.Location = new System.Drawing.Point(58, 428);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 19;
            this.lblError.Text = "lblError";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(697, 23);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 18;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chkbxRemTimeHist
            // 
            this.chkbxRemTimeHist.AutoSize = true;
            this.chkbxRemTimeHist.Location = new System.Drawing.Point(223, 8);
            this.chkbxRemTimeHist.Name = "chkbxRemTimeHist";
            this.chkbxRemTimeHist.Size = new System.Drawing.Size(125, 17);
            this.chkbxRemTimeHist.TabIndex = 24;
            this.chkbxRemTimeHist.Text = "Remove Timestamps";
            this.chkbxRemTimeHist.UseVisualStyleBackColor = true;
            this.chkbxRemTimeHist.CheckedChanged += new System.EventHandler(this.chkbxRemTimeHist_CheckedChanged);
            // 
            // chkbxKeepFileType
            // 
            this.chkbxKeepFileType.AutoSize = true;
            this.chkbxKeepFileType.Location = new System.Drawing.Point(363, 8);
            this.chkbxKeepFileType.Name = "chkbxKeepFileType";
            this.chkbxKeepFileType.Size = new System.Drawing.Size(118, 17);
            this.chkbxKeepFileType.TabIndex = 25;
            this.chkbxKeepFileType.Text = "Keep same file type";
            this.chkbxKeepFileType.UseVisualStyleBackColor = true;
            this.chkbxKeepFileType.CheckedChanged += new System.EventHandler(this.chkbxKeepFileType_CheckedChanged);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.ForeColor = System.Drawing.Color.Blue;
            this.lblAction.Location = new System.Drawing.Point(222, 33);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(47, 13);
            this.lblAction.TabIndex = 26;
            this.lblAction.Text = "lblAction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Full Path to Gpsbabel executable";
            // 
            // txtGpsBabelExeLoc
            // 
            this.txtGpsBabelExeLoc.Location = new System.Drawing.Point(56, 392);
            this.txtGpsBabelExeLoc.Name = "txtGpsBabelExeLoc";
            this.txtGpsBabelExeLoc.Size = new System.Drawing.Size(695, 20);
            this.txtGpsBabelExeLoc.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 454);
            this.Controls.Add(this.txtGpsBabelExeLoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.chkbxKeepFileType);
            this.Controls.Add(this.chkbxRemTimeHist);
            this.Controls.Add(this.lstbxFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox chkbxRemTimeHist;
        private System.Windows.Forms.CheckBox chkbxKeepFileType;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGpsBabelExeLoc;
    }
}

