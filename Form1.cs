using System;
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
using Wave;

namespace waveEditerVersion1
{
    public partial class Form1 : Form

    {
        double[] samples, selectedSamples, selectedFourier, fourierAmp;
        int selectedRange, selectStart, selectEnd;
        int fourierRange, startFourier, endFourier;
        byte[] signalData;
        byte[] bData;
        int sampleStart = 0, sampleEnd = 0, sampleRange = 0;
        bool selected = false;
        bool selectFourier = false;
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

        public void copy()
        {
            short[] toShort = samples.Select(element => (short)(element)).ToArray();
            signalData = toShort.Select(element => Convert.ToInt16(element))
            .SelectMany(element => BitConverter.GetBytes(element)).ToArray();

            plotSample(samples.Length);
        }

        public void cut()
        {
            if (!selected)
            {
                return;
            }
            selectedSamples = new double[selectedRange];

            double[] left = new List<double>(samples).GetRange(0, selectStart).ToArray();
            double[] right = new List<double>(samples).GetRange(selectEnd, samples.Length - selectEnd).ToArray();
            selectedSamples = new List<double>(samples).GetRange(selectStart, selectedRange).ToArray();

            samples = new double[left.Length + right.Length];
            left.CopyTo(samples, 0);
            right.CopyTo(samples, left.Length);

            short[] toShort = samples.Select(element => (short)(element)).ToArray();
            signalData = toShort.Select(element => Convert.ToInt16(element))
            .SelectMany(element => BitConverter.GetBytes(element)).ToArray();


            plotSample(samples.Length);
        }

        public void paste()
        {
            double[] left = new List<double>(samples).GetRange(0, selectEnd).ToArray();
            double[] right = new List<double>(samples).GetRange(selectEnd, samples.Length - selectEnd).ToArray();

            samples = new double[left.Length + selectedSamples.Length + right.Length];
            left.CopyTo(samples, 0);
            selectedSamples.CopyTo(samples, left.Length);
            right.CopyTo(samples, selectedSamples.Length + left.Length);

            short[] toShort = samples.Select(element => (short)(element)).ToArray();
            signalData = toShort.Select(element => Convert.ToInt16(element))
            .SelectMany(element => BitConverter.GetBytes(element)).ToArray();

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
                //chartArea.AxisX.ScaleView.Zoomable = true;
                //chartArea.AxisX.ScaleView.Zoom(0, 100);
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
            frequencySeries.Points.Clear();

            if (!selected)
            {
                return;
            }
            fourierAmp = fourier.DFT(selectedSamples);

            int N = fourierAmp.Length;
            for (int f = 0; f < N; f++)
            {
                frequencySeries.Points.AddXY(f, fourierAmp[f]);
            }
        }

        private void ApplyInverse()
        {
            if (fourierAmp == null)
            {
                return;
            }

            samples = fourier.inverseDFT(fourierAmp);
            plotSample(samples.Length);

            short[] toShort = samples.Select(element => (short)(element)).ToArray();
            signalData = toShort.Select(element => Convert.ToInt16(element))
            .SelectMany(element => BitConverter.GetBytes(element)).ToArray();
        }

        private void ApplyFilter()
        {
            Series frequencySeries = frequencyChart.Series["frequencySeries"];
            frequencySeries.Points.Clear();

            if (fourierAmp == null)
            {
                return;
            }

            fourierAmp = fourier.applyFilter(double.Parse(HighPassValue.Text), double.Parse(LowPassValue.Text), fourierAmp);
            for (int f = 0; f < fourierAmp.Length; f++)
            {
                frequencySeries.Points.AddXY(f, fourierAmp[f]);
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

        //void selectSamples(object sender, CursorEventArgs e)
        //{
        //    if (samples == null)
        //    {
        //        return;
        //    }
        //    selectStart = (int)e.NewSelectionStart;
        //    selectEnd = (int)e.NewSelectionEnd;
        //    selectedRange = Math.Abs(selectStart - selectEnd);
        //}
        private void selectionSignal(object sender, CursorEventArgs e)
        {
            if (samples == null)
            {
                return;
            }
            selected = true;
            selectStart = (int)e.NewSelectionStart;
            selectEnd = (int)e.NewSelectionEnd;

            Debug.WriteLine((int)e.NewSelectionStart);
            Debug.WriteLine((int)e.NewSelectionEnd);

            if (selectStart > selectEnd)
            {
                int temp = selectEnd;
                selectEnd = selectStart;
                selectStart = temp;
            }
            selectedRange = Math.Abs(selectEnd - selectStart);

            selectedSamples = new double[selectedRange];
            selectedSamples = new List<double>(samples).GetRange(selectStart, selectedRange).ToArray();

            return;
        }

        private void selectionFreq(object sender, CursorEventArgs a)
        {
            /*if (fourierAmp == null)
            {
                return;
            }
            selectFourier = true;
            startFourier = (int)a.NewSelectionStart;
            endFourier = (int)a.NewSelectionEnd;
            if (startFourier > endFourier)
            {
                int temp = endFourier;
                endFourier = startFourier;
                startFourier = temp;
            }
            fourierRange = Math.Abs(endFourier - selectStart);

            selectedFourier = new double[fourierRange];
            selectedFourier = new List<double>(fourierAmp).GetRange(startFourier, fourierRange).ToArray();*/

            Debug.WriteLine((int)a.NewSelectionStart);
            Debug.WriteLine((int)a.NewSelectionEnd);

            return;
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

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cut();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paste();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void InverseDFT_Click(object sender, EventArgs e)
        {
            ApplyInverse();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copy();
        }

        private void FilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("FILTERING");
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
