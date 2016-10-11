using System;
using System.Drawing;
using System.Windows.Forms;

namespace DitherImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            if (fileName.EndsWith(".jpg"))
            {
                string newFileName = ImageProcessor.dither(fileName);
                if (Image.FromFile(newFileName).Height > 768 || Image.FromFile(newFileName).Width > 1024)
                {
                    pictureBox1.Size = new Size(1024, 768);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                pictureBox1.ImageLocation = newFileName;
            } else
            {
                MessageBox.Show("Please select a .jpg file");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
