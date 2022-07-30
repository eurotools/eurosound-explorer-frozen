
namespace sb_explorer
{
    partial class UserControl_StreamData
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl_Markers = new System.Windows.Forms.TabControl();
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
            this.Button_ValidateADPCM = new System.Windows.Forms.Button();
            this.Textbox_StreamFilePath = new System.Windows.Forms.TextBox();
            this.Button_LoadStreamData = new System.Windows.Forms.Button();
            this.OpenFileDialog_StreamData = new System.Windows.Forms.OpenFileDialog();
            this.ListView_StreamData = new sb_explorer.ListView_ColumnSortingClick();
            this.StreamData_Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_AdpcmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_MarkerOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_MarkerSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_AudioOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_AudioLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StreamData_BaseVolume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabControl_Markers.SuspendLayout();
            this.TabPage_StartMarkers.SuspendLayout();
            this.TabPage_Markers.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl_Markers
            // 
            this.TabControl_Markers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_Markers.Controls.Add(this.TabPage_StartMarkers);
            this.TabControl_Markers.Controls.Add(this.TabPage_Markers);
            this.TabControl_Markers.Location = new System.Drawing.Point(3, 341);
            this.TabControl_Markers.Name = "TabControl_Markers";
            this.TabControl_Markers.SelectedIndex = 0;
            this.TabControl_Markers.Size = new System.Drawing.Size(407, 231);
            this.TabControl_Markers.TabIndex = 1;
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
            this.TabPage_StartMarkers.Size = new System.Drawing.Size(399, 205);
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
            this.ListView_StreamData_StartMarkers.Location = new System.Drawing.Point(3, 32);
            this.ListView_StreamData_StartMarkers.Name = "ListView_StreamData_StartMarkers";
            this.ListView_StreamData_StartMarkers.Size = new System.Drawing.Size(393, 170);
            this.ListView_StreamData_StartMarkers.TabIndex = 3;
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
            this.Textbox_StartMarkers_Count.TabIndex = 1;
            // 
            // Label_StartMarkers_Count
            // 
            this.Label_StartMarkers_Count.AutoSize = true;
            this.Label_StartMarkers_Count.Location = new System.Drawing.Point(6, 9);
            this.Label_StartMarkers_Count.Name = "Label_StartMarkers_Count";
            this.Label_StartMarkers_Count.Size = new System.Drawing.Size(71, 13);
            this.Label_StartMarkers_Count.TabIndex = 0;
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
            this.TabPage_Markers.Size = new System.Drawing.Size(399, 205);
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
            this.ListView_StreamData_Markers.Location = new System.Drawing.Point(3, 32);
            this.ListView_StreamData_Markers.Name = "ListView_StreamData_Markers";
            this.ListView_StreamData_Markers.Size = new System.Drawing.Size(393, 201);
            this.ListView_StreamData_Markers.TabIndex = 5;
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
            this.Label_StreamData_MarkerCount.TabIndex = 3;
            this.Label_StreamData_MarkerCount.Text = "Marker Count";
            // 
            // Textbox_MarkersCount
            // 
            this.Textbox_MarkersCount.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_MarkersCount.Location = new System.Drawing.Point(83, 6);
            this.Textbox_MarkersCount.Name = "Textbox_MarkersCount";
            this.Textbox_MarkersCount.ReadOnly = true;
            this.Textbox_MarkersCount.Size = new System.Drawing.Size(100, 20);
            this.Textbox_MarkersCount.TabIndex = 4;
            // 
            // Button_ValidateADPCM
            // 
            this.Button_ValidateADPCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_ValidateADPCM.Enabled = false;
            this.Button_ValidateADPCM.Location = new System.Drawing.Point(84, 578);
            this.Button_ValidateADPCM.Name = "Button_ValidateADPCM";
            this.Button_ValidateADPCM.Size = new System.Drawing.Size(144, 23);
            this.Button_ValidateADPCM.TabIndex = 8;
            this.Button_ValidateADPCM.Text = "Validate All Streams";
            this.Button_ValidateADPCM.Click += new System.EventHandler(this.Button_ValidateADPCM_Click);
            // 
            // Textbox_StreamFilePath
            // 
            this.Textbox_StreamFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_StreamFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_StreamFilePath.Location = new System.Drawing.Point(3, 607);
            this.Textbox_StreamFilePath.Name = "Textbox_StreamFilePath";
            this.Textbox_StreamFilePath.ReadOnly = true;
            this.Textbox_StreamFilePath.Size = new System.Drawing.Size(407, 20);
            this.Textbox_StreamFilePath.TabIndex = 9;
            // 
            // Button_LoadStreamData
            // 
            this.Button_LoadStreamData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_LoadStreamData.Location = new System.Drawing.Point(3, 578);
            this.Button_LoadStreamData.Name = "Button_LoadStreamData";
            this.Button_LoadStreamData.Size = new System.Drawing.Size(75, 23);
            this.Button_LoadStreamData.TabIndex = 7;
            this.Button_LoadStreamData.Text = "Load...";
            this.Button_LoadStreamData.Click += new System.EventHandler(this.Button_LoadStreamData_Click);
            // 
            // OpenFileDialog_StreamData
            // 
            this.OpenFileDialog_StreamData.Filter = "Stream Files (*StreamData.sfx)|*.sfx|Stream Files (HC0?FFFF.sfx)|*.sfx|All Files " +
    "(*.*)|*.*";
            // 
            // ListView_StreamData
            // 
            this.ListView_StreamData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_StreamData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StreamData_Index,
            this.StreamData_AdpcmStatus,
            this.StreamData_MarkerOffset,
            this.StreamData_MarkerSize,
            this.StreamData_AudioOffset,
            this.StreamData_AudioLength,
            this.StreamData_BaseVolume});
            this.ListView_StreamData.FullRowSelect = true;
            this.ListView_StreamData.GridLines = true;
            this.ListView_StreamData.HideSelection = false;
            this.ListView_StreamData.Location = new System.Drawing.Point(3, 3);
            this.ListView_StreamData.Name = "ListView_StreamData";
            this.ListView_StreamData.Size = new System.Drawing.Size(407, 332);
            this.ListView_StreamData.TabIndex = 0;
            this.ListView_StreamData.UseCompatibleStateImageBehavior = false;
            this.ListView_StreamData.View = System.Windows.Forms.View.Details;
            this.ListView_StreamData.SelectedIndexChanged += new System.EventHandler(this.ListView_StreamData_SelectedIndexChanged);
            this.ListView_StreamData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_StreamData_MouseDoubleClick);
            // 
            // StreamData_Index
            // 
            this.StreamData_Index.Text = "No";
            this.StreamData_Index.Width = 42;
            // 
            // StreamData_AdpcmStatus
            // 
            this.StreamData_AdpcmStatus.Text = "ADPCM";
            // 
            // StreamData_MarkerOffset
            // 
            this.StreamData_MarkerOffset.Text = "Marker Offset";
            this.StreamData_MarkerOffset.Width = 81;
            // 
            // StreamData_MarkerSize
            // 
            this.StreamData_MarkerSize.Text = "Marker Size";
            this.StreamData_MarkerSize.Width = 71;
            // 
            // StreamData_AudioOffset
            // 
            this.StreamData_AudioOffset.Text = "Audio Offset";
            this.StreamData_AudioOffset.Width = 80;
            // 
            // StreamData_AudioLength
            // 
            this.StreamData_AudioLength.Text = "Audio Length";
            this.StreamData_AudioLength.Width = 95;
            // 
            // StreamData_BaseVolume
            // 
            this.StreamData_BaseVolume.Text = "Base Volume";
            this.StreamData_BaseVolume.Width = 82;
            // 
            // UserControl_StreamData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Button_ValidateADPCM);
            this.Controls.Add(this.Textbox_StreamFilePath);
            this.Controls.Add(this.Button_LoadStreamData);
            this.Controls.Add(this.TabControl_Markers);
            this.Controls.Add(this.ListView_StreamData);
            this.Name = "UserControl_StreamData";
            this.Size = new System.Drawing.Size(413, 634);
            this.TabControl_Markers.ResumeLayout(false);
            this.TabPage_StartMarkers.ResumeLayout(false);
            this.TabPage_StartMarkers.PerformLayout();
            this.TabPage_Markers.ResumeLayout(false);
            this.TabPage_Markers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader StreamData_Index;
        private System.Windows.Forms.ColumnHeader StreamData_AdpcmStatus;
        private System.Windows.Forms.ColumnHeader StreamData_MarkerOffset;
        private System.Windows.Forms.ColumnHeader StreamData_MarkerSize;
        private System.Windows.Forms.ColumnHeader StreamData_AudioOffset;
        private System.Windows.Forms.ColumnHeader StreamData_AudioLength;
        private System.Windows.Forms.ColumnHeader StreamData_BaseVolume;
        private System.Windows.Forms.TabControl TabControl_Markers;
        private System.Windows.Forms.TabPage TabPage_StartMarkers;
        private System.Windows.Forms.TabPage TabPage_Markers;
        private System.Windows.Forms.Button Button_ValidateADPCM;
        private System.Windows.Forms.Button Button_LoadStreamData;
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
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_StreamData;
        protected internal ListView_ColumnSortingClick ListView_StreamData;
        protected internal System.Windows.Forms.TextBox Textbox_StreamFilePath;
    }
}
