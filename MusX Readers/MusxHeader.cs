using System.IO;
using System.Text;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal class MusxHeader
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        internal int ReadFileVersion(string filePath)
        {
            int fileVersion = -1;

            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Magic value MUSX
                string Magic = Encoding.ASCII.GetString(BReader.ReadBytes(4));
                if (Magic.Equals("MUSX"))
                {
                    BReader.BaseStream.Seek(4, SeekOrigin.Current);

                    //Current version of the file
                    fileVersion = BReader.ReadInt32();
                }
            }

            return fileVersion;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal bool ReadSoundBankHeader(string filePath, MusXHeaderData headerData)
        {
            bool fileIsCorrect = false;

            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Magic value MUSX
                string Magic = Encoding.ASCII.GetString(BReader.ReadBytes(4));
                if (Magic.Equals("MUSX"))
                {
                    fileIsCorrect = true;

                    //Hashcode for the current soundbank 
                    headerData.FileHashCode = BReader.ReadUInt32();
                    //Current version of the file
                    headerData.FileVersion = BReader.ReadUInt32();
                    //Size of the whole file, in bytes
                    headerData.FileSize = BReader.ReadUInt32();

                    //Fields in the new versions
                    if (headerData.FileVersion != 201)
                    {
                        //Platform PS2_ PC__ GC__ XB__
                        headerData.Platform = Encoding.ASCII.GetString(BReader.ReadBytes(4));
                        headerData.Timespan = BReader.ReadUInt32(); //Seconds from 1/1/2000, 1:00:00 (946684800)

                        //Seems padding but when the platform is PC__ or GC__ is set to 1
                        BReader.ReadUInt32();
                        //Padding??
                        BReader.ReadUInt32();

                        //Big endian
                        if (headerData.Platform.Equals("GC__") || headerData.Platform.Equals("XB2_"))
                        {
                            headerData.IsBigEndian = true;
                        }
                    }

                    //Section where soundbanks are stored
                    headerData.SFXStart = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    //Size of the first section, in bytes
                    headerData.SFXLenght = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);

                    //Section where the sample properties are stored
                    headerData.SampleInfoStart = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    //Size of the second section, in bytes. 
                    headerData.SampleInfoLenght = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);

                    //Section where the ADPCM metadata and parameters for the GameCube DSP are stored
                    headerData.SpecialSampleInfoStart = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    //Size of the block, in bytes.
                    headerData.SpecialSampleInfoLength = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);

                    //Points to the beginning of the PCM data, where sound is actually stored. 
                    headerData.SampleDataStart = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    //Size of the block, in bytes. 
                    headerData.SampleDataLength = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                }

                //Close
                BReader.Close();
            }

            return fileIsCorrect;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal bool ReadStreamBankHeader(string filePath, MusXHeaderData headerData)
        {
            bool fileIsCorrect = false;

            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Magic value MUSX
                string Magic = Encoding.ASCII.GetString(BReader.ReadBytes(4));
                if (Magic.Equals("MUSX"))
                {
                    fileIsCorrect = true;

                    //Hashcode for the current soundbank 
                    headerData.FileHashCode = BReader.ReadUInt32();
                    //Current version of the file
                    headerData.FileVersion = BReader.ReadUInt32();
                    //Size of the whole file, in bytes
                    headerData.FileSize = BReader.ReadUInt32();

                    //Fields in the new versions
                    if (headerData.FileVersion > 1 && headerData.FileVersion < 10)
                    {
                        //Platform PS2_ PC__ GC__ XB__
                        headerData.Platform = Encoding.ASCII.GetString(BReader.ReadBytes(4));
                        //??????
                        headerData.Timespan = BReader.ReadUInt32();

                        //Seems padding but when the platform is PC__ or GC__ is set to 1
                        BReader.ReadUInt32();
                        //Padding??
                        BReader.ReadUInt32();
                    }

                    //Big endian
                    if (headerData.Platform.Contains("GC"))
                    {
                        headerData.IsBigEndian = true;
                    }

                    //Points to the stream look-up file details
                    headerData.FileStart1 = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    //Size of the first section, in bytes. 
                    headerData.FileLength1 = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);

                    //Offset to the second section with the sample data. 
                    headerData.FileStart2 = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    //Size of the second section, in bytes. 
                    headerData.FileLength2 = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);

                    if (headerData.FileVersion == 201 || headerData.FileVersion == 1)
                    {
                        //Unused offset. Set to zero.
                        headerData.FileStart3 = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                        //Unused. Set to zero.
                        headerData.FileLength3 = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    }
                }

                //Close
                BReader.Close();
            }

            return fileIsCorrect;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
