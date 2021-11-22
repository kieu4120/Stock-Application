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

namespace COP4365Project3
{
    public partial class StockDataForm : Form
    {
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

        public StockDataForm()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b"); 
        }
       
        public StockDataForm(List<double> high, List<double>low, List<double>open,List<double>close, List<long>timestamp)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.ChartAreas["ChartArea1"].BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.Gray;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.Gray;



            //convert timestamp to human readable, data type: var char, string cool. 
            List<string> timestamp_string = new List<string>();
            foreach(long t in timestamp)
            {
                timestamp_string.Add(epoch2string(t));
                
            }

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("date", typeof(string));
            dataTable.Columns.Add("High", typeof(double));
            dataTable.Columns.Add("Low", typeof(double));
            dataTable.Columns.Add("Close", typeof(double));
            dataTable.Columns.Add("Open", typeof(double));


            int count = high.Count();
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("high:{0}, low:{1}, open:{2}, close:{3}, time:{4}", high[i], low[i], open[i], close[i], timestamp[i]);
            }

            for (int i = 0; i < count; i ++)
            {
                DataRow row = dataTable.NewRow();
            
                row["High"] = high[i];
                row["Low"] = low[i];
                row["Open"] = open[i];
                row["Close"] = close[i];
                row["date"] = timestamp_string[i];
                dataTable.Rows.Add(row);
            }

            foreach(DataRow row in dataTable.Rows)
            {
                foreach(var item in row.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
            
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;


            //init
            candleStick_chart.Series["data"].XValueMember = "date";
            candleStick_chart.Series["data"].YValueMembers = "High,Low,Close,Open";
            
            candleStick_chart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            candleStick_chart.Series["data"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Blue";
            candleStick_chart.DataManipulator.IsStartFromFirst = true;
            candleStick_chart.Series["data"].IsVisibleInLegend = false;
            //candleStick_chart.Series["data"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            candleStick_chart.Series["data"]["OpenCloseStyle"] = "Triangle";
            candleStick_chart.Series["data"]["ShowOpenClose"] = "Both";
            //candleStick_chart.Series["data"].IsValueShownAsLabel = true;
            candleStick_chart.DataManipulator.IsStartFromFirst = true;
            
            candleStick_chart.DataSource = dataTable;
            candleStick_chart.DataBind();
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            candleStick_chart.Update();
        }
    


    }
}
