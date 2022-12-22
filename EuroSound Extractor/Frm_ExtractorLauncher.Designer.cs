
namespace EuroSound_Extractor
{
    partial class Frm_ExtractorLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ExtractorLauncher));
            this.lblSfxFilePath = new System.Windows.Forms.Label();
            this.txtSfxFilePath = new System.Windows.Forms.TextBox();
            this.btnSearchSFX = new System.Windows.Forms.Button();
            this.lblDestFolder = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnSearchOutFolder = new System.Windows.Forms.Button();
            this.lblSoundh = new System.Windows.Forms.Label();
            this.btnSoundh = new System.Windows.Forms.Button();
            this.txtSoundH = new System.Windows.Forms.TextBox();
            this.progBarExtraction = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.opFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSfxFilePath
            // 
            this.lblSfxFilePath.AutoSize = true;
            this.lblSfxFilePath.Location = new System.Drawing.Point(12, 15);
            this.lblSfxFilePath.Name = "lblSfxFilePath";
            this.lblSfxFilePath.Size = new System.Drawing.Size(74, 13);
            this.lblSfxFilePath.TabIndex = 0;
            this.lblSfxFilePath.Text = "SFX File Path:";
            // 
            // txtSfxFilePath
            // 
            this.txtSfxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSfxFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txtSfxFilePath.Location = new System.Drawing.Point(92, 12);
            this.txtSfxFilePath.Name = "txtSfxFilePath";
            this.txtSfxFilePath.ReadOnly = true;
            this.txtSfxFilePath.Size = new System.Drawing.Size(236, 20);
            this.txtSfxFilePath.TabIndex = 1;
            // 
            // btnSearchSFX
            // 
            this.btnSearchSFX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSFX.Location = new System.Drawing.Point(334, 12);
            this.btnSearchSFX.Name = "btnSearchSFX";
            this.btnSearchSFX.Size = new System.Drawing.Size(25, 20);
            this.btnSearchSFX.TabIndex = 2;
            this.btnSearchSFX.Text = "...";
            this.btnSearchSFX.UseVisualStyleBackColor = true;
            this.btnSearchSFX.Click += new System.EventHandler(this.BtnSearchSFX_Click);
            // 
            // lblDestFolder
            // 
            this.lblDestFolder.AutoSize = true;
            this.lblDestFolder.Location = new System.Drawing.Point(22, 67);
            this.lblDestFolder.Name = "lblDestFolder";
            this.lblDestFolder.Size = new System.Drawing.Size(64, 13);
            this.lblDestFolder.TabIndex = 3;
            this.lblDestFolder.Text = "Dest Folder:";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutputFolder.Location = new System.Drawing.Point(92, 64);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(236, 20);
            this.txtOutputFolder.TabIndex = 4;
            // 
            // btnSearchOutFolder
            // 
            this.btnSearchOutFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchOutFolder.Location = new System.Drawing.Point(334, 64);
            this.btnSearchOutFolder.Name = "btnSearchOutFolder";
            this.btnSearchOutFolder.Size = new System.Drawing.Size(25, 20);
            this.btnSearchOutFolder.TabIndex = 5;
            this.btnSearchOutFolder.Text = "...";
            this.btnSearchOutFolder.UseVisualStyleBackColor = true;
            this.btnSearchOutFolder.Click += new System.EventHandler(this.BtnSearchOutFolder_Click);
            // 
            // lblSoundh
            // 
            this.lblSoundh.AutoSize = true;
            this.lblSoundh.Location = new System.Drawing.Point(17, 41);
            this.lblSoundh.Name = "lblSoundh";
            this.lblSoundh.Size = new System.Drawing.Size(69, 13);
            this.lblSoundh.TabIndex = 6;
            this.lblSoundh.Text = "Sound.h File:";
            // 
            // btnSoundh
            // 
            this.btnSoundh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoundh.Location = new System.Drawing.Point(334, 38);
            this.btnSoundh.Name = "btnSoundh";
            this.btnSoundh.Size = new System.Drawing.Size(25, 20);
            this.btnSoundh.TabIndex = 8;
            this.btnSoundh.Text = "...";
            this.btnSoundh.UseVisualStyleBackColor = true;
            this.btnSoundh.Click += new System.EventHandler(this.BtnSoundh_Click);
            // 
            // txtSoundH
            // 
            this.txtSoundH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoundH.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoundH.Location = new System.Drawing.Point(92, 38);
            this.txtSoundH.Name = "txtSoundH";
            this.txtSoundH.ReadOnly = true;
            this.txtSoundH.Size = new System.Drawing.Size(236, 20);
            this.txtSoundH.TabIndex = 7;
            // 
            // progBarExtraction
            // 
            this.progBarExtraction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBarExtraction.Location = new System.Drawing.Point(12, 122);
            this.progBarExtraction.Name = "progBarExtraction";
            this.progBarExtraction.Size = new System.Drawing.Size(347, 23);
            this.progBarExtraction.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(203, 151);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(284, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // opFileDlg
            // 
            this.opFileDlg.Filter = "SFX File (*.SFX)|*.sfx|HashTable File (*.h)|*.h";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Type Of File:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SoundBank",
            "StreamBank",
            "MusicBank"});
            this.comboBox1.Location = new System.Drawing.Point(92, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(267, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // Frm_ExtractorLauncher
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(371, 183);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progBarExtraction);
            this.Controls.Add(this.btnSoundh);
            this.Controls.Add(this.txtSoundH);
            this.Controls.Add(this.lblSoundh);
            this.Controls.Add(this.btnSearchOutFolder);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.lblDestFolder);
            this.Controls.Add(this.btnSearchSFX);
            this.Controls.Add(this.txtSfxFilePath);
            this.Controls.Add(this.lblSfxFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ExtractorLauncher";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EuroSound Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSfxFilePath;
        private System.Windows.Forms.TextBox txtSfxFilePath;
        private System.Windows.Forms.Button btnSearchSFX;
        private System.Windows.Forms.Label lblDestFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnSearchOutFolder;
        private System.Windows.Forms.Label lblSoundh;
        private System.Windows.Forms.Button btnSoundh;
        private System.Windows.Forms.TextBox txtSoundH;
        private System.Windows.Forms.ProgressBar progBarExtraction;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog opFileDlg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}