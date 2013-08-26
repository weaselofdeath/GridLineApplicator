using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Grid_Lines_Applicator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.BackgroundImage.Dispose();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = "c:\\";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picture.Image = new Bitmap(OpenFileDialog1.FileName);
               // picture.Image.Width = picture.Width;
               // picture.Image.Height = picture.Height;
                Form1.ActiveForm.Width = picture.Image.Width;
                Form1.ActiveForm.Height = picture.Image.Height + menuStrip1.Height + controls.Height;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SizeChanger(object sender, EventArgs e)
        {
            picture.Location = new Point(0, menuStrip1.Height);
            picture.Width = Form1.ActiveForm.Width;
            picture.Height = Form1.ActiveForm.Height-(menuStrip1.Height + controls.Height);
            controls.Location = new Point(0,Form1.ActiveForm.Height - 82);
            controls.Width = Form1.ActiveForm.Width;
            slider.Width = controls.Width - 65;
        }
    }
}
