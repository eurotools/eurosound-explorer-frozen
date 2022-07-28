using System.Collections.Generic;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public class StreamSample
    {
        //Markers
        public List<StreamStartMarker> StartMarkers = new List<StreamStartMarker>();
        public List<StreamMarker> Markers = new List<StreamMarker>();

        //Audio Data
        public byte[] SampleByteData = new byte[0];

        //Parameters
        public uint BlockPosition;
        public uint MarkerOffset;
        public uint MarkerSize;
        public uint AudioOffset;
        public uint AudioSize;
        public uint StartMarkerOffset;
        public uint BaseVolume = 100;
        public uint StartMarkersCount;
        public uint MarkersCount;
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
