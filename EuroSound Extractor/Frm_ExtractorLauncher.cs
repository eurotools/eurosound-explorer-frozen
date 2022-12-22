using System;
using System.IO;
using System.Windows.Forms;

namespace EuroSound_Extractor
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class Frm_ExtractorLauncher : Form
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        public Frm_ExtractorLauncher()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void BtnSearchSFX_Click(object sender, EventArgs e)
        {
            if (opFileDlg.ShowDialog() == DialogResult.OK)
            {
                txtSfxFilePath.Text = folderBrowser.SelectedPath;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void BtnSoundh_Click(object sender, EventArgs e)
        {
            if (opFileDlg.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = opFileDlg.FileName;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void BtnSearchOutFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = folderBrowser.SelectedPath;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //Check that all data is correct.
            if (File.Exists(txtSfxFilePath.Text) && Directory.Exists(txtOutputFolder.Text))
            {
                if (File.Exists(txtSoundH.Text))
                {
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    if (MessageBox.Show("'Sound.h' file not found, are you sure that you still want to export the Sound bank data?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!backgroundWorker1.IsBusy)
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The SFX file OR output folder path does not exists or is not valid", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
