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
            if (OpenFileDiag_SfxFiles.ShowDialog() == DialogResult.OK)
            {
                headerData = new MusXHeaderData();
                samplesList = new SortedDictionary<uint, Sample>();
                wavesList = new List<WavHeaderData>();

                //Read Header and make sure is a valid MUSX file
                MusxHeader sfxHeaderData = new MusxHeader();
                if (sfxHeaderData.ReadSoundBankHeader(OpenFileDiag_SfxFiles.FileName, headerData))
                {
                    if (headerData.FileVersion != 201)
                    {
                        //Read file data
                        NewMusX newSoundbanksFile = new NewMusX();
                        newSoundbanksFile.ReadSoundbank(OpenFileDiag_SfxFiles.FileName, headerData, samplesList, wavesList);

                        //Update Flags
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.Clear();
                        UserControl_SampleProperties.CheckedListBox_SampleFlags.Items.AddRange(new string[] { "MaxReject", "UnPausable", "IgnoreMasterVolume", "MultiSample", "RandomPick", "Shuffled", "Loop", "Polyphonic", "UnderWater", "PauseInstant", "HasSubSfx", "StealOnLouder", "TreatLikeMusic", "KillMeOwnGroup", "GroupStealReject", "OneInstancePerFrame" });
                    }

                    //Update Status Bar
                    StatusLabel_HashCode.Text = "HashCode: " + "0x" + headerData.FileHashCode.ToString("X8");
                    StatusLabel_Version.Text = "Version: " + headerData.FileVersion;
                    StatusLabel_Platform.Text = "Platform: " + headerData.Platform;

                    //Update Main Textboxes
                    Textbox_SoundbankName.Text = OpenFileDiag_SfxFiles.FileName;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(@"C:\Users\Jordi Martinez\Desktop\Soundbanks Tests\list.txt"))
            {
                string[] SFXFiles = Directory.GetFiles(@"C:\Users\Jordi Martinez\Desktop\Soundbanks Tests\PS2 - Robots [PAL] [Es,Fr,De,En,It]", "*.sfx", SearchOption.AllDirectories);
                for (int i = 0; i < SFXFiles.Length; i++)
                {
                    string pathToRead = SFXFiles[i];
                    FileInfo fi = new FileInfo(pathToRead);
                    string[] breakPath = pathToRead.Split('\\');
                    string[] shortPath = new string[breakPath.Length - 7];
                    Array.Copy(breakPath, 7, shortPath, 0, shortPath.Length);

                    using (BinaryReader BReader = new BinaryReader(File.Open(pathToRead, FileMode.Open, FileAccess.Read, FileShare.Read)))
                    {
                        BReader.BaseStream.Seek(20, SeekOrigin.Begin);
                        uint timestamp = BReader.ReadUInt32();
                        sw.WriteLine(string.Format("{0};{1};{2};{3}", Path.GetDirectoryName(string.Join("\\", shortPath)), Path.GetFileName(pathToRead), timestamp.ToString("X8"), fi.Length.ToString() + " Bytes"));
                    }
                }
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
