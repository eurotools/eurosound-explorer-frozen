﻿using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.IO;
using System.Windows.Forms;

namespace sb_explorer
{
    public partial class MediaPlayer_Stereo : Form
    {
        //*===============================================================================================
        //* GLOBAL VARS
        //*===============================================================================================
        private readonly WaveOut AudioPlayer = new WaveOut();
        private readonly byte[] pcmDataToPlayL, pcmDataToPlayR;
        private readonly int Frequency;

        public MediaPlayer_Stereo(byte[] vPcmDataToPlayL, byte[] vPcmDataToPlayR, int vFrequency)
        {
            InitializeComponent();
            pcmDataToPlayL = vPcmDataToPlayL;
            pcmDataToPlayR = vPcmDataToPlayR;
            Frequency = vFrequency;
        }


        //*===============================================================================================
        //* Form Events
        //*===============================================================================================
        private void MediaPlayer_Stereo_Shown(object sender, System.EventArgs e)
        {
            WavesViewerLeft.WaveStream = new RawSourceWaveStream(new MemoryStream(pcmDataToPlayL), new WaveFormat(Frequency, 16, 1));
            WavesViewerLeft.InitControl();
            WavesViewerRight.WaveStream = new RawSourceWaveStream(new MemoryStream(pcmDataToPlayR), new WaveFormat(Frequency, 16, 1));
            WavesViewerRight.InitControl();
        }

        private void MediaPlayer_Stereo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AudioPlayer.PlaybackState == PlaybackState.Playing)
            {
                AudioPlayer.Stop();
                AudioPlayer.Dispose();
            }
        }

        //*===============================================================================================
        //* Button Events
        //*===============================================================================================
        private void Button_Play_Click(object sender, System.EventArgs e)
        {
            //Check if we have an output device
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            if (enumerator.HasDefaultAudioEndpoint(DataFlow.Render, Role.Console))
            {
                if (Frequency != 0)
                {
                    if (AudioPlayer.PlaybackState == PlaybackState.Stopped)
                    {
                        MemoryStream AudioSample = new MemoryStream(pcmDataToPlayL);
                        IWaveProvider providerLeft = new RawSourceWaveStream(AudioSample, new WaveFormat(Frequency, 16, 1));
                        AudioSample = new MemoryStream(pcmDataToPlayR);
                        IWaveProvider providerRight = new RawSourceWaveStream(AudioSample, new WaveFormat(Frequency, 16, 1));

                        MultiplexingWaveProvider waveProvider = new MultiplexingWaveProvider(new IWaveProvider[] { providerLeft, providerRight }, 2);
                        AudioPlayer.Init(waveProvider);
                        AudioPlayer.Play();
                    }
                }
            }
            else
            {
                MessageBox.Show("The selected audio could not been played because it has not been possible to find an output device.", "EuroSound", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Button_Stop_Click(object sender, System.EventArgs e)
        {
            if (AudioPlayer.PlaybackState == PlaybackState.Playing)
            {
                AudioPlayer.Stop();
            }
        }

        private void Button_SaveWav_Click(object sender, System.EventArgs e)
        {
            //Set file name and extension
            SaveFileDlg_SaveFile.Filter = "Wave Audio File (*.wav)|*.wav";
            SaveFileDlg_SaveFile.FileName = "output.wav";

            //Show dialog
            DialogResult saveFileDialog = SaveFileDlg_SaveFile.ShowDialog();
            if (saveFileDialog == DialogResult.OK)
            {
                string filePath = SaveFileDlg_SaveFile.FileName;
                try
                {
                    //Save file
                    MemoryStream AudioSample = new MemoryStream(pcmDataToPlayL);
                    IWaveProvider providerLeft = new RawSourceWaveStream(AudioSample, new WaveFormat(Frequency, 16, 1));
                    AudioSample = new MemoryStream(pcmDataToPlayR);
                    IWaveProvider providerRight = new RawSourceWaveStream(AudioSample, new WaveFormat(Frequency, 16, 1));
                    MultiplexingWaveProvider waveProvider = new MultiplexingWaveProvider(new IWaveProvider[] { providerLeft, providerRight }, 2);
                    WaveFileWriter.CreateWaveFile(filePath, waveProvider);

                    //Inform user
                    MessageBox.Show("File saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button_Close_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
