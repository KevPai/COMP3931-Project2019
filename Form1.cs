﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WaveFile;
using static Wave.Fourier;


namespace waveEditerVersion1
{
    public partial class Form1 : Form

    {
        double[] samples;
        byte[] signalData;
        byte[] bData;
        int sampleStart = 0, sampleEnd = 0, sampleRange = 0;
        bool selected = false;
        Wave.Fourier fourier = new Wave.Fourier();
        double volumeVal = 1.0;

        Wav wav;




        public Form1()
        {
            InitializeComponent();
        }


        public void readWaveFile()
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    samples = Array.ConvertAll(WaveFile.Wav.readWav(fileDialog.FileName), e => (double) e);
            //    plotSample(samples.Length);
            //}
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                byte[] wavData = File.ReadAllBytes(fileDialog.FileName);
                byte[] wavHeader = new List<byte>(wavData).GetRange(0, 44).ToArray();
                wav = new WaveFile.Wav(wavHeader);
                wavData = new List<byte>(wavData).GetRange(44, wavData.Length - 44).ToArray();

                Debug.WriteLine("\nOpening File:"
                    + "\nChunk ID:        " + wav.RIFFChunkID
                    + "\nRIFF Chuck Size: " + wav.RIFFChuckSize
                    + "\nFormat:          " + wav.format
                    + "\nfmt Chuck ID:    " + wav.fmtChuckID
                    + "\nfmt Chunk Size:  " + wav.fmtChunkSize
                    + "\naudio format:    " + wav.audioFormat
                    + "\nNum Channels:    " + wav.numChannels
                    + "\nSample Rate:     " + wav.sampleRate
                    + "\nByte Rate:       " + wav.byteRate
                    + "\nBlock Align:     " + wav.blockAlign
                    + "\nBits Per Sample: " + wav.bitsPerSample
                    + "\nData Chunk ID:   " + wav.dataChunkID
                    + "\nData Chunk Size: " + wav.dataChunkSize);
                signalData = new byte[wavData.Length];
                signalData = wavData;
                generateWavSample(wavData);
            }
        }
        public void generateWavSample(byte[] data)
        {
            samples = new double[(int)wav.dataChunkSize / wav.blockAlign];
            short[] temp = new short[samples.Length];

            for (int i = 0, j = 0; i < wav.dataChunkSize - 4; i += (int)wav.blockAlign, j++)
            {
                temp[j] = BitConverter.ToInt16(data, i);
            }
            samples = temp.Select(x => (double)(x)).ToArray();
            plotSample(samples.Length);
        }


        public void plotSample(int length)
        {
            waveChart.Series["waveSeries"].Points.Clear();
            Series series = waveChart.Series["waveSeries"];
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.Double;

            double miny = 5;
            double maxy = -5;

            //if (!selected)
            if (samples != null)
            {
                for (int i = 0; i < length; i++)
                {
                    if (samples[i] < miny)
                    {
                        miny = samples[i];
                    }
                    else if (samples[i] > maxy)
                    {
                        maxy = samples[i];
                    }
                    waveChart.Series["waveSeries"].Points.AddXY(i, samples[i]);

                }
                ChartArea chartArea = waveChart.ChartAreas[waveChart.Series["waveSeries"].ChartArea];
                chartArea.AxisX.Minimum = 0;
                chartArea.AxisX.Maximum = length;
                chartArea.AxisX.ScaleView.Zoomable = true;
                chartArea.AxisX.ScaleView.Zoom(0, 100);
                chartArea.AxisY.Minimum = miny;
                chartArea.AxisY.Maximum = maxy;
                chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
                chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chartArea.AxisX.ScrollBar.ButtonColor = Color.Black;
            }
            //else
            //{
            //    sampleRange = sampleEnd - sampleStart;
            //    for (int i = 0; i < sampleRange; i++)
            //    {
            //        waveChart.Series["waveSeries"].Points.AddXY(sampleStart+i, samples[sampleStart + i]);
            //    }
            //    ChartArea chartArea = waveChart.ChartAreas[waveChart.Series["waveSeries"].ChartArea];
            //    chartArea.AxisX.Minimum = sampleStart;
            //    chartArea.AxisX.Maximum = sampleEnd;
            //    chartArea.AxisX.ScaleView.Zoomable = true;
            //    chartArea.AxisX.ScaleView.Zoom(sampleStart, sampleRange);
            //    chartArea.AxisY.Minimum = -4;
            //    chartArea.AxisY.Maximum = 4;
            //    chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            //    chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            //    chartArea.AxisX.ScrollBar.ButtonColor = Color.Black;
            //}
        }
        public void saveAsWav()
        {
            if (wav == null)
                return;
            short[] toShort = samples.Select(e => (short)(e)).ToArray();
            byte[] data = toShort.Select(e => Convert.ToInt16(e))
                .SelectMany(e => BitConverter.GetBytes(e)).ToArray();
            byte[] header = new byte[44];


            Buffer.BlockCopy(wav.RIFFChunkID.ToCharArray(), 0, header, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.RIFFChuckSize), 0, header, 4, 4);
            Buffer.BlockCopy(wav.format.ToCharArray(), 0, header, 8, 4);
            Buffer.BlockCopy(wav.fmtChuckID.ToCharArray(), 0, header, 12, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.fmtChunkSize), 0, header, 16, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.audioFormat), 0, header, 20, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.numChannels), 0, header, 22, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.sampleRate), 0, header, 24, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.byteRate), 0, header, 28, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.blockAlign), 0, header, 32, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.bitsPerSample), 0, header, 34, 2);
            Buffer.BlockCopy(wav.dataChunkID.ToCharArray(), 0, header, 36, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(wav.dataChunkSize), 0, header, 40, 4);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "WAV|*.wav";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveDialog.FileName, FileMode.CreateNew))
                {
                    using (BinaryWriter bw = new BinaryWriter(s))
                    {
                        bw.Write(header);
                        bw.Write(data);
                    }
                }
            }
        }

        private void ApplyDFT()
        {
            Series frequencySeries = frequencyChart.Series["frequencySeries"];
            double[] Amp = fourier.DFT(samples);
            int N = Amp.Length;
            for (int f = 0; f < N; f++)
            {
                frequencySeries.Points.AddXY(f, Amp[f]);
            }
        }

        public void StartRecord()
        {
            Debug.WriteLine(OpenDialog() ? "open rec succeeded" : "open rec failed");
            Debug.WriteLine(StartRec(16, 22050) ? "start rec succeeded" : "start rec failed");
        }
        public void StopRecord()
        {
            RecordData recordData = StopRec();
            bData = new byte[recordData.len];
            Debug.WriteLine(recordData.len);
            Marshal.Copy(recordData.ip, bData, 0, (int)recordData.len);

            WaveHeader header = (WaveHeader)Marshal.PtrToStructure(GetWaveform(), typeof(WaveHeader));
            wav = new Wav("RIFF", recordData.len + 36, "WAVE",
                "fmt", 16, 1, header.nChannels, header.nSamplesPerSec,
                header.nAvgBytesPerSec, header.nBlockAlign, header.wBitsPerSample,
                "data", recordData.len);


            short[] temp = new short[recordData.len / (int)wav.blockAlign];
            for (int i = 0; i < temp.Length - 1; i++)
                temp[i] = BitConverter.ToInt16(bData, i * (int)wav.blockAlign);
            samples = temp.Select(x => (double)(x)).ToArray();

            plotSample(samples.Length);
        }
        public void PlayRecord()
        {
            //byte[] data = null;
            //data = samples.Select(x => (short)(x)).ToArray()
            //        .Select(x => Convert.ToInt16(x))
            //        .SelectMany(x => BitConverter.GetBytes(x)).ToArray();
            if (volumeVal != 1)
            {

                int c = bData.Length;
                Debug.WriteLine(bData[5000]);
                for (int i = 0; i < c; i++)
                {
                    double temp = bData[i];
                    temp -= 128;
                    temp *= volumeVal;
                    temp += 128;
                    if (temp > 255)
                    {
                        temp = 255;
                    }
                    if (temp < 0)
                    {
                        temp = 0;
                    }
                    bData[i] = (byte)temp;
                }
                Debug.WriteLine(bData[5000]);
            }

            IntPtr iptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(byte)) * bData.Length);
            Marshal.Copy(bData, 0, iptr, bData.Length);
            Debug.WriteLine(PlayStart(iptr, bData.Length, 16, 22050) ?
                "play start succeeded" : "play start failed");
            Marshal.FreeHGlobal(iptr);
        }

        void playWavSignal()
        {
            // make sure not to opendialog twice. do an if statement check later.
            OpenDialog();
            IntPtr iptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(byte)) * signalData.Length);
            Marshal.Copy(signalData, 0, iptr, signalData.Length);
            Debug.WriteLine(PlayStart(iptr, signalData.Length, 16, 22050) ?
                "play start succeeded" : "play start failed");
            Marshal.FreeHGlobal(iptr);
        }

        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool OpenDialog();
        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CloseDialog();
        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern RecordData StopRec();
        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StartRec(int d, int r);
        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaveform();
        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PlayPause();
        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PlayStart(IntPtr p, int size, int d, int r);
        [DllImport("Record.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PlayStop();

        public struct RecordData
        {
            public uint len;
            public IntPtr ip;
        }

        public struct WaveHeader
        {
            public ushort wFormatTag;
            public ushort nChannels;
            public uint nSamplesPerSec;
            public uint nAvgBytesPerSec;
            public ushort nBlockAlign;
            public ushort wBitsPerSample;
            public ushort cbSize;
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            ApplyDFT();
        }

        private void OPENToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void WavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readWaveFile();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsWav();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartRecord();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            StopRecord();
        }

        private void Button4_Click_2(object sender, EventArgs e)
        {
            PlayRecord();
        }

        private void Button4_Click_3(object sender, EventArgs e)
        {
            volumeVal = double.Parse(volumeValue.Text) / 100.0;
        }

        private void Button4_Click_4(object sender, EventArgs e)
        {
            playWavSignal();
        }

        Point? clickPosition = null;
        Point startPos; 
        Point currentPos;
        bool drawing;
        List<Rectangle> rectangles = new List<Rectangle>();
        double startX, endX;
        List<double> originSamples, tempSamples, cutSamples;
        bool cut, copy, paste;

        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }

        private void WaveChart_MouseDown(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            clickPosition = pos;
            var results = waveChart.HitTest(pos.X, pos.Y, false,
                             ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    currentPos = startPos = e.Location;
                    drawing = true;

                    startX = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    Debug.WriteLine("Starting point is: " + startX);
                }
            }

            if (paste && (tempSamples != null) && (originSamples != null))
            {
                for (int i = 0; i < tempSamples.Count; i++)
                {
                    originSamples.Insert((((int) startX) + i), tempSamples.ElementAt(i));
                }

                samples = originSamples.ToArray();
                plotSample(samples.Length);

                paste = false;
            }
        }

        private void WaveChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickPosition.HasValue && e.Location != clickPosition)
            {
                clickPosition = null;
            }

            currentPos = e.Location;
            if (drawing) waveChart.Invalidate();
        }

        private void WaveChart_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                waveChart.Invalidate();
            }

            var pos = e.Location;
            clickPosition = pos;
            var results = waveChart.HitTest(pos.X, pos.Y, false,
                             ChartElementType.PlottingArea);

            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    endX = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    Debug.WriteLine("Ending point is: " + endX);


                    if (cut || copy)
                    {
                        originSamples = samples.OfType<double>().ToList();
                        tempSamples = new List<double>();
                        for (int i = 0; i < samples.Length; i++)
                        {
                            if (startX < i && endX > i)
                            {
                                tempSamples.Add(originSamples.ElementAt(i));
                            }
                        }

                        if (cut)
                        {
                            cutSamples = originSamples.Except(tempSamples).ToList();

                            samples = cutSamples.ToArray();
                            plotSample(samples.Length);
                        }

                        cut = false;
                        copy = false;
                    }
                }
            }
        }

        private void WaveChart_Paint(object sender, PaintEventArgs e)
        {
            if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            cut = true;
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            copy = true;
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            paste = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            sampleStart = int.Parse(sampleStartTextbox.Text);
            sampleEnd = int.Parse(sampleEndTextbox.Text);
            selected = true;
            plotSample(300);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            plotSample(300);
        }
    }   
}
