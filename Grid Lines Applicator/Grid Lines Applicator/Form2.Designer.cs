namespace Grid_Lines_Applicator
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.letterentry = new System.Windows.Forms.MaskedTextBox();
            this.enterbut = new System.Windows.Forms.Button();
            this.cancelbut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Letter:";
            // 
            // letterentry
            // 
            this.letterentry.Location = new System.Drawing.Point(48, 25);
            this.letterentry.Mask = "?";
            this.letterentry.Name = "letterentry";
            this.letterentry.Size = new System.Drawing.Size(147, 20);
            this.letterentry.TabIndex = 1;
            this.letterentry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // enterbut
            // 
            this.enterbut.Location = new System.Drawing.Point(11, 59);
            this.enterbut.Name = "enterbut";
            this.enterbut.Size = new System.Drawing.Size(111, 23);
            this.enterbut.TabIndex = 2;
            this.enterbut.Text = "Enter";
            this.enterbut.UseVisualStyleBackColor = true;
            this.enterbut.Click += new System.EventHandler(this.enterbut_Click);
            this.enterbut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterbut_KeyPress);
            // 
            // cancelbut
            // 
            this.cancelbut.Location = new System.Drawing.Point(128, 59);
            this.cancelbut.Name = "cancelbut";
            this.cancelbut.Size = new System.Drawing.Size(111, 23);
            this.cancelbut.TabIndex = 3;
            this.cancelbut.Text = "Cancel";
            this.cancelbut.UseVisualStyleBackColor = true;
            this.cancelbut.Click += new System.EventHandler(this.cancelbut_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 97);
            this.Controls.Add(this.cancelbut);
            this.Controls.Add(this.enterbut);
            this.Controls.Add(this.letterentry);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Letter Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button enterbut;
        private System.Windows.Forms.Button cancelbut;
        public System.Windows.Forms.MaskedTextBox letterentry;
    }
}