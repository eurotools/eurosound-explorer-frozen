using System.Collections.Generic;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public class MusicSample
    {
        //Markers
        public List<StreamStartMarker> StartMarkers = new List<StreamStartMarker>();
        public List<StreamMarker> Markers = new List<StreamMarker>();

        //Channel info
        public byte[] SampleByteData_RightChannel = new byte[0];
        public byte[] SampleByteData_LeftChannel = new byte[0];

        //Parameters
        public uint MarkerSize;
        public uint AudioOffset;
        public uint AudioSize;
        public uint StartMarkerOffset;
        public uint MarkerOffset;
        public uint BaseVolume;
        public uint HashCode;
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
