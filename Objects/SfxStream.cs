using System.Collections.Generic;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public class SfxStream
    {
        //Markers
        public List<StartMarker> StartMarkers = new List<StartMarker>();
        public List<Marker> Markers = new List<Marker>();

        //Audio Data
        public byte[] SampleByteData = new byte[0];

        //Parameters
        public uint BlockPosition;
        public uint MarkerOffset;
        public uint MarkerSize;
        public uint AudioOffset;
        public uint AudioSize;
        public uint StartMarkerOffset;
        public uint BaseVolume;
        public uint StartMarkersCount;
        public uint MarkersCount;
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
