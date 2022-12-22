using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public static class CommonFunctions
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        public static byte[] DecodeSfxSound(SfxData wavData)
        {
            byte[] decodedData = null;

            MusXHeaderData MusXheaderData = ((Frm_Main)Application.OpenForms[nameof(Frm_Main)]).headerData;
            if (MusXheaderData.FileVersion > 3 && MusXheaderData.FileVersion < 10)
            {
                if (MusXheaderData.Platform.Equals("PC__") || MusXheaderData.Platform.Equals("XB__") || MusXheaderData.Platform.Equals("XB1_"))
                {
                    Eurocom_ImaAdpcm eurocomDAT = new Eurocom_ImaAdpcm();
                    decodedData = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(wavData.EncodedData));
                }
                else if (MusXheaderData.Platform.Equals("GC__"))
                {
                    DspAdpcm gameCubeDecoder = new DspAdpcm();
                    decodedData = AudioFunctions.ShortArrayToByteArray(gameCubeDecoder.Decode(wavData.EncodedData, wavData.DspCoeffs));
                }
                else if (MusXheaderData.Platform.Equals("PS2_"))
                {
                    SonyAdpcm vagDecoder = new SonyAdpcm();
                    decodedData = vagDecoder.Decode(wavData.EncodedData);
                }
            }
            else
            {
                switch (MusXheaderData.Platform)
                {
                    case "PC":
                        decodedData = wavData.EncodedData;
                        break;
                    case "PS2":
                        SonyAdpcm vagDecoder = new SonyAdpcm();
                        decodedData = vagDecoder.Decode(wavData.EncodedData);
                        break;
                    case "GC":
                        DspAdpcm gameCubeDecoder = new DspAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(gameCubeDecoder.Decode(wavData.EncodedData, wavData.DspCoeffs));
                        break;
                    case "XB":
                        XboxAdpcm xboxDecoder = new XboxAdpcm();
                        decodedData = AudioFunctions.ShortArrayToByteArray(xboxDecoder.Decode(wavData.EncodedData));
                        break;
                }
            }

            return decodedData;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        public static byte[] DecodeStreamSound(MusXHeaderData headerData, SfxStream streamToDecode)
        {
            byte[] decodedData = null;
            if (headerData.FileVersion == 201 || headerData.FileVersion == 1)
            {
                if (headerData.Platform.Equals("PC") || headerData.Platform.Equals("GC"))
                {
                    ImaAdpcm imaFile = new ImaAdpcm();
                    decodedData = AudioFunctions.ShortArrayToByteArray(imaFile.Decode(streamToDecode.SampleByteData, streamToDecode.SampleByteData.Length * 2));
                }
                else if (headerData.Platform.Equals("PS2"))
                {
                    SonyAdpcm vagDecoder = new SonyAdpcm();
                    decodedData = vagDecoder.Decode(streamToDecode.SampleByteData);
                }
                else if (headerData.Platform.Equals("XB"))
                {
                    XboxAdpcm xboxDecoder = new XboxAdpcm();
                    decodedData = AudioFunctions.ShortArrayToByteArray(xboxDecoder.Decode(streamToDecode.SampleByteData));
                }
            }
            else
            {
                if (headerData.Platform.Equals("PC__") || headerData.Platform.Equals("XB__"))
                {
                    Eurocom_ImaAdpcm eurocomDAT = new Eurocom_ImaAdpcm();
                    decodedData = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(streamToDecode.SampleByteData));
                }
                if (headerData.Platform.Equals("GC__"))
                {
                    Eurocom_ImaAdpcm eurocomDAT = new Eurocom_ImaAdpcm();
                    decodedData = AudioFunctions.ShortArrayToByteArray(eurocomDAT.Decode(streamToDecode.SampleByteData));
                }
                else if (headerData.Platform.Equals("PS2_"))
                {
                    SonyAdpcm vagDecoder = new SonyAdpcm();
                    decodedData = vagDecoder.Decode(streamToDecode.SampleByteData);
                }
            }

            return decodedData;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
