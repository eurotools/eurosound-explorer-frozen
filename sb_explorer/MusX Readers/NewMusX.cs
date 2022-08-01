using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal class NewMusX
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        internal void ReadSoundbank(string filePath, MusXHeaderData headerData, SortedDictionary<uint, SfxSound> samplesDictionary, List<SfxData> wavesList)
        {
            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Read SFX Start
                BReader.BaseStream.Seek(headerData.SFXStart, SeekOrigin.Begin);
                uint sfxCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                for (int i = 0; i < sfxCount; i++)
                {
                    uint hashcode;
                    switch (headerData.FileVersion)
                    {
                        case 201:
                            hashcode = 0x1A000000 | BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                            break;
                        case 6:
                            hashcode = 0x2D700000 | BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                            break;
                        default:
                            hashcode = 0x1AF00000 | BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                            break;
                    }

                    uint curSfxPos = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    long prevPos = BReader.BaseStream.Position;

                    //Goto SFX Data
                    BReader.BaseStream.Seek(headerData.SFXStart + curSfxPos, SeekOrigin.Begin);

                    //Save position
                    long startOffset = BReader.BaseStream.Position - (headerData.SFXStart + curSfxPos);
                    SfxSound sample = new SfxSound
                    {
                        DuckerLenght = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        MinDelay = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        MaxDelay = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        ReverbSend = BReader.ReadSByte(),
                        TrackingType = BReader.ReadSByte(),
                        MaxVoices = BReader.ReadSByte(),
                        Priority = BReader.ReadSByte(),
                        Ducker = BReader.ReadSByte(),
                        MasterVolume = BReader.ReadSByte()
                    };
                    sample.HexViewerData.HeaderDataLength = startOffset;

                    //Read flags and sample pool
                    if (headerData.Platform.Contains("PS2") || (headerData.Platform.Contains("XB") && headerData.FileVersion < 5) || (headerData.Platform.Contains("GC") && headerData.FileVersion < 5))
                    {
                        startOffset = BReader.BaseStream.Position - (headerData.SFXStart + curSfxPos);
                        sample.GroupHashCode = BReader.ReadInt16();
                        sample.GroupMaxChannels = (sbyte)(sample.GroupHashCode & 15);
                        sample.GroupHashCode >>= 4;

                        //Read Flags
                        sample.Flags = BReader.ReadUInt16();
                        sample.HexViewerData.FlagsDataLength = startOffset;

                        //Read UserFlags
                        if (headerData.FileVersion > 4)
                        {
                            startOffset = BReader.BaseStream.Position - (headerData.SFXStart + curSfxPos);
                            sample.UserFlags = BinaryFunctions.FlipUShort(BReader.ReadUInt16(), headerData.IsBigEndian);
                            sample.DopplerValue = BReader.ReadSByte();
                            sample.UserValue = BReader.ReadSByte();
                            sample.HexViewerData.UserFlagsDataLength = startOffset;
                        }
                    }
                    else
                    {
                        sample.GroupHashCode = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian);
                        sample.GroupMaxChannels = BReader.ReadSByte();
                        BReader.ReadSByte();

                        //Flags
                        startOffset = BReader.BaseStream.Position - (headerData.SFXStart + curSfxPos);
                        for (int j = 0; j < 16; j++)
                        {
                            sbyte flagState = BReader.ReadSByte();
                            if (flagState == 1)
                            {
                                sample.Flags = (ushort)(sample.Flags | (flagState << j));
                            }
                        }
                        sample.HexViewerData.FlagsDataLength = startOffset;

                        //User Flags
                        if (headerData.FileVersion > 4)
                        {
                            startOffset = BReader.BaseStream.Position - (headerData.SFXStart + curSfxPos);
                            for (int j = 0; j < 16; j++)
                            {
                                sbyte flagState = BReader.ReadSByte();
                                if (flagState == 1)
                                {
                                    sample.UserFlags = (ushort)(sample.UserFlags | (flagState << j));
                                }
                            }
                            sample.DopplerValue = BReader.ReadSByte();
                            sample.UserValue = BReader.ReadSByte();
                            sample.HexViewerData.UserFlagsDataLength = startOffset;
                        }
                    }

                    if (headerData.FileVersion > 5)
                    {
                        sample.SFXDucker = BReader.ReadSByte();
                        sample.Spare = BReader.ReadSByte();
                    }

                    //Read Sample Pool 
                    startOffset = BReader.BaseStream.Position - (headerData.SFXStart + curSfxPos);
                    ushort samplesCount = BinaryFunctions.FlipUShort(BReader.ReadUInt16(), headerData.IsBigEndian);
                    for (int j = 0; j < samplesCount; j++)
                    {
                        SfxSample samplePoolItem = new SfxSample
                        {
                            FileRef = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                            Pitch = BReader.ReadSByte(),
                            PitchOffset = BReader.ReadSByte(),
                            Volume = BReader.ReadSByte(),
                            VolumeOffset = BReader.ReadSByte(),
                            Pan = BReader.ReadSByte(),
                            PanOffset = BReader.ReadSByte()
                        };
                        sample.samplesList.Add(samplePoolItem);
                    }
                    sample.HexViewerData.SamplePoolDataLength = startOffset;

                    //Save in dictionary
                    if (!samplesDictionary.ContainsKey(hashcode))
                    { 
                        samplesDictionary.Add(hashcode, sample);
                    }

                    //Read data to show in the Hex viewer
                    sample.HexViewerData.BinaryLength = (int)(BReader.BaseStream.Position - (curSfxPos + headerData.SFXStart));
                    BReader.BaseStream.Seek(curSfxPos + headerData.SFXStart, SeekOrigin.Begin);
                    sample.HexViewerData.BinaryData = BReader.ReadBytes(sample.HexViewerData.BinaryLength);

                    //return 
                    BReader.BaseStream.Seek(prevPos, SeekOrigin.Begin);
                }

                //Read Sample info
                BReader.BaseStream.Seek(headerData.SampleInfoStart, SeekOrigin.Begin);
                uint waveCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                for (int i = 0; i < waveCount; i++)
                {
                    SfxData wavHeaderData = new SfxData
                    {
                        Flags = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Address = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        MemorySize = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Frequency = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        SampleSize = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        PsiSampleHeader = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        LoopStartOffset = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Duration = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian)
                    };

                    //Store current position
                    long prevPos = BReader.BaseStream.Position;

                    //Read audio pcm data
                    BReader.BaseStream.Seek(headerData.SampleDataStart + wavHeaderData.Address, SeekOrigin.Begin);
                    wavHeaderData.EncodedData = BReader.ReadBytes(wavHeaderData.SampleSize);

                    //Read coeffs
                    if (headerData.Platform.Contains("GC"))
                    {
                        BReader.BaseStream.Seek(headerData.SpecialSampleInfoStart + wavHeaderData.PsiSampleHeader, SeekOrigin.Begin);
                        BReader.BaseStream.Seek(28, SeekOrigin.Current);
                        wavHeaderData.DspCoeffs = new short[16];
                        for (int j = 0; j < wavHeaderData.DspCoeffs.Length; j++)
                        {
                            wavHeaderData.DspCoeffs[j] = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian);
                        }
                    }

                    //Store data
                    wavesList.Add(wavHeaderData);

                    //Return to previous position
                    BReader.BaseStream.Seek(prevPos, SeekOrigin.Begin);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void ReadStreamFile(string filePath, MusXHeaderData headerData, List<SfxStream> streamedSamples)
        {
            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Go to File Start 1
                BReader.BaseStream.Seek(headerData.FileStart1, SeekOrigin.Begin);

                //Get count of the stored elements
                uint[] storedElements = new uint[headerData.FileLength1 / 4];

                //Read Offsets
                for (int i = 0; i < storedElements.Length; i++)
                {
                    storedElements[i] = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                }

                //Read File Section 2
                for (int i = 0; i < storedElements.Length; i++)
                {
                    BReader.BaseStream.Seek(headerData.FileStart2 + storedElements[i], SeekOrigin.Begin);

                    SfxStream streamSample = new SfxStream
                    {
                        BlockPosition = storedElements[i],
                        MarkerSize = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        AudioOffset = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        AudioSize = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        StartMarkersCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        MarkersCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        StartMarkerOffset = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        MarkerOffset = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        BaseVolume = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian)
                    };

                    //Stream marker start data
                    for (int j = 0; j < streamSample.StartMarkersCount; j++)
                    {
                        StartMarker startMarker = new StartMarker
                        {
                            Index = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                            Position = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            Type = (byte)BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopStart = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopMarkerCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                            MarkerPos = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        };

                        //Add marker
                        streamSample.StartMarkers.Add(startMarker);
                    }

                    //Stream marker data 
                    for (int j = 0; j < streamSample.MarkersCount; j++)
                    {
                        Marker DataMarker = new Marker
                        {
                            Index = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                            Position = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            Type = (byte)BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopStart = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopMarkerCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        };

                        //Add marker
                        streamSample.Markers.Add(DataMarker);
                    }

                    //Read Audio Data
                    BReader.BaseStream.Seek(headerData.FileStart2 + streamSample.AudioOffset, SeekOrigin.Begin);
                    streamSample.SampleByteData = BReader.ReadBytes((int)streamSample.AudioSize);

                    //Add audio to list
                    streamedSamples.Add(streamSample);
                }

                BReader.Close();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal MusicSample ReadMusicFile(string filePath, MusXHeaderData headerData, int interleave_block_size)
        {
            MusicSample MusicData = null;

            using (BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Go to File Start 1
                binaryReader.BaseStream.Seek(headerData.FileStart1, SeekOrigin.Begin);

                //Stream marker header data 
                uint StartMarkersCount = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                uint MarkersCount = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian);
                MusicData = new MusicSample
                {
                    //Properties
                    StartMarkerOffset = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                    MarkerOffset = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                    BaseVolume = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                };

                //Read Start Markers
                for (int j = 0; j < StartMarkersCount; j++)
                {
                    StartMarker StartMarker = new StartMarker
                    {
                        Index = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                        Position = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Type = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopStart = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopMarkerCount = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                        MarkerPos = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                    };

                    //Add marker
                    MusicData.StartMarkers.Add(StartMarker);
                }

                //Read Markers
                for (int k = 0; k < MarkersCount; k++)
                {
                    Marker DataMarker = new Marker
                    {
                        Index = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                        Position = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        Type = (byte)BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopStart = BinaryFunctions.FlipUInt32(binaryReader.ReadUInt32(), headerData.IsBigEndian),
                        LoopMarkerCount = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
                    };

                    //Add marker
                    MusicData.Markers.Add(DataMarker);
                }

                //Read Section 2
                uint TracksLength = headerData.FileLength2 / 2;
                bool InterleavedStereo = true;
                int IndexLC = 0, IndexRC = 0;

                //Seek Position
                binaryReader.BaseStream.Seek(headerData.FileStart2, SeekOrigin.Begin);

                //Save offset
                MusicData.AudioOffset = (uint)binaryReader.BaseStream.Position;

                //Init arrays
                MusicData.SampleByteData_LeftChannel = new byte[TracksLength];
                MusicData.SampleByteData_RightChannel = new byte[TracksLength];

                //Read Stereo interleaving
                while (binaryReader.BaseStream.Position < (headerData.FileStart2 + headerData.FileLength2))
                {
                    if (InterleavedStereo)
                    {
                        Buffer.BlockCopy(binaryReader.ReadBytes(interleave_block_size), 0, MusicData.SampleByteData_LeftChannel, IndexLC, interleave_block_size);
                        IndexLC += interleave_block_size;
                    }
                    else
                    {
                        Buffer.BlockCopy(binaryReader.ReadBytes(interleave_block_size), 0, MusicData.SampleByteData_RightChannel, IndexRC, interleave_block_size);
                        IndexRC += interleave_block_size;
                    }
                    InterleavedStereo = !InterleavedStereo;
                }
            }

            return MusicData;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal ProjectFile ReadProjectFile(string filePath, MusXHeaderData headerData)
        {
            ProjectFile projectData = null;
            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                projectData = new ProjectFile();

                //Read Memory Slots Section
                BReader.BaseStream.Seek(headerData.SFXStart, SeekOrigin.Begin);
                projectData.MemmorySlotsCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                projectData.MemorySlotsOffset = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                long soundbanksPos = BReader.BaseStream.Position;
                BReader.BaseStream.Seek(headerData.SFXStart + projectData.MemorySlotsOffset, SeekOrigin.Begin);
                for (int i = 0; i < projectData.MemmorySlotsCount; i++)
                {
                    ProjectSlots projSlots = new ProjectSlots
                    {
                        SlotNumber = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        MemorySize = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Quantity = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian)
                    };
                    projectData.memorySlotsData.Add(projSlots);
                }

                //Read Soundbanks Section
                BReader.BaseStream.Seek(soundbanksPos, SeekOrigin.Begin);
                projectData.soundBanksCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                projectData.soundBanksOffset = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                long flagsPos = BReader.BaseStream.Position;
                BReader.BaseStream.Seek(projectData.soundBanksOffset + headerData.SFXStart, SeekOrigin.Begin);
                for (int i = 0; i < projectData.soundBanksCount; i++)
                {
                    ProjectSoundBank soundbankData = new ProjectSoundBank
                    {
                        soundBankHashCode = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        soundBankSlotNumber = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian)
                    };
                    projectData.soundBanksData.Add(soundbankData);
                }

                //Read Flags Data
                BReader.BaseStream.Seek(flagsPos + 16, SeekOrigin.Begin);
                projectData.stereoStreamCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                projectData.monoStreamCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                projectData.projectCode = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                for (int i = 0; i < 10; i++)
                {
                    projectData.flagsValues[i] = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian);
                }
            }
            return projectData;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}