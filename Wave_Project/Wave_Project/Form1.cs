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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Brushes.Black, 7.0F);

            float x1 = 0;
            float y1 = 0;

            float y2 = 0;

            float yEx = 100;
            float eF = 40;

            for (float x = 0; x < 20; x += 0.1F)
            {
                y2 = (float)Math.Sin(x);

                g.DrawLine(pen, x1 * eF, y1 * eF + yEx, x * eF, y2 * eF + yEx);

                x1 = x;
                y1 = y2;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
