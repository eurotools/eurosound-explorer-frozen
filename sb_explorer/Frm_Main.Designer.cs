
namespace sb_explorer
{
    partial class Frm_Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem_File = new System.Windows.Forms.MenuItem();
            this.MenuItem_File_LoadSoundBank = new System.Windows.Forms.MenuItem();
            this.MenuItem_File_ViewMusicFile = new System.Windows.Forms.MenuItem();
            this.MenuItem_File_ViewProjectFile = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_ExtractSoundBank = new System.Windows.Forms.MenuItem();
            this.MenuItem_File_Separator1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_File_SetSoundH = new System.Windows.Forms.MenuItem();
            this.MenuItem_File_Separator2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_File_Exit = new System.Windows.Forms.MenuItem();
            this.MenuItem_View = new System.Windows.Forms.MenuItem();
            this.MenuItem_View_FindHashCode = new System.Windows.Forms.MenuItem();
            this.MenuItem_View_FindNext = new System.Windows.Forms.MenuItem();
            this.MenuItem_About = new System.Windows.Forms.MenuItem();
            this.MenuItem_About_About = new System.Windows.Forms.MenuItem();
            this.MenuItem_About_CheckUpdates = new System.Windows.Forms.MenuItem();
            this.OpenFileDiag_SoundbankFiles = new System.Windows.Forms.OpenFileDialog();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenFileDialog_MusicFiles = new System.Windows.Forms.OpenFileDialog();
            this.OpenFileDiag_ProjectFiles = new System.Windows.Forms.OpenFileDialog();
            this.SplitContainer_HashCodes = new System.Windows.Forms.SplitContainer();
            this.UserControl_Hashcode = new sb_explorer.UserControl_HashCodes();
            this.StatusBar = new System.Windows.Forms.StatusBar();
            this.StatusLabel_HashCode = new System.Windows.Forms.StatusBarPanel();
            this.StatusLabel_Version = new System.Windows.Forms.StatusBarPanel();
            this.StatusLabel_Platform = new System.Windows.Forms.StatusBarPanel();
            this.StatusLabel_SoundhDir = new System.Windows.Forms.StatusBarPanel();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPage_HexView = new System.Windows.Forms.TabPage();
            this.UserControl_HexEditor = new sb_explorer.UserControl_HexEditor();
            this.TabPage_WavHeaderData = new System.Windows.Forms.TabPage();
            this.UserControl_WavHeaderData = new sb_explorer.UserControl_WavHeaderData();
            this.TabPage_StreamData = new System.Windows.Forms.TabPage();
            this.userControl_StreamData1 = new sb_explorer.UserControl_StreamData();
            this.Textbox_HashcodeName = new System.Windows.Forms.TextBox();
            this.UserControl_SampleProperties = new sb_explorer.UserControl_Samples_Properties();
            this.Label_HashCodeName = new System.Windows.Forms.Label();
            this.Textbox_SoundbankName = new System.Windows.Forms.TextBox();
            this.Label_SoundBank_Name = new System.Windows.Forms.Label();
            this.Button_ReloadSoundbank = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_HashCodes)).BeginInit();
            this.SplitContainer_HashCodes.Panel1.SuspendLayout();
            this.SplitContainer_HashCodes.Panel2.SuspendLayout();
            this.SplitContainer_HashCodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_HashCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_Version)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_Platform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_SoundhDir)).BeginInit();
            this.TabControl.SuspendLayout();
            this.TabPage_HexView.SuspendLayout();
            this.TabPage_WavHeaderData.SuspendLayout();
            this.TabPage_StreamData.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_File,
            this.MenuItem_View,
            this.MenuItem_About});
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.Index = 0;
            this.MenuItem_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_File_LoadSoundBank,
            this.MenuItem_File_ViewMusicFile,
            this.MenuItem_File_ViewProjectFile,
            this.menuItem1,
            this.MenuItem_ExtractSoundBank,
            this.MenuItem_File_Separator1,
            this.MenuItem_File_SetSoundH,
            this.MenuItem_File_Separator2,
            this.MenuItem_File_Exit});
            this.MenuItem_File.Text = "File";
            // 
            // MenuItem_File_LoadSoundBank
            // 
            this.MenuItem_File_LoadSoundBank.Index = 0;
            this.MenuItem_File_LoadSoundBank.Text = "Load Soundbank *.sfx";
            this.MenuItem_File_LoadSoundBank.Click += new System.EventHandler(this.MenuItem_File_LoadSoundBank_Click);
            // 
            // MenuItem_File_ViewMusicFile
            // 
            this.MenuItem_File_ViewMusicFile.Index = 1;
            this.MenuItem_File_ViewMusicFile.Text = "View Music File *.sfx";
            this.MenuItem_File_ViewMusicFile.Click += new System.EventHandler(this.MenuItem_File_ViewMusicFile_Click);
            // 
            // MenuItem_File_ViewProjectFile
            // 
            this.MenuItem_File_ViewProjectFile.Index = 2;
            this.MenuItem_File_ViewProjectFile.Text = "View Project File *.sfx";
            this.MenuItem_File_ViewProjectFile.Click += new System.EventHandler(this.MenuItem_File_ViewProjectFile_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // MenuItem_ExtractSoundBank
            // 
            this.MenuItem_ExtractSoundBank.Index = 4;
            this.MenuItem_ExtractSoundBank.Text = "Extract SoundBank";
            this.MenuItem_ExtractSoundBank.Click += new System.EventHandler(this.MenuItem_ExtractSoundBank_Click);
            // 
            // MenuItem_File_Separator1
            // 
            this.MenuItem_File_Separator1.Index = 5;
            this.MenuItem_File_Separator1.Text = "-";
            // 
            // MenuItem_File_SetSoundH
            // 
            this.MenuItem_File_SetSoundH.Index = 6;
            this.MenuItem_File_SetSoundH.Text = "Set Sound.h Directory";
            this.MenuItem_File_SetSoundH.Click += new System.EventHandler(this.MenuItem_File_SetSoundH_Click);
            // 
            // MenuItem_File_Separator2
            // 
            this.MenuItem_File_Separator2.Index = 7;
            this.MenuItem_File_Separator2.Text = "-";
            // 
            // MenuItem_File_Exit
            // 
            this.MenuItem_File_Exit.Index = 8;
            this.MenuItem_File_Exit.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
            this.MenuItem_File_Exit.Text = "Exit";
            this.MenuItem_File_Exit.Click += new System.EventHandler(this.MenuItem_File_Exit_Click);
            // 
            // MenuItem_View
            // 
            this.MenuItem_View.Index = 1;
            this.MenuItem_View.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_View_FindHashCode,
            this.MenuItem_View_FindNext});
            this.MenuItem_View.Text = "View";
            // 
            // MenuItem_View_FindHashCode
            // 
            this.MenuItem_View_FindHashCode.Enabled = false;
            this.MenuItem_View_FindHashCode.Index = 0;
            this.MenuItem_View_FindHashCode.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.MenuItem_View_FindHashCode.Text = "Find Hashcode";
            this.MenuItem_View_FindHashCode.Click += new System.EventHandler(this.MenuItem_View_FindHashCode_Click);
            // 
            // MenuItem_View_FindNext
            // 
            this.MenuItem_View_FindNext.Enabled = false;
            this.MenuItem_View_FindNext.Index = 1;
            this.MenuItem_View_FindNext.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.MenuItem_View_FindNext.Text = "Find Next";
            this.MenuItem_View_FindNext.Click += new System.EventHandler(this.MenuItem_View_FindNext_Click);
            // 
            // MenuItem_About
            // 
            this.MenuItem_About.Index = 2;
            this.MenuItem_About.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_About_About,
            this.MenuItem_About_CheckUpdates});
            this.MenuItem_About.Text = "Help";
            // 
            // MenuItem_About_About
            // 
            this.MenuItem_About_About.Index = 0;
            this.MenuItem_About_About.Text = "About";
            this.MenuItem_About_About.Click += new System.EventHandler(this.MenuItem_About_About_Click);
            // 
            // MenuItem_About_CheckUpdates
            // 
            this.MenuItem_About_CheckUpdates.Index = 1;
            this.MenuItem_About_CheckUpdates.Text = "Check for updates";
            this.MenuItem_About_CheckUpdates.Click += new System.EventHandler(this.MenuItem_About_CheckUpdates_Click);
            // 
            // OpenFileDiag_SoundbankFiles
            // 
            this.OpenFileDiag_SoundbankFiles.Filter = "SFX Files (???_SB_*.sfx)|???_SB_*.sfx|SFX Files (HC0?00??.sfx)|HC0?00??.sfx|All F" +
    "iles (*.*)|*.*";
            this.OpenFileDiag_SoundbankFiles.FilterIndex = 0;
            // 
            // OpenFileDialog_MusicFiles
            // 
            this.OpenFileDialog_MusicFiles.Filter = "MUS Files (_MUS_*.sfx)|_MUS_*.sfx|MUS Files (HCE??0??.sfx)|HCE??0??.sfx|All Files" +
    " (*.*)|*.*";
            this.OpenFileDialog_MusicFiles.FilterIndex = 0;
            // 
            // OpenFileDiag_ProjectFiles
            // 
            this.OpenFileDiag_ProjectFiles.Filter = "Project Files (__projectdetails.sfx)|__projectdetails.sfx|All Files (*.*)|*.*";
            this.OpenFileDiag_ProjectFiles.FilterIndex = 0;
            // 
            // SplitContainer_HashCodes
            // 
            this.SplitContainer_HashCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_HashCodes.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_HashCodes.Name = "SplitContainer_HashCodes";
            // 
            // SplitContainer_HashCodes.Panel1
            // 
            this.SplitContainer_HashCodes.Panel1.Controls.Add(this.UserControl_Hashcode);
            // 
            // SplitContainer_HashCodes.Panel2
            // 
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.StatusBar);
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.TabControl);
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.Textbox_HashcodeName);
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.UserControl_SampleProperties);
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.Label_HashCodeName);
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.Textbox_SoundbankName);
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.Label_SoundBank_Name);
            this.SplitContainer_HashCodes.Panel2.Controls.Add(this.Button_ReloadSoundbank);
            this.SplitContainer_HashCodes.Size = new System.Drawing.Size(1166, 869);
            this.SplitContainer_HashCodes.SplitterDistance = 210;
            this.SplitContainer_HashCodes.TabIndex = 0;
            // 
            // UserControl_Hashcode
            // 
            this.UserControl_Hashcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl_Hashcode.Location = new System.Drawing.Point(0, 0);
            this.UserControl_Hashcode.Name = "UserControl_Hashcode";
            this.UserControl_Hashcode.Size = new System.Drawing.Size(210, 869);
            this.UserControl_Hashcode.TabIndex = 0;
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 847);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.StatusLabel_HashCode,
            this.StatusLabel_Version,
            this.StatusLabel_Platform,
            this.StatusLabel_SoundhDir});
            this.StatusBar.ShowPanels = true;
            this.StatusBar.Size = new System.Drawing.Size(952, 22);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "statusBar1";
            // 
            // StatusLabel_HashCode
            // 
            this.StatusLabel_HashCode.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
            this.StatusLabel_HashCode.Name = "StatusLabel_HashCode";
            this.StatusLabel_HashCode.Text = "HashCode:";
            this.StatusLabel_HashCode.Width = 200;
            // 
            // StatusLabel_Version
            // 
            this.StatusLabel_Version.Name = "StatusLabel_Version";
            this.StatusLabel_Version.Text = "Version:";
            this.StatusLabel_Version.Width = 99;
            // 
            // StatusLabel_Platform
            // 
            this.StatusLabel_Platform.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
            this.StatusLabel_Platform.Name = "StatusLabel_Platform";
            this.StatusLabel_Platform.Text = "Platform:";
            this.StatusLabel_Platform.Width = 99;
            // 
            // StatusLabel_SoundhDir
            // 
            this.StatusLabel_SoundhDir.Name = "StatusLabel_SoundhDir";
            this.StatusLabel_SoundhDir.Text = "Sound.h Dir:";
            this.StatusLabel_SoundhDir.Width = 250;
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.TabPage_HexView);
            this.TabControl.Controls.Add(this.TabPage_WavHeaderData);
            this.TabControl.Controls.Add(this.TabPage_StreamData);
            this.TabControl.Location = new System.Drawing.Point(554, 3);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(395, 803);
            this.TabControl.TabIndex = 7;
            // 
            // TabPage_HexView
            // 
            this.TabPage_HexView.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage_HexView.Controls.Add(this.UserControl_HexEditor);
            this.TabPage_HexView.Location = new System.Drawing.Point(4, 22);
            this.TabPage_HexView.Name = "TabPage_HexView";
            this.TabPage_HexView.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_HexView.Size = new System.Drawing.Size(387, 777);
            this.TabPage_HexView.TabIndex = 0;
            this.TabPage_HexView.Text = "Hex View";
            // 
            // UserControl_HexEditor
            // 
            this.UserControl_HexEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl_HexEditor.Location = new System.Drawing.Point(3, 3);
            this.UserControl_HexEditor.Name = "UserControl_HexEditor";
            this.UserControl_HexEditor.Size = new System.Drawing.Size(381, 771);
            this.UserControl_HexEditor.TabIndex = 0;
            // 
            // TabPage_WavHeaderData
            // 
            this.TabPage_WavHeaderData.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage_WavHeaderData.Controls.Add(this.UserControl_WavHeaderData);
            this.TabPage_WavHeaderData.Location = new System.Drawing.Point(4, 22);
            this.TabPage_WavHeaderData.Name = "TabPage_WavHeaderData";
            this.TabPage_WavHeaderData.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_WavHeaderData.Size = new System.Drawing.Size(387, 777);
            this.TabPage_WavHeaderData.TabIndex = 1;
            this.TabPage_WavHeaderData.Text = "Wav Header Data";
            // 
            // UserControl_WavHeaderData
            // 
            this.UserControl_WavHeaderData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserControl_WavHeaderData.Location = new System.Drawing.Point(6, 6);
            this.UserControl_WavHeaderData.Name = "UserControl_WavHeaderData";
            this.UserControl_WavHeaderData.Size = new System.Drawing.Size(375, 718);
            this.UserControl_WavHeaderData.TabIndex = 0;
            // 
            // TabPage_StreamData
            // 
            this.TabPage_StreamData.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage_StreamData.Controls.Add(this.userControl_StreamData1);
            this.TabPage_StreamData.Location = new System.Drawing.Point(4, 22);
            this.TabPage_StreamData.Name = "TabPage_StreamData";
            this.TabPage_StreamData.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_StreamData.Size = new System.Drawing.Size(387, 777);
            this.TabPage_StreamData.TabIndex = 2;
            this.TabPage_StreamData.Text = "Stream Data";
            // 
            // userControl_StreamData1
            // 
            this.userControl_StreamData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_StreamData1.Location = new System.Drawing.Point(3, 3);
            this.userControl_StreamData1.Name = "userControl_StreamData1";
            this.userControl_StreamData1.Size = new System.Drawing.Size(381, 771);
            this.userControl_StreamData1.TabIndex = 0;
            // 
            // Textbox_HashcodeName
            // 
            this.Textbox_HashcodeName.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_HashcodeName.Location = new System.Drawing.Point(11, 55);
            this.Textbox_HashcodeName.Name = "Textbox_HashcodeName";
            this.Textbox_HashcodeName.ReadOnly = true;
            this.Textbox_HashcodeName.Size = new System.Drawing.Size(537, 20);
            this.Textbox_HashcodeName.TabIndex = 4;
            // 
            // UserControl_SampleProperties
            // 
            this.UserControl_SampleProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UserControl_SampleProperties.Location = new System.Drawing.Point(3, 81);
            this.UserControl_SampleProperties.Name = "UserControl_SampleProperties";
            this.UserControl_SampleProperties.Size = new System.Drawing.Size(545, 658);
            this.UserControl_SampleProperties.TabIndex = 5;
            // 
            // Label_HashCodeName
            // 
            this.Label_HashCodeName.AutoSize = true;
            this.Label_HashCodeName.Location = new System.Drawing.Point(8, 39);
            this.Label_HashCodeName.Name = "Label_HashCodeName";
            this.Label_HashCodeName.Size = new System.Drawing.Size(87, 13);
            this.Label_HashCodeName.TabIndex = 3;
            this.Label_HashCodeName.Text = "Hashcode Name";
            // 
            // Textbox_SoundbankName
            // 
            this.Textbox_SoundbankName.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_SoundbankName.Location = new System.Drawing.Point(11, 16);
            this.Textbox_SoundbankName.Name = "Textbox_SoundbankName";
            this.Textbox_SoundbankName.ReadOnly = true;
            this.Textbox_SoundbankName.Size = new System.Drawing.Size(537, 20);
            this.Textbox_SoundbankName.TabIndex = 2;
            // 
            // Label_SoundBank_Name
            // 
            this.Label_SoundBank_Name.AutoSize = true;
            this.Label_SoundBank_Name.Location = new System.Drawing.Point(8, 0);
            this.Label_SoundBank_Name.Name = "Label_SoundBank_Name";
            this.Label_SoundBank_Name.Size = new System.Drawing.Size(104, 13);
            this.Label_SoundBank_Name.TabIndex = 1;
            this.Label_SoundBank_Name.Text = "Soundbank filename";
            // 
            // Button_ReloadSoundbank
            // 
            this.Button_ReloadSoundbank.Location = new System.Drawing.Point(11, 745);
            this.Button_ReloadSoundbank.Name = "Button_ReloadSoundbank";
            this.Button_ReloadSoundbank.Size = new System.Drawing.Size(112, 32);
            this.Button_ReloadSoundbank.TabIndex = 6;
            this.Button_ReloadSoundbank.Text = "Reload";
            this.Button_ReloadSoundbank.UseVisualStyleBackColor = true;
            this.Button_ReloadSoundbank.Click += new System.EventHandler(this.Button_ReloadSoundbank_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 869);
            this.Controls.Add(this.SplitContainer_HashCodes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MainMenu;
            this.Name = "Frm_Main";
            this.Text = "Eurosound Soundbank Explorer";
            this.SplitContainer_HashCodes.Panel1.ResumeLayout(false);
            this.SplitContainer_HashCodes.Panel2.ResumeLayout(false);
            this.SplitContainer_HashCodes.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_HashCodes)).EndInit();
            this.SplitContainer_HashCodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_HashCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_Version)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_Platform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusLabel_SoundhDir)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.TabPage_HexView.ResumeLayout(false);
            this.TabPage_WavHeaderData.ResumeLayout(false);
            this.TabPage_StreamData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem MenuItem_File;
        private System.Windows.Forms.MenuItem MenuItem_View;
        private System.Windows.Forms.MenuItem MenuItem_About;
        private System.Windows.Forms.SplitContainer SplitContainer_HashCodes;
        private System.Windows.Forms.StatusBar StatusBar;
        protected internal System.Windows.Forms.StatusBarPanel StatusLabel_HashCode;
        protected internal System.Windows.Forms.StatusBarPanel StatusLabel_Version;
        protected internal System.Windows.Forms.StatusBarPanel StatusLabel_Platform;
        protected internal System.Windows.Forms.StatusBarPanel StatusLabel_SoundhDir;
        private System.Windows.Forms.Label Label_SoundBank_Name;
        private System.Windows.Forms.Label Label_HashCodeName;
        private System.Windows.Forms.TextBox Textbox_SoundbankName;
        private System.Windows.Forms.Button Button_ReloadSoundbank;
        private System.Windows.Forms.MenuItem MenuItem_File_LoadSoundBank;
        private System.Windows.Forms.MenuItem MenuItem_File_ViewMusicFile;
        private System.Windows.Forms.MenuItem MenuItem_File_ViewProjectFile;
        private System.Windows.Forms.MenuItem MenuItem_File_Separator1;
        private System.Windows.Forms.MenuItem MenuItem_File_SetSoundH;
        private System.Windows.Forms.MenuItem MenuItem_File_Separator2;
        private System.Windows.Forms.MenuItem MenuItem_File_Exit;
        private System.Windows.Forms.MenuItem MenuItem_View_FindHashCode;
        private System.Windows.Forms.MenuItem MenuItem_View_FindNext;
        private System.Windows.Forms.MenuItem MenuItem_About_About;
        private System.Windows.Forms.TabPage TabPage_HexView;
        private System.Windows.Forms.OpenFileDialog OpenFileDiag_SoundbankFiles;
        protected internal UserControl_Samples_Properties UserControl_SampleProperties;
        protected internal UserControl_StreamData userControl_StreamData1;
        protected internal UserControl_WavHeaderData UserControl_WavHeaderData;
        protected internal UserControl_HashCodes UserControl_Hashcode;
        protected internal System.Windows.Forms.TextBox Textbox_HashcodeName;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        protected internal UserControl_HexEditor UserControl_HexEditor;
        protected internal System.Windows.Forms.TabControl TabControl;
        protected internal System.Windows.Forms.TabPage TabPage_WavHeaderData;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_MusicFiles;
        private System.Windows.Forms.OpenFileDialog OpenFileDiag_ProjectFiles;
        protected internal System.Windows.Forms.TabPage TabPage_StreamData;
        private System.Windows.Forms.MenuItem MenuItem_About_CheckUpdates;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem MenuItem_ExtractSoundBank;
    }
}

