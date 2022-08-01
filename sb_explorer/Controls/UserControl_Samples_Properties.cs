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
            TabControl tabPanel = ((Frm_Main)Application.OpenForms["Frm_Main"]).TabControl;
            TabPage Tab_Wav_Head_Data = ((Frm_Main)Application.OpenForms["Frm_Main"]).TabPage_WavHeaderData;
            ListView_ColumnSortingClick ListView_WavData = ((Frm_Main)Application.OpenForms["Frm_Main"]).UserControl_WavHeaderData.ListView_WavData;

            if (ListView_SamplePool.SelectedIndices.Count != 0)
            {
                //Get index
                short Index = (short)ListView_SamplePool.SelectedItems[0].Tag;
                if (Index >= 0 && CheckedListBox_SampleFlags.GetItemCheckState(10) == CheckState.Unchecked)
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
                        if (itemToCheck.SubItems[0].Text.Equals(Index.ToString()))
                        {
                            itemToCheck.Selected = true;
                            itemToCheck.Focused = true;
                            itemToCheck.EnsureVisible();

                            ((Frm_Main)Application.OpenForms["Frm_Main"]).UserControl_WavHeaderData.OpenMediaPlayer((int)itemToCheck.Tag);
                            break;
                        }
                    }
                }
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
