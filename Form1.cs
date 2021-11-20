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

            //get ticker: - need to get rid of the name and use the ticker only. 
            string ticker = ticker_comboBox.Text;
            //Console.WriteLine(ticker_comboBox.SelectedText);
            //get start date - period2
            //string start_epoch = human_readable_date_to_Epoc(y,m,d);
            string start_epoch = human_readable_date_to_Epoc(y, m, d);

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

            List<double> High = JsonClassObj.Chart.Result[0].Indicators.Quote[0].High;
            //paste in open, high and close data to the stock dataForm 


            StockDataForm form1 = new StockDataForm();
            form1.Show();
            /*
            var client = new RestClient("https://yh-finance.p.rapidapi.com/stock/v2/get-chart?interval=1wk&symbol=AAPL&region=US&period1=1637280000&period2=1637280000");
            //create request
            var request = new RestRequest(Method.GET);



            //add stuff to request header
            request.AddHeader("x-rapidapi-key", "f1407ffcd5msh250c8cde3235ed4p1072ccjsn12d793e69372");
            request.AddHeader("x-rapidapi-host", "yh-finance.p.rapidapi.com");

            //client request data and store response?
            //if using execute<t> get the response 
            IRestResponse response = client.Execute(request);

            //Console.WriteLine(response.Content);
            //Console.WriteLine(response.Content);
            */






        }
    }
}
 