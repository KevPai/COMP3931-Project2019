using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
            //Axis and Title
            formsPlot1.plt.Title("Wave Analyzer");
            formsPlot1.plt.XLabel("Time");
            formsPlot1.plt.YLabel("Frequency");

            //Generates sample waves
            int pointCount = 50;
            double[] dataXs = ScottPlot.DataGen.Consecutive(pointCount);
            double[] dataSin = ScottPlot.DataGen.Sin(pointCount);
            double[] dataCos = ScottPlot.DataGen.Cos(pointCount);

            formsPlot1.plt.PlotScatter(dataXs, dataSin);
            formsPlot1.plt.PlotScatter(dataXs, dataCos);

            //Attributes of horizontal and vertical lines
            formsPlot1.plt.PlotVLine(0, color: Color.Black, lineWidth: 3);
            formsPlot1.plt.PlotHLine(0, color: Color.Black, lineWidth: 3);

            //Save your graph to an image
            formsPlot1.plt.SaveFig("Wave.png");

            formsPlot1.Render();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
