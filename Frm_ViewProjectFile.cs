using System;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class Frm_ViewProjectFile : Form
    {
        readonly ProjectFile projectFileData;

        //-------------------------------------------------------------------------------------------------------------------------------
        public Frm_ViewProjectFile(ProjectFile projectData)
        {
            InitializeComponent();
            projectFileData = projectData;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void Frm_ViewProjectFile_Shown(object sender, EventArgs e)
        {
            Textbox_MemmorySlotsCount.Text = projectFileData.MemmorySlotsCount.ToString();

            //Update listview
            ListView_MemmorySlots.BeginUpdate();
            ListView_MemmorySlots.Items.Clear();
            for (int i = 0; i < projectFileData.MemmorySlotsCount; i++)
            {
                ProjectSlots currentMemSlot = projectFileData.memorySlotsData[i];
                ListView_MemmorySlots.Items.Add(new ListViewItem(new string[]
                {
                    currentMemSlot.SlotNumber.ToString(),
                    currentMemSlot.MemorySize.ToString(),
                    currentMemSlot.Quantity.ToString(),
                }));
            }
            ListView_MemmorySlots.EndUpdate();

            //Read SoundBanks Section
            Textbox_SoundBankCount.Text = projectFileData.soundBanksCount.ToString();

            //Update Listview
            ListView_SoundBank.BeginUpdate();
            ListView_SoundBank.Items.Clear();
            for (int i = 0; i < projectFileData.soundBanksCount; i++)
            {
                ListView_SoundBank.Items.Add(new ListViewItem(new string[]
                {
                    projectFileData.soundBanksData[i].soundBankHashCode.ToString("X8"),
                    projectFileData.soundBanksData[i].soundBankSlotNumber.ToString()
                }));
            }
            ListView_SoundBank.EndUpdate();

            //Read User Flags Section
            Textbox_StereoStreamCount.Text = projectFileData.stereoStreamCount.ToString();
            Textbox_MonoStreamCount.Text = projectFileData.monoStreamCount.ToString();
            Textbox_ProjectCode.Text = projectFileData.projectCode.ToString();

            //Update listview
            ListView_FlagsValues.BeginUpdate();
            ListView_FlagsValues.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                ListView_FlagsValues.Items.Add(new ListViewItem(new string[]
                {
                    i.ToString(),
                    projectFileData.flagsValues[i].ToString()
                }));
            }
            ListView_FlagsValues.EndUpdate();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
