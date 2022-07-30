using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class Frm_Main : Form
    {
        internal MusXHeaderData headerData;
        internal SortedDictionary<uint, Sample> samplesList;
        internal List<WavHeaderData> wavesList;

        //-------------------------------------------------------------------------------------------------------------------------------
        public Frm_Main()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_File_LoadSoundBank_Click(object sender, EventArgs e)
        {
            if (OpenFileDiag_SoundbankFiles.ShowDialog() == DialogResult.OK)
            {
                samplesList = new SortedDictionary<uint, Sample>();
                wavesList = new List<WavHeaderData>();
                MusxHeader sfxHeaderData = new MusxHeader();
                int fileVersion = sfxHeaderData.ReadFileVersion(OpenFileDiag_SoundbankFiles.FileName);

                //Read Header and make sure is a valid MUSX file
                headerData = new MusXHeaderData();
                if ((fileVersion == 201 || fileVersion == 1) && fileVersion > 0)
                {
                    Frm_ChoosePlatform specifyPlatform = new Frm_ChoosePlatform(OpenFileDiag_SoundbankFiles.FileName);
                    if (specifyPlatform.ShowDialog() == DialogResult.OK)
                    {
                        headerData.Platform = specifyPlatform.Combobox_Platform.Text;
                    }
                }

                //Read file
                if (sfxHeaderData.ReadSoundBankHeader(OpenFileDiag_SoundbankFiles.FileName, headerData) && headerData.Platform != null)
                {
                    if (headerData.FileVersion == 201 || headerData.FileVersion == 1)
                    {
                        //Read file data
                        OldMusX newSoundbanksFile = new OldMusX();
                        newSoundbanksFile.ReadSoundbank(OpenFileDiag_SoundbankFiles.FileName, headerData, samplesList, wavesList);

                        //Update Flags
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.Clear();
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.AddRange(new string[] { "MaxReject", "NextFreeOneToUse", "IgnoreAge", "MultiSample", "RandomPick", "Shuffled", "Loop", "Polyphonic", "UnderWater", "PauseInNis", "HasSubSfx", "StealOnLouder", "TreatLikeMusic", "UserFlags14", "UserFlags15", "UserFlags16" });
                    }
                    else
                    { 
                        //Read file data
                        NewMusX newSoundbanksFile = new NewMusX();
                        newSoundbanksFile.ReadSoundbank(OpenFileDiag_SoundbankFiles.FileName, headerData, samplesList, wavesList);

                        //Update Flags
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.Clear();
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.AddRange(new string[] { "MaxReject", "UnPausable", "IgnoreMasterVolume", "MultiSample", "RandomPick", "Shuffled", "Loop", "Polyphonic", "UnderWater", "PauseInstant", "HasSubSfx", "StealOnLouder", "TreatLikeMusic", "KillMeOwnGroup", "GroupStealReject", "OneInstancePerFrame" });
                    }

                    //Update Status Bar
                    StatusLabel_HashCode.Text = "HashCode: " + "0x" + headerData.FileHashCode.ToString("X8");
                    StatusLabel_Version.Text = "Version: " + headerData.FileVersion;
                    StatusLabel_Platform.Text = "Platform: " + headerData.Platform;

                    //Update Main Textboxes
                    Textbox_SoundbankName.Text = OpenFileDiag_SoundbankFiles.FileName;
                    Textbox_HashcodeName.Text = string.Empty;

                    //Hashcodes listview
                    UserControl_Hashcode.UpdateHashcodesListView(samplesList);
                    UserControl_WavHeaderData.UpdateWavHeaderData(wavesList);
                }

            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_File_SetSoundH_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = Path.Combine(FolderBrowserDialog.SelectedPath, "Sound.h");
                if (File.Exists(filePath))
                {
                    Hashcodes.Read_Sound_h(filePath);

                    //Enable search menu items
                    MenuItem_View_FindHashCode.Enabled = true;
                    MenuItem_View_FindNext.Enabled = true;

                    //Update hashcodes
                    UserControl_Hashcode.UpdateHashcodesListView(samplesList);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_File_ViewMusicFile_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog_MusicFiles.ShowDialog() == DialogResult.OK)
            {
                MusxHeader sfxHeaderData = new MusxHeader();
                int fileVersion = sfxHeaderData.ReadFileVersion(OpenFileDialog_MusicFiles.FileName);

                //Read Header and make sure is a valid MUSX file
                headerData = new MusXHeaderData();
                if ((fileVersion == 201 || fileVersion == 1) && fileVersion > 0)
                {
                    Frm_ChoosePlatform specifyPlatform = new Frm_ChoosePlatform(OpenFileDialog_MusicFiles.FileName);
                    if (specifyPlatform.ShowDialog() == DialogResult.OK)
                    {
                        headerData.Platform = specifyPlatform.Combobox_Platform.Text;
                    }
                }

                //Read file
                if (sfxHeaderData.ReadStreamBankHeader(OpenFileDialog_MusicFiles.FileName, headerData) && headerData.Platform != null)
                {
                    MusicSample musicDat = null;

                    //Sphinx & Athens 2004
                    if (headerData.FileVersion == 201 || headerData.FileVersion == 1)
                    {
                        OldMusX musicFilesReader = new OldMusX();
                        switch (headerData.Platform)
                        {
                            case "PC":
                                musicDat = musicFilesReader.ReadMusicBank(OpenFileDialog_MusicFiles.FileName, headerData, 1);
                                break;
                            case "PS2":
                                musicDat = musicFilesReader.ReadMusicBank(OpenFileDialog_MusicFiles.FileName, headerData, 128);
                                break;
                            case "GC":
                                musicDat = musicFilesReader.ReadMusicBank(OpenFileDialog_MusicFiles.FileName, headerData, 1);
                                break;
                            case "XB":
                                musicDat = musicFilesReader.ReadMusicBank(OpenFileDialog_MusicFiles.FileName, headerData, 4);
                                break;
                        }
                    }
                    else
                    {
                        NewMusX musicFilesReader = new NewMusX();
                        switch (headerData.Platform)
                        {
                            case "PC__":
                                musicDat = musicFilesReader.ReadMusicFile(OpenFileDialog_MusicFiles.FileName, headerData, 32);
                                break;
                            case "PS2_":
                                musicDat = musicFilesReader.ReadMusicFile(OpenFileDialog_MusicFiles.FileName, headerData, 128);
                                break;
                            case "GC__":
                                musicDat = musicFilesReader.ReadMusicFile(OpenFileDialog_MusicFiles.FileName, headerData, 32);
                                break;
                            case "XB__":
                                musicDat = musicFilesReader.ReadMusicFile(OpenFileDialog_MusicFiles.FileName, headerData, 32);
                                break;
                            case "XB1_":
                                musicDat = musicFilesReader.ReadMusicFile(OpenFileDialog_MusicFiles.FileName, headerData, 32);
                                break;
                        }
                    }

                    //Open form
                    if (musicDat != null)
                    {
                        Frm_ViewMusicFile musicsForm = new Frm_ViewMusicFile(musicDat, OpenFileDialog_MusicFiles.FileName);
                        musicsForm.ShowDialog();
                    }
                }
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
