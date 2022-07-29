﻿
namespace sb_explorer
{
    partial class MediaPlayer_Stereo
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
            this.Button_SaveWav = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.Button_Stop = new System.Windows.Forms.Button();
            this.Button_Play = new System.Windows.Forms.Button();
            this.WavesViewerLeft = new sb_explorer.Controls.EuroSound_WaveViewer();
            this.WavesViewerRight = new sb_explorer.Controls.EuroSound_WaveViewer();
            this.Label_RightChannel = new System.Windows.Forms.Label();
            this.Label_LeftChannel = new System.Windows.Forms.Label();
            this.SaveFileDlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Button_SaveWav
            // 
            this.Button_SaveWav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SaveWav.Location = new System.Drawing.Point(263, 286);
            this.Button_SaveWav.Name = "Button_SaveWav";
            this.Button_SaveWav.Size = new System.Drawing.Size(75, 23);
            this.Button_SaveWav.TabIndex = 4;
            this.Button_SaveWav.Text = "Save";
            this.Button_SaveWav.UseVisualStyleBackColor = true;
            this.Button_SaveWav.Click += new System.EventHandler(this.Button_SaveWav_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Close.Location = new System.Drawing.Point(506, 286);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 23);
            this.Button_Close.TabIndex = 7;
            this.Button_Close.Text = "Close";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Button_Stop
            // 
            this.Button_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Stop.Location = new System.Drawing.Point(425, 286);
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Size = new System.Drawing.Size(75, 23);
            this.Button_Stop.TabIndex = 6;
            this.Button_Stop.Text = "Stop";
            this.Button_Stop.UseVisualStyleBackColor = true;
            this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // Button_Play
            // 
            this.Button_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Play.Location = new System.Drawing.Point(344, 286);
            this.Button_Play.Name = "Button_Play";
            this.Button_Play.Size = new System.Drawing.Size(75, 23);
            this.Button_Play.TabIndex = 5;
            this.Button_Play.Text = "Play";
            this.Button_Play.UseVisualStyleBackColor = true;
            this.Button_Play.Click += new System.EventHandler(this.Button_Play_Click);
            // 
            // WavesViewerLeft
            // 
            this.WavesViewerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.WavesViewerLeft.CurrentWaveImage = null;
            this.WavesViewerLeft.Location = new System.Drawing.Point(31, 12);
            this.WavesViewerLeft.Name = "WavesViewerLeft";
            this.WavesViewerLeft.PenWidth = 1F;
            this.WavesViewerLeft.SamplesPerPixel = 128;
            this.WavesViewerLeft.Size = new System.Drawing.Size(550, 132);
            this.WavesViewerLeft.StartPosition = ((long)(0));
            this.WavesViewerLeft.TabIndex = 1;
            this.WavesViewerLeft.WaveStream = null;
            // 
            // WavesViewerRight
            // 
            this.WavesViewerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.WavesViewerRight.CurrentWaveImage = null;
            this.WavesViewerRight.Location = new System.Drawing.Point(31, 150);
            this.WavesViewerRight.Name = "WavesViewerRight";
            this.WavesViewerRight.PenWidth = 1F;
            this.WavesViewerRight.SamplesPerPixel = 128;
            this.WavesViewerRight.Size = new System.Drawing.Size(550, 130);
            this.WavesViewerRight.StartPosition = ((long)(0));
            this.WavesViewerRight.TabIndex = 3;
            this.WavesViewerRight.WaveStream = null;
            // 
            // Label_RightChannel
            // 
            this.Label_RightChannel.AutoSize = true;
            this.Label_RightChannel.Location = new System.Drawing.Point(10, 213);
            this.Label_RightChannel.Name = "Label_RightChannel";
            this.Label_RightChannel.Size = new System.Drawing.Size(15, 13);
            this.Label_RightChannel.TabIndex = 2;
            this.Label_RightChannel.Text = "R";
            // 
            // Label_LeftChannel
            // 
            this.Label_LeftChannel.AutoSize = true;
            this.Label_LeftChannel.Location = new System.Drawing.Point(12, 77);
            this.Label_LeftChannel.Name = "Label_LeftChannel";
            this.Label_LeftChannel.Size = new System.Drawing.Size(13, 13);
            this.Label_LeftChannel.TabIndex = 0;
            this.Label_LeftChannel.Text = "L";
            // 
            // MediaPlayer_Stereo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 321);
            this.Controls.Add(this.Label_RightChannel);
            this.Controls.Add(this.Label_LeftChannel);
            this.Controls.Add(this.WavesViewerRight);
            this.Controls.Add(this.WavesViewerLeft);
            this.Controls.Add(this.Button_SaveWav);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_Stop);
            this.Controls.Add(this.Button_Play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MediaPlayer_Stereo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Media Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MediaPlayer_Stereo_FormClosing);
            this.Shown += new System.EventHandler(this.MediaPlayer_Stereo_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_SaveWav;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.Button Button_Stop;
        private System.Windows.Forms.Button Button_Play;
        private Controls.EuroSound_WaveViewer WavesViewerLeft;
        private Controls.EuroSound_WaveViewer WavesViewerRight;
        private System.Windows.Forms.Label Label_RightChannel;
        private System.Windows.Forms.Label Label_LeftChannel;
        private System.Windows.Forms.SaveFileDialog SaveFileDlg_SaveFile;
    }
}