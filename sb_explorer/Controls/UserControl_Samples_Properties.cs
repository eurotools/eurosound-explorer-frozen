﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class UserControl_Samples_Properties : UserControl
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        public UserControl_Samples_Properties()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void ClearControls()
        {
            Textbox_TrackingType.Text = "0";
            Textbox_MinDelay.Text = "0";
            Textbox_MaxDelay.Text = "0";
            Textbox_ReverbSend.Text = "0";
            Textbox_GroupHashcode.Text = "0";
            Textbox_MaxVoices.Text = "0";
            Textbox_Priority.Text = "0";
            Textbox_Ducker.Text = "0";
            Textbox_MasterVolume.Text = "0";
            Textbox_GroupMaxChannels.Text = "0";
            Textbox_Doppler.Text = "0";
            Textbox_UserValue.Text = "0";
            Textbox_DuckerLength.Text = "0";
            Textbox_SFXDucker.Text = "0";
            Textbox_Spare.Text = "0";
            Textbox_InnerRadius.Text = "0";
            Textbox_OuterRadius.Text = "0";
            Textbox_SampleCount.Text = "0";
            ListView_SamplePool.Items.Clear();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ListView_SamplePool_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabControl tabPanel = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).TabControl;
            TabPage Tab_Wav_Head_Data = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).TabPage_WavHeaderData;
            TabPage Tab_Stream_Data = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).TabPage_StreamData;
            ListView_ColumnSortingClick ListView_WavData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).UserControl_WavHeaderData.ListView_WavData;
            ListView_ColumnSortingClick ListView_StreamData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).userControl_StreamData1.ListView_StreamData;

            if (ListView_SamplePool.SelectedIndices.Count != 0)
            {
                //Get index
                short fileRef = (short)ListView_SamplePool.SelectedItems[0].Tag;
                if (fileRef >= 0 && CheckedListBox_SampleFlags.GetItemCheckState(10) == CheckState.Unchecked)
                {
                    //Select tab
                    if (tabPanel.SelectedTab != Tab_Wav_Head_Data)
                    {
                        tabPanel.SelectedTab = Tab_Wav_Head_Data;
                    }

                    //Unselect all items
                    ListView_WavData.SelectedItems.Clear();

                    //Select item
                    foreach (ListViewItem itemToCheck in ListView_WavData.Items)
                    {
                        if (itemToCheck.SubItems[0].Text.Equals(fileRef.ToString()))
                        {
                            itemToCheck.Selected = true;
                            itemToCheck.Focused = true;
                            itemToCheck.EnsureVisible();
                            ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).UserControl_WavHeaderData.DecodeAndShowPlayer((int)itemToCheck.Tag);
                            break;
                        }
                    }
                }
                else if (fileRef < 0 && CheckedListBox_SampleFlags.GetItemCheckState(10) == CheckState.Unchecked)
                {
                    List<SfxStream> streamedSamples = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).streamedSamples;

                    if (streamedSamples != null && streamedSamples.Count > 0)
                    {
                        short positiveNumber = (short)(Math.Abs(fileRef) - 1);

                        //Select tab
                        if (tabPanel.SelectedTab != Tab_Stream_Data)
                        {
                            tabPanel.SelectedTab = Tab_Stream_Data;
                        }

                        //Unselect all items
                        ListView_StreamData.SelectedItems.Clear();

                        //Select file
                        foreach (ListViewItem itemToCheck in ListView_StreamData.Items)
                        {
                            if (itemToCheck.SubItems[0].Text.Equals(positiveNumber.ToString()))
                            {
                                itemToCheck.Selected = true;
                                itemToCheck.Focused = true;
                                itemToCheck.EnsureVisible();
                                ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).userControl_StreamData1.DecodeAndShowPlayer(positiveNumber, streamedSamples);
                                break;
                            }
                        }
                    }
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_SaveWav_Click(object sender, EventArgs e)
        {
            ListView_ColumnSortingClick ListView_WavData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).UserControl_WavHeaderData.ListView_WavData;
            ListView_ColumnSortingClick ListView_HashCodes = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).UserControl_Hashcode.ListView_HashCodes;
            ListView_ColumnSortingClick ListView_StreamData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).userControl_StreamData1.ListView_StreamData;

            if (ListView_SamplePool.SelectedIndices.Count != 0 && ListView_HashCodes.SelectedItems.Count > 0)
            {
                //Get index
                short fileRef = (short)ListView_SamplePool.SelectedItems[0].Tag;
                if (fileRef >= 0 && CheckedListBox_SampleFlags.GetItemCheckState(10) == CheckState.Unchecked)
                {
                    //Select item
                    foreach (ListViewItem itemToCheck in ListView_WavData.Items)
                    {
                        if (itemToCheck.SubItems[0].Text.Equals(fileRef.ToString()))
                        {
                            DecodeAndSave((int)itemToCheck.Tag, ListView_HashCodes.SelectedItems[0].SubItems[2].Text);
                            break;
                        }
                    }
                }
                else if (fileRef < 0 && CheckedListBox_SampleFlags.GetItemCheckState(10) == CheckState.Unchecked)
                {
                    List<SfxStream> streamedSamples = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).streamedSamples;

                    if (streamedSamples != null && streamedSamples.Count > 0)
                    {
                        short positiveNumber = (short)(Math.Abs(fileRef) - 1);

                        //Select file
                        foreach (ListViewItem itemToCheck in ListView_StreamData.Items)
                        {
                            if (itemToCheck.SubItems[0].Text.Equals(positiveNumber.ToString()))
                            {
                                ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).userControl_StreamData1.DecodeAndSave(positiveNumber, streamedSamples, saveSamplesDiag, ListView_HashCodes.SelectedItems[0].SubItems[2].Text);
                                break;
                            }
                        }
                    }
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void DecodeAndSave(int selectedIndex, string hashCodeName)
        {
            List<SfxData> wavHeaderData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).wavesList;

            //Decode and Show Save Form
            byte[] decodedData = CommonFunctions.DecodeSfxSound(wavHeaderData[selectedIndex]);
            if (decodedData != null)
            {
                saveSamplesDiag.FileName = hashCodeName;
                DialogResult diagResult = saveSamplesDiag.ShowDialog();
                if (diagResult == DialogResult.OK)
                {
                    IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(decodedData), new WaveFormat(wavHeaderData[selectedIndex].Frequency, 16, 1));
                    WaveFileWriter.CreateWaveFile(saveSamplesDiag.FileName, provider);
                }
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
