using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;

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
            this.BackColor = ColorTranslator.FromHtml("#1a152b");
            requestData_bttn.BackColor = ColorTranslator.FromHtml("#0ba792");
            requestData_bttn.ForeColor = ColorTranslator.FromHtml("#d9d8e2");
            //BackgroundImage = getFormBackgroundImage();
        }

        private string human_readable_date_to_Epoc(int y, int m,int d)
        {
            TimeSpan t = DateTime.Now - new DateTime(y, m, d);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            return secondsSinceEpoch.ToString();
        }

        private void requestData_bttn_Click(object sender, EventArgs e)
        {
            StockDataForm form1 = new StockDataForm();
            form1.Show();

            int y = start_dateTimePicker.Value.Year;
            int m = start_dateTimePicker.Value.Month;
            int d = start_dateTimePicker.Value.Day;

            //get ticker: - need to get rid of the name and use the ticker only. 
            string ticker = ticker_comboBox.SelectedText;
            //get start date: 
            string start = start_dateTimePicker.Value.ToString("yyyy-MM-dd");

            string start_epoch = human_readable_date_to_Epoc(y,m,d);

            //get end date:
            string end = end_dateTimePicker.Value.ToString("yyyy-MM-dd");
            y = end_dateTimePicker.Value.Year;
            m = end_dateTimePicker.Value.Month;
            d = end_dateTimePicker.Value.Day;

            string end_epoch = human_readable_date_to_Epoc(y, m, d);

            //get the interval


            //need to specify ticker, start, end, and period
            var data = new data(ticker,start_epoch,end_epoch,) ;

            
            



        }
    }
}
 