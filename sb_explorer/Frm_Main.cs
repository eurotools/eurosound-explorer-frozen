using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class Frm_Main : Form
    {
        internal MusXHeaderData headerData;
        internal SortedDictionary<uint, SfxSound> samplesList;
        internal List<SfxData> wavesList;
        private IEnumerator SearchEnumerator;
        private Regex SearchRegEx;

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
                LoadSoundbank(OpenFileDiag_SoundbankFiles.FileName);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void LoadSoundbank(string filePath)
        {
            try
            {
                samplesList = new SortedDictionary<uint, SfxSound>();
                wavesList = new List<SfxData>();
                MusxHeader sfxHeaderData = new MusxHeader();
                int fileVersion = sfxHeaderData.ReadFileVersion(filePath);

                //Read Header and make sure is a valid MUSX file
                headerData = new MusXHeaderData();
                if (fileVersion == 201 || fileVersion == 1)
                {
                    Frm_ChoosePlatform specifyPlatform = new Frm_ChoosePlatform(filePath);
                    if (specifyPlatform.ShowDialog() == DialogResult.OK)
                    {
                        headerData.Platform = specifyPlatform.Combobox_Platform.Text;
                    }
                }

                //Read file
                if (sfxHeaderData.ReadSoundBankHeader(filePath, headerData) && headerData.Platform != null)
                {
                    if (headerData.FileVersion == 201 || headerData.FileVersion == 1)
                    {
                        //Read file data
                        OldMusX newSoundbanksFile = new OldMusX();
                        newSoundbanksFile.ReadSoundbank(filePath, headerData, samplesList, wavesList);

                        //Update Flags
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.Clear();
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.AddRange(new string[] { "MaxReject", "NextFreeOneToUse", "IgnoreAge", "MultiSample", "RandomPick", "Shuffled", "Loop", "Polyphonic", "UnderWater", "PauseInNis", "HasSubSfx", "StealOnLouder", "TreatLikeMusic", "UserFlags14", "UserFlags15", "UserFlags16" });
                    }
                    else
                    {
                        //Read file data
                        NewMusX newSoundbanksFile = new NewMusX();
                        newSoundbanksFile.ReadSoundbank(filePath, headerData, samplesList, wavesList);

                        //Update Flags
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.Clear();
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.AddRange(new string[] { "MaxReject", "UnPausable", "IgnoreMasterVolume", "MultiSample", "RandomPick", "Shuffled", "Loop", "Polyphonic", "UnderWater", "PauseInstant", "HasSubSfx", "StealOnLouder", "TreatLikeMusic", "KillMeOwnGroup", "GroupStealReject", "OneInstancePerFrame" });
                    }

                    //Update Status Bar
                    StatusLabel_HashCode.Text = "HashCode: " + "0x" + headerData.FileHashCode.ToString("X8");
                    StatusLabel_Version.Text = "Version: " + headerData.FileVersion;
                    StatusLabel_Platform.Text = "Platform: " + headerData.Platform;

                    //Update Main Textboxes
                    Textbox_SoundbankName.Text = filePath;
                    Textbox_HashcodeName.Text = string.Empty;

                    //Hashcodes listview
                    UserControl_Hashcode.UpdateHashcodesListView(samplesList);
                    UserControl_WavHeaderData.UpdateWavHeaderData(wavesList);
                }
            }
            catch (Exception ex)
            {
                //Clear all controls
                UserControl_Hashcode.ListView_HashCodes.Items.Clear();
                UserControl_SampleProperties.ClearControls();
                UserControl_HexEditor.ListView_HexEditor.Items.Clear();
                UserControl_WavHeaderData.ListView_WavData.Items.Clear();

                //Inform user about this error
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Button_ReloadSoundbank_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Textbox_SoundbankName.Text))
            {
                LoadSoundbank(Textbox_SoundbankName.Text);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_File_ViewMusicFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFileDialog_MusicFiles.ShowDialog() == DialogResult.OK)
                {
                    MusxHeader sfxHeaderData = new MusxHeader();
                    int fileVersion = sfxHeaderData.ReadFileVersion(OpenFileDialog_MusicFiles.FileName);

                    //Read Header and make sure is a valid MUSX file
                    headerData = new MusXHeaderData();
                    if (fileVersion == 201 || fileVersion == 1)
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
                            Frm_ViewMusicFile musicsForm = new Frm_ViewMusicFile(musicDat, headerData, OpenFileDialog_MusicFiles.FileName);
                            musicsForm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_File_ViewProjectFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFileDiag_ProjectFiles.ShowDialog() == DialogResult.OK)
                {
                    MusxHeader sfxHeaderData = new MusxHeader();
                    int fileVersion = sfxHeaderData.ReadFileVersion(OpenFileDiag_ProjectFiles.FileName);

                    //Read Header and make sure is a valid MUSX file
                    headerData = new MusXHeaderData();

                    //Read file
                    if (sfxHeaderData.ReadSoundBankHeader(OpenFileDiag_ProjectFiles.FileName, headerData) && headerData.Platform != null)
                    {
                        //Read Data
                        NewMusX projectFilesReader = new NewMusX();
                        ProjectFile projectDat = projectFilesReader.ReadProjectFile(OpenFileDiag_ProjectFiles.FileName, headerData);
                        //Show form
                        using (Frm_ViewProjectFile projectFile = new Frm_ViewProjectFile(projectDat))
                        {
                            projectFile.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_File_SetSoundH_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_View_FindHashCode_Click(object sender, EventArgs e)
        {
            //Show form
            using (FindHashCode findHashcode = new FindHashCode())
            {
                if (findHashcode.ShowDialog() == DialogResult.OK)
                {
                    UserControl_Hashcode.ListView_HashCodes.Focus();
                    SearchHashcodes(findHashcode.Textbox_TextSearch.Text);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        public void SearchHashcodes(string str)
        {
            //Start iterating
            SearchEnumerator = UserControl_Hashcode.ListView_HashCodes.Items.GetEnumerator();
            SearchRegEx = new Regex(str, RegexOptions.IgnoreCase);
            if (!SearchEnumerator.MoveNext())
            {
                return;
            }

            //Search items
            ListViewItem listViewItem;
            while (true)
            {
                listViewItem = SearchEnumerator.Current as ListViewItem;
                if (SearchRegEx.Match(listViewItem.SubItems[2].Text).Success)
                {
                    break;
                }
                if (!SearchEnumerator.MoveNext())
                {
                    return;
                }
            }

            //Select item
            UserControl_Hashcode.ListView_HashCodes.EnsureVisible(listViewItem.Index);
            if (UserControl_Hashcode.ListView_HashCodes.SelectedItems.Count != 0)
            {
                UserControl_Hashcode.ListView_HashCodes.SelectedItems[0].Selected = false;
            }
            listViewItem.Selected = true;
            listViewItem.Focused = true;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_View_FindNext_Click(object sender, EventArgs e)
        {
            //Check that the search is not null
            if (SearchEnumerator == null || SearchRegEx == null)
            {
                return;
            }

            //Select item
            if (SearchEnumerator.MoveNext())
            {
                do
                {
                    ListViewItem listViewItem = SearchEnumerator.Current as ListViewItem;
                    if (SearchRegEx.Match(listViewItem.SubItems[2].Text).Success)
                    {
                        UserControl_Hashcode.ListView_HashCodes.EnsureVisible(listViewItem.Index);
                        if (UserControl_Hashcode.ListView_HashCodes.SelectedItems.Count != 0)
                        {
                            UserControl_Hashcode.ListView_HashCodes.SelectedItems[0].Selected = false;
                        }
                        listViewItem.Selected = true;
                        listViewItem.Focused = true;
                        return;
                    }
                }
                while (SearchEnumerator.MoveNext());
            }

            //Inform user
            MessageBox.Show("No more occurrences Found!", "Find Hashcodes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SearchEnumerator = UserControl_Hashcode.ListView_HashCodes.Items.GetEnumerator();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_About_About_Click(object sender, EventArgs e)
        {
            using (Frm_About aboutForm = new Frm_About())
            {
                aboutForm.ShowDialog();
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
