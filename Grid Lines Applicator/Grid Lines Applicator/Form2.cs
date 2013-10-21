using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Grid_Lines_Applicator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void enterbut_Click(object sender, EventArgs e)
        {
            if (variables.left == true)
            {
                variables.letterleft = letterentry.Text;
                variables.left = false;
                this.Close();
            }
            if (variables.top == true)
            {
                variables.lettertop = letterentry.Text;
                variables.top = false;
                this.Close();
            }
        }

        private void cancelbut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enterbut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyDown == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
