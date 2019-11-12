using System;
using System.Windows.Forms;
namespace waveEditerVersion1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.waveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sampleEndTextbox = new System.Windows.Forms.TextBox();
            this.sampleStartTextbox = new System.Windows.Forms.TextBox();
            this.frequencyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oPENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecordGroup = new System.Windows.Forms.GroupBox();
            this.RecordPlay = new System.Windows.Forms.Button();
            this.RecordStop = new System.Windows.Forms.Button();
            this.recordStart = new System.Windows.Forms.Button();
            this.volume = new System.Windows.Forms.Button();
            this.volumeValue = new System.Windows.Forms.TextBox();
            this.PlayWav = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.waveChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.RecordGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // waveChart
            // 
            chartArea9.Name = "ChartArea1";
            this.waveChart.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.waveChart.Legends.Add(legend9);
            this.waveChart.Location = new System.Drawing.Point(71, 98);
            this.waveChart.Margin = new System.Windows.Forms.Padding(2);
            this.waveChart.Name = "waveChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series9.Legend = "Legend1";
            series9.Name = "waveSeries";
            this.waveChart.Series.Add(series9);
            this.waveChart.Size = new System.Drawing.Size(1179, 262);
            this.waveChart.TabIndex = 0;
            this.waveChart.Text = "waveChart";
            this.waveChart.Paint += new System.Windows.Forms.PaintEventHandler(this.WaveChart_Paint);
            this.waveChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WaveChart_MouseDown);
            this.waveChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WaveChart_MouseMove);
            this.waveChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WaveChart_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1064, 243);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "draw wave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1064, 129);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "Select Samples";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // sampleEndTextbox
            // 
            this.sampleEndTextbox.Location = new System.Drawing.Point(1160, 164);
            this.sampleEndTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.sampleEndTextbox.Name = "sampleEndTextbox";
            this.sampleEndTextbox.Size = new System.Drawing.Size(76, 26);
            this.sampleEndTextbox.TabIndex = 3;
            this.sampleEndTextbox.Text = "100";
            // 
            // sampleStartTextbox
            // 
            this.sampleStartTextbox.Location = new System.Drawing.Point(1160, 129);
            this.sampleStartTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.sampleStartTextbox.Name = "sampleStartTextbox";
            this.sampleStartTextbox.Size = new System.Drawing.Size(76, 26);
            this.sampleStartTextbox.TabIndex = 4;
            this.sampleStartTextbox.Text = "0";
            // 
            // frequencyChart
            // 
            chartArea10.Name = "ChartArea1";
            this.frequencyChart.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.frequencyChart.Legends.Add(legend10);
            this.frequencyChart.Location = new System.Drawing.Point(71, 390);
            this.frequencyChart.Margin = new System.Windows.Forms.Padding(2);
            this.frequencyChart.Name = "frequencyChart";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "frequencySeries";
            this.frequencyChart.Series.Add(series10);
            this.frequencyChart.Size = new System.Drawing.Size(1179, 265);
            this.frequencyChart.TabIndex = 5;
            this.frequencyChart.Text = "frequencyChart";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1064, 195);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 36);
            this.button3.TabIndex = 6;
            this.button3.Text = "DFT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPENToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1312, 36);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oPENToolStripMenuItem
            // 
            this.oPENToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.saveAsToolStripMenuItem});
            this.oPENToolStripMenuItem.Name = "oPENToolStripMenuItem";
            this.oPENToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.oPENToolStripMenuItem.Text = "File";
            this.oPENToolStripMenuItem.Click += new System.EventHandler(this.OPENToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wavToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 34);
            this.toolStripMenuItem1.Text = "open";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // wavToolStripMenuItem
            // 
            this.wavToolStripMenuItem.Name = "wavToolStripMenuItem";
            this.wavToolStripMenuItem.Size = new System.Drawing.Size(149, 34);
            this.wavToolStripMenuItem.Text = ".wav";
            this.wavToolStripMenuItem.Click += new System.EventHandler(this.WavToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(171, 34);
            this.saveAsToolStripMenuItem.Text = "save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // RecordGroup
            // 
            this.RecordGroup.Controls.Add(this.RecordPlay);
            this.RecordGroup.Controls.Add(this.RecordStop);
            this.RecordGroup.Controls.Add(this.recordStart);
            this.RecordGroup.Location = new System.Drawing.Point(1041, 468);
            this.RecordGroup.Margin = new System.Windows.Forms.Padding(2);
            this.RecordGroup.Name = "RecordGroup";
            this.RecordGroup.Padding = new System.Windows.Forms.Padding(2);
            this.RecordGroup.Size = new System.Drawing.Size(144, 170);
            this.RecordGroup.TabIndex = 8;
            this.RecordGroup.TabStop = false;
            this.RecordGroup.Text = "Record";
            this.RecordGroup.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // RecordPlay
            // 
            this.RecordPlay.Location = new System.Drawing.Point(5, 122);
            this.RecordPlay.Margin = new System.Windows.Forms.Padding(2);
            this.RecordPlay.Name = "RecordPlay";
            this.RecordPlay.Size = new System.Drawing.Size(134, 36);
            this.RecordPlay.TabIndex = 2;
            this.RecordPlay.Text = "Play";
            this.RecordPlay.UseVisualStyleBackColor = true;
            this.RecordPlay.Click += new System.EventHandler(this.Button4_Click_2);
            // 
            // RecordStop
            // 
            this.RecordStop.Location = new System.Drawing.Point(5, 74);
            this.RecordStop.Margin = new System.Windows.Forms.Padding(2);
            this.RecordStop.Name = "RecordStop";
            this.RecordStop.Size = new System.Drawing.Size(134, 35);
            this.RecordStop.TabIndex = 1;
            this.RecordStop.Text = "stop";
            this.RecordStop.UseVisualStyleBackColor = true;
            this.RecordStop.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // recordStart
            // 
            this.recordStart.Location = new System.Drawing.Point(5, 25);
            this.recordStart.Margin = new System.Windows.Forms.Padding(2);
            this.recordStart.Name = "recordStart";
            this.recordStart.Size = new System.Drawing.Size(134, 36);
            this.recordStart.TabIndex = 0;
            this.recordStart.Text = "start";
            this.recordStart.UseVisualStyleBackColor = true;
            this.recordStart.Click += new System.EventHandler(this.Button4_Click);
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(1046, 428);
            this.volume.Margin = new System.Windows.Forms.Padding(2);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(101, 35);
            this.volume.TabIndex = 9;
            this.volume.Text = "setVolume";
            this.volume.UseVisualStyleBackColor = true;
            this.volume.Click += new System.EventHandler(this.Button4_Click_3);
            // 
            // volumeValue
            // 
            this.volumeValue.Location = new System.Drawing.Point(1152, 434);
            this.volumeValue.Margin = new System.Windows.Forms.Padding(2);
            this.volumeValue.Name = "volumeValue";
            this.volumeValue.Size = new System.Drawing.Size(76, 26);
            this.volumeValue.TabIndex = 10;
            this.volumeValue.Text = "100";
            // 
            // PlayWav
            // 
            this.PlayWav.Location = new System.Drawing.Point(1064, 293);
            this.PlayWav.Margin = new System.Windows.Forms.Padding(2);
            this.PlayWav.Name = "PlayWav";
            this.PlayWav.Size = new System.Drawing.Size(172, 37);
            this.PlayWav.TabIndex = 11;
            this.PlayWav.Text = "Play";
            this.PlayWav.UseVisualStyleBackColor = true;
            this.PlayWav.Click += new System.EventHandler(this.Button4_Click_4);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(215, 36);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 42);
            this.button5.TabIndex = 13;
            this.button5.Text = "Copy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Copy_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(71, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 42);
            this.button4.TabIndex = 15;
            this.button4.Text = "Cut";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Cut_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(355, 36);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 42);
            this.button6.TabIndex = 16;
            this.button6.Text = "Paste";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Paste_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 684);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.PlayWav);
            this.Controls.Add(this.volumeValue);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.RecordGroup);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.frequencyChart);
            this.Controls.Add(this.sampleStartTextbox);
            this.Controls.Add(this.sampleEndTextbox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.waveChart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.waveChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RecordGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart waveChart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox sampleEndTextbox;
        private System.Windows.Forms.TextBox sampleStartTextbox;
        private System.Windows.Forms.DataVisualization.Charting.Chart frequencyChart;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oPENToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.GroupBox RecordGroup;
        private System.Windows.Forms.Button recordStart;
        private Button RecordStop;
        private Button RecordPlay;
        private Button volume;
        private TextBox volumeValue;
        private Button PlayWav;
        private Button button5;
        private Button button4;
        private Button button6;
    }
}

