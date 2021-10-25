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
            int[,] newPixels = null;
            if (this.rbAverage.Checked)
            {
                newPixels = MatrixFilters.FilterAverage(pixels, windowSize);
            }
            else if (this.rbMiddle.Checked)
            {
                newPixels = MatrixFilters.FilterMiddle(pixels, windowSize);
            }
            else if (this.rbGauss.Checked)
            {
                newPixels = MatrixFilters.FilterGauss(pixels, windowSize);
            }
            else
            {
                newPixels = MatrixFilters.FilterSobel(pixels, 3);
            }

            var result = new Bitmap(this.source.Width, this.source.Height);
            result = result.SetPixels(newPixels);
            this.pbTarget.Image = result;
        }
    }
}
