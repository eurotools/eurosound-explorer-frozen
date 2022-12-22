using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal static class Hashcodes
    {
        internal static Hashtable sound_HashCodes;

        //-------------------------------------------------------------------------------------------------------------------------------
        internal static void Read_Sound_h(string filePath)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    string input = streamReader.ReadToEnd();
                    if (sound_HashCodes == null)
                    {
                        sound_HashCodes = new Hashtable();
                    }
                    else
                    {
                        sound_HashCodes.Clear();
                    }

                    string pattern = "#define([\\s])+([\\w]+)([\\s])+(0x[\\da-fA-F]{8,8})";
                    MatchCollection matchCollection = Regex.Matches(input, pattern);

                    if (matchCollection.Count > 0)
                    {
                        for (int i = 0; i < matchCollection.Count; i++)
                        {
                            input = matchCollection[i].ToString();
                            input = input.Replace("#define ", string.Empty);
                            Match match = Regex.Match(input, "([\\w]+)");
                            Match match2 = Regex.Match(input, "(0x[\\da-fA-F]{8,8})");
                            uint hashCode = Convert.ToUInt32(match2.ToString().Trim(), 16);
                            if (!sound_HashCodes.ContainsKey(hashCode))
                            {
                                //Remove HT_Sound prefix
                                string hashcodeMatch = match.ToString().Trim();
                                if (hashcodeMatch.StartsWith("HT_Sound_", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (hashcodeMatch.Length > 9)
                                    {
                                        hashcodeMatch = hashcodeMatch.Substring(9);
                                    }
                                }

                                //Add HashCode
                                sound_HashCodes.Add(hashCode, hashcodeMatch);
                            }
                        }
                    }

                    ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).StatusLabel_SoundhDir.Text = filePath;
                }
            }
            catch (Exception ex)
            {
                ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).StatusLabel_SoundhDir.Text = "Sound.h not loaded";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
