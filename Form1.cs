using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace COP4365Project3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// main form constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b");
            requestData_bttn.BackColor = ColorTranslator.FromHtml("#0ba792");
            requestData_bttn.ForeColor = ColorTranslator.FromHtml("#d9d8e2");

            start_dateTimePicker.MaxDate = DateTime.Now;
            end_dateTimePicker.MaxDate = DateTime.Now;

            ticker_comboBox.SelectedIndex = 1;
            candleStick_period_cbBox.SelectedIndex = 0;
        }


        /// <summary>
        /// call when click apply button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void requestData_bttn_Click(object sender, EventArgs e)
        {

            var epoch = new DateTime(1970, 1, 1, 0, 0, 0);
            int start_epoch_ = Convert.ToInt32((start_dateTimePicker.Value.ToUniversalTime()-epoch).TotalSeconds);
            int end_epoch_ = Convert.ToInt32((end_dateTimePicker.Value.ToUniversalTime() - epoch).TotalSeconds);

            if(start_epoch_ > end_epoch_)
            {
                string message = "End date must be newer than start date";
                string title = "Title";
                MessageBox.Show(message, title);

                return;
            }


            string[] fromTickers = ticker_comboBox.Text.Split('-');
            string ticker = fromTickers[0];

            //get the interval and turn it into right format: 
            string interval = "1d";
            if (candleStick_period_cbBox.Text == "Daily")
                interval = "1d";
            else if (candleStick_period_cbBox.Text == "Weekly")
                interval = "1wk";
            else if (candleStick_period_cbBox.Text == "Monthly")
                interval = "1mo";

            //download data 
            string URL = "https://query1.finance.yahoo.com/v7/finance/download/" + ticker + "?period1=" + start_epoch_ + "&period2=" + end_epoch_ + "&interval=" + interval + "&events=history&includeAdjustedClose=true";
            System.Net.WebClient client = new System.Net.WebClient();
            byte[] buffer = client.DownloadData(URL);
            string filePath = @"..\stock.csv";
            Stream stream = new FileStream(filePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(buffer);
            stream.Close();

            //start new form.
            StockDataForm stockForm = new StockDataForm(fromTickers[1]);
            stockForm.Show();

            
        }

    }
}
 