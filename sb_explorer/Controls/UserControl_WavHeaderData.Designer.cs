
namespace sb_explorer
{
    partial class UserControl_WavHeaderData
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
            this.ListView_WavData = new sb_explorer.ListView_ColumnSortingClick();
            this.WavHeaderData_Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WavHeaderData_Flags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WavHeaderData_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WavHeaderData_MemorySize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WavHeaderData_SampleSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WavHeaderData_Frequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WavHeaderData_LoopStartOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WavHeaderData_Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ListView_WavData
            // 
            this.ListView_WavData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.WavHeaderData_Number,
            this.WavHeaderData_Flags,
            this.WavHeaderData_Address,
            this.WavHeaderData_MemorySize,
            this.WavHeaderData_SampleSize,
            this.WavHeaderData_Frequency,
            this.WavHeaderData_LoopStartOffset,
            this.WavHeaderData_Duration});
            this.ListView_WavData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_WavData.FullRowSelect = true;
            this.ListView_WavData.GridLines = true;
            this.ListView_WavData.HideSelection = false;
            this.ListView_WavData.Location = new System.Drawing.Point(0, 0);
            this.ListView_WavData.Name = "ListView_WavData";
            this.ListView_WavData.Size = new System.Drawing.Size(516, 604);
            this.ListView_WavData.TabIndex = 1;
            this.ListView_WavData.UseCompatibleStateImageBehavior = false;
            this.ListView_WavData.View = System.Windows.Forms.View.Details;
            this.ListView_WavData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_WavData_MouseDoubleClick);
            // 
            // WavHeaderData_Number
            // 
            this.WavHeaderData_Number.Text = "No.";
            this.WavHeaderData_Number.Width = 34;
            // 
            // WavHeaderData_Flags
            // 
            this.WavHeaderData_Flags.Text = "Flags";
            this.WavHeaderData_Flags.Width = 40;
            // 
            // WavHeaderData_Address
            // 
            this.WavHeaderData_Address.Text = "Address";
            // 
            // WavHeaderData_MemorySize
            // 
            this.WavHeaderData_MemorySize.Text = "Memory Size";
            this.WavHeaderData_MemorySize.Width = 75;
            // 
            // WavHeaderData_SampleSize
            // 
            this.WavHeaderData_SampleSize.Text = "Sample Size";
            this.WavHeaderData_SampleSize.Width = 73;
            // 
            // WavHeaderData_Frequency
            // 
            this.WavHeaderData_Frequency.Text = "Freq.";
            this.WavHeaderData_Frequency.Width = 42;
            // 
            // WavHeaderData_LoopStartOffset
            // 
            this.WavHeaderData_LoopStartOffset.Text = "LoopStartOffset";
            this.WavHeaderData_LoopStartOffset.Width = 89;
            // 
            // WavHeaderData_Duration
            // 
            this.WavHeaderData_Duration.Text = "Duration (ms)";
            this.WavHeaderData_Duration.Width = 80;
            // 
            // UserControl_WavHeaderData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView_WavData);
            this.Name = "UserControl_WavHeaderData";
            this.Size = new System.Drawing.Size(516, 604);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader WavHeaderData_Number;
        private System.Windows.Forms.ColumnHeader WavHeaderData_Flags;
        private System.Windows.Forms.ColumnHeader WavHeaderData_Address;
        private System.Windows.Forms.ColumnHeader WavHeaderData_MemorySize;
        private System.Windows.Forms.ColumnHeader WavHeaderData_SampleSize;
        private System.Windows.Forms.ColumnHeader WavHeaderData_Frequency;
        private System.Windows.Forms.ColumnHeader WavHeaderData_LoopStartOffset;
        private System.Windows.Forms.ColumnHeader WavHeaderData_Duration;
        protected internal ListView_ColumnSortingClick ListView_WavData;
    }
}
