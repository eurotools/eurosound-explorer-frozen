namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public class WavHeaderData
    {
        public int Flags;
        public int Address;
        public int MemorySize;
        public int Frequency;
        public int SampleSize;
        public int PSI_SampleHeader;
        public int Channels;
        public int Bits;
        public int LoopStartOffset;
        public int DurationInMilliseconds;
        public byte[] EncodedData;
        public short[] DspCoeffs;
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
