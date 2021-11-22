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
            DateTime input = new DateTime(y, m, d);
            TimeSpan t = input - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            return secondsSinceEpoch.ToString();
        }

        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }

        private void requestData_bttn_Click(object sender, EventArgs e)
        {


            int y = start_dateTimePicker.Value.Year;
            int m = start_dateTimePicker.Value.Month;
            int d = start_dateTimePicker.Value.Day;

            string[] fromTickers = ticker_comboBox.Text.Split('-');
            string ticker = fromTickers[0];
            string start_epoch = human_readable_date_to_Epoc(y, m, d);

            Console.WriteLine("START EPOCH" + start_epoch);

            //get end date - period1
            y = end_dateTimePicker.Value.Year;
            m = end_dateTimePicker.Value.Month;
            d = end_dateTimePicker.Value.Day;
            string end_epoch = human_readable_date_to_Epoc(y, m, d);

            //get the interval and turn it into right format: 
            string interval = "1d";
            if (candleStick_period_cbBox.Text == "Daily")
                interval = "1d";
            else if (candleStick_period_cbBox.Text == "Weekly")
                interval = "1wk";
            else if (candleStick_period_cbBox.Text == "Monthly")
                interval = "1m";
            

            //need to specify ticker, start, end, and period
            var data = new data(ticker,start_epoch,end_epoch,interval);
            JsonClass JsonClassObj = data.getJsonClassObj();

            //this return null when in 2nd form.
            List<double> high = JsonClassObj.Chart.Result[0].Indicators.Quote[0].High;
            List<long> timestamp = JsonClassObj.Chart.Result[0].Timestamp;
            List<double> low = JsonClassObj.Chart.Result[0].Indicators.Quote[0].Low;
            List<double> open = JsonClassObj.Chart.Result[0].Indicators.Quote[0].Open;
            List<double> close = JsonClassObj.Chart.Result[0].Indicators.Quote[0].Close; 
            StockDataForm stockForm = new StockDataForm(high, low, open, close, timestamp);
            stockForm.Show();
        }

    }
}
 