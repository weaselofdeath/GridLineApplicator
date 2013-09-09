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
        Bitmap bmp, bmp2;
        //string error;
        Pen drawpen = new Pen(Color.Red);
        Font stringfont = new Font("Times New Roman", 16);
        int origheight, origwidth, divide = 16;
        SolidBrush stringbrush = new SolidBrush(Color.Red);
        bool openedpic = false,gridletters = true;
        public Form1()
        {
            InitializeComponent();
            origheight = this.Height;
            origwidth = this.Width;
            gridpic.Location = new Point(0, 0);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.Image = null;
            this.Height = origheight;
            this.Width = origwidth;
            openedpic = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp3 = new Bitmap(bmp.Width, bmp.Height);
            if (openedpic == true)
            {
                using (Graphics g = Graphics.FromImage(bmp3))
                {
                    g.DrawImage(bmp, 0, 0);
                    g.DrawImage(bmp2, 0, 0);
                    picture.Image = bmp3;
                    gridpic.Image = null;
                }
            }
            MessageBox.Show("Warning: After saving\nthis application will close.");
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
            catch 
            {
                MessageBox.Show("You must load an image before trying to save.\nPlease do so.");
            }
            if (openedpic == true)
            {
                this.Close();
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
                    this.Width = picture.Image.Width;
                    this.Height = picture.Image.Height + menuStrip1.Height + controls.Height+35;
                    bmp2 = new Bitmap(gridpic.Width, gridpic.Height);
                    gridpic.Image = bmp2;
                    if (bmp.Width > Screen.PrimaryScreen.WorkingArea.Width)
                    {
                        this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    }
                    if (bmp.Height > Screen.PrimaryScreen.WorkingArea.Height)
                    {
                        this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    }
                    gridpic.Invalidate();
                    
                    
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
            picture.Width = this.Width;
            picture.Height = this.Height - (menuStrip1.Height + controls.Height + 36);
            gridpic.Location = new Point(0,0);
            gridpic.Width = this.Width;
            gridpic.Height = this.Height - (menuStrip1.Height + controls.Height + 36);
            controls.Location = new Point(0, this.Height - 82);
            controls.Width = this.Width;
            controls2.Location = new Point(picture.Right - (controls2.Width/2)-5,menuStrip1.Height);
            controls2.Height = this.Height - menuStrip1.Height - controls.Height-36;
            trackBar1.Height = this.Height - menuStrip1.Height - controls.Height - 50;
            slider.Width = controls.Width - 65;
            picture.SizeMode = PictureBoxSizeMode.CenterImage;
            gridpic.SizeMode = PictureBoxSizeMode.CenterImage;
            gridpic.Invalidate();
        }

        private void paint(object sender, PaintEventArgs e)
        {

        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            if (openedpic == true)
            {
                Bitmap bmp2 = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb);
            }
            stringfont = new Font("Times New Roman", 51-(Convert.ToInt32(Convert.ToDouble(slider.Value)/1.3)));
            divide = slider.Value/3;
            picture.Invalidate();
            gridpic.Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog1 = new ColorDialog();
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                stringbrush.Color = ColorDialog1.Color;
                drawpen.Color = ColorDialog1.Color;
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
            int formwidth = this.Width, formheight = this.Height;
            if (openedpic == false)
            {
                Graphics g = e.Graphics;
                for (int x = 0; x < divide; x++)
                {
                    number += formwidth / divide;
                    number2 += formheight / divide;
                    g.DrawLine(drawpen, 0 + number, 0, 0 + number, picture.Bottom);//vertical red lines
                    g.DrawLine(drawpen, picture.Left, 0 + number2, picture.Right, 0 + number2);//horizontal red lines
                }
                if (gridletters == true)
                {
                    number = 0;
                    number2 = 0;
                    for (int x = 0; x < divide; x++)
                    {
                        number2 += Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(formheight / divide)));
                        Point vert = new Point(0,number2);
                        Point horz = new Point(number,0);
                        g.DrawString("G" + (x + 1), stringfont, stringbrush, vert);//vertical letters and numbers: starting at 1
                        g.DrawString("G" + x, stringfont, stringbrush, horz);//horizontal letters and numbers: starting at 0
                        number += Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(formwidth / divide)));
                    }
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
                    g.DrawLine(drawpen, 0 + number, 0, 0 + number, picture.Bottom);//vertical red lines
                    g.DrawLine(drawpen, picture.Left, 0 + number2, picture.Right, 0 + number2);//horizontal red lines
                } 
                    if (gridletters == true)
                    {
                        number = 0;
                        number2 = 0;
                        for (int x = 0; x < divide; x++)
                        {
                            number2 += formheight / divide;
                            Point vert = new Point(0, Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(number2))));
                            Point horz = new Point(Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(number))), 0);
                            g.DrawString("G" + (x + 1), stringfont, stringbrush, vert);//vertical letters and numbers: starting at 1
                            g.DrawString("G" + x, stringfont, stringbrush, horz);//horizontal letters and numbers: starting at 0
                            number += formwidth / divide;
                        }
                    }
                
            }

        }

        private void gridLettersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridletters == false)
            {
                gridLettersToolStripMenuItem.Checked = true;
                gridletters = true;
            }
            else
            {
                gridLettersToolStripMenuItem.Checked = false;
                gridletters = false;
            }
            gridpic.Invalidate();
        }
    }
}
