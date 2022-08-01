using System.Collections.Generic;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    public class ProjectFile
    {
        public int MemmorySlotsCount;
        public int MemorySlotsOffset;

        public int soundBanksCount;
        public int soundBanksOffset;

        public int stereoStreamCount;
        public int monoStreamCount;
        public int projectCode;

        public List<ProjectSoundBank> soundBanksData = new List<ProjectSoundBank>();
        public List<ProjectSlots> memorySlotsData = new List<ProjectSlots>();

        public int[] flagsValues = new int[10];
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
