using System;
using System.Drawing;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class Frm_ViewMusicFile : Form
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        private readonly MusicSample musicFileData;
        private readonly string musicFilePath;

        //-------------------------------------------------------------------------------------------------------------------------------
        public Frm_ViewMusicFile(MusicSample musicObj, string filePath)
        {
            InitializeComponent();

            musicFileData = musicObj;
            musicFilePath = filePath;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Frm_ViewMusicFile_Shown(object sender, EventArgs e)
        {
            Textbox_BaseVolume.Text = musicFileData.BaseVolume.ToString();
            Textbox_MusicLength.Text = (musicFileData.SampleByteData_LeftChannel.Length + musicFileData.SampleByteData_RightChannel.Length).ToString();
            Textbox_FilePath.Text = musicFilePath;

            //Print counts
            Textbox_StartMarkers_Count.Text = musicFileData.StartMarkers.Count.ToString();
            Textbox_MarkersCount.Text = musicFileData.StartMarkers.Count.ToString();

            //Clear listview
            ListView_StreamData_StartMarkers.BeginUpdate();
            ListView_StreamData_StartMarkers.Items.Clear();

            //Print Start Markers
            if (musicFileData.StartMarkers.Count >= 0 && musicFileData.StartMarkers.Count <= 20)
            {
                Textbox_StartMarkers_Count.ForeColor = SystemColors.ControlText;

                for (int i = 0; i < musicFileData.StartMarkers.Count; i++)
                {
                    //Create listview item
                    ListViewItem listViewItem = new ListViewItem(new string[] { "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" })
                    {
                        UseItemStyleForSubItems = false
                    };

                    ushort errors = 0;

                    StreamStartMarker musicMarkerStartData = musicFileData.StartMarkers[i];
                    listViewItem.Text = i.ToString();
                    listViewItem.SubItems[1].Text = musicMarkerStartData.Name.ToString();
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
                    int streamLenght = musicFileData.SampleByteData_LeftChannel.Length * 4;

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
            if (musicFileData.Markers.Count >= 0 && musicFileData.Markers.Count <= 20)
            {
                Textbox_MarkersCount.ForeColor = SystemColors.ControlText;

                for (int i = 0; i < musicFileData.Markers.Count; i++)
                {
                    //Create listview item
                    ListViewItem listViewItem = new ListViewItem(new string[] { "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" })
                    {
                        UseItemStyleForSubItems = false
                    };

                    ushort errors = 0;
                    StreamMarker musicMarkerStartData = musicFileData.Markers[i];
                    listViewItem.Text = i.ToString();
                    listViewItem.SubItems[1].Text = musicMarkerStartData.Name.ToString();
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
                    int streamLenght = musicFileData.SampleByteData_LeftChannel.Length * 4;

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

            //ADPCM Validate
            MusXHeaderData MusXheaderData = ((Frm_Main)Application.OpenForms["Frm_Main"]).headerData;
            if ((MusXheaderData.Platform.Contains("PC") || MusXheaderData.Platform.Contains("GC")) && MusXheaderData.FileVersion > 1 && MusXheaderData.FileVersion < 10)
            {
                byte[] ImaDataLeft = musicFileData.SampleByteData_LeftChannel;
                byte[] ImaDataRight = musicFileData.SampleByteData_RightChannel;
                if (ImaDataLeft[3] == 65 && ImaDataRight[3] == 65)
                {
                    Textbox_AdpcmStatus.Text = "ADPCM data is Valid";
                    Textbox_AdpcmStatus.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    Textbox_AdpcmStatus.Text = "ADPCM data is *INVALID*";
                    Textbox_AdpcmStatus.ForeColor = Color.Red;
                }                
            }
            else
            {
                Textbox_AdpcmStatus.Text = "Cannot validate PS2 adpcm...";
                Textbox_AdpcmStatus.ForeColor = SystemColors.ControlText;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_MediaPlayer_Click(object sender, EventArgs e)
        {
            MusXHeaderData MusXheaderData = ((Frm_Main)Application.OpenForms["Frm_Main"]).headerData;
            byte[] decodedDataL = null;
            byte[] decodedDataR = null;
            int frequency = 32000;

            if (MusXheaderData.FileVersion != 201)
            {
                if (MusXheaderData.Platform.Equals("PC__") || MusXheaderData.Platform.Contains("GC__"))
                {
                    Eurocom_ImaAdpcm eurocomDAT = new Eurocom_ImaAdpcm();
                    decodedDataL = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(musicFileData.SampleByteData_LeftChannel));
                    decodedDataR = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(musicFileData.SampleByteData_RightChannel));
                }
                else if (MusXheaderData.Platform.Equals("PS2_"))
                {
                    SonyAdpcm vagDecoder = new SonyAdpcm();
                    decodedDataL = vagDecoder.Decode(musicFileData.SampleByteData_LeftChannel);
                    decodedDataR = vagDecoder.Decode(musicFileData.SampleByteData_RightChannel);
                }
                else if(MusXheaderData.Platform.Equals("XB__"))
                {
                    frequency = 44100;
                    Eurocom_ImaAdpcm xboxDecoder = new Eurocom_ImaAdpcm();
                    decodedDataL = AudioFunctions.ShortArrayToByteArray(xboxDecoder.Decode(musicFileData.SampleByteData_LeftChannel));
                    decodedDataR = AudioFunctions.ShortArrayToByteArray(xboxDecoder.Decode(musicFileData.SampleByteData_RightChannel));
                }
            }

            //Show player
            if (decodedDataL != null && decodedDataR != null)
            {
                MediaPlayer_Stereo sfxPlayer = new MediaPlayer_Stereo(decodedDataL, decodedDataR, frequency);
                sfxPlayer.ShowDialog();
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
