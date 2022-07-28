
namespace sb_explorer
{
    partial class UserControl_HashCodes
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
            this.ListView_HashCodes = new sb_explorer.ListView_ColumnSortingClick();
            this.Col_HashCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ListView_HashCodes
            // 
            this.ListView_HashCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_HashCode,
            this.Col_Status,
            this.Col_Name});
            this.ListView_HashCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_HashCodes.FullRowSelect = true;
            this.ListView_HashCodes.HideSelection = false;
            this.ListView_HashCodes.Location = new System.Drawing.Point(0, 0);
            this.ListView_HashCodes.Name = "ListView_HashCodes";
            this.ListView_HashCodes.Size = new System.Drawing.Size(513, 457);
            this.ListView_HashCodes.TabIndex = 0;
            this.ListView_HashCodes.UseCompatibleStateImageBehavior = false;
            this.ListView_HashCodes.View = System.Windows.Forms.View.Details;
            this.ListView_HashCodes.SelectedIndexChanged += new System.EventHandler(this.ListView_HashCodes_SelectedIndexChanged);
            // 
            // Col_HashCode
            // 
            this.Col_HashCode.Text = "HashCode";
            this.Col_HashCode.Width = 75;
            // 
            // Col_Status
            // 
            this.Col_Status.Text = "OK";
            this.Col_Status.Width = 30;
            // 
            // Col_Name
            // 
            this.Col_Name.Text = "Name";
            this.Col_Name.Width = 100;
            // 
            // UserControl_HashCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView_HashCodes);
            this.Name = "UserControl_HashCodes";
            this.Size = new System.Drawing.Size(513, 457);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader Col_HashCode;
        private System.Windows.Forms.ColumnHeader Col_Status;
        private System.Windows.Forms.ColumnHeader Col_Name;
        protected internal ListView_ColumnSortingClick ListView_HashCodes;
    }
}
