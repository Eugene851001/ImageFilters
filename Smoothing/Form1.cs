using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Smoothing
{
    public partial class Form1 : Form
    {
        private Bitmap source;


        public Form1()
        {
            InitializeComponent();
            this.pbSource.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbTarget.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                using (var stream = File.OpenRead(filename))
                {
                    this.source = new Bitmap(stream);
                }
            }

            this.pbSource.Image = this.source;
        }

        private void btProcess_Click(object sender, EventArgs e)
        {
            int windowSize = int.Parse(this.tbWindowSize.Text);

            int[,] pixels = this.source.GetPixels();
            MatrixFilter filter;

            if (this.rbAverage.Checked)
            {
                filter = new AverageFilter();
            }
            else if (this.rbMiddle.Checked)
            {
                filter = new MiddleFilter();
            }
            else if (this.rbGauss.Checked)
            {
                double sigma = double.Parse(this.tbSigma.Text, CultureInfo.InvariantCulture);
                filter = new GaussFilter(sigma);
            }
            else
            {
                filter = new SobelFilter();
            }

            int[,] newPixels = filter.Filter(pixels, windowSize);

            var result = new Bitmap(this.source.Width, this.source.Height);
            result = result.SetPixels(newPixels);
            this.pbTarget.Image = result;
        }
    }
}
