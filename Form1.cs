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

        private void requestData_bttn_Click(object sender, EventArgs e)
        {
            StockDataForm form1 = new StockDataForm();
            form1.Show();

            var client = new RestClient("https://yh-finance.p.rapidapi.com/stock/v3/get-historical-data?symbol=AMRN");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "yh-finance.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "SIGN-UP-FOR-KEY");
            IRestResponse response = client.Execute(request);



        }
    }
}
 