using System.Collections.Generic;
using System.IO;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal class NewMusX
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        internal void ReadSoundbank(string filePath, MusXHeaderData headerData, SortedDictionary<uint, Sample> samplesDictionary, List<WavHeaderData> wavesList)
        {
            using (BinaryReader BReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                //Read SFX Start
                BReader.BaseStream.Seek(headerData.SFXStart, SeekOrigin.Begin);
                uint sfxCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                for (int i = 0; i < sfxCount; i++)
                {
                    uint hashcode = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian) | 0x1A000000;
                    uint sfxPos = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                    long prevPos = BReader.BaseStream.Position;

                    //Goto SFX Data
                    BReader.BaseStream.Seek(headerData.SFXStart + sfxPos, SeekOrigin.Begin);

                    //Save position
                    long startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
                    Sample sample = new Sample
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
                    if (!headerData.Platform.Equals("PS2_"))
                    {
                        sample.GroupHashCode = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian);
                        sample.GroupMaxChannels = BReader.ReadSByte();
                        BReader.ReadSByte();

                        //Flags
                        startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
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
                        startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
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
                    else
                    {
                        sample.GroupHashCode = BinaryFunctions.FlipShort(BReader.ReadInt16(), headerData.IsBigEndian);
                        sample.GroupMaxChannels = (sbyte)(sample.GroupHashCode & 15);
                        sample.GroupHashCode >>= 4;

                        //Read Flags
                        startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
                        sample.Flags = BinaryFunctions.FlipUShort(BReader.ReadUInt16(), headerData.IsBigEndian);
                        sample.HexViewerData.FlagsDataLength = startOffset;

                        //Read UserFlags
                        startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
                        if (headerData.Platform.Equals("PS2_") & headerData.FileVersion > 4)
                        {
                            sample.UserFlags = BinaryFunctions.FlipUShort(BReader.ReadUInt16(), headerData.IsBigEndian);
                            sample.DopplerValue = BReader.ReadSByte();
                            sample.UserValue = BReader.ReadSByte();
                        }
                        sample.HexViewerData.UserFlagsDataLength = startOffset;
                    }

                    if (headerData.FileVersion > 5)
                    {
                        sample.SFXDucker = BReader.ReadSByte();
                        sample.Spare = BReader.ReadSByte();
                    }

                    //Read Sample Pool 
                    startOffset = BReader.BaseStream.Position - (headerData.SFXStart + sfxPos);
                    ushort samplesCount = BinaryFunctions.FlipUShort(BReader.ReadUInt16(), headerData.IsBigEndian);
                    for (int j = 0; j < samplesCount; j++)
                    {
                        SamplePoolItem samplePoolItem = new SamplePoolItem
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
                    samplesDictionary.Add(hashcode, sample);

                    //Read data to show in the Hex viewer
                    sample.HexViewerData.BinaryLength = (int)(BReader.BaseStream.Position - (sfxPos + headerData.SFXStart));
                    BReader.BaseStream.Seek(sfxPos + headerData.SFXStart, SeekOrigin.Begin);
                    sample.HexViewerData.BinaryData = BReader.ReadBytes(sample.HexViewerData.BinaryLength);

                    //return 
                    BReader.BaseStream.Seek(prevPos, SeekOrigin.Begin);
                }

                //Read Sample info
                BReader.BaseStream.Seek(headerData.SampleInfoStart, SeekOrigin.Begin);
                uint waveCount = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian);
                for (int i = 0; i < waveCount; i++)
                {
                    WavHeaderData wavHeaderData = new WavHeaderData
                    {
                        Flags = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Address = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        MemorySize = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        Frequency = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        SampleSize = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        PSI_SampleHeader = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        LoopStartOffset = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        DurationInMilliseconds = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian)
                    };

                    //Store current position
                    long pos = BReader.BaseStream.Position;

                    //Read audio pcm data
                    BReader.BaseStream.Seek(headerData.SampleDataStart + wavHeaderData.Address, SeekOrigin.Begin);
                    wavHeaderData.EncodedData = BReader.ReadBytes(wavHeaderData.SampleSize);

                    //Read coeffs
                    if (headerData.Platform.Contains("GC"))
                    {
                        BReader.BaseStream.Seek(headerData.SpecialSampleInfoStart + wavHeaderData.PSI_SampleHeader, SeekOrigin.Begin);
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
                    BReader.BaseStream.Seek(pos, SeekOrigin.Begin);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal void ReadStreamFile(string filePath, MusXHeaderData headerData, List<StreamSample> streamedSamples)
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

                    StreamSample streamSample = new StreamSample
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
                        StreamStartMarker StartMarker = new StreamStartMarker
                        {
                            Name = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                            Position = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            Type = (byte)BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopStart = BinaryFunctions.FlipUInt32(BReader.ReadUInt32(), headerData.IsBigEndian),
                            LoopMarkerCount = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                            MarkerPos = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
                        };

                        //Add marker
                        streamSample.StartMarkers.Add(StartMarker);
                    }

                    //Stream marker data 
                    for (int k = 0; k < streamSample.MarkersCount; k++)
                    {
                        StreamMarker DataMarker = new StreamMarker
                        {
                            Name = BinaryFunctions.FlipInt32(BReader.ReadInt32(), headerData.IsBigEndian),
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
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
