using System;
using System.Runtime.InteropServices;
using static System.Text.Encoding;
using System.IO;

namespace WaveFile
{
    public class Wav
    {

        public string RIFFChunkID;

        public uint RIFFChuckSize;

        public string format;

        public string fmtChuckID;

        public uint fmtChunkSize;
        public uint audioFormat;
        public uint numChannels;
        public uint sampleRate;
        public uint byteRate;
        public uint blockAlign;
        public uint bitsPerSample;
        public string dataChunkID;
        public uint dataChunkSize;


        public Wav(string rci, uint rcs, string fmt, 
                          string fci, uint fcs, uint af, uint nc, uint sr, uint br, uint ba, uint bps,
                          string dci, uint dcs )
        {
     
            RIFFChunkID = rci;
            RIFFChuckSize = rcs;
            format = fmt;
            fmtChuckID = fci;
            fmtChunkSize = fcs;
            audioFormat = af;
            numChannels = nc;
            sampleRate = sr;
            byteRate = br;
            blockAlign = ba;
            bitsPerSample = bps;
            dataChunkID = dci;
            dataChunkSize = dcs;
        }

        public Wav(byte[] bytes)
        {
            byte[] temp;

            // RIFF chunk
            temp = ReadField(bytes[0], bytes[1], bytes[2], bytes[3]);
            RIFFChunkID = Default.GetString(temp);
            temp = ReadField(bytes[4], bytes[5], bytes[6], bytes[7]);
            RIFFChuckSize = BitConverter.ToUInt32(temp, 0);
            temp = ReadField(bytes[8], bytes[9], bytes[10], bytes[11]);
            format = Default.GetString(temp);

            // fmt chuck
            temp = ReadField(bytes[12], bytes[13], bytes[14], bytes[15]);
            fmtChuckID = Default.GetString(temp);
            temp = ReadField(bytes[16], bytes[17], bytes[18], bytes[19]);
            fmtChunkSize = BitConverter.ToUInt32(temp, 0);
            temp = ReadField(bytes[20], bytes[21]);
            audioFormat = BitConverter.ToUInt32(temp, 0);
            temp = ReadField(bytes[22], bytes[23]);
            numChannels = BitConverter.ToUInt32(temp, 0);
            temp = ReadField(bytes[24], bytes[25], bytes[26], bytes[27]);
            sampleRate = BitConverter.ToUInt32(temp, 0);
            temp = ReadField(bytes[28], bytes[29], bytes[30], bytes[31]);
            byteRate = BitConverter.ToUInt32(temp, 0);
            temp = ReadField(bytes[32], bytes[33]);
            blockAlign = BitConverter.ToUInt32(temp, 0);
            temp = ReadField(bytes[34], bytes[35]);
            bitsPerSample = BitConverter.ToUInt32(temp, 0);

            // data chunk
            temp = ReadField(bytes[36], bytes[37], bytes[38], bytes[39]);
            dataChunkID = Default.GetString(temp);
            temp = ReadField(bytes[40], bytes[41], bytes[42], bytes[43]);
            dataChunkSize = BitConverter.ToUInt32(temp, 0);
        }

        private byte[] ReadField(byte b1, byte b2, byte b3 = 0, byte b4 = 0)
        {
            byte[] result = new byte[4];

            result[0] = b1;
            result[1] = b2;
            result[2] = b3;
            result[3] = b4;

            return result;
        }

        public static float[] readWav(string filename)
        {
            //float [] left = new float[1];

            //float [] right;
            try
            {
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    BinaryReader reader = new BinaryReader(fs);

                    // chunk 0
                    int chunkID = reader.ReadInt32();
                    int fileSize = reader.ReadInt32();
                    int riffType = reader.ReadInt32();


                    // chunk 1
                    int fmtID = reader.ReadInt32();
                    int fmtSize = reader.ReadInt32(); // bytes for this chunk
                    int fmtCode = reader.ReadInt16();
                    int channels = reader.ReadInt16();
                    int sampleRate = reader.ReadInt32();
                    int byteRate = reader.ReadInt32();
                    int fmtBlockAlign = reader.ReadInt16();
                    int bitDepth = reader.ReadInt16();

                    if (fmtSize == 18)
                    {
                        // Read any extra values
                        int fmtExtraSize = reader.ReadInt16();
                        reader.ReadBytes(fmtExtraSize);
                    }

                    // chunk 2
                    int dataID = reader.ReadInt32();
                    int bytes = reader.ReadInt32();

                    // DATA!
                    byte[] byteArray = reader.ReadBytes(bytes);

                    int bytesForSamp = bitDepth / 8;
                    int samps = bytes / bytesForSamp;


                    float[] asFloat = null;
                    switch (bitDepth)
                    {
                        case 64:
                            double[]
                            asDouble = new double[samps];
                            Buffer.BlockCopy(byteArray, 0, asDouble, 0, bytes);
                            asFloat = Array.ConvertAll(asDouble, e => (float)e);
                            return asFloat;
                        case 32:
                            asFloat = new float[samps];
                            Buffer.BlockCopy(byteArray, 0, asFloat, 0, bytes);
                            return asFloat;
                        case 16:
                            Int16[]
                            asInt16 = new Int16[samps];
                            Buffer.BlockCopy(byteArray, 0, asInt16, 0, bytes);
                            asFloat = Array.ConvertAll(asInt16, e => e / (float)Int16.MaxValue);
                            return asFloat;
                        default:
                            return null;
                    }

                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("...Failed to load note: " + filename);
                return null;
                //left = new float[ 1 ]{ 0f };
            }

            return null;
        }

    }


}
