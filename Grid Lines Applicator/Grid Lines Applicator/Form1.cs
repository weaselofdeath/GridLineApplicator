using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Grid_Lines_Applicator
{
    public partial class Form1 : Form
    {
        int origheight, origwidth,divide = 16;
        Bitmap bmp, bmp2; 
        string colord = "Red", error;
        bool openedpic = false;
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
            openedpic = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                picture.Image.Save(sfd.FileName, format);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = "c:\\";
            try
            {
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    openedpic = true;
                    bmp = new Bitmap(OpenFileDialog1.FileName);
                    picture.Image = bmp;
                    bmp2 = new Bitmap(picture.Width, picture.Height);
                    gridpic.Image = bmp2;
                    Form1.ActiveForm.Width = picture.Image.Width;
                    Form1.ActiveForm.Height = picture.Image.Height + menuStrip1.Height + controls.Height + 65;
                    if (bmp.Width > Screen.PrimaryScreen.WorkingArea.Width)
                    {
                        Form1.ActiveForm.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    }
                    if (bmp.Height > Screen.PrimaryScreen.WorkingArea.Height)
                    {
                        Form1.ActiveForm.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    }
                    
                    
                }
            }
            catch
            {
                MessageBox.Show("There has been a problem with loading the image.\nThe program will now close.");
                this.Close();   
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
           // picture.Location = new Point(0, menuStrip1.Height);
            picture.Width = Form1.ActiveForm.Width;
            picture.Height = Form1.ActiveForm.Height-(menuStrip1.Height + controls.Height+36);
            //gridpic.Location = new Point(0, menuStrip1.Height);
            gridpic.Width = Form1.ActiveForm.Width- (controls2.Width/2);
            gridpic.Height = Form1.ActiveForm.Height - (menuStrip1.Height + controls.Height+36);
            controls.Location = new Point(0,Form1.ActiveForm.Height - 82);
            controls.Width = Form1.ActiveForm.Width;
            controls2.Location = new Point(picture.Right - (controls2.Width/2)-5,menuStrip1.Height);
            controls2.Height = Form1.ActiveForm.Height - menuStrip1.Height - controls.Height-36;
            trackBar1.Height = Form1.ActiveForm.Height - menuStrip1.Height - controls.Height - 50;
            slider.Width = controls.Width - 65;
            picture.SizeMode = PictureBoxSizeMode.CenterImage;
            gridpic.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void paint(object sender, PaintEventArgs e)
        {

        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            if (openedpic == true)
            {
                Bitmap bmp2 = new Bitmap(gridpic.Width, gridpic.Height, PixelFormat.Format32bppPArgb);
            }
            divide = slider.Value;
            picture.Invalidate();
            gridpic.Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog1 = new ColorDialog();
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                colord = ColorDialog1.Color.Name.ToString();
                picture.Invalidate();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridpic.BackColor = Color.Transparent;
            gridpic.Parent = picture;
        }

        private void gridpic_Paint(object sender, PaintEventArgs e)
        {
            int number = 0, number2 = 0;
            int formwidth = Form1.ActiveForm.Width, formheight = Form1.ActiveForm.Height;
            if (openedpic == false)
            {
                Graphics g = e.Graphics;
                for (int x = 0; x < divide; x++)
                {
                    number += formwidth / divide;
                    number2 += formheight / divide;
                    g.DrawLine(Pens.Red, 0 + number, 0, 0 + number, picture.Bottom);//vertical red lines
                    g.DrawLine(Pens.Red, picture.Left, 0 + number2, picture.Right, 0 + number2);//horizontal red lines
                }
            }
            else if (openedpic == true)
            {
                Graphics g = Graphics.FromImage(bmp2);
                g.Clear(Color.Transparent);
                for (int x = 0; x < divide; x++)
                {
                    number += formwidth / divide;
                    number2 += formheight / divide;
                    g.DrawLine(new Pen(Color.Red), new Point(0 + number, gridpic.Top), new Point(0 + number, gridpic.Bottom));
                    g.DrawLine(new Pen(Color.Red), new Point(gridpic.Left, 0 + number2), new Point(gridpic.Right, 0 + number2));
                }
            }
        }
    }
}
