using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.IO;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class Frm_MediaPlayer_Mono : Form
    {
        //*===============================================================================================
        //* GLOBAL VARS
        //*===============================================================================================
        private readonly WaveOut AudioPlayer = new WaveOut();
        private readonly byte[] pcmDataToPlay, encodedRawData;
        private readonly int Frequency;

        //-------------------------------------------------------------------------------------------------------------------------------
        public Frm_MediaPlayer_Mono(byte[] decodedData, byte[] encodedData, int vFrequency)
        {
            InitializeComponent();
            pcmDataToPlay = decodedData;
            Frequency = vFrequency;
            encodedRawData = encodedData;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MediaPlayer_Mono_Shown(object sender, EventArgs e)
        {
            WavesViewer.WaveStream = new RawSourceWaveStream(new MemoryStream(pcmDataToPlay), new WaveFormat(Frequency, 16, 1));
            WavesViewer.InitControl();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MediaPlayer_Mono_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AudioPlayer.PlaybackState == PlaybackState.Playing)
            {
                AudioPlayer.Stop();
                AudioPlayer.Dispose();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_SaveRaw_Click(object sender, EventArgs e)
        {
            //Set file name and extension
            SaveFileDlg_SaveFile.Filter = "RAW Audio File (*.raw)|*.raw";
            SaveFileDlg_SaveFile.FileName = "output.raw";

            //Show dialog
            DialogResult saveFileDialog = SaveFileDlg_SaveFile.ShowDialog();
            if (saveFileDialog == DialogResult.OK)
            {
                string filePath = SaveFileDlg_SaveFile.FileName;
                File.WriteAllBytes(filePath, encodedRawData);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_SaveWav_Click(object sender, EventArgs e)
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
                    IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(pcmDataToPlay), new WaveFormat(Frequency, 16, 1));
                    WaveFileWriter.CreateWaveFile(filePath, provider);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_Play_Click(object sender, EventArgs e)
        {
            //Check if we have an output device
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            if (enumerator.HasDefaultAudioEndpoint(DataFlow.Render, Role.Console))
            {
                //Play audio
                if (Frequency != 0)
                {
                    if (AudioPlayer.PlaybackState == PlaybackState.Stopped)
                    {
                        IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(pcmDataToPlay), new WaveFormat(Frequency, 16, 1));
                        AudioPlayer.Init(provider);
                        AudioPlayer.Play();
                    }
                }
            }
            else
            {
                MessageBox.Show("The selected audio could not been played because it has not been possible to find an output device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_Stop_Click(object sender, EventArgs e)
        {
            if (AudioPlayer.PlaybackState == PlaybackState.Playing)
            {
                AudioPlayer.Stop();
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
