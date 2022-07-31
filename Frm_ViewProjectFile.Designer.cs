
namespace sb_explorer
{
    partial class Frm_ViewProjectFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ViewProjectFile));
            this.TabControl_ProjectSettings = new System.Windows.Forms.TabControl();
            this.tabPage_MemmorySlots = new System.Windows.Forms.TabPage();
            this.ListView_MemmorySlots = new System.Windows.Forms.ListView();
            this.Column_MemmorySlotsCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_MemmorySlots_MemmorySize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column_MemmorySlots_Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Textbox_MemmorySlotsCount = new System.Windows.Forms.TextBox();
            this.Label_MemmorySlotsCount = new System.Windows.Forms.Label();
            this.tabPage_SoundBanks = new System.Windows.Forms.TabPage();
            this.ListView_SoundBank = new System.Windows.Forms.ListView();
            this.Col_SoundBanks_Hashcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_SoundBanks_SlotNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Textbox_SoundBankCount = new System.Windows.Forms.TextBox();
            this.Label_SoundBankCount = new System.Windows.Forms.Label();
            this.tabPage_Musics = new System.Windows.Forms.TabPage();
            this.ListView_Music = new System.Windows.Forms.ListView();
            this.Col_Music_HashCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Music_MaxSeconds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Music_ForceRestart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Music_ForceXFade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Music_Min_FadeUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Music_Max_FadeUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Music_Min_FadeDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Music_Max_FadeDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Textbox_Music_Count = new System.Windows.Forms.TextBox();
            this.Label_Music_Count = new System.Windows.Forms.Label();
            this.Textbox_StereoStreamCount = new System.Windows.Forms.TextBox();
            this.Label_StereoStreamCount = new System.Windows.Forms.Label();
            this.Textbox_MonoStreamCount = new System.Windows.Forms.TextBox();
            this.Label_MonoStreamCount = new System.Windows.Forms.Label();
            this.Textbox_ProjectCode = new System.Windows.Forms.TextBox();
            this.Label_ProjectCode = new System.Windows.Forms.Label();
            this.ListView_FlagsValues = new System.Windows.Forms.ListView();
            this.Col_UserFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Button_OK = new System.Windows.Forms.Button();
            this.TabControl_ProjectSettings.SuspendLayout();
            this.tabPage_MemmorySlots.SuspendLayout();
            this.tabPage_SoundBanks.SuspendLayout();
            this.tabPage_Musics.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl_ProjectSettings
            // 
            this.TabControl_ProjectSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_ProjectSettings.Controls.Add(this.tabPage_MemmorySlots);
            this.TabControl_ProjectSettings.Controls.Add(this.tabPage_SoundBanks);
            this.TabControl_ProjectSettings.Controls.Add(this.tabPage_Musics);
            this.TabControl_ProjectSettings.Location = new System.Drawing.Point(12, 12);
            this.TabControl_ProjectSettings.Name = "TabControl_ProjectSettings";
            this.TabControl_ProjectSettings.SelectedIndex = 0;
            this.TabControl_ProjectSettings.Size = new System.Drawing.Size(612, 450);
            this.TabControl_ProjectSettings.TabIndex = 0;
            // 
            // tabPage_MemmorySlots
            // 
            this.tabPage_MemmorySlots.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_MemmorySlots.Controls.Add(this.ListView_MemmorySlots);
            this.tabPage_MemmorySlots.Controls.Add(this.Textbox_MemmorySlotsCount);
            this.tabPage_MemmorySlots.Controls.Add(this.Label_MemmorySlotsCount);
            this.tabPage_MemmorySlots.Location = new System.Drawing.Point(4, 22);
            this.tabPage_MemmorySlots.Name = "tabPage_MemmorySlots";
            this.tabPage_MemmorySlots.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_MemmorySlots.Size = new System.Drawing.Size(604, 424);
            this.tabPage_MemmorySlots.TabIndex = 0;
            this.tabPage_MemmorySlots.Text = "Memmory Slots";
            // 
            // ListView_MemmorySlots
            // 
            this.ListView_MemmorySlots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListView_MemmorySlots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column_MemmorySlotsCount,
            this.Column_MemmorySlots_MemmorySize,
            this.Column_MemmorySlots_Quantity});
            this.ListView_MemmorySlots.FullRowSelect = true;
            this.ListView_MemmorySlots.GridLines = true;
            this.ListView_MemmorySlots.HideSelection = false;
            this.ListView_MemmorySlots.Location = new System.Drawing.Point(6, 32);
            this.ListView_MemmorySlots.Name = "ListView_MemmorySlots";
            this.ListView_MemmorySlots.Size = new System.Drawing.Size(266, 386);
            this.ListView_MemmorySlots.TabIndex = 10;
            this.ListView_MemmorySlots.UseCompatibleStateImageBehavior = false;
            this.ListView_MemmorySlots.View = System.Windows.Forms.View.Details;
            // 
            // Column_MemmorySlotsCount
            // 
            this.Column_MemmorySlotsCount.Text = "No";
            this.Column_MemmorySlotsCount.Width = 40;
            // 
            // Column_MemmorySlots_MemmorySize
            // 
            this.Column_MemmorySlots_MemmorySize.Text = "Memmory Size";
            this.Column_MemmorySlots_MemmorySize.Width = 100;
            // 
            // Column_MemmorySlots_Quantity
            // 
            this.Column_MemmorySlots_Quantity.Text = "Quantity";
            // 
            // Textbox_MemmorySlotsCount
            // 
            this.Textbox_MemmorySlotsCount.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_MemmorySlotsCount.Location = new System.Drawing.Point(50, 6);
            this.Textbox_MemmorySlotsCount.Name = "Textbox_MemmorySlotsCount";
            this.Textbox_MemmorySlotsCount.ReadOnly = true;
            this.Textbox_MemmorySlotsCount.Size = new System.Drawing.Size(100, 20);
            this.Textbox_MemmorySlotsCount.TabIndex = 9;
            this.Textbox_MemmorySlotsCount.Text = "0";
            // 
            // Label_MemmorySlotsCount
            // 
            this.Label_MemmorySlotsCount.AutoSize = true;
            this.Label_MemmorySlotsCount.Location = new System.Drawing.Point(6, 9);
            this.Label_MemmorySlotsCount.Name = "Label_MemmorySlotsCount";
            this.Label_MemmorySlotsCount.Size = new System.Drawing.Size(38, 13);
            this.Label_MemmorySlotsCount.TabIndex = 0;
            this.Label_MemmorySlotsCount.Text = "Count:";
            // 
            // tabPage_SoundBanks
            // 
            this.tabPage_SoundBanks.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_SoundBanks.Controls.Add(this.ListView_SoundBank);
            this.tabPage_SoundBanks.Controls.Add(this.Textbox_SoundBankCount);
            this.tabPage_SoundBanks.Controls.Add(this.Label_SoundBankCount);
            this.tabPage_SoundBanks.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SoundBanks.Name = "tabPage_SoundBanks";
            this.tabPage_SoundBanks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SoundBanks.Size = new System.Drawing.Size(604, 424);
            this.tabPage_SoundBanks.TabIndex = 1;
            this.tabPage_SoundBanks.Text = "SoundBank";
            // 
            // ListView_SoundBank
            // 
            this.ListView_SoundBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListView_SoundBank.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_SoundBanks_Hashcode,
            this.Col_SoundBanks_SlotNumber});
            this.ListView_SoundBank.FullRowSelect = true;
            this.ListView_SoundBank.GridLines = true;
            this.ListView_SoundBank.HideSelection = false;
            this.ListView_SoundBank.Location = new System.Drawing.Point(6, 32);
            this.ListView_SoundBank.Name = "ListView_SoundBank";
            this.ListView_SoundBank.Size = new System.Drawing.Size(266, 386);
            this.ListView_SoundBank.TabIndex = 13;
            this.ListView_SoundBank.UseCompatibleStateImageBehavior = false;
            this.ListView_SoundBank.View = System.Windows.Forms.View.Details;
            // 
            // Col_SoundBanks_Hashcode
            // 
            this.Col_SoundBanks_Hashcode.Text = "Hashcode";
            this.Col_SoundBanks_Hashcode.Width = 90;
            // 
            // Col_SoundBanks_SlotNumber
            // 
            this.Col_SoundBanks_SlotNumber.Text = "Slot Number";
            this.Col_SoundBanks_SlotNumber.Width = 100;
            // 
            // Textbox_SoundBankCount
            // 
            this.Textbox_SoundBankCount.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_SoundBankCount.Location = new System.Drawing.Point(50, 6);
            this.Textbox_SoundBankCount.Name = "Textbox_SoundBankCount";
            this.Textbox_SoundBankCount.ReadOnly = true;
            this.Textbox_SoundBankCount.Size = new System.Drawing.Size(100, 20);
            this.Textbox_SoundBankCount.TabIndex = 12;
            this.Textbox_SoundBankCount.Text = "0";
            // 
            // Label_SoundBankCount
            // 
            this.Label_SoundBankCount.AutoSize = true;
            this.Label_SoundBankCount.Location = new System.Drawing.Point(6, 9);
            this.Label_SoundBankCount.Name = "Label_SoundBankCount";
            this.Label_SoundBankCount.Size = new System.Drawing.Size(38, 13);
            this.Label_SoundBankCount.TabIndex = 11;
            this.Label_SoundBankCount.Text = "Count:";
            // 
            // tabPage_Musics
            // 
            this.tabPage_Musics.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Musics.Controls.Add(this.ListView_Music);
            this.tabPage_Musics.Controls.Add(this.Textbox_Music_Count);
            this.tabPage_Musics.Controls.Add(this.Label_Music_Count);
            this.tabPage_Musics.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Musics.Name = "tabPage_Musics";
            this.tabPage_Musics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Musics.Size = new System.Drawing.Size(604, 424);
            this.tabPage_Musics.TabIndex = 2;
            this.tabPage_Musics.Text = "Music";
            // 
            // ListView_Music
            // 
            this.ListView_Music.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_Music.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_Music_HashCode,
            this.Col_Music_MaxSeconds,
            this.Col_Music_ForceRestart,
            this.Col_Music_ForceXFade,
            this.Col_Music_Min_FadeUp,
            this.Col_Music_Max_FadeUp,
            this.Col_Music_Min_FadeDown,
            this.Col_Music_Max_FadeDown});
            this.ListView_Music.FullRowSelect = true;
            this.ListView_Music.GridLines = true;
            this.ListView_Music.HideSelection = false;
            this.ListView_Music.Location = new System.Drawing.Point(6, 32);
            this.ListView_Music.Name = "ListView_Music";
            this.ListView_Music.Size = new System.Drawing.Size(592, 386);
            this.ListView_Music.TabIndex = 16;
            this.ListView_Music.UseCompatibleStateImageBehavior = false;
            this.ListView_Music.View = System.Windows.Forms.View.Details;
            // 
            // Col_Music_HashCode
            // 
            this.Col_Music_HashCode.Text = "Hashcode";
            this.Col_Music_HashCode.Width = 70;
            // 
            // Col_Music_MaxSeconds
            // 
            this.Col_Music_MaxSeconds.Text = "Max Seconds";
            this.Col_Music_MaxSeconds.Width = 90;
            // 
            // Col_Music_ForceRestart
            // 
            this.Col_Music_ForceRestart.Text = "Force Restart";
            this.Col_Music_ForceRestart.Width = 90;
            // 
            // Col_Music_ForceXFade
            // 
            this.Col_Music_ForceXFade.Text = "Force XFade";
            this.Col_Music_ForceXFade.Width = 90;
            // 
            // Col_Music_Min_FadeUp
            // 
            this.Col_Music_Min_FadeUp.Text = "Min Fade Up";
            this.Col_Music_Min_FadeUp.Width = 90;
            // 
            // Col_Music_Max_FadeUp
            // 
            this.Col_Music_Max_FadeUp.Text = "Max Fade Up";
            this.Col_Music_Max_FadeUp.Width = 90;
            // 
            // Col_Music_Min_FadeDown
            // 
            this.Col_Music_Min_FadeDown.Text = "Min Fade Down";
            this.Col_Music_Min_FadeDown.Width = 90;
            // 
            // Col_Music_Max_FadeDown
            // 
            this.Col_Music_Max_FadeDown.Text = "Max Fade Down";
            this.Col_Music_Max_FadeDown.Width = 90;
            // 
            // Textbox_Music_Count
            // 
            this.Textbox_Music_Count.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_Music_Count.Location = new System.Drawing.Point(50, 6);
            this.Textbox_Music_Count.Name = "Textbox_Music_Count";
            this.Textbox_Music_Count.ReadOnly = true;
            this.Textbox_Music_Count.Size = new System.Drawing.Size(100, 20);
            this.Textbox_Music_Count.TabIndex = 15;
            this.Textbox_Music_Count.Text = "0";
            // 
            // Label_Music_Count
            // 
            this.Label_Music_Count.AutoSize = true;
            this.Label_Music_Count.Location = new System.Drawing.Point(6, 9);
            this.Label_Music_Count.Name = "Label_Music_Count";
            this.Label_Music_Count.Size = new System.Drawing.Size(38, 13);
            this.Label_Music_Count.TabIndex = 14;
            this.Label_Music_Count.Text = "Count:";
            // 
            // Textbox_StereoStreamCount
            // 
            this.Textbox_StereoStreamCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Textbox_StereoStreamCount.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_StereoStreamCount.Location = new System.Drawing.Point(123, 468);
            this.Textbox_StereoStreamCount.Name = "Textbox_StereoStreamCount";
            this.Textbox_StereoStreamCount.ReadOnly = true;
            this.Textbox_StereoStreamCount.Size = new System.Drawing.Size(100, 20);
            this.Textbox_StereoStreamCount.TabIndex = 2;
            this.Textbox_StereoStreamCount.Text = "0";
            // 
            // Label_StereoStreamCount
            // 
            this.Label_StereoStreamCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_StereoStreamCount.AutoSize = true;
            this.Label_StereoStreamCount.Location = new System.Drawing.Point(12, 471);
            this.Label_StereoStreamCount.Name = "Label_StereoStreamCount";
            this.Label_StereoStreamCount.Size = new System.Drawing.Size(105, 13);
            this.Label_StereoStreamCount.TabIndex = 1;
            this.Label_StereoStreamCount.Text = "Stereo Stream Count";
            // 
            // Textbox_MonoStreamCount
            // 
            this.Textbox_MonoStreamCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Textbox_MonoStreamCount.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_MonoStreamCount.Location = new System.Drawing.Point(123, 494);
            this.Textbox_MonoStreamCount.Name = "Textbox_MonoStreamCount";
            this.Textbox_MonoStreamCount.ReadOnly = true;
            this.Textbox_MonoStreamCount.Size = new System.Drawing.Size(100, 20);
            this.Textbox_MonoStreamCount.TabIndex = 4;
            this.Textbox_MonoStreamCount.Text = "0";
            // 
            // Label_MonoStreamCount
            // 
            this.Label_MonoStreamCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_MonoStreamCount.AutoSize = true;
            this.Label_MonoStreamCount.Location = new System.Drawing.Point(16, 497);
            this.Label_MonoStreamCount.Name = "Label_MonoStreamCount";
            this.Label_MonoStreamCount.Size = new System.Drawing.Size(101, 13);
            this.Label_MonoStreamCount.TabIndex = 3;
            this.Label_MonoStreamCount.Text = "Mono Stream Count";
            // 
            // Textbox_ProjectCode
            // 
            this.Textbox_ProjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Textbox_ProjectCode.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_ProjectCode.Location = new System.Drawing.Point(123, 520);
            this.Textbox_ProjectCode.Name = "Textbox_ProjectCode";
            this.Textbox_ProjectCode.ReadOnly = true;
            this.Textbox_ProjectCode.Size = new System.Drawing.Size(100, 20);
            this.Textbox_ProjectCode.TabIndex = 6;
            this.Textbox_ProjectCode.Text = "0";
            // 
            // Label_ProjectCode
            // 
            this.Label_ProjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_ProjectCode.AutoSize = true;
            this.Label_ProjectCode.Location = new System.Drawing.Point(49, 523);
            this.Label_ProjectCode.Name = "Label_ProjectCode";
            this.Label_ProjectCode.Size = new System.Drawing.Size(68, 13);
            this.Label_ProjectCode.TabIndex = 5;
            this.Label_ProjectCode.Text = "Project Code";
            // 
            // ListView_FlagsValues
            // 
            this.ListView_FlagsValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ListView_FlagsValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_UserFlag,
            this.Col_Value});
            this.ListView_FlagsValues.FullRowSelect = true;
            this.ListView_FlagsValues.GridLines = true;
            this.ListView_FlagsValues.HideSelection = false;
            this.ListView_FlagsValues.Location = new System.Drawing.Point(229, 468);
            this.ListView_FlagsValues.Name = "ListView_FlagsValues";
            this.ListView_FlagsValues.Size = new System.Drawing.Size(209, 183);
            this.ListView_FlagsValues.TabIndex = 7;
            this.ListView_FlagsValues.UseCompatibleStateImageBehavior = false;
            this.ListView_FlagsValues.View = System.Windows.Forms.View.Details;
            // 
            // Col_UserFlag
            // 
            this.Col_UserFlag.Text = "User Flag";
            this.Col_UserFlag.Width = 80;
            // 
            // Col_Value
            // 
            this.Col_Value.Text = "Value";
            this.Col_Value.Width = 100;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_OK.Location = new System.Drawing.Point(549, 611);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 40);
            this.Button_OK.TabIndex = 8;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            // 
            // Frm_ViewProjectFile
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 663);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.ListView_FlagsValues);
            this.Controls.Add(this.Textbox_ProjectCode);
            this.Controls.Add(this.Textbox_StereoStreamCount);
            this.Controls.Add(this.Label_ProjectCode);
            this.Controls.Add(this.Textbox_MonoStreamCount);
            this.Controls.Add(this.Label_MonoStreamCount);
            this.Controls.Add(this.Label_StereoStreamCount);
            this.Controls.Add(this.TabControl_ProjectSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ViewProjectFile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Project File";
            this.Shown += new System.EventHandler(this.Frm_ViewProjectFile_Shown);
            this.TabControl_ProjectSettings.ResumeLayout(false);
            this.tabPage_MemmorySlots.ResumeLayout(false);
            this.tabPage_MemmorySlots.PerformLayout();
            this.tabPage_SoundBanks.ResumeLayout(false);
            this.tabPage_SoundBanks.PerformLayout();
            this.tabPage_Musics.ResumeLayout(false);
            this.tabPage_Musics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl_ProjectSettings;
        private System.Windows.Forms.TabPage tabPage_MemmorySlots;
        private System.Windows.Forms.TabPage tabPage_SoundBanks;
        private System.Windows.Forms.TabPage tabPage_Musics;
        private System.Windows.Forms.Label Label_StereoStreamCount;
        private System.Windows.Forms.TextBox Textbox_StereoStreamCount;
        private System.Windows.Forms.TextBox Textbox_MonoStreamCount;
        private System.Windows.Forms.Label Label_MonoStreamCount;
        private System.Windows.Forms.TextBox Textbox_ProjectCode;
        private System.Windows.Forms.Label Label_ProjectCode;
        private System.Windows.Forms.ListView ListView_FlagsValues;
        private System.Windows.Forms.ColumnHeader Col_UserFlag;
        private System.Windows.Forms.ColumnHeader Col_Value;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.ListView ListView_MemmorySlots;
        private System.Windows.Forms.ColumnHeader Column_MemmorySlotsCount;
        private System.Windows.Forms.ColumnHeader Column_MemmorySlots_MemmorySize;
        private System.Windows.Forms.ColumnHeader Column_MemmorySlots_Quantity;
        private System.Windows.Forms.TextBox Textbox_MemmorySlotsCount;
        private System.Windows.Forms.Label Label_MemmorySlotsCount;
        private System.Windows.Forms.ListView ListView_SoundBank;
        private System.Windows.Forms.ColumnHeader Col_SoundBanks_Hashcode;
        private System.Windows.Forms.ColumnHeader Col_SoundBanks_SlotNumber;
        private System.Windows.Forms.TextBox Textbox_SoundBankCount;
        private System.Windows.Forms.Label Label_SoundBankCount;
        private System.Windows.Forms.ListView ListView_Music;
        private System.Windows.Forms.TextBox Textbox_Music_Count;
        private System.Windows.Forms.Label Label_Music_Count;
        private System.Windows.Forms.ColumnHeader Col_Music_HashCode;
        private System.Windows.Forms.ColumnHeader Col_Music_MaxSeconds;
        private System.Windows.Forms.ColumnHeader Col_Music_ForceRestart;
        private System.Windows.Forms.ColumnHeader Col_Music_ForceXFade;
        private System.Windows.Forms.ColumnHeader Col_Music_Min_FadeUp;
        private System.Windows.Forms.ColumnHeader Col_Music_Max_FadeUp;
        private System.Windows.Forms.ColumnHeader Col_Music_Min_FadeDown;
        private System.Windows.Forms.ColumnHeader Col_Music_Max_FadeDown;
    }
}