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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.waveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sampleEndTextbox = new System.Windows.Forms.TextBox();
            this.sampleStartTextbox = new System.Windows.Forms.TextBox();
            this.frequencyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.filterButton = new System.Windows.Forms.Button();
            this.HighPassValue = new System.Windows.Forms.TextBox();
            this.LowPassValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inverseDFT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.waveChart)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyChart)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.RecordGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // waveChart
            // 
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisY.ScaleView.Zoomable = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.waveChart.ChartAreas.Add(chartArea1);
            this.waveChart.ContextMenuStrip = this.contextMenuStrip1;
            this.waveChart.Cursor = System.Windows.Forms.Cursors.IBeam;
            legend1.Name = "Legend1";
            this.waveChart.Legends.Add(legend1);
            this.waveChart.Location = new System.Drawing.Point(71, 47);
            this.waveChart.Margin = new System.Windows.Forms.Padding(2);
            this.waveChart.Name = "waveChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "waveSeries";
            this.waveChart.Series.Add(series1);
            this.waveChart.Size = new System.Drawing.Size(1179, 275);
            this.waveChart.TabIndex = 0;
            this.waveChart.Text = "waveChart";
            this.waveChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.selectionSignal);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.pasteToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 100);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(126, 32);
            this.toolStripMenuItem2.Text = "Cut";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(126, 32);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(126, 32);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1064, 243);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Draw Wave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1063, 93);
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
            this.sampleEndTextbox.Location = new System.Drawing.Point(1159, 128);
            this.sampleEndTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.sampleEndTextbox.Name = "sampleEndTextbox";
            this.sampleEndTextbox.Size = new System.Drawing.Size(76, 26);
            this.sampleEndTextbox.TabIndex = 3;
            this.sampleEndTextbox.Text = "100";
            // 
            // sampleStartTextbox
            // 
            this.sampleStartTextbox.Location = new System.Drawing.Point(1159, 93);
            this.sampleStartTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.sampleStartTextbox.Name = "sampleStartTextbox";
            this.sampleStartTextbox.Size = new System.Drawing.Size(76, 26);
            this.sampleStartTextbox.TabIndex = 4;
            this.sampleStartTextbox.Text = "0";
            // 
            // frequencyChart
            // 
            chartArea2.AxisX.ScaleView.Zoomable = false;
            chartArea2.AxisY.ScaleView.Zoomable = false;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea2";
            this.frequencyChart.ChartAreas.Add(chartArea2);
            this.frequencyChart.ContextMenuStrip = this.contextMenuStrip2;
            this.frequencyChart.Cursor = System.Windows.Forms.Cursors.Default;
            legend2.Name = "Legend2";
            this.frequencyChart.Legends.Add(legend2);
            this.frequencyChart.Location = new System.Drawing.Point(71, 345);
            this.frequencyChart.Margin = new System.Windows.Forms.Padding(2);
            this.frequencyChart.Name = "frequencyChart";
            series2.ChartArea = "ChartArea2";
            series2.Legend = "Legend2";
            series2.Name = "frequencySeries";
            this.frequencyChart.Series.Add(series2);
            this.frequencyChart.Size = new System.Drawing.Size(1179, 265);
            this.frequencyChart.TabIndex = 5;
            this.frequencyChart.Text = "frequencyChart";
            this.frequencyChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.selectionFreq);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(123, 36);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(122, 32);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.FilterToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1063, 167);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 33);
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
            this.menuStrip1.Size = new System.Drawing.Size(1303, 33);
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
            this.RecordGroup.Location = new System.Drawing.Point(1003, 424);
            this.RecordGroup.Margin = new System.Windows.Forms.Padding(2);
            this.RecordGroup.Name = "RecordGroup";
            this.RecordGroup.Padding = new System.Windows.Forms.Padding(2);
            this.RecordGroup.Size = new System.Drawing.Size(128, 170);
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
            this.RecordPlay.Size = new System.Drawing.Size(119, 36);
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
            this.RecordStop.Size = new System.Drawing.Size(119, 35);
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
            this.recordStart.Size = new System.Drawing.Size(119, 36);
            this.recordStart.TabIndex = 0;
            this.recordStart.Text = "start";
            this.recordStart.UseVisualStyleBackColor = true;
            this.recordStart.Click += new System.EventHandler(this.Button4_Click);
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(1003, 385);
            this.volume.Margin = new System.Windows.Forms.Padding(2);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(128, 35);
            this.volume.TabIndex = 9;
            this.volume.Text = "setVolume";
            this.volume.UseVisualStyleBackColor = true;
            this.volume.Click += new System.EventHandler(this.Button4_Click_3);
            // 
            // volumeValue
            // 
            this.volumeValue.Location = new System.Drawing.Point(1150, 389);
            this.volumeValue.Margin = new System.Windows.Forms.Padding(2);
            this.volumeValue.Name = "volumeValue";
            this.volumeValue.Size = new System.Drawing.Size(76, 26);
            this.volumeValue.TabIndex = 10;
            this.volumeValue.Text = "100";
            // 
            // PlayWav
            // 
            this.PlayWav.Location = new System.Drawing.Point(1064, 280);
            this.PlayWav.Margin = new System.Windows.Forms.Padding(2);
            this.PlayWav.Name = "PlayWav";
            this.PlayWav.Size = new System.Drawing.Size(172, 33);
            this.PlayWav.TabIndex = 11;
            this.PlayWav.Text = "Play";
            this.PlayWav.UseVisualStyleBackColor = true;
            this.PlayWav.Click += new System.EventHandler(this.Button4_Click_4);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(1137, 424);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(99, 42);
            this.filterButton.TabIndex = 13;
            this.filterButton.Text = "Apply Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // HighPassValue
            // 
            this.HighPassValue.Location = new System.Drawing.Point(1136, 507);
            this.HighPassValue.Name = "HighPassValue";
            this.HighPassValue.Size = new System.Drawing.Size(100, 26);
            this.HighPassValue.TabIndex = 14;
            this.HighPassValue.Text = "0";
            // 
            // LowPassValue
            // 
            this.LowPassValue.Location = new System.Drawing.Point(1136, 568);
            this.LowPassValue.Name = "LowPassValue";
            this.LowPassValue.Size = new System.Drawing.Size(100, 26);
            this.LowPassValue.TabIndex = 15;
            this.LowPassValue.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1132, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "High-pass (Hz)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1133, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Low-pass (Hz)";
            // 
            // inverseDFT
            // 
            this.inverseDFT.Location = new System.Drawing.Point(1062, 205);
            this.inverseDFT.Name = "inverseDFT";
            this.inverseDFT.Size = new System.Drawing.Size(173, 33);
            this.inverseDFT.TabIndex = 18;
            this.inverseDFT.Text = "Inverse DFT";
            this.inverseDFT.UseVisualStyleBackColor = true;
            this.inverseDFT.Click += new System.EventHandler(this.InverseDFT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 640);
            this.Controls.Add(this.inverseDFT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LowPassValue);
            this.Controls.Add(this.HighPassValue);
            this.Controls.Add(this.filterButton);
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
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frequencyChart)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
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
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private Button filterButton;
        private TextBox HighPassValue;
        private TextBox LowPassValue;
        private Label label1;
        private Label label2;
        private Button inverseDFT;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem filterToolStripMenuItem;
    }
}

