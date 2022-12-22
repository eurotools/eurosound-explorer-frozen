using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class ADPCM_Validator_PC : Form
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        public ADPCM_Validator_PC()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void ADPCM_Validator_PC_Shown(object sender, EventArgs e)
        {
            UserControl_StreamData streamsListView = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).userControl_StreamData1;
            List<SfxStream> streamsList = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).streamedSamples;

            for (int i = 0; i < streamsListView.ListView_StreamData.Items.Count; i++)
            {
                //Update Progress Bar
                ProgressBar_Validation.Value = (int)(decimal.Divide(i, streamsListView.ListView_StreamData.Items.Count) * 100);

                //Check files
                ListViewItem currentItem = streamsListView.ListView_StreamData.Items[i];
                byte[] ImaData = streamsList[(int)currentItem.Tag].SampleByteData;
                if (ImaData[3] == 65)
                {
                    currentItem.SubItems[1].Text = "OK";
                    currentItem.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    currentItem.SubItems[1].Text = "INVALID";
                    currentItem.ForeColor = Color.Red;
                }
            }

            Close();
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
