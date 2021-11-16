﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365Project3
{
    public partial class Form1 : Form
    {
        public Bitmap getFormBackgroundImage()
        {
            Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(this.BackgroundImage,
                    new Rectangle(0, 0, bmp.Width, bmp.Height));
            }
            return bmp;
        }


        public Form1()
        {
            InitializeComponent();

            BackgroundImage = getFormBackgroundImage();
        }

        private void requestData_bttn_Click(object sender, EventArgs e)
        {
            StockDataForm form1 = new StockDataForm();
            form1.Show();
        }
    }
}
