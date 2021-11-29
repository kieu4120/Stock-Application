using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace COP4365Project3
{
    public partial class StockDataForm : Form
    {
        DataTable dt = new DataTable();
        /// <summary>
        /// stretch background image
        /// </summary>
        /// <returns></returns>
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

        public string epoch2string(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToShortDateString();
        }

        public StockDataForm(string companyName)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b");
            companyName_label.Text = companyName;
            companyName_label.ForeColor = Color.Gray;


            //dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("High", typeof(double));
            dt.Columns.Add("Low", typeof(double));
            dt.Columns.Add("Close", typeof(double));
            dt.Columns.Add("Open", typeof(double));

            //load data: 
            var r = new StreamReader(@"..\stock.csv");
            r.ReadLine();
            while(!r.EndOfStream)
            {
                DataRow row = dt.NewRow();

                var line = r.ReadLine();
                var data = line.Split(',');
  

                row["High"] = data[2];
                row["Low"] = data[3];
                row["Open"] = data[1];
                row["Close"] = data[4];
                row["date"] = data[0];
                dt.Rows.Add(row);
            }

            r.Close();


            loadChart();
        }

        public void loadChart()
        {

            candleStick_chart.ChartAreas["ChartArea1"].BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.Gray;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.Gray;

            candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;


            //init
            candleStick_chart.Series["data"].XValueMember = "date";
            candleStick_chart.Series["data"].YValueMembers = "High,Low,Close,Open";

            candleStick_chart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            candleStick_chart.Series["data"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
            candleStick_chart.DataManipulator.IsStartFromFirst = true;
            candleStick_chart.Series["data"].IsVisibleInLegend = false;
            //candleStick_chart.Series["data"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            candleStick_chart.Series["data"]["OpenCloseStyle"] = "Triangle";
            candleStick_chart.Series["data"]["ShowOpenClose"] = "Both";
            //candleStick_chart.Series["data"].IsValueShownAsLabel = true;
            candleStick_chart.DataManipulator.IsStartFromFirst = true;

            candleStick_chart.DataSource = dt;
            candleStick_chart.DataBind();
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            //candleStick_chart.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoom(4000, 3000);
            candleStick_chart.Update();


            foreach(DataPoint p in candleStick_chart.Series["data"].Points)
            {
                Console.WriteLine(p.YValues[0]);
                Console.WriteLine(p);
            }

            //candleStick_chart.Series["data"].Points;
        }
    }
}
