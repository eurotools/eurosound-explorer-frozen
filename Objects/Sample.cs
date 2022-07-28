﻿using System.Collections.Generic;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public class Sample
    {
        //Data for the HEX Editor
        public HexData HexViewerData = new HexData();

        //Parameters
        public short DuckerLenght;
        public short MinDelay;
        public short MaxDelay;
        public sbyte ReverbSend;
        public sbyte TrackingType;
        public sbyte MaxVoices;
        public sbyte Priority;
        public sbyte Ducker;
        public sbyte MasterVolume;
        public short GroupHashCode;
        public sbyte GroupMaxChannels;
        public sbyte DopplerValue;
        public sbyte UserValue;
        public sbyte SFXDucker;
        public sbyte Spare;
        public short InnerRadius;
        public short OuterRadius;

        //Flags
        public ushort Flags;
        public ushort UserFlags;

        //Samples
        public List<SamplePoolItem> samplesList = new List<SamplePoolItem>();
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
