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
        int origheight, origwidth,divide = 16;
        public Form1()
        {
            InitializeComponent();
            origheight = Form1.ActiveForm.Height;
            origwidth = Form1.ActiveForm.Width;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.Image = null;
            Form1.ActiveForm.Height = origheight;
            Form1.ActiveForm.Width = origwidth;
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
                Form1.ActiveForm.Width = picture.Image.Width;
                Form1.ActiveForm.Height = picture.Image.Height + menuStrip1.Height + controls.Height +65;
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
            picture.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void paint(object sender, PaintEventArgs e)
        {
            int number = 0, number2 = 0;
            int formwidth = Form1.ActiveForm.Width, formheight = Form1.ActiveForm.Height;
            Graphics g = e.Graphics;
            for (int x = 0; x < divide; x++)
            {
                number += formwidth / divide;
                number2 += formheight / divide;
                g.DrawLine(Pens.Red, 0 + number, 0, 0 + number, picture.Bottom);
                g.DrawLine(Pens.Red, picture.Left, 0 + number2, picture.Right, 0 + number2);
            }
            
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            divide = slider.Value;
            picture.Invalidate();
        }
    }
}
