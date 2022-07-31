using System;
using System.IO;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class Frm_ViewProjectFile : Form
    {
        readonly string projectFilePath;

        //-------------------------------------------------------------------------------------------------------------------------------
        public Frm_ViewProjectFile(string filePath)
        {
            InitializeComponent();
            projectFilePath = filePath;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Frm_ViewProjectFile_Shown(object sender, EventArgs e)
        {
            MusXHeaderData MusXheaderData = ((Frm_Main)Application.OpenForms["Frm_Main"]).headerData;
            using (BinaryReader BReader = new BinaryReader(File.Open(projectFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Read Memory Slots Section
                BReader.BaseStream.Seek(MusXheaderData.SFXStart, SeekOrigin.Begin);
                int memmorySlotsCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian);
                int memmorySlotsOffet = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian);
                Textbox_MemmorySlotsCount.Text = memmorySlotsCount.ToString();
                long position1 = BReader.BaseStream.Position;
                BReader.BaseStream.Seek(MusXheaderData.SFXStart + memmorySlotsOffet, SeekOrigin.Begin);

                //Update listview
                ListView_MemmorySlots.BeginUpdate();
                ListView_MemmorySlots.Items.Clear();
                for (int i = 0; i < memmorySlotsCount; i++)
                {
                    ListView_MemmorySlots.Items.Add(new ListViewItem(new string[3]
                    {
                        BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString(),
                        BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString(),
                        BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString()
                    }));
                }
                ListView_MemmorySlots.EndUpdate();

                //Read SoundBanks Section
                BReader.BaseStream.Seek(position1, SeekOrigin.Begin);
                int soundBanksCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian);
                int soundBanksOffset = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian);
                Textbox_SoundBankCount.Text = soundBanksCount.ToString();
                long position2 = BReader.BaseStream.Position;
                BReader.BaseStream.Seek(soundBanksOffset + MusXheaderData.SFXStart, SeekOrigin.Begin);

                //Update Listview
                ListView_SoundBank.BeginUpdate();
                ListView_SoundBank.Items.Clear();
                for (int i = 0; i < soundBanksCount; i++)
                {
                    string[] items = new string[2];
                    int num6 = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian);
                    items[0] = "0x" + num6.ToString("X8");
                    items[1] = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString();
                    ListView_SoundBank.Items.Add(new ListViewItem(items));
                }
                ListView_SoundBank.EndUpdate();

                //Read User Flags Section
                BReader.BaseStream.Seek(position2, SeekOrigin.Begin);
                BReader.BaseStream.Seek(16, SeekOrigin.Current);
                Textbox_StereoStreamCount.Text = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString();
                Textbox_MonoStreamCount.Text = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString();
                Textbox_ProjectCode.Text = BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString();

                //Update listview
                ListView_FlagsValues.BeginUpdate();
                ListView_FlagsValues.Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    ListView_FlagsValues.Items.Add(new ListViewItem(new string[2]
                    {
                      i.ToString(),
                      BinaryFunctions.FlipInt32(BReader.ReadInt32(), MusXheaderData.IsBigEndian).ToString()
                    }));
                }
                ListView_FlagsValues.EndUpdate();
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
