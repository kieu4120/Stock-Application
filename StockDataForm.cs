using System;
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
            //BackgroundImage = getFormBackgroundImage();
        }

        //
        public StockDataForm(List<double> high, List<double>low, List<double>open,List<double>close, List<long>timestamp)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b");

            int candleNum = high.Count();



            //candleStick_chart.DataSource =
            DataSet1.chartDataTable dataTable = new DataSet1.chartDataTable();
            DataSet1.chartRow row = dataTable.NewchartRow();

            int count = high.Count();
            for (int i = 0; i < count; i ++)
            {
                row["high"] = high[i];
                dataTable.Rows.Add(row);
                row["low"] = low[i];
                dataTable.Rows.Add(row);
                row["open"] = open[i];
                dataTable.Rows.Add(row);
                row["close"] = close[i];
                dataTable.Rows.Add(row);

                //timestamp - what is the data type in the table?
            }

            //populate the row

            //clear data
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //init
            candleStick_chart.Series["data"].YValueMembers = "high,low,open,close";
            candleStick_chart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            candleStick_chart.Series["data"].CustomProperties = "PricdeDownColor=Red,PriceUpColor=Blue";
            candleStick_chart.Series["data"]["OpenCloseStyle"] = "Triangle";
            candleStick_chart.Series["data"]["ShowOpenClose"] = "Both";
            candleStick_chart.DataManipulator.IsStartFromFirst = true;
            candleStick_chart.DataSource = dataTable;
            candleStick_chart.DataBind();




        }

        
    }
}
