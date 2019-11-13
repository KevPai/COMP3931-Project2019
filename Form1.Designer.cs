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
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.waveChart)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyChart)).BeginInit();
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
            this.waveChart.Location = new System.Drawing.Point(95, 59);
            this.waveChart.Name = "waveChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "waveSeries";
            this.waveChart.Series.Add(series1);
            this.waveChart.Size = new System.Drawing.Size(1572, 328);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(301, 162);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(300, 38);
            this.toolStripMenuItem2.Text = "Cut";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1418, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "draw wave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1418, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 74);
            this.button2.TabIndex = 2;
            this.button2.Text = "Select Samples";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // sampleEndTextbox
            // 
            this.sampleEndTextbox.Location = new System.Drawing.Point(1547, 141);
            this.sampleEndTextbox.Name = "sampleEndTextbox";
            this.sampleEndTextbox.Size = new System.Drawing.Size(100, 31);
            this.sampleEndTextbox.TabIndex = 3;
            this.sampleEndTextbox.Text = "100";
            // 
            // sampleStartTextbox
            // 
            this.sampleStartTextbox.Location = new System.Drawing.Point(1547, 98);
            this.sampleStartTextbox.Name = "sampleStartTextbox";
            this.sampleStartTextbox.Size = new System.Drawing.Size(100, 31);
            this.sampleStartTextbox.TabIndex = 4;
            this.sampleStartTextbox.Text = "0";
            // 
            // frequencyChart
            // 
            chartArea2.Name = "ChartArea1";
            this.frequencyChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.frequencyChart.Legends.Add(legend2);
            this.frequencyChart.Location = new System.Drawing.Point(95, 406);
            this.frequencyChart.Name = "frequencyChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "frequencySeries";
            this.frequencyChart.Series.Add(series2);
            this.frequencyChart.Size = new System.Drawing.Size(1572, 331);
            this.frequencyChart.TabIndex = 5;
            this.frequencyChart.Text = "frequencyChart";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1418, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(229, 45);
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
            this.menuStrip1.Size = new System.Drawing.Size(1698, 40);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oPENToolStripMenuItem
            // 
            this.oPENToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.saveAsToolStripMenuItem});
            this.oPENToolStripMenuItem.Name = "oPENToolStripMenuItem";
            this.oPENToolStripMenuItem.Size = new System.Drawing.Size(72, 36);
            this.oPENToolStripMenuItem.Text = "File";
            this.oPENToolStripMenuItem.Click += new System.EventHandler(this.OPENToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wavToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 44);
            this.toolStripMenuItem1.Text = "open";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // wavToolStripMenuItem
            // 
            this.wavToolStripMenuItem.Name = "wavToolStripMenuItem";
            this.wavToolStripMenuItem.Size = new System.Drawing.Size(195, 44);
            this.wavToolStripMenuItem.Text = ".wav";
            this.wavToolStripMenuItem.Click += new System.EventHandler(this.WavToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(225, 44);
            this.saveAsToolStripMenuItem.Text = "save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // RecordGroup
            // 
            this.RecordGroup.Controls.Add(this.RecordPlay);
            this.RecordGroup.Controls.Add(this.RecordStop);
            this.RecordGroup.Controls.Add(this.recordStart);
            this.RecordGroup.Location = new System.Drawing.Point(1388, 504);
            this.RecordGroup.Name = "RecordGroup";
            this.RecordGroup.Size = new System.Drawing.Size(192, 212);
            this.RecordGroup.TabIndex = 8;
            this.RecordGroup.TabStop = false;
            this.RecordGroup.Text = "Record";
            this.RecordGroup.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // RecordPlay
            // 
            this.RecordPlay.Location = new System.Drawing.Point(7, 152);
            this.RecordPlay.Name = "RecordPlay";
            this.RecordPlay.Size = new System.Drawing.Size(179, 45);
            this.RecordPlay.TabIndex = 2;
            this.RecordPlay.Text = "Play";
            this.RecordPlay.UseVisualStyleBackColor = true;
            this.RecordPlay.Click += new System.EventHandler(this.Button4_Click_2);
            // 
            // RecordStop
            // 
            this.RecordStop.Location = new System.Drawing.Point(7, 92);
            this.RecordStop.Name = "RecordStop";
            this.RecordStop.Size = new System.Drawing.Size(179, 44);
            this.RecordStop.TabIndex = 1;
            this.RecordStop.Text = "stop";
            this.RecordStop.UseVisualStyleBackColor = true;
            this.RecordStop.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // recordStart
            // 
            this.recordStart.Location = new System.Drawing.Point(7, 31);
            this.recordStart.Name = "recordStart";
            this.recordStart.Size = new System.Drawing.Size(179, 45);
            this.recordStart.TabIndex = 0;
            this.recordStart.Text = "start";
            this.recordStart.UseVisualStyleBackColor = true;
            this.recordStart.Click += new System.EventHandler(this.Button4_Click);
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(1395, 454);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(135, 44);
            this.volume.TabIndex = 9;
            this.volume.Text = "setVolume";
            this.volume.UseVisualStyleBackColor = true;
            this.volume.Click += new System.EventHandler(this.Button4_Click_3);
            // 
            // volumeValue
            // 
            this.volumeValue.Location = new System.Drawing.Point(1536, 461);
            this.volumeValue.Name = "volumeValue";
            this.volumeValue.Size = new System.Drawing.Size(100, 31);
            this.volumeValue.TabIndex = 10;
            this.volumeValue.Text = "100";
            // 
            // PlayWav
            // 
            this.PlayWav.Location = new System.Drawing.Point(1418, 302);
            this.PlayWav.Name = "PlayWav";
            this.PlayWav.Size = new System.Drawing.Size(229, 46);
            this.PlayWav.TabIndex = 11;
            this.PlayWav.Text = "Play";
            this.PlayWav.UseVisualStyleBackColor = true;
            this.PlayWav.Click += new System.EventHandler(this.Button4_Click_4);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1698, 749);
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
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.waveChart)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
    }
}

