using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public partial class UserControl_HexEditor : UserControl
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        public UserControl_HexEditor()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void UpdateHexViewer(HexData dataToDisplay, uint fileVersion)
        {
            //Clear listview
            ListView_HexEditor.Items.Clear();

            //Print data
            int index = 0;
            do
            {
                string[] fullData = new string[10];
                fullData[0] = index.ToString("X4");

                StringBuilder hexString = new StringBuilder();
                for (int j = 0; j < 8; j++)
                {
                    //Quit loop required
                    if (index >= dataToDisplay.BinaryLength)
                    {
                        break;
                    }

                    //Get hex string and store data in hex format
                    if (dataToDisplay.BinaryData[index] >= 32 && dataToDisplay.BinaryData[index] < 127)
                    {
                        hexString.Append(Convert.ToChar(dataToDisplay.BinaryData[index]));
                    }
                    else
                    {
                        hexString.Append(".");
                    }

                    //Add data
                    fullData[j + 1] = dataToDisplay.BinaryData[index++].ToString("X2");
                }

                fullData[9] = hexString.ToString();
                ListViewItem listViewItem2 = new ListViewItem(fullData)
                {
                    UseItemStyleForSubItems = false
                };
                ListView_HexEditor.Items.Add(listViewItem2);
            }
            while (index < dataToDisplay.BinaryLength);

            //Colorize
            int currentByte = 0;
            for (int rowIndex = 0; rowIndex < ListView_HexEditor.Items.Count; rowIndex++)
            {
                for (int i = 1; i < ListView_HexEditor.Items[rowIndex].SubItems.Count - 1; i++)
                {
                    currentByte++;

                    if (currentByte < dataToDisplay.FlagsDataLength)
                    {
                        ListView_HexEditor.Items[rowIndex].SubItems[i].ForeColor = SystemColors.WindowText;
                    }

                    if (fileVersion > 4 && fileVersion < 10)
                    {
                        if (currentByte > dataToDisplay.FlagsDataLength && currentByte <= dataToDisplay.UserFlagsDataLength)
                        {
                            ListView_HexEditor.Items[rowIndex].SubItems[i].ForeColor = Color.Blue;
                        }
                        if (currentByte > dataToDisplay.UserFlagsDataLength && currentByte <= dataToDisplay.SamplePoolDataLength)
                        {
                            ListView_HexEditor.Items[rowIndex].SubItems[i].ForeColor = Color.Purple;
                        }
                    }
                    else
                    {
                        if (currentByte > dataToDisplay.FlagsDataLength && currentByte <= dataToDisplay.SamplePoolDataLength)
                        {
                            ListView_HexEditor.Items[rowIndex].SubItems[i].ForeColor = Color.Blue;
                        }
                    }
                    if (currentByte > dataToDisplay.SamplePoolDataLength)
                    {
                        ListView_HexEditor.Items[rowIndex].SubItems[i].ForeColor = Color.Green;
                    }
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void MenuItem_HexContextMenu_ChangeFont_Click(object sender, EventArgs e)
        {
            if (HexViewfontDialog.ShowDialog() == DialogResult.OK)
            {
                ListView_HexEditor.Font = HexViewfontDialog.Font;
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
