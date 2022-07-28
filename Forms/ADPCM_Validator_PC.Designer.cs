
namespace sb_explorer
{
    partial class ADPCM_Validator_PC
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
            this.ProgressBar_Validation = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ProgressBar_Validation
            // 
            this.ProgressBar_Validation.Location = new System.Drawing.Point(28, 35);
            this.ProgressBar_Validation.Name = "ProgressBar_Validation";
            this.ProgressBar_Validation.Size = new System.Drawing.Size(328, 23);
            this.ProgressBar_Validation.TabIndex = 2;
            // 
            // ADPCM_Validator_PC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 93);
            this.Controls.Add(this.ProgressBar_Validation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ADPCM_Validator_PC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validating ADPCM data";
            this.Shown += new System.EventHandler(this.ADPCM_Validator_PC_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        protected internal System.Windows.Forms.ProgressBar ProgressBar_Validation;
    }
}