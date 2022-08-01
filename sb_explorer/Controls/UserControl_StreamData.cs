using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class UserControl_StreamData : UserControl
    {
        internal int frequency = 22050;
        private MusXHeaderData headerData;

        //-------------------------------------------------------------------------------------------------------------------------------
        public UserControl_StreamData()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_LoadStreamData_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFileDialog_StreamData.ShowDialog() == DialogResult.OK)
                {
                    //Reset frequency variable 
                    frequency = 22050;

                    //Update textbox
                    Textbox_StreamFilePath.Text = OpenFileDialog_StreamData.FileName;

                    //Get file version
                    MusxHeader sfxHeaderData = new MusxHeader();
                    int fileVersion = sfxHeaderData.ReadFileVersion(OpenFileDialog_StreamData.FileName);

                    //Read Header and make sure is a valid MUSX file
                    headerData = new MusXHeaderData();
                    if ((fileVersion == 201 || fileVersion == 1) && fileVersion > 0)
                    {
                        Frm_ChoosePlatform specifyPlatform = new Frm_ChoosePlatform(OpenFileDialog_StreamData.FileName);
                        if (specifyPlatform.ShowDialog() == DialogResult.OK)
                        {
                            headerData.Platform = specifyPlatform.Combobox_Platform.Text;
                        }
                    }

                    //Read File
                    if (sfxHeaderData.ReadStreamBankHeader(OpenFileDialog_StreamData.FileName, headerData) && headerData.Platform != null)
                    {
                        ((Frm_Main)Application.OpenForms["Frm_Main"]).streamedSamples = new List<SfxStream>();
                        if (headerData.FileVersion == 201 || headerData.FileVersion == 1)
                        {
                            //Read file data
                            OldMusX streamsReader = new OldMusX();
                            streamsReader.LoadStreamFile(OpenFileDialog_StreamData.FileName, headerData, ((Frm_Main)Application.OpenForms["Frm_Main"]).streamedSamples);

                            Button_ValidateADPCM.Enabled = false;
                        }
                        else
                        {
                            //Read file data
                            NewMusX streamsReader = new NewMusX();
                            streamsReader.ReadStreamFile(OpenFileDialog_StreamData.FileName, headerData, ((Frm_Main)Application.OpenForms["Frm_Main"]).streamedSamples);

                            //Enable validation tool - Only For Custom EuroCom ADPCM
                            if (headerData.Platform.Contains("PC"))
                            {
                                Button_ValidateADPCM.Enabled = true;
                            }
                            else
                            {
                                Button_ValidateADPCM.Enabled = false;
                            }

                            //For batman begins they changed the frequency to 16000
                            if (headerData.Platform.Contains("GC"))
                            {
                                if (MessageBox.Show("The current game is Batman Begins?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    frequency = 16000;
                                }
                            }
                        }

                        PrintSamplesData(((Frm_Main)Application.OpenForms["Frm_Main"]).streamedSamples);
                    }
                }
            }
            catch (Exception ex)
            {
                ListView_StreamData.Items.Clear();
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ListView_StreamData_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SfxStream> streamedSamples = ((Frm_Main)Application.OpenForms["Frm_Main"]).streamedSamples;
            if (ListView_StreamData.SelectedItems.Count == 1 && streamedSamples != null)
            {
                //Print markers data
                int selectedIndex = (int)ListView_StreamData.SelectedItems[0].Tag;

                //Print counts
                Textbox_StartMarkers_Count.Text = streamedSamples[selectedIndex].StartMarkersCount.ToString();
                Textbox_MarkersCount.Text = streamedSamples[selectedIndex].MarkersCount.ToString();

                //Clear listview
                ListView_StreamData_StartMarkers.BeginUpdate();
                ListView_StreamData_StartMarkers.Items.Clear();

                //Print Start Markers
                if (streamedSamples[selectedIndex].StartMarkers.Count >= 0 && streamedSamples[selectedIndex].StartMarkers.Count <= 20)
                {
                    Textbox_StartMarkers_Count.ForeColor = SystemColors.ControlText;

                    for (int i = 0; i < streamedSamples[selectedIndex].StartMarkers.Count; i++)
                    {
                        //Create listview item
                        ListViewItem listViewItem = new ListViewItem(new string[] { "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" })
                        {
                            UseItemStyleForSubItems = false
                        };

                        ushort errors = 0;

                        StartMarker musicMarkerStartData = streamedSamples[selectedIndex].StartMarkers[i];
                        listViewItem.Text = i.ToString();
                        listViewItem.SubItems[1].Text = musicMarkerStartData.Index.ToString();
                        listViewItem.SubItems[2].Text = musicMarkerStartData.Position.ToString();
                        switch (musicMarkerStartData.Type)
                        {
                            case 10:
                                listViewItem.SubItems[3].Text = "Start";
                                break;
                            case 9:
                                listViewItem.SubItems[3].Text = "End";
                                break;
                            case 7:
                                listViewItem.SubItems[3].Text = "Goto";
                                break;
                            case 6:
                                listViewItem.SubItems[3].Text = "Loop";
                                break;
                            case 5:
                                listViewItem.SubItems[3].Text = "Pause";
                                break;
                            case 0:
                                listViewItem.SubItems[3].Text = "Jump";
                                break;
                            default:
                                listViewItem.SubItems[3].Text = "Error";
                                break;
                        }
                        listViewItem.SubItems[4].Text = musicMarkerStartData.LoopStart.ToString();
                        listViewItem.SubItems[5].Text = musicMarkerStartData.LoopMarkerCount.ToString();
                        listViewItem.SubItems[6].Text = musicMarkerStartData.MarkerPos.ToString();

                        //Check for errors
                        int streamLenght = streamedSamples[selectedIndex].SampleByteData.Length * 4;

                        if (musicMarkerStartData.Position > streamLenght)
                            errors |= (1 << 2);
                        if (musicMarkerStartData.LoopStart > streamLenght)
                            errors |= (1 << 4);

                        //Change color if we have errors
                        for (int j = 0; j < listViewItem.SubItems.Count; j++)
                        {
                            if (Convert.ToBoolean((errors >> j) & 1))
                                listViewItem.SubItems[j].ForeColor = Color.Red;
                        }
                        ListView_StreamData_StartMarkers.Items.Add(listViewItem);
                    }
                }
                else
                {
                    Textbox_StartMarkers_Count.ForeColor = Color.Red;
                }
                ListView_StreamData_StartMarkers.EndUpdate();

                //Print markers
                ListView_StreamData_Markers.BeginUpdate();
                ListView_StreamData_Markers.Items.Clear();
                if (streamedSamples[selectedIndex].Markers.Count >= 0 && streamedSamples[selectedIndex].Markers.Count <= 20)
                {
                    Textbox_MarkersCount.ForeColor = SystemColors.ControlText;

                    for (int i = 0; i < streamedSamples[selectedIndex].Markers.Count; i++)
                    {
                        //Create listview item
                        ListViewItem listViewItem = new ListViewItem(new string[] { "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" })
                        {
                            UseItemStyleForSubItems = false
                        };

                        ushort errors = 0;
                        Marker musicMarkerStartData = streamedSamples[selectedIndex].Markers[i];
                        listViewItem.Text = i.ToString();
                        listViewItem.SubItems[1].Text = musicMarkerStartData.Index.ToString();
                        listViewItem.SubItems[2].Text = musicMarkerStartData.Position.ToString();
                        switch (musicMarkerStartData.Type)
                        {
                            case 10:
                                listViewItem.SubItems[3].Text = "Start";
                                break;
                            case 9:
                                listViewItem.SubItems[3].Text = "End";
                                break;
                            case 7:
                                listViewItem.SubItems[3].Text = "Goto";
                                break;
                            case 6:
                                listViewItem.SubItems[3].Text = "Loop";
                                break;
                            case 5:
                                listViewItem.SubItems[3].Text = "Pause";
                                break;
                            case 0:
                                listViewItem.SubItems[3].Text = "Jump";
                                break;
                            default:
                                listViewItem.SubItems[3].Text = "Error";
                                break;
                        }
                        listViewItem.SubItems[4].Text = musicMarkerStartData.LoopStart.ToString();
                        listViewItem.SubItems[5].Text = musicMarkerStartData.LoopMarkerCount.ToString();

                        //Check for errors
                        int streamLenght = streamedSamples[selectedIndex].SampleByteData.Length * 4;

                        if (musicMarkerStartData.Position > streamLenght)
                            errors |= (1 << 2);
                        if (musicMarkerStartData.LoopStart > streamLenght)
                            errors |= (1 << 4);


                        //Change color if we have errors
                        for (int j = 0; j < listViewItem.SubItems.Count; j++)
                        {
                            if (Convert.ToBoolean((errors >> j) & 1))
                                listViewItem.SubItems[j].ForeColor = Color.Red;
                        }
                        ListView_StreamData_Markers.Items.Add(listViewItem);
                    }
                }
                else
                {
                    Textbox_MarkersCount.ForeColor = Color.Red;
                }
                ListView_StreamData_Markers.EndUpdate();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ListView_StreamData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<SfxStream> streamedSamples = ((Frm_Main)Application.OpenForms["Frm_Main"]).streamedSamples;
            if (ListView_StreamData.SelectedItems.Count == 1 && streamedSamples != null)
            {
                int selectedIndex = (int)ListView_StreamData.SelectedItems[0].Tag;
                DecodeAndShowPlayer(selectedIndex, streamedSamples);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void DecodeAndShowPlayer(int selectedIndex, List<SfxStream> streamedSamples)
        {
            if (selectedIndex < streamedSamples.Count)
            {
                byte[] decodedData = null;
                if (headerData.FileVersion == 201 || headerData.FileVersion == 1)
                {
                    if (headerData.Platform.Equals("PC") || headerData.Platform.Equals("GC"))
                    {
                        ImaAdpcm imaFile = new ImaAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(imaFile.Decode(streamedSamples[selectedIndex].SampleByteData, streamedSamples[selectedIndex].SampleByteData.Length * 2));
                    }
                    else if (headerData.Platform.Equals("PS2"))
                    {
                        SonyAdpcm vagDecoder = new SonyAdpcm();
                        decodedData = vagDecoder.Decode(streamedSamples[selectedIndex].SampleByteData);
                    }
                    else if (headerData.Platform.Equals("XB"))
                    {
                        XboxAdpcm xboxDecoder = new XboxAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(xboxDecoder.Decode(streamedSamples[selectedIndex].SampleByteData));
                    }
                }
                else
                {
                    if (headerData.Platform.Equals("PC__") || headerData.Platform.Equals("XB__"))
                    {
                        Eurocom_ImaAdpcm eurocomDAT = new Eurocom_ImaAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(streamedSamples[selectedIndex].SampleByteData));
                    }
                    if (headerData.Platform.Equals("GC__"))
                    {
                        Eurocom_ImaAdpcm eurocomDAT = new Eurocom_ImaAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(streamedSamples[selectedIndex].SampleByteData));
                    }
                    else if (headerData.Platform.Equals("PS2_"))
                    {
                        SonyAdpcm vagDecoder = new SonyAdpcm();
                        decodedData = vagDecoder.Decode(streamedSamples[selectedIndex].SampleByteData);
                    }
                }

                //Show player
                if (decodedData != null)
                {
                    Frm_MediaPlayer_Mono sfxPlayer = new Frm_MediaPlayer_Mono(decodedData, streamedSamples[selectedIndex].SampleByteData, frequency);
                    sfxPlayer.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid index, overflows the streams list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void PrintSamplesData(List<SfxStream> streamedSamples)
        {
            ListView_StreamData.BeginUpdate();
            ListView_StreamData.Items.Clear();

            for (int i = 0; i < streamedSamples.Count; i++)
            {
                SfxStream currentSample = streamedSamples[i];
                ushort errors = 0;

                //Create item and add it to list
                ListViewItem listViewItem2 = new ListViewItem(new string[] { i.ToString(), "??", currentSample.BlockPosition.ToString(), currentSample.MarkerSize.ToString(), currentSample.AudioOffset.ToString(), currentSample.AudioSize.ToString(), currentSample.BaseVolume.ToString() })
                {
                    Tag = i
                };

                //Check for errors
                if (currentSample.MarkerSize < 0)
                {
                    errors |= (1 << 3);
                }
                if (currentSample.AudioOffset < 0)
                {
                    errors |= (1 << 4);
                }
                if (currentSample.AudioSize < 0)
                {
                    errors |= (1 << 5);
                }
                if (currentSample.BaseVolume < 0 || currentSample.BaseVolume > 100)
                {
                    errors |= (1 << 6);
                }

                //Red fields
                for (int j = 0; j < 7; j++)
                {
                    if (Convert.ToBoolean((errors >> j) & 1))
                    {
                        listViewItem2.SubItems[j].ForeColor = Color.Red;
                    }
                }
                ListView_StreamData.Items.Add(listViewItem2);
            }

            ListView_StreamData.EndUpdate();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_ValidateADPCM_Click(object sender, EventArgs e)
        {
            ADPCM_Validator_PC validateEurocomIMA = new ADPCM_Validator_PC();
            validateEurocomIMA.ShowDialog();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
