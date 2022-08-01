using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class UserControl_HashCodes : UserControl
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        public UserControl_HashCodes()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void UpdateHashcodesListView(SortedDictionary<uint, SfxSound> samplesList)
        {
            if (samplesList != null && samplesList.Count > 0)
            {
                ListView_HashCodes.BeginUpdate();
                ListView_HashCodes.Items.Clear();

                //Add HashCodes to ListView
                foreach (KeyValuePair<uint, SfxSound> currentSample in samplesList)
                {
                    //Check if hashcode exists
                    ListViewItem listViewItem = new ListViewItem(new string[] { string.Format("0x{0:X8}", currentSample.Key), "*", "" });
                    if (Hashcodes.sound_HashCodes == null)
                    {
                        listViewItem.SubItems[2].Text = "N/A";
                        listViewItem.ForeColor = Color.Red;
                    }
                    else if (Hashcodes.sound_HashCodes.ContainsKey(currentSample.Key))
                    {
                        listViewItem.SubItems[2].Text = Hashcodes.sound_HashCodes[currentSample.Key].ToString();
                    }
                    else
                    {
                        listViewItem.SubItems[2].Text = "Hashcode not found";
                        listViewItem.ForeColor = Color.Red;
                    }
                    listViewItem.Tag = currentSample.Key;
                    ListView_HashCodes.Items.Add(listViewItem);
                }

                ListView_HashCodes.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                ListView_HashCodes.EndUpdate();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ListView_HashCodes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ListView_HashCodes.SelectedItems.Count == 1)
            {
                MusXHeaderData MusXheaderData = ((Frm_Main)Application.OpenForms["Frm_Main"]).headerData;
                SortedDictionary<uint, SfxSound> samplesDictionary = ((Frm_Main)Application.OpenForms["Frm_Main"]).samplesList;
                List<SfxData> wavHeaderData = ((Frm_Main)Application.OpenForms["Frm_Main"]).wavesList;
                UserControl_Samples_Properties samplePropsControl = ((Frm_Main)Application.OpenForms["Frm_Main"]).UserControl_SampleProperties;

                //Update textbox name
                ((Frm_Main)Application.OpenForms["Frm_Main"]).Textbox_HashcodeName.Text = ListView_HashCodes.SelectedItems[0].SubItems[2].Text;

                //Get Hashcode UInteger
                uint selectedHashCode = (uint)ListView_HashCodes.SelectedItems[0].Tag;

                //Update parameters control
                if (samplesDictionary.ContainsKey(selectedHashCode))
                {
                    samplePropsControl.ClearControls();

                    //Get sample data
                    SfxSound sampleData = samplesDictionary[selectedHashCode];

                    //Update Textboxes
                    if (MusXheaderData.FileVersion == 201 || MusXheaderData.FileVersion == 1)
                    {
                        switch (sampleData.TrackingType)
                        {
                            case 0:
                                samplePropsControl.Textbox_TrackingType.Text = "2D";
                                break;
                            case 1:
                                samplePropsControl.Textbox_TrackingType.Text = "2D AMB ";
                                break;
                            case 2:
                                samplePropsControl.Textbox_TrackingType.Text = "3D";
                                break;
                            case 3:
                                samplePropsControl.Textbox_TrackingType.Text = "3D RND POS";
                                break;
                            case 4:
                                samplePropsControl.Textbox_TrackingType.Text = "2D PL2";
                                break;
                        }
                    }
                    else
                    {
                        /*00 = 2D
                        01 = 3D
                        02 = 2D AMB
                        03 = 3D AMB
                        04 = 2D RND
                        05 = 3D RND
                        06 = 2D AMB RND
                        07 = 3D AMB RND
                        08 = 2D NT
                        09 = 3D NT*/
                        StringBuilder stringBuilder1 = new StringBuilder();
                        if ((sbyte)(sampleData.TrackingType & 1) != 0)
                            stringBuilder1.Append("3D ");
                        else
                            stringBuilder1.Append("2D ");
                        if ((sbyte)(sampleData.TrackingType & 2) != 0)
                            stringBuilder1.Append("AMB ");
                        if ((sbyte)(sampleData.TrackingType & 4) != 0)
                            stringBuilder1.Append("RND ");
                        if ((sbyte)(sampleData.TrackingType & 8) != 0)
                            stringBuilder1.Append("NT ");
                        samplePropsControl.Textbox_TrackingType.Text = stringBuilder1.ToString();
                    }
                    samplePropsControl.Textbox_MinDelay.Text = sampleData.MinDelay.ToString();
                    samplePropsControl.Textbox_MaxDelay.Text = sampleData.MaxDelay.ToString();
                    samplePropsControl.Textbox_ReverbSend.Text = sampleData.ReverbSend.ToString();
                    samplePropsControl.Textbox_MaxVoices.Text = sampleData.MaxVoices.ToString();
                    samplePropsControl.Textbox_Priority.Text = sampleData.Priority.ToString();
                    samplePropsControl.Textbox_Ducker.Text = sampleData.Ducker.ToString();
                    samplePropsControl.Textbox_MasterVolume.Text = sampleData.MasterVolume.ToString();
                    if (MusXheaderData.FileVersion > 2 && MusXheaderData.FileVersion < 10)
                    {
                        samplePropsControl.Textbox_GroupHashcode.Text = sampleData.GroupHashCode.ToString("X");
                        samplePropsControl.Textbox_GroupMaxChannels.Text = sampleData.GroupMaxChannels.ToString();
                    }
                    else
                    {
                        samplePropsControl.Textbox_GroupHashcode.Text = "N/A";
                        samplePropsControl.Textbox_GroupMaxChannels.Text = "N/A";
                    }
                    if (MusXheaderData.FileVersion > 5 && MusXheaderData.FileVersion < 15)
                    {
                        samplePropsControl.Textbox_Doppler.Text = sampleData.DopplerValue.ToString();
                        samplePropsControl.Textbox_UserValue.Text = sampleData.UserValue.ToString();
                    }
                    else
                    {
                        samplePropsControl.Textbox_Doppler.Text = "N/A";
                        samplePropsControl.Textbox_UserValue.Text = "N/A";
                    }
                    samplePropsControl.Textbox_DuckerLength.Text = sampleData.DuckerLenght.ToString();
                    if (MusXheaderData.FileVersion > 5 && MusXheaderData.FileVersion < 15)
                    {
                        samplePropsControl.Textbox_SFXDucker.Text = sampleData.SFXDucker.ToString();
                        samplePropsControl.Textbox_Spare.Text = sampleData.Spare.ToString();
                    }
                    else
                    {
                        samplePropsControl.Textbox_SFXDucker.Text = "N/A";
                        samplePropsControl.Textbox_Spare.Text = "N/A";
                    }
                    if (MusXheaderData.FileVersion == 201 || MusXheaderData.FileVersion == 1)
                    {
                        samplePropsControl.Textbox_InnerRadius.Text = sampleData.InnerRadius.ToString();
                        samplePropsControl.Textbox_OuterRadius.Text = sampleData.OuterRadius.ToString();
                    }
                    else
                    {
                        samplePropsControl.Textbox_InnerRadius.Text = "N/A";
                        samplePropsControl.Textbox_OuterRadius.Text = "N/A";
                    }

                    //Update Flags
                    for (int i = 0; i < samplePropsControl.CheckedListBox_SampleFlags.Items.Count; i++)
                    {
                        samplePropsControl.CheckedListBox_SampleFlags.SetItemChecked(i, Convert.ToBoolean((sampleData.Flags >> i) & 1));
                    }

                    //Update User Flags
                    for (int i = 0; i < samplePropsControl.CheckedListBox_UserFlags.Items.Count; i++)
                    {
                        samplePropsControl.CheckedListBox_UserFlags.SetItemChecked(i, Convert.ToBoolean((sampleData.UserFlags >> i) & 1));
                    }

                    //Update Sample Pool
                    samplePropsControl.Textbox_SampleCount.Text = sampleData.samplesList.Count.ToString();
                    foreach (SfxSample samplePoolItem in sampleData.samplesList)
                    {
                        ListViewItem listViewItem = new ListViewItem(new string[] { "", "", "", "", "", "", "" });
                        short finalFileRef = samplePoolItem.FileRef;

                        //Check for SubSFX
                        if (Convert.ToBoolean((sampleData.Flags >> 10) & 1))
                        {
                            if (finalFileRef < 0)
                            {
                                //Apply 0x3FFF and turn it into negative to be detected by the tool as a stream file.
                                if (MusXheaderData.FileVersion > 5)
                                {
                                    finalFileRef = (short)((samplePoolItem.FileRef & 0x3FFF) * -1);
                                }
                                listViewItem.Text = "Stream: " + finalFileRef;
                            }
                            else if (Hashcodes.sound_HashCodes == null)
                            {
                                listViewItem.Text = finalFileRef.ToString();
                            }
                            else
                            {
                                //Find HashCode Section
                                uint hashcodeToCheck;
                                switch (MusXheaderData.FileVersion)
                                {
                                    case 201:
                                        hashcodeToCheck = (uint)(0x1A000000 | (ushort)finalFileRef);
                                        break;
                                    case 6:
                                        hashcodeToCheck = (uint)(0x2D700000 | (ushort)finalFileRef);
                                        break;
                                    default:
                                        hashcodeToCheck = (uint)(0x1AF00000 | (ushort)finalFileRef);
                                        break;
                                }

                                //Print HashCode
                                if (Hashcodes.sound_HashCodes.ContainsKey(hashcodeToCheck))
                                {
                                    listViewItem.Text = Hashcodes.sound_HashCodes[hashcodeToCheck].ToString();
                                    listViewItem.SubItems[0].ForeColor = SystemColors.ControlText;
                                }
                                else
                                {
                                    listViewItem.Text = "0x" + hashcodeToCheck.ToString("X8");
                                    listViewItem.UseItemStyleForSubItems = false;
                                    listViewItem.SubItems[0].ForeColor = Color.Red;
                                }
                            }
                        }
                        else if (finalFileRef < 0)
                        {
                            //Apply 0x3FFF and turn it into negative to be detected by the tool as a stream file.
                            if (MusXheaderData.FileVersion > 5)
                            {
                                finalFileRef = (short)((samplePoolItem.FileRef & 0x3FFF) * -1);
                            }
                            listViewItem.Text = "Stream: " + finalFileRef;
                        }
                        else
                        {
                            if (finalFileRef > wavHeaderData.Count)
                            {
                                listViewItem.UseItemStyleForSubItems = false;
                                listViewItem.SubItems[0].ForeColor = Color.Red;
                            }
                            listViewItem.Text = "Wav: " + finalFileRef;
                        }
                        listViewItem.SubItems[1].Text = samplePoolItem.Volume.ToString();
                        listViewItem.SubItems[2].Text = samplePoolItem.VolumeOffset.ToString();
                        if (MusXheaderData.FileVersion == 201 || MusXheaderData.FileVersion == 1)
                        {
                            listViewItem.SubItems[3].Text = decimal.Divide(samplePoolItem.OldMusXPitch, 1024).ToString();
                            listViewItem.SubItems[4].Text = decimal.Divide(samplePoolItem.OldMusXPitchOffset, 1024).ToString();
                        }
                        else
                        {
                            float finalPitch = samplePoolItem.Pitch * 0.2f;
                            listViewItem.SubItems[3].Text = finalPitch.ToString();

                            float finalPitchOffset = samplePoolItem.PitchOffset * 0.1f;
                            listViewItem.SubItems[4].Text = finalPitchOffset.ToString();
                        }
                        listViewItem.SubItems[5].Text = samplePoolItem.Pan.ToString();
                        listViewItem.SubItems[6].Text = samplePoolItem.PanOffset.ToString();
                        listViewItem.Tag = finalFileRef;

                        //Add item to listview
                        samplePropsControl.ListView_SamplePool.Items.Add(listViewItem);
                    }

                    //Update Hex Viewer
                    ((Frm_Main)Application.OpenForms["Frm_Main"]).UserControl_HexEditor.UpdateHexViewer(sampleData.HexViewerData, MusXheaderData.FileVersion);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ContextMenuItem_CopyName_Click(object sender, EventArgs e)
        {
            if (ListView_HashCodes.SelectedItems.Count != 0)
            {
                Clipboard.SetText(ListView_HashCodes.SelectedItems[0].SubItems[2].Text);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ContextMenuItem_CopyHashCode_Click(object sender, EventArgs e)
        {
            if (ListView_HashCodes.SelectedItems.Count != 0)
            {
                Clipboard.SetText(ListView_HashCodes.SelectedItems[0].SubItems[0].Text);
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
