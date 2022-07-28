namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal class MusXHeaderData
    {
        internal bool IsBigEndian;
        internal uint FileHashCode;
        internal uint FileVersion;
        internal uint FileSize;
        internal string Platform;
        internal uint Timespan;

        //Soundbanks
        internal uint SFXStart;
        internal uint SFXLenght;

        internal uint SampleInfoStart;
        internal uint SampleInfoLenght;

        internal uint SpecialSampleInfoStart;
        internal uint SpecialSampleInfoLength;

        internal uint SampleDataStart;
        internal uint SampleDataLength;

        //Streambank
        internal uint FileStart1;
        internal uint FileLength1;

        internal uint FileStart2;
        internal uint FileLength2;

        internal uint FileStart3;
        internal uint FileLength3;
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
