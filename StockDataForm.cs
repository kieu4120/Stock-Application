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

        public DateTime epoch2string(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }

        public StockDataForm()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b");
            //BackgroundImage = getFormBackgroundImage();
        }
        /*
        public StockDataForm(List<double> high, List<double> low, List<double> open, List<double> close, List<long> timestamp)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b");

            //convert timestamp to human readable, data type: var char, string cool. 
            List<DateTime> timestamp_string = new List<DateTime>();
            foreach (long t in timestamp)
            {
                timestamp_string.Add(epoch2string(t));

            }



            //candleStick_chart.DataSource =
            //DataSet1.chartDataTable dataTable = new DataSet1.chartDataTable();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("high",typeof(string));
            dataTable.Columns.Add("low", typeof(string));
            dataTable.Columns.Add("open", typeof(string));
            dataTable.Columns.Add("close",typeof(string));
            dataTable.Columns.Add("day",typeof(DateTime));



            int count = high.Count();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("high:{0}, low:{1}, open:{2}, close:{3}, time:{4}", high[i], low[i], open[i], close[i], timestamp[i]);
            }

            for (int i = 0; i < count; i++)
            {
                
                DataSet1.chartRow highRow = dataTable.NewchartRow();
                DataSet1.chartRow lowRow = dataTable.NewchartRow();
                DataSet1.chartRow openRow = dataTable.NewchartRow();
                DataSet1.chartRow closeRow = dataTable.NewchartRow();
                DataSet1.chartRow timestampRow = dataTable.NewchartRow();
                

                DataRow highRow = dataTable.NewRow();
                DataRow lowRow = dataTable.NewRow();
                DataRow openRow = dataTable.NewRow();
                DataRow closeRow = dataTable.NewRow();
                DataRow timestampRow = dataTable.NewRow();



                highRow["high"] = high[i];
                dataTable.Rows.Add(highRow);
                lowRow["low"] = low[i];
                dataTable.Rows.Add(lowRow);
                openRow["open"] = open[i];
                dataTable.Rows.Add(openRow);
                closeRow["close"] = close[i];
                dataTable.Rows.Add(closeRow);
                timestampRow["day"] = timestamp_string[i];
                dataTable.Rows.Add(timestampRow);

                //timestamp - what is the data type in the table?
            }

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }

            //populate the row

            //clear data
            //candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            //candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //init

            //candleStick_chart.Series.Add("data");
            candleStick_chart.Series["data"].XValueMember = "day";
            candleStick_chart.Series["data"].YValueMembers = "high,low,open,close";
            /*
            candleStick_chart.Series["data"].YValueMembers = "high";
            candleStick_chart.Series["data"].YValueMembers = "low";
            candleStick_chart.Series["data"].YValueMembers = "open";
            candleStick_chart.Series["data"].YValueMembers = "close";
            
            candleStick_chart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            //candleStick_chart.Series["data"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Blue";
            candleStick_chart.Series["data"]["opencloseStyle"] = "Triangle";
            candleStick_chart.Series["data"]["Showopenclose"] = "Both";
            candleStick_chart.Series["data"].IsValueShownAsLabel = true;
            candleStick_chart.DataManipulator.IsStartFromFirst = true;
            candleStick_chart.DataSource = dataTable;

            //problem: Data points insertion error. Only 1 Y values can be set for this data series.
            candleStick_chart.DataBind();
            candleStick_chart.Update();




        }
        */

        //
        
        public StockDataForm(List<double> high, List<double>low, List<double>open,List<double>close, List<long>timestamp)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1a152b");

            //convert timestamp to human readable, data type: var char, string cool. 
            List<DateTime> timestamp_string = new List<DateTime>();
            foreach(long t in timestamp)
            {
                timestamp_string.Add(epoch2string(t));
                
            }



            //candleStick_chart.DataSource =
            DataSet1.chartDataTable dataTable = new DataSet1.chartDataTable();
            
            
            int count = high.Count();
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("high:{0}, low:{1}, open:{2}, close:{3}, time:{4}", high[i], low[i], open[i], close[i], timestamp[i]);
            }

            for (int i = 0; i < count; i ++)
            {
                DataSet1.chartRow highRow = dataTable.NewchartRow();
                DataSet1.chartRow lowRow = dataTable.NewchartRow();
                DataSet1.chartRow openRow = dataTable.NewchartRow();
                DataSet1.chartRow closeRow = dataTable.NewchartRow();
                DataSet1.chartRow timestampRow = dataTable.NewchartRow();

                highRow["high"] = high[i];
                dataTable.Rows.Add(highRow);
                lowRow["low"] = low[i];
                dataTable.Rows.Add(lowRow);
                openRow["open"] = open[i];
                dataTable.Rows.Add(openRow);
                closeRow["close"] = close[i];
                dataTable.Rows.Add(closeRow);
                timestampRow["day"] = timestamp_string[i];
                dataTable.Rows.Add(timestampRow);

                //timestamp - what is the data type in the table?
            }

            foreach(DataRow row in dataTable.Rows)
            {
                foreach(var item in row.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }

            //populate the row
            
            //clear data
            //candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            //candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //init
            
            //candleStick_chart.Series.Add("data");
            candleStick_chart.Series["data"].XValueMember = "day";
            candleStick_chart.Series["data"].YValueMembers = "high,low,open,close";
            
            candleStick_chart.Series["data"].YValueMembers = "high";
            candleStick_chart.Series["data"].YValueMembers = "low";
            candleStick_chart.Series["data"].YValueMembers = "open";
            candleStick_chart.Series["data"].YValueMembers = "close";
            
            candleStick_chart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            //candleStick_chart.Series["data"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Blue";
            candleStick_chart.Series["data"]["opencloseStyle"] = "Triangle";
            candleStick_chart.Series["data"]["Showopenclose"] = "Both";
            candleStick_chart.Series["data"].IsValueShownAsLabel = true;
            candleStick_chart.DataManipulator.IsStartFromFirst = true;
            candleStick_chart.DataSource = dataTable;

            //problem: Data points insertion error. Only 1 Y values can be set for this data series.
            candleStick_chart.DataBind();
            //candleStick_chart.Update();




        }
    


    }
}
