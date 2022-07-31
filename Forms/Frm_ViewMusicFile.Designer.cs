
namespace sb_explorer
{
    partial class Frm_ViewMusicFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ViewMusicFile));
            this.Label_BaseVolume = new System.Windows.Forms.Label();
            this.Textbox_BaseVolume = new System.Windows.Forms.TextBox();
            this.Label_MusicLength = new System.Windows.Forms.Label();
            this.Textbox_MusicLength = new System.Windows.Forms.TextBox();
            this.TabControl_MusicData = new System.Windows.Forms.TabControl();
            this.TabPage_StartMarkers = new System.Windows.Forms.TabPage();
            this.ListView_StreamData_StartMarkers = new System.Windows.Forms.ListView();
            this.StreamData_StartMarkers_No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_StartMarkers_Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_StartMarkers_Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_StartMarkers_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_StartMarkers_LoopStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_StartMarkers_LoopMarkerIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_StartMarkers_MarkerPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Textbox_StartMarkers_Count = new System.Windows.Forms.TextBox();
            this.Label_StartMarkers_Count = new System.Windows.Forms.Label();
            this.TabPage_Markers = new System.Windows.Forms.TabPage();
            this.ListView_StreamData_Markers = new System.Windows.Forms.ListView();
            this.StreamData_Markers_No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_Markers_StartMarkerIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_Markers_Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_Markers_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_Markers_LoopStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_Markers_LoopMarkerIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label_StreamData_MarkerCount = new System.Windows.Forms.Label();
            this.Textbox_MarkersCount = new System.Windows.Forms.TextBox();
            this.Label_FilePath = new System.Windows.Forms.Label();
            this.Textbox_FilePath = new System.Windows.Forms.TextBox();
            this.Label_ADPCM_Status = new System.Windows.Forms.Label();
            this.Textbox_AdpcmStatus = new System.Windows.Forms.TextBox();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_MediaPlayer = new System.Windows.Forms.Button();
            this.TabControl_MusicData.SuspendLayout();
            this.TabPage_StartMarkers.SuspendLayout();
            this.TabPage_Markers.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_BaseVolume
            // 
            this.Label_BaseVolume.AutoSize = true;
            this.Label_BaseVolume.Location = new System.Drawing.Point(12, 9);
            this.Label_BaseVolume.Name = "Label_BaseVolume";
            this.Label_BaseVolume.Size = new System.Drawing.Size(69, 13);
            this.Label_BaseVolume.TabIndex = 0;
            this.Label_BaseVolume.Text = "Base Volume";
            // 
            // Textbox_BaseVolume
            // 
            this.Textbox_BaseVolume.Location = new System.Drawing.Point(87, 6);
            this.Textbox_BaseVolume.Name = "Textbox_BaseVolume";
            this.Textbox_BaseVolume.Size = new System.Drawing.Size(100, 20);
            this.Textbox_BaseVolume.TabIndex = 1;
            // 
            // Label_MusicLength
            // 
            this.Label_MusicLength.AutoSize = true;
            this.Label_MusicLength.Location = new System.Drawing.Point(193, 9);
            this.Label_MusicLength.Name = "Label_MusicLength";
            this.Label_MusicLength.Size = new System.Drawing.Size(71, 13);
            this.Label_MusicLength.TabIndex = 2;
            this.Label_MusicLength.Text = "Music Length";
            // 
            // Textbox_MusicLength
            // 
            this.Textbox_MusicLength.Location = new System.Drawing.Point(270, 6);
            this.Textbox_MusicLength.Name = "Textbox_MusicLength";
            this.Textbox_MusicLength.Size = new System.Drawing.Size(100, 20);
            this.Textbox_MusicLength.TabIndex = 3;
            // 
            // TabControl_MusicData
            // 
            this.TabControl_MusicData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_MusicData.Controls.Add(this.TabPage_StartMarkers);
            this.TabControl_MusicData.Controls.Add(this.TabPage_Markers);
            this.TabControl_MusicData.Location = new System.Drawing.Point(8, 32);
            this.TabControl_MusicData.Name = "TabControl_MusicData";
            this.TabControl_MusicData.SelectedIndex = 0;
            this.TabControl_MusicData.Size = new System.Drawing.Size(536, 616);
            this.TabControl_MusicData.TabIndex = 5;
            // 
            // TabPage_StartMarkers
            // 
            this.TabPage_StartMarkers.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage_StartMarkers.Controls.Add(this.ListView_StreamData_StartMarkers);
            this.TabPage_StartMarkers.Controls.Add(this.Textbox_StartMarkers_Count);
            this.TabPage_StartMarkers.Controls.Add(this.Label_StartMarkers_Count);
            this.TabPage_StartMarkers.Location = new System.Drawing.Point(4, 22);
            this.TabPage_StartMarkers.Name = "TabPage_StartMarkers";
            this.TabPage_StartMarkers.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_StartMarkers.Size = new System.Drawing.Size(528, 590);
            this.TabPage_StartMarkers.TabIndex = 0;
            this.TabPage_StartMarkers.Text = "Start Markers";
            // 
            // ListView_StreamData_StartMarkers
            // 
            this.ListView_StreamData_StartMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_StreamData_StartMarkers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StreamData_StartMarkers_No,
            this.StreamData_StartMarkers_Index,
            this.StreamData_StartMarkers_Position,
            this.StreamData_StartMarkers_Type,
            this.StreamData_StartMarkers_LoopStart,
            this.StreamData_StartMarkers_LoopMarkerIndex,
            this.StreamData_StartMarkers_MarkerPosition});
            this.ListView_StreamData_StartMarkers.FullRowSelect = true;
            this.ListView_StreamData_StartMarkers.GridLines = true;
            this.ListView_StreamData_StartMarkers.HideSelection = false;
            this.ListView_StreamData_StartMarkers.Location = new System.Drawing.Point(6, 32);
            this.ListView_StreamData_StartMarkers.Name = "ListView_StreamData_StartMarkers";
            this.ListView_StreamData_StartMarkers.Size = new System.Drawing.Size(516, 552);
            this.ListView_StreamData_StartMarkers.TabIndex = 6;
            this.ListView_StreamData_StartMarkers.UseCompatibleStateImageBehavior = false;
            this.ListView_StreamData_StartMarkers.View = System.Windows.Forms.View.Details;
            // 
            // StreamData_StartMarkers_No
            // 
            this.StreamData_StartMarkers_No.Text = "No.";
            this.StreamData_StartMarkers_No.Width = 30;
            // 
            // StreamData_StartMarkers_Index
            // 
            this.StreamData_StartMarkers_Index.Text = "Index";
            // 
            // StreamData_StartMarkers_Position
            // 
            this.StreamData_StartMarkers_Position.Text = "Position";
            // 
            // StreamData_StartMarkers_Type
            // 
            this.StreamData_StartMarkers_Type.Text = "Type";
            // 
            // StreamData_StartMarkers_LoopStart
            // 
            this.StreamData_StartMarkers_LoopStart.Text = "Loop Start";
            this.StreamData_StartMarkers_LoopStart.Width = 80;
            // 
            // StreamData_StartMarkers_LoopMarkerIndex
            // 
            this.StreamData_StartMarkers_LoopMarkerIndex.Text = "Loop Marker Index";
            this.StreamData_StartMarkers_LoopMarkerIndex.Width = 120;
            // 
            // StreamData_StartMarkers_MarkerPosition
            // 
            this.StreamData_StartMarkers_MarkerPosition.Text = "Marker Position";
            this.StreamData_StartMarkers_MarkerPosition.Width = 98;
            // 
            // Textbox_StartMarkers_Count
            // 
            this.Textbox_StartMarkers_Count.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_StartMarkers_Count.Location = new System.Drawing.Point(83, 6);
            this.Textbox_StartMarkers_Count.Name = "Textbox_StartMarkers_Count";
            this.Textbox_StartMarkers_Count.ReadOnly = true;
            this.Textbox_StartMarkers_Count.Size = new System.Drawing.Size(100, 20);
            this.Textbox_StartMarkers_Count.TabIndex = 5;
            // 
            // Label_StartMarkers_Count
            // 
            this.Label_StartMarkers_Count.AutoSize = true;
            this.Label_StartMarkers_Count.Location = new System.Drawing.Point(6, 9);
            this.Label_StartMarkers_Count.Name = "Label_StartMarkers_Count";
            this.Label_StartMarkers_Count.Size = new System.Drawing.Size(71, 13);
            this.Label_StartMarkers_Count.TabIndex = 4;
            this.Label_StartMarkers_Count.Text = "Marker Count";
            // 
            // TabPage_Markers
            // 
            this.TabPage_Markers.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage_Markers.Controls.Add(this.ListView_StreamData_Markers);
            this.TabPage_Markers.Controls.Add(this.Label_StreamData_MarkerCount);
            this.TabPage_Markers.Controls.Add(this.Textbox_MarkersCount);
            this.TabPage_Markers.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Markers.Name = "TabPage_Markers";
            this.TabPage_Markers.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Markers.Size = new System.Drawing.Size(528, 590);
            this.TabPage_Markers.TabIndex = 1;
            this.TabPage_Markers.Text = "Markers";
            // 
            // ListView_StreamData_Markers
            // 
            this.ListView_StreamData_Markers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_StreamData_Markers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StreamData_Markers_No,
            this.StreamData_Markers_StartMarkerIndex,
            this.StreamData_Markers_Position,
            this.StreamData_Markers_Type,
            this.StreamData_Markers_LoopStart,
            this.StreamData_Markers_LoopMarkerIndex});
            this.ListView_StreamData_Markers.FullRowSelect = true;
            this.ListView_StreamData_Markers.GridLines = true;
            this.ListView_StreamData_Markers.HideSelection = false;
            this.ListView_StreamData_Markers.Location = new System.Drawing.Point(6, 32);
            this.ListView_StreamData_Markers.Name = "ListView_StreamData_Markers";
            this.ListView_StreamData_Markers.Size = new System.Drawing.Size(516, 552);
            this.ListView_StreamData_Markers.TabIndex = 8;
            this.ListView_StreamData_Markers.UseCompatibleStateImageBehavior = false;
            this.ListView_StreamData_Markers.View = System.Windows.Forms.View.Details;
            // 
            // StreamData_Markers_No
            // 
            this.StreamData_Markers_No.Text = "No.";
            this.StreamData_Markers_No.Width = 30;
            // 
            // StreamData_Markers_StartMarkerIndex
            // 
            this.StreamData_Markers_StartMarkerIndex.Text = "Start Marker Index";
            this.StreamData_Markers_StartMarkerIndex.Width = 103;
            // 
            // StreamData_Markers_Position
            // 
            this.StreamData_Markers_Position.Text = "Position";
            // 
            // StreamData_Markers_Type
            // 
            this.StreamData_Markers_Type.Text = "Type";
            // 
            // StreamData_Markers_LoopStart
            // 
            this.StreamData_Markers_LoopStart.Text = "Loop Start";
            this.StreamData_Markers_LoopStart.Width = 80;
            // 
            // StreamData_Markers_LoopMarkerIndex
            // 
            this.StreamData_Markers_LoopMarkerIndex.Text = "Loop Marker Index";
            this.StreamData_Markers_LoopMarkerIndex.Width = 120;
            // 
            // Label_StreamData_MarkerCount
            // 
            this.Label_StreamData_MarkerCount.AutoSize = true;
            this.Label_StreamData_MarkerCount.Location = new System.Drawing.Point(6, 9);
            this.Label_StreamData_MarkerCount.Name = "Label_StreamData_MarkerCount";
            this.Label_StreamData_MarkerCount.Size = new System.Drawing.Size(71, 13);
            this.Label_StreamData_MarkerCount.TabIndex = 6;
            this.Label_StreamData_MarkerCount.Text = "Marker Count";
            // 
            // Textbox_MarkersCount
            // 
            this.Textbox_MarkersCount.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_MarkersCount.Location = new System.Drawing.Point(83, 6);
            this.Textbox_MarkersCount.Name = "Textbox_MarkersCount";
            this.Textbox_MarkersCount.ReadOnly = true;
            this.Textbox_MarkersCount.Size = new System.Drawing.Size(100, 20);
            this.Textbox_MarkersCount.TabIndex = 7;
            // 
            // Label_FilePath
            // 
            this.Label_FilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_FilePath.AutoSize = true;
            this.Label_FilePath.Location = new System.Drawing.Point(12, 659);
            this.Label_FilePath.Name = "Label_FilePath";
            this.Label_FilePath.Size = new System.Drawing.Size(26, 13);
            this.Label_FilePath.TabIndex = 6;
            this.Label_FilePath.Text = "File:";
            // 
            // Textbox_FilePath
            // 
            this.Textbox_FilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_FilePath.Location = new System.Drawing.Point(44, 656);
            this.Textbox_FilePath.Name = "Textbox_FilePath";
            this.Textbox_FilePath.Size = new System.Drawing.Size(500, 20);
            this.Textbox_FilePath.TabIndex = 7;
            // 
            // Label_ADPCM_Status
            // 
            this.Label_ADPCM_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_ADPCM_Status.AutoSize = true;
            this.Label_ADPCM_Status.Location = new System.Drawing.Point(12, 690);
            this.Label_ADPCM_Status.Name = "Label_ADPCM_Status";
            this.Label_ADPCM_Status.Size = new System.Drawing.Size(81, 13);
            this.Label_ADPCM_Status.TabIndex = 8;
            this.Label_ADPCM_Status.Text = "ADPCM Status:";
            // 
            // Textbox_AdpcmStatus
            // 
            this.Textbox_AdpcmStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_AdpcmStatus.Location = new System.Drawing.Point(99, 688);
            this.Textbox_AdpcmStatus.Name = "Textbox_AdpcmStatus";
            this.Textbox_AdpcmStatus.Size = new System.Drawing.Size(359, 20);
            this.Textbox_AdpcmStatus.TabIndex = 9;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_OK.Location = new System.Drawing.Point(464, 680);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(80, 32);
            this.Button_OK.TabIndex = 10;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            // 
            // Button_MediaPlayer
            // 
            this.Button_MediaPlayer.Location = new System.Drawing.Point(376, 5);
            this.Button_MediaPlayer.Name = "Button_MediaPlayer";
            this.Button_MediaPlayer.Size = new System.Drawing.Size(85, 20);
            this.Button_MediaPlayer.TabIndex = 4;
            this.Button_MediaPlayer.Text = "Media Player";
            this.Button_MediaPlayer.UseVisualStyleBackColor = true;
            this.Button_MediaPlayer.Click += new System.EventHandler(this.Button_MediaPlayer_Click);
            // 
            // Frm_ViewMusicFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 719);
            this.Controls.Add(this.Button_MediaPlayer);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Textbox_AdpcmStatus);
            this.Controls.Add(this.Label_ADPCM_Status);
            this.Controls.Add(this.Textbox_FilePath);
            this.Controls.Add(this.Label_FilePath);
            this.Controls.Add(this.TabControl_MusicData);
            this.Controls.Add(this.Textbox_MusicLength);
            this.Controls.Add(this.Label_MusicLength);
            this.Controls.Add(this.Textbox_BaseVolume);
            this.Controls.Add(this.Label_BaseVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ViewMusicFile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Music";
            this.Shown += new System.EventHandler(this.Frm_ViewMusicFile_Shown);
            this.TabControl_MusicData.ResumeLayout(false);
            this.TabPage_StartMarkers.ResumeLayout(false);
            this.TabPage_StartMarkers.PerformLayout();
            this.TabPage_Markers.ResumeLayout(false);
            this.TabPage_Markers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_BaseVolume;
        private System.Windows.Forms.TextBox Textbox_BaseVolume;
        private System.Windows.Forms.Label Label_MusicLength;
        private System.Windows.Forms.TextBox Textbox_MusicLength;
        private System.Windows.Forms.TabControl TabControl_MusicData;
        private System.Windows.Forms.TabPage TabPage_StartMarkers;
        private System.Windows.Forms.TabPage TabPage_Markers;
        private System.Windows.Forms.Label Label_FilePath;
        private System.Windows.Forms.TextBox Textbox_FilePath;
        private System.Windows.Forms.Label Label_ADPCM_Status;
        private System.Windows.Forms.TextBox Textbox_AdpcmStatus;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_MediaPlayer;
        private System.Windows.Forms.ListView ListView_StreamData_StartMarkers;
        private System.Windows.Forms.ColumnHeader StreamData_StartMarkers_No;
        private System.Windows.Forms.ColumnHeader StreamData_StartMarkers_Index;
        private System.Windows.Forms.ColumnHeader StreamData_StartMarkers_Position;
        private System.Windows.Forms.ColumnHeader StreamData_StartMarkers_Type;
        private System.Windows.Forms.ColumnHeader StreamData_StartMarkers_LoopStart;
        private System.Windows.Forms.ColumnHeader StreamData_StartMarkers_LoopMarkerIndex;
        private System.Windows.Forms.ColumnHeader StreamData_StartMarkers_MarkerPosition;
        private System.Windows.Forms.TextBox Textbox_StartMarkers_Count;
        private System.Windows.Forms.Label Label_StartMarkers_Count;
        private System.Windows.Forms.ListView ListView_StreamData_Markers;
        private System.Windows.Forms.ColumnHeader StreamData_Markers_No;
        private System.Windows.Forms.ColumnHeader StreamData_Markers_StartMarkerIndex;
        private System.Windows.Forms.ColumnHeader StreamData_Markers_Position;
        private System.Windows.Forms.ColumnHeader StreamData_Markers_Type;
        private System.Windows.Forms.ColumnHeader StreamData_Markers_LoopStart;
        private System.Windows.Forms.ColumnHeader StreamData_Markers_LoopMarkerIndex;
        private System.Windows.Forms.Label Label_StreamData_MarkerCount;
        private System.Windows.Forms.TextBox Textbox_MarkersCount;
    }
}