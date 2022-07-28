
namespace sb_explorer
{
    partial class UserControl_HexEditor
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
            this.Label_HexViewer_Key = new System.Windows.Forms.Label();
            this.Label_HexViewer_SamplePool = new System.Windows.Forms.Label();
            this.Button_HexViewer_SamplePool = new System.Windows.Forms.Button();
            this.Label_HexViewer_UserFlags = new System.Windows.Forms.Label();
            this.Button_HexViewer_UserFlags = new System.Windows.Forms.Button();
            this.Label_HexViewer_Flags = new System.Windows.Forms.Label();
            this.Button_HexViewer_Flags = new System.Windows.Forms.Button();
            this.Label_HexViewer_HeaderData = new System.Windows.Forms.Label();
            this.Button_HexViewer_HeaderData = new System.Windows.Forms.Button();
            this.ListView_HexEditor = new System.Windows.Forms.ListView();
            this.HexViewer_Offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_Byte8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexViewer_ASCII = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Label_HexViewer_Key
            // 
            this.Label_HexViewer_Key.AutoSize = true;
            this.Label_HexViewer_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_HexViewer_Key.Location = new System.Drawing.Point(3, 525);
            this.Label_HexViewer_Key.Name = "Label_HexViewer_Key";
            this.Label_HexViewer_Key.Size = new System.Drawing.Size(32, 13);
            this.Label_HexViewer_Key.TabIndex = 20;
            this.Label_HexViewer_Key.Text = "Key:";
            // 
            // Label_HexViewer_SamplePool
            // 
            this.Label_HexViewer_SamplePool.AutoSize = true;
            this.Label_HexViewer_SamplePool.Location = new System.Drawing.Point(312, 525);
            this.Label_HexViewer_SamplePool.Name = "Label_HexViewer_SamplePool";
            this.Label_HexViewer_SamplePool.Size = new System.Drawing.Size(66, 13);
            this.Label_HexViewer_SamplePool.TabIndex = 28;
            this.Label_HexViewer_SamplePool.Text = "Sample Pool";
            // 
            // Button_HexViewer_SamplePool
            // 
            this.Button_HexViewer_SamplePool.BackColor = System.Drawing.Color.Green;
            this.Button_HexViewer_SamplePool.Enabled = false;
            this.Button_HexViewer_SamplePool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Button_HexViewer_SamplePool.Location = new System.Drawing.Point(296, 523);
            this.Button_HexViewer_SamplePool.Name = "Button_HexViewer_SamplePool";
            this.Button_HexViewer_SamplePool.Size = new System.Drawing.Size(16, 16);
            this.Button_HexViewer_SamplePool.TabIndex = 27;
            this.Button_HexViewer_SamplePool.UseVisualStyleBackColor = false;
            // 
            // Label_HexViewer_UserFlags
            // 
            this.Label_HexViewer_UserFlags.AutoSize = true;
            this.Label_HexViewer_UserFlags.Location = new System.Drawing.Point(224, 525);
            this.Label_HexViewer_UserFlags.Name = "Label_HexViewer_UserFlags";
            this.Label_HexViewer_UserFlags.Size = new System.Drawing.Size(57, 13);
            this.Label_HexViewer_UserFlags.TabIndex = 26;
            this.Label_HexViewer_UserFlags.Text = "User Flags";
            // 
            // Button_HexViewer_UserFlags
            // 
            this.Button_HexViewer_UserFlags.BackColor = System.Drawing.Color.Purple;
            this.Button_HexViewer_UserFlags.Enabled = false;
            this.Button_HexViewer_UserFlags.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Button_HexViewer_UserFlags.Location = new System.Drawing.Point(208, 523);
            this.Button_HexViewer_UserFlags.Name = "Button_HexViewer_UserFlags";
            this.Button_HexViewer_UserFlags.Size = new System.Drawing.Size(16, 16);
            this.Button_HexViewer_UserFlags.TabIndex = 25;
            this.Button_HexViewer_UserFlags.UseVisualStyleBackColor = false;
            // 
            // Label_HexViewer_Flags
            // 
            this.Label_HexViewer_Flags.AutoSize = true;
            this.Label_HexViewer_Flags.Location = new System.Drawing.Point(160, 525);
            this.Label_HexViewer_Flags.Name = "Label_HexViewer_Flags";
            this.Label_HexViewer_Flags.Size = new System.Drawing.Size(32, 13);
            this.Label_HexViewer_Flags.TabIndex = 24;
            this.Label_HexViewer_Flags.Text = "Flags";
            // 
            // Button_HexViewer_Flags
            // 
            this.Button_HexViewer_Flags.BackColor = System.Drawing.Color.Blue;
            this.Button_HexViewer_Flags.Enabled = false;
            this.Button_HexViewer_Flags.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Button_HexViewer_Flags.Location = new System.Drawing.Point(144, 523);
            this.Button_HexViewer_Flags.Name = "Button_HexViewer_Flags";
            this.Button_HexViewer_Flags.Size = new System.Drawing.Size(16, 16);
            this.Button_HexViewer_Flags.TabIndex = 23;
            this.Button_HexViewer_Flags.UseVisualStyleBackColor = false;
            // 
            // Label_HexViewer_HeaderData
            // 
            this.Label_HexViewer_HeaderData.AutoSize = true;
            this.Label_HexViewer_HeaderData.Location = new System.Drawing.Point(64, 525);
            this.Label_HexViewer_HeaderData.Name = "Label_HexViewer_HeaderData";
            this.Label_HexViewer_HeaderData.Size = new System.Drawing.Size(68, 13);
            this.Label_HexViewer_HeaderData.TabIndex = 22;
            this.Label_HexViewer_HeaderData.Text = "Header Data";
            // 
            // Button_HexViewer_HeaderData
            // 
            this.Button_HexViewer_HeaderData.BackColor = System.Drawing.Color.Black;
            this.Button_HexViewer_HeaderData.Enabled = false;
            this.Button_HexViewer_HeaderData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Button_HexViewer_HeaderData.Location = new System.Drawing.Point(48, 523);
            this.Button_HexViewer_HeaderData.Name = "Button_HexViewer_HeaderData";
            this.Button_HexViewer_HeaderData.Size = new System.Drawing.Size(16, 16);
            this.Button_HexViewer_HeaderData.TabIndex = 21;
            this.Button_HexViewer_HeaderData.UseVisualStyleBackColor = false;
            // 
            // ListView_HexEditor
            // 
            this.ListView_HexEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_HexEditor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HexViewer_Offset,
            this.HexViewer_Byte1,
            this.HexViewer_Byte2,
            this.HexViewer_Byte3,
            this.HexViewer_Byte4,
            this.HexViewer_Byte5,
            this.HexViewer_Byte6,
            this.HexViewer_Byte7,
            this.HexViewer_Byte8,
            this.HexViewer_ASCII});
            this.ListView_HexEditor.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.ListView_HexEditor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_HexEditor.HideSelection = false;
            this.ListView_HexEditor.Location = new System.Drawing.Point(3, 3);
            this.ListView_HexEditor.Name = "ListView_HexEditor";
            this.ListView_HexEditor.Size = new System.Drawing.Size(380, 512);
            this.ListView_HexEditor.TabIndex = 19;
            this.ListView_HexEditor.UseCompatibleStateImageBehavior = false;
            this.ListView_HexEditor.View = System.Windows.Forms.View.Details;
            // 
            // HexViewer_Offset
            // 
            this.HexViewer_Offset.Text = "Offset";
            this.HexViewer_Offset.Width = 66;
            // 
            // HexViewer_Byte1
            // 
            this.HexViewer_Byte1.Text = "";
            this.HexViewer_Byte1.Width = 28;
            // 
            // HexViewer_Byte2
            // 
            this.HexViewer_Byte2.Text = "";
            this.HexViewer_Byte2.Width = 28;
            // 
            // HexViewer_Byte3
            // 
            this.HexViewer_Byte3.Text = "";
            this.HexViewer_Byte3.Width = 28;
            // 
            // HexViewer_Byte4
            // 
            this.HexViewer_Byte4.Text = "";
            this.HexViewer_Byte4.Width = 28;
            // 
            // HexViewer_Byte5
            // 
            this.HexViewer_Byte5.Text = "";
            this.HexViewer_Byte5.Width = 28;
            // 
            // HexViewer_Byte6
            // 
            this.HexViewer_Byte6.Text = "";
            this.HexViewer_Byte6.Width = 28;
            // 
            // HexViewer_Byte7
            // 
            this.HexViewer_Byte7.Text = "";
            this.HexViewer_Byte7.Width = 28;
            // 
            // HexViewer_Byte8
            // 
            this.HexViewer_Byte8.Text = "";
            this.HexViewer_Byte8.Width = 28;
            // 
            // HexViewer_ASCII
            // 
            this.HexViewer_ASCII.Text = "ASCII";
            this.HexViewer_ASCII.Width = 77;
            // 
            // UserControl_HexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label_HexViewer_Key);
            this.Controls.Add(this.Label_HexViewer_SamplePool);
            this.Controls.Add(this.Button_HexViewer_SamplePool);
            this.Controls.Add(this.Label_HexViewer_UserFlags);
            this.Controls.Add(this.Button_HexViewer_UserFlags);
            this.Controls.Add(this.Label_HexViewer_Flags);
            this.Controls.Add(this.Button_HexViewer_Flags);
            this.Controls.Add(this.Label_HexViewer_HeaderData);
            this.Controls.Add(this.Button_HexViewer_HeaderData);
            this.Controls.Add(this.ListView_HexEditor);
            this.Name = "UserControl_HexEditor";
            this.Size = new System.Drawing.Size(386, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_HexViewer_Key;
        private System.Windows.Forms.Label Label_HexViewer_SamplePool;
        private System.Windows.Forms.Button Button_HexViewer_SamplePool;
        private System.Windows.Forms.Label Label_HexViewer_UserFlags;
        private System.Windows.Forms.Button Button_HexViewer_UserFlags;
        private System.Windows.Forms.Label Label_HexViewer_Flags;
        private System.Windows.Forms.Button Button_HexViewer_Flags;
        private System.Windows.Forms.Label Label_HexViewer_HeaderData;
        private System.Windows.Forms.Button Button_HexViewer_HeaderData;
        protected internal System.Windows.Forms.ListView ListView_HexEditor;
        private System.Windows.Forms.ColumnHeader HexViewer_Offset;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte1;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte2;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte3;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte4;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte5;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte6;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte7;
        private System.Windows.Forms.ColumnHeader HexViewer_Byte8;
        private System.Windows.Forms.ColumnHeader HexViewer_ASCII;
    }
}
