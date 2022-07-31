using System.Collections.Generic;
using System.Drawing;
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
        internal void UpdateWavHeaderData(List<WavHeaderData> wavesList)
        {
            if (wavesList.Count > 0)
            {
                ListView_WavData.BeginUpdate();
                ListView_WavData.Items.Clear();
                int index = 0;

                foreach (WavHeaderData waveData in wavesList)
                {
                    //Create item and add it to list
                    ListViewItem listViewItem2 = new ListViewItem(new string[] { (index).ToString(), waveData.Flags.ToString(), waveData.Address.ToString(), waveData.MemorySize.ToString(), waveData.SampleSize.ToString(), waveData.Frequency.ToString(), waveData.LoopStartOffset.ToString(), waveData.DurationInMilliseconds.ToString() })
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
                byte[] decodedData = null;
                List<WavHeaderData> wavHeaderData = ((Frm_Main)Application.OpenForms["Frm_Main"]).wavesList;

                MusXHeaderData MusXheaderData = ((Frm_Main)Application.OpenForms["Frm_Main"]).headerData;
                if (MusXheaderData.FileVersion > 3 && MusXheaderData.FileVersion < 10)
                {
                    if (MusXheaderData.Platform.Equals("PC__") || MusXheaderData.Platform.Equals("XB__") || MusXheaderData.Platform.Equals("XB1_"))
                    {
                        Eurocom_ImaAdpcm eurocomDAT = new Eurocom_ImaAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(wavHeaderData[selectedIndex].EncodedData));
                    }
                    else if (MusXheaderData.Platform.Equals("GC__"))
                    {
                        DspAdpcm gameCubeDecoder = new DspAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(gameCubeDecoder.Decode(wavHeaderData[selectedIndex].EncodedData, wavHeaderData[selectedIndex].DspCoeffs));
                    }
                    else if (MusXheaderData.Platform.Equals("PS2_"))
                    {
                        SonyAdpcm vagDecoder = new SonyAdpcm();
                        decodedData = vagDecoder.Decode(wavHeaderData[selectedIndex].EncodedData);
                    }
                }
                else
                {
                    switch (MusXheaderData.Platform)
                    {
                        case "PC":
                            decodedData = wavHeaderData[selectedIndex].EncodedData;
                            break;
                        case "PS2":
                            SonyAdpcm vagDecoder = new SonyAdpcm();
                            decodedData = vagDecoder.Decode(wavHeaderData[selectedIndex].EncodedData);
                            break;
                        case "GC":
                            DspAdpcm gameCubeDecoder = new DspAdpcm();
                            decodedData = AudioFunctions.ShortArrayToByteArray(gameCubeDecoder.Decode(wavHeaderData[selectedIndex].EncodedData, wavHeaderData[selectedIndex].DspCoeffs));
                            break;
                        case "XB":
                            XboxAdpcm xboxDecoder = new XboxAdpcm();
                            decodedData = AudioFunctions.ShortArrayToByteArray(xboxDecoder.Decode(wavHeaderData[selectedIndex].EncodedData));
                            break;
                    }
                }

                //Show player
                if (decodedData != null)
                {
                    Frm_MediaPlayer_Mono sfxPlayer = new Frm_MediaPlayer_Mono(decodedData, wavHeaderData[selectedIndex].EncodedData, wavHeaderData[selectedIndex].Frequency);
                    sfxPlayer.ShowDialog();
                }
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
