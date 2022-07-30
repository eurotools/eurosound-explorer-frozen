using System;
using System.Collections.Generic;
using System.IO;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal class OldMusX
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        internal MusicSample ReadMusicBank(string filePath, MusXHeaderData headerData, int interleave_block_size)
        {
            MusicSample musicDat;
            using (BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Seek Position Section 1
                binaryReader.BaseStream.Seek(headerData.FileStart1, SeekOrigin.Begin);

                //Stream marker header data 
                uint StartMarkersCount = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                uint MarkersCount = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                musicDat = new MusicSample
                {
                    //Properties
                    StartMarkerOffset = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                    MarkerOffset = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                    BaseVolume = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                };

                //Read Start Markers
                for (int j = 0; j < StartMarkersCount; j++)
                {
                    StreamStartMarker StartMarker = new StreamStartMarker
                    {
                        Name = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                        Position = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Type = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Flags = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Extra = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopStart = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        MarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopMarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),

                        //StartMarker
                        MarkerPos = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        IsInstant = Convert.ToBoolean(BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian)),
                        InstantBuffer = Convert.ToBoolean(BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian)),
                        StateA = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        StateB = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian)
                    };

                    //Add marker
                    musicDat.StartMarkers.Add(StartMarker);
                }

                //Read Markers
                for (int k = 0; k < MarkersCount; k++)
                {
                    StreamMarker DataMarker = new StreamMarker
                    {
                        Name = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                        Position = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Type = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Flags = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Extra = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopStart = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        MarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopMarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                    };

                    //Add marker
                    musicDat.Markers.Add(DataMarker);
                }

                //Read Section 2
                uint TracksLength = headerData.FileLength2 / 2;
                bool InterleavedStereo = true;
                int IndexLC = 0, IndexRC = 0;

                //Seek Position
                binaryReader.BaseStream.Seek(headerData.FileStart2, SeekOrigin.Begin);

                //Save offset
                musicDat.AudioOffset = (uint)binaryReader.BaseStream.Position;

                //Init arrays
                musicDat.SampleByteData_LeftChannel = new byte[TracksLength];
                musicDat.SampleByteData_RightChannel = new byte[TracksLength];

                //Read Stereo interleaving
                while (binaryReader.BaseStream.Position < (headerData.FileStart2 + headerData.FileLength2))
                {
                    if (InterleavedStereo)
                    {
                        Buffer.BlockCopy(binaryReader.ReadBytes(interleave_block_size), 0, musicDat.SampleByteData_LeftChannel, IndexLC, interleave_block_size);
                        IndexLC += interleave_block_size;
                    }
                    else
                    {
                        Buffer.BlockCopy(binaryReader.ReadBytes(interleave_block_size), 0, musicDat.SampleByteData_RightChannel, IndexRC, interleave_block_size);
                        IndexRC += interleave_block_size;
                    }
                    InterleavedStereo = !InterleavedStereo;
                }
            }

            return musicDat;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void LoadStreamFile(string filePath, MusXHeaderData headerData, List<StreamSample> StreamFileDictionaryData)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Read Section 1
                uint[] storedElements = new uint[headerData.FileLength1 / 4];

                //Go to section
                binaryReader.BaseStream.Seek(headerData.FileStart1, SeekOrigin.Begin);

                //Read Offsets
                for (int i = 0; i < storedElements.Length; i++)
                {
                    storedElements[i] = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                }

                //Read Section 2
                for (int i = 0; i < storedElements.Length; i++)
                {
                    binaryReader.BaseStream.Seek(headerData.FileStart2 + storedElements[i], SeekOrigin.Begin);
                    StreamSample StreamSoundToAdd = new StreamSample
                    {
                        BlockPosition = storedElements[i],
                        MarkerSize = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        AudioOffset = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        AudioSize = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian)
                    };

                    //Stream marker header data 
                    uint StartMarkersCount = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                    uint MarkersCount = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                    StreamSoundToAdd.StartMarkerOffset = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                    StreamSoundToAdd.MarkerOffset = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                    StreamSoundToAdd.BaseVolume = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);

                    //Stream marker start data
                    for (int j = 0; j < StartMarkersCount; j++)
                    {
                        StreamStartMarker StartMarker = new StreamStartMarker
                        {
                            Name = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                            Position = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            Type = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            Flags = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            Extra = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopStart = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            MarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopMarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),

                            //StartMarker
                            MarkerPos = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            IsInstant = Convert.ToBoolean(BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian)),
                            InstantBuffer = Convert.ToBoolean(BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian)),
                            StateA = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            StateB = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian)
                        };

                        //Add marker
                        StreamSoundToAdd.StartMarkers.Add(StartMarker);
                    }

                    //Stream marker data 
                    for (int k = 0; k < MarkersCount; k++)
                    {
                        StreamMarker DataMarker = new StreamMarker
                        {
                            Name = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                            Position = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            Type = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            Flags = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            Extra = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopStart = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            MarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopMarkerCount = (int)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        };

                        //Add marker
                        StreamSoundToAdd.Markers.Add(DataMarker);
                    }

                    //Read Audio Data
                    binaryReader.BaseStream.Seek(headerData.FileStart2 + StreamSoundToAdd.AudioOffset, SeekOrigin.Begin);
                    StreamSoundToAdd.SampleByteData = binaryReader.ReadBytes((int)StreamSoundToAdd.AudioSize);

                    //Add Sound to Dictionary
                    StreamFileDictionaryData.Add(StreamSoundToAdd);
                }
                binaryReader.Close();
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
