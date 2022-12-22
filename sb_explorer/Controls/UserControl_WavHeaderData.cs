using NAudio.Wave;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class UserControl_WavHeaderData : UserControl
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        public UserControl_WavHeaderData()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void UpdateWavHeaderData(List<SfxData> wavesList)
        {
            if (wavesList.Count > 0)
            {
                ListView_WavData.BeginUpdate();
                ListView_WavData.Items.Clear();
                int index = 0;

                foreach (SfxData waveData in wavesList)
                {
                    //Create item and add it to list
                    ListViewItem listViewItem2 = new ListViewItem(new string[] { (index).ToString(), waveData.Flags.ToString(), waveData.Address.ToString(), waveData.MemorySize.ToString(), waveData.SampleSize.ToString(), waveData.Frequency.ToString(), waveData.LoopStartOffset.ToString(), waveData.Duration.ToString() })
                    {
                        Tag = index
                    };
                    if (waveData.LoopStartOffset > waveData.MemorySize)
                    {
                        listViewItem2.UseItemStyleForSubItems = false;
                        listViewItem2.SubItems[6].ForeColor = Color.Red;
                    }
                    ListView_WavData.Items.Add(listViewItem2);

                    //Increase index
                    index++;
                }

                ListView_WavData.EndUpdate();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ListView_WavData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListView_WavData.SelectedItems.Count == 1)
            {
                int selectedIndex = (int)ListView_WavData.SelectedItems[0].Tag;
                DecodeAndShowPlayer(selectedIndex);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItemSaveSound_Click(object sender, System.EventArgs e)
        {
            if (ListView_WavData.SelectedItems.Count == 1)
            {
                int selectedIndex = (int)ListView_WavData.SelectedItems[0].Tag;
                List<SfxData> wavHeaderData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).wavesList;
                byte[] decodedData = CommonFunctions.DecodeSfxSound(wavHeaderData[selectedIndex]);
                if (decodedData != null)
                {
                    //Save Wav
                    DialogResult saveDialog = SaveFileDialog.ShowDialog();
                    if (saveDialog == DialogResult.OK)
                    {
                        IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(decodedData), new WaveFormat(wavHeaderData[selectedIndex].Frequency, 16, 1));
                        WaveFileWriter.CreateWaveFile(SaveFileDialog.FileName, provider);
                    }
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItemOpenPlayer_Click(object sender, System.EventArgs e)
        {
            if (ListView_WavData.SelectedItems.Count == 1)
            {
                int selectedIndex = (int)ListView_WavData.SelectedItems[0].Tag;
                DecodeAndShowPlayer(selectedIndex);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void DecodeAndShowPlayer(int selectedIndex)
        {
            List<SfxData> wavHeaderData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).wavesList;
            byte[] decodedData = CommonFunctions.DecodeSfxSound(wavHeaderData[selectedIndex]);
            if (decodedData != null)
            {
                Frm_MediaPlayer_Mono sfxPlayer = new Frm_MediaPlayer_Mono(decodedData, wavHeaderData[selectedIndex].EncodedData, wavHeaderData[selectedIndex].Frequency);
                sfxPlayer.ShowDialog();
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
