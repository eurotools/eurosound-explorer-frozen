using System;
using System.IO;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal static class AudioFunctions
    {
        internal static byte[] ShortArrayToByteArray(short[] inputArray)
        {
            byte[] byteArray = new byte[inputArray.Length * 2];
            Buffer.BlockCopy(inputArray, 0, byteArray, 0, byteArray.Length);

            return byteArray;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        internal static byte[][] GetInterleavedStereo(byte[] inputData, int interleave_block_size)
        {
            byte[][] Channels = new byte[2][];

            //Calculate length and initialize index
            int TracksLength = inputData.Length / 2;
            bool InterleavedStereo = true;
            int IndexLC = 0, IndexRC = 0;

            //Init arrays
            Channels[0] = new byte[TracksLength];
            Channels[1] = new byte[TracksLength];

            //Read Stereo interleaving
            using (BinaryReader BReader = new BinaryReader(new MemoryStream(inputData)))
            {
                while (BReader.BaseStream.Position < inputData.Length)
                {
                    if (InterleavedStereo)
                    {
                        Buffer.BlockCopy(BReader.ReadBytes(interleave_block_size), 0, Channels[0], IndexLC, interleave_block_size);
                        IndexLC += interleave_block_size;
                    }
                    else
                    {
                        Buffer.BlockCopy(BReader.ReadBytes(interleave_block_size), 0, Channels[1], IndexRC, interleave_block_size);
                        IndexRC += interleave_block_size;
                    }
                    InterleavedStereo = !InterleavedStereo;
                }
            }

            return Channels;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
