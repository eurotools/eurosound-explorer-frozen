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
        internal void ReadSoundbank(string filePath, MusXHeaderData headerData, SortedDictionary<uint, SfxSound> samplesDictionary, List<SfxData> wavesList)
        {
            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Go to SFX Start
                BReader.BaseStream.Seek(headerData.SFXStart, SeekOrigin.Begin);

                //Loop througt stored elements
                uint sfxCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                for (int i = 0; i < sfxCount; i++)
                {
                    uint hashcode = 0x1A000000 | BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    uint sfxPos = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    long prevPos = BReader.BaseStream.Position;

                    //go to sound offset
                    BReader.BaseStream.Seek(sfxPos + headerData.SFXStart, SeekOrigin.Begin);

                    //Read sound properties
                    long startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
                    SfxSound sample = new SfxSound
                    {
                        DuckerLenght = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        MinDelay = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        MaxDelay = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        InnerRadius = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        OuterRadius = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                        ReverbSend = BReader.ReadSByte(),
                        TrackingType = BReader.ReadSByte(),
                        MaxVoices = BReader.ReadSByte(),
                        Priority = BReader.ReadSByte(),
                        Ducker = BReader.ReadSByte(),
                        MasterVolume = BReader.ReadSByte()
                    };
                    sample.HexViewerData.HeaderDataLength = startOffset;

                    //Read flags
                    startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
                    sample.Flags = BReader.ReadUInt16();
                    sample.HexViewerData.FlagsDataLength = startOffset;

                    //get samples count
                    startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
                    ushort sfxSamplesCount = BinaryFunctions.FlipUShort(BReader.ReadUInt16(), headerData.IsBigEndian);

                    //Loop througt all SFX samples
                    for (int j = 0; j < sfxSamplesCount; j++)
                    {
                        //Read sample properties
                        SfxSample samplePoolItem = new SfxSample()
                        {
                            FileRef = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                            OldMusXPitch = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                            OldMusXPitchOffset = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian),
                            Volume = BReader.ReadSByte(),
                            VolumeOffset = BReader.ReadSByte(),
                            Pan = BReader.ReadSByte(),
                            PanOffset = BReader.ReadSByte()
                        };
                        sample.samplesList.Add(samplePoolItem);

                        //Padding
                        BReader.BaseStream.Seek(2, SeekOrigin.Current);
                    }
                    sample.HexViewerData.SamplePoolDataLength = startOffset;

                    //Save in dictionary
                    samplesDictionary.Add(hashcode, sample);

                    //Read data to show in the Hex viewer
                    sample.HexViewerData.BinaryLength = (int)(BReader.BaseStream.Position - (sfxPos + headerData.SFXStart));
                    BReader.BaseStream.Seek(sfxPos + headerData.SFXStart, SeekOrigin.Begin);
                    sample.HexViewerData.BinaryData = BReader.ReadBytes(sample.HexViewerData.BinaryLength);

                    //return 
                    BReader.BaseStream.Seek(prevPos, SeekOrigin.Begin);
                }

                //Go to sample info section
                BReader.BaseStream.Seek(headerData.SampleInfoStart, SeekOrigin.Begin);
                uint waveCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                for (int i = 0; i < waveCount; i++)
                {
                    SfxData wavHeaderData = new SfxData
                    {
                        Flags = (ushort)BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                        Address = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        MemorySize = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Frequency = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        SampleSize = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Channels = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Bits = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        PsiSampleHeader = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        LoopStartOffset = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Duration = BReader.ReadInt32(),
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
        internal void LoadStreamFile(string filePath, MusXHeaderData headerData, List<SfxStream> StreamFileDictionaryData)
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
                    SfxStream StreamSoundToAdd = new SfxStream
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
                        StartMarker StartMarker = new StartMarker
                        {
                            Index = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
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
                        Marker DataMarker = new Marker
                        {
                            Index = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
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
                    StartMarker StartMarker = new StartMarker
                    {
                        Index = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
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
                    Marker DataMarker = new Marker
                    {
                        Index = BinaryFunctions.FlipInt32(binaryReader.ReadInt32(), headerData.IsBigEndian),
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
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
