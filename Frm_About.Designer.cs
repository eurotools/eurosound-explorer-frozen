﻿
namespace sb_explorer
{
    partial class Frm_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_About));
            this.Panel_About = new System.Windows.Forms.Panel();
            this.Label_Credits = new System.Windows.Forms.Label();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Panel_About.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_About
            // 
            this.Panel_About.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_About.BackColor = System.Drawing.Color.White;
            this.Panel_About.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_About.Controls.Add(this.Label_Credits);
            this.Panel_About.Location = new System.Drawing.Point(16, 16);
            this.Panel_About.Name = "Panel_About";
            this.Panel_About.Size = new System.Drawing.Size(256, 168);
            this.Panel_About.TabIndex = 11;
            // 
            // Label_Credits
            // 
            this.Label_Credits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Credits.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Credits.Location = new System.Drawing.Point(0, 0);
            this.Label_Credits.Name = "Label_Credits";
            this.Label_Credits.Size = new System.Drawing.Size(252, 164);
            this.Label_Credits.TabIndex = 1;
            this.Label_Credits.Text = "Eurosound Soundbank Explorer\r\n\r\nOriginal version by:\r\nKevin Grantham (Eurocom)\r\n\r" +
    "\nProgrammer:\r\nJordi Martínez (jmarti856)\r\n\r\nFile formats doc by:\r\nIsmael Ferrera" +
    "s (Swyter)";
            this.Label_Credits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_OK.Location = new System.Drawing.Point(112, 200);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(64, 40);
            this.Button_OK.TabIndex = 10;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            // 
            // Frm_About
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 247);
            this.Controls.Add(this.Panel_About);
            this.Controls.Add(this.Button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Panel_About.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_About;
        private System.Windows.Forms.Label Label_Credits;
        private System.Windows.Forms.Button Button_OK;
    }
}