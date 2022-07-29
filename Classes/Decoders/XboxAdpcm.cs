﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_explorer
{
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------
    internal class XboxAdpcm
    {
        //-------------------------------------------------------------------------------------------------------------------------------
        private class ImaAdpcmState
        {
            public int valprev;
            public int index;
        }

        /* Intel ADPCM step variation table */
        private readonly int[] indexTable = {
            -1, -1, -1, -1, 2, 4, 6, 8,
            -1, -1, -1, -1, 2, 4, 6, 8,
        };
        
        //-------------------------------------------------------------------------------------------------------------------------------
        private readonly int[] stepsizeTable = {
            7, 8, 9, 10, 11, 12, 13, 14, 16, 17,
            19, 21, 23, 25, 28, 31, 34, 37, 41, 45,
            50, 55, 60, 66, 73, 80, 88, 97, 107, 118,
            130, 143, 157, 173, 190, 209, 230, 253, 279, 307,
            337, 371, 408, 449, 494, 544, 598, 658, 724, 796,
            876, 963, 1060, 1166, 1282, 1411, 1552, 1707, 1878, 2066,
            2272, 2499, 2749, 3024, 3327, 3660, 4026, 4428, 4871, 5358,
            5894, 6484, 7132, 7845, 8630, 9493, 10442, 11487, 12635, 13899,
            15289, 16818, 18500, 20350, 22385, 24623, 27086, 29794, 32767
        };

        //-------------------------------------------------------------------------------------------------------------------------------
        public byte[] Decode(byte[] ImaFileData)
        {
            byte[] outBuff;
            int sign;               /* Current adpcm sign bit */
            int delta;              /* Current adpcm output value */
            int step;               /* Stepsize */
            int valpred;            /* Predicted value */
            int vpdiff;             /* Current change to valpred */
            int index;              /* Current step change index */
            int inputbuffer;        /* place to keep next 4-bit value */

            using (BinaryReader BReader = new BinaryReader(new MemoryStream(ImaFileData)))
            using (MemoryStream pcmStream = new MemoryStream())
            using (BinaryWriter pcmWriter = new BinaryWriter(pcmStream))
            {
                ImaAdpcmState state = new ImaAdpcmState();
                while (BReader.BaseStream.Position < BReader.BaseStream.Length)
                {
                    valpred = BReader.ReadInt16();
                    index = BReader.ReadInt16();
                    step = stepsizeTable[index];

                    for (int j = 0; j < 8; j++)
                    {
                        bool bufferstep = false;
                        for (int k = 0; k < 8; k++)
                        {
                            /* Step 1 - get the delta value */
                            inputbuffer = BReader.ReadByte();
                            BReader.BaseStream.Position -= 1;

                            if (bufferstep)
                            {
                                delta = (inputbuffer >> 4) & 0xf;
                                BReader.BaseStream.Position++;
                            }
                            else
                            {
                                delta = inputbuffer & 0xf;
                            }
                            bufferstep = !bufferstep;

                            /* Step 2 - Find new index value (for later) */
                            index += indexTable[delta & 7];
                            if (index < 0) index = 0;
                            if (index > 88) index = 88;

                            /* Step 3 - Separate sign and magnitude */
                            sign = delta & 8;
                            delta &= 7;

                            /* Step 4 - Compute difference and new predicted value */
                            /*
                            ** Computes 'vpdiff = (delta+0.5)*step/4', but see comment
                            ** in adpcm_coder.
                            */
                            vpdiff = step >> 3;
                            if ((delta & 4) != 0) vpdiff += step;
                            if ((delta & 2) != 0) vpdiff += step >> 1;
                            if ((delta & 1) != 0) vpdiff += step >> 2;

                            if (sign != 0)
                                valpred -= vpdiff;
                            else
                                valpred += vpdiff;

                            /* Step 5 - clamp output value */
                            if (valpred > short.MaxValue)
                                valpred = short.MaxValue;
                            else if (valpred < short.MinValue)
                                valpred = short.MinValue;

                            /* Step 6 - Update step value */
                            step = stepsizeTable[index];

                            /* Step 7 - Output value */
                            pcmWriter.Write((short)valpred);
                        }
                        state.valprev = valpred;
                        state.index = index;
                    }
                }
                outBuff = pcmStream.ToArray();

                pcmWriter.Close();
                pcmStream.Close();
                BReader.Close();
            }

            return outBuff;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
}
