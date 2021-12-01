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
        int lowest;
        int highest;
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

            DataRow row1 = dt.NewRow();

            var line1 = r.ReadLine();
            var data1 = line1.Split(',');


            row1["High"] = data1[2];
            row1["Low"] = data1[3];
            row1["Open"] = data1[1];
            row1["Close"] = data1[4];
            row1["date"] = data1[0];
            dt.Rows.Add(row1);

            lowest = Convert.ToInt32(Convert.ToDouble(data1[1]));


            while (!r.EndOfStream)
            {
                DataRow row = dt.NewRow();

                var line = r.ReadLine();
                var data = line.Split(',');

                if (lowest > Convert.ToInt32(Convert.ToDouble(data[1])))
                    lowest = Convert.ToInt32(Convert.ToDouble(data[1]));
                row["High"] = data[2];
                row["Low"] = data[3];
                row["Open"] = data[1];
                row["Close"] = data[4];
                row["date"] = data[0];
                dt.Rows.Add(row);
            }

            r.Close();

            lowest = Convert.ToInt32(dt.Compute("min([High])", string.Empty));
            highest = Convert.ToInt32(dt.Compute("max([High])", string.Empty));

            int highMin = Convert.ToInt32(dt.Compute("min([High])", string.Empty));
            int lowMin = Convert.ToInt32(dt.Compute("min([Low])", string.Empty));
            int lowOpen = Convert.ToInt32(dt.Compute("min([Open])", string.Empty));
            int lowClose = Convert.ToInt32(dt.Compute("min([Close])", string.Empty));

            int[] lowArr = { highMin, lowMin, lowOpen, lowClose};

            int highMax = Convert.ToInt32(dt.Compute("max([High])", string.Empty));
            int lowMax = Convert.ToInt32(dt.Compute("max([Low])", string.Empty));
            int openMax = Convert.ToInt32(dt.Compute("max([Open])", string.Empty));
            int closeMax = Convert.ToInt32(dt.Compute("max([Close])", string.Empty));

            int[] highArr = { highMax, lowMax, openMax, closeMax };


            foreach (int i in lowArr)
            {
                if (lowest > i)
                    lowest = i;
                
            }

            foreach( int i in highArr)
            {
                if (highest < i)
                    highest = i;
            }
            
              
            Console.WriteLine(dt.Compute("min([High])", string.Empty));
            Console.WriteLine(dt.Compute("min([Low])", string.Empty));
            Console.WriteLine(dt.Compute("min([Open])", string.Empty));
            Console.WriteLine(dt.Compute("min([Close])", string.Empty));


            loadChart();
        }

        public void loadChart()
        {
            //design the chart
            candleStick_chart.ChartAreas["ChartArea1"].BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.Gray;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.Gray;

            candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            candleStick_chart.ChartAreas["ChartArea1"].AxisY.Minimum = lowest + 10;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.Maximum = highest + 10;
            //candleStick_chart.ChartAreas[0].AxisY.IsStartedFromZero = false;

            //set up the chart
            candleStick_chart.Series["data"].XValueMember = "date";
            candleStick_chart.Series["data"].YValueMembers = "High,Low,Close,Open";

            candleStick_chart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            candleStick_chart.Series["data"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
            candleStick_chart.DataManipulator.IsStartFromFirst = true;
            candleStick_chart.Series["data"].IsVisibleInLegend = false;
            //candleStick_chart.Series["data"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            candleStick_chart.Series["data"]["OpenCloseStyle"] = "Triangle";
            candleStick_chart.Series["data"]["ShowOpenClose"] = "Both";
            //candleStick_chart.Series["data"]["ShowHighLow"] = "Both";
            //candleStick_chart.Series["data"].IsValueShownAsLabel = true;
            candleStick_chart.DataManipulator.IsStartFromFirst = true;

            candleStick_chart.DataSource = dt;
            candleStick_chart.DataBind();
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            //candleStick_chart.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;
            //candleStick_chart.ChartAreas["ChartArea1"].AxisY.Minimum = lowest;

            candleStick_chart.Update();

            //var point1 = candleStick_chart.Series["data"].Points
            foreach (DataPoint p in candleStick_chart.Series["data"].Points)
            {
                
            }

            
            foreach (DataPoint p in candleStick_chart.Series["data"].Points)
            {
                Console.WriteLine(p.YValues[0]);
                Console.WriteLine(p);

            /*
                double y_range = candleStick_chart.ChartAreas["ChartArea1"].AxisY.Maximum - candleStick_chart.ChartAreas["ChartArea1"].AxisY.Minimum;

                RectangleAnnotation annotation = new RectangleAnnotation();
                annotation.BackColor = Color.Red;
                annotation.ToolTip = "rectangle annotation";
                annotation.Width = 50 / candleStick_chart.Series["data"].Points.Count;
 
                annotation.Height = ((p.YValues[0] - p.YValues[1]) / y_range) * 85;
                annotation.AnchorOffsetY = -(annotation.Height);
                annotation.SetAnchor(p);
                
                candleStick_chart.Annotations.Add(annotation);
              */ 
            }
            

            var point = candleStick_chart.Series["data"].Points[0];

            double y_range = candleStick_chart.ChartAreas["ChartArea1"].AxisY.Maximum - candleStick_chart.ChartAreas["ChartArea1"].AxisY.Minimum;


            RectangleAnnotation annotation = new RectangleAnnotation();
            //annotation.BackColor = Color.Red;
            annotation.BackColor = Color.FromArgb(128, Color.White);
            annotation.ToolTip = "rectangle annotation";
            //annotation.Width = candleStick_chart.Width * 0.08 / candleStick_chart.Series["data"].Points.Count;
            annotation.Width = 50 / candleStick_chart.Series["data"].Points.Count;
            //annotation.Width = candleStick_chart.Width * 0.08 / candleStick_chart.Series["data"].Points.Count;
            //annotation.Height = point.YValues[0] - point.YValues[1];
            //annotation.Height = 3596 - 3531;
            //annotation.Text = "I am a\nRectangleAnnotation";
            
            //annotation.Height = point.YValues[0] - point.YValues[1];
            annotation.Height = ((point.YValues[0] - point.YValues[1]) / y_range) * 85;
            Console.WriteLine("data");
            Console.WriteLine(y_range);
            Console.WriteLine(point.YValues[0] - point.YValues[1]);
            Console.WriteLine("Height: " + ((point.YValues[0] - point.YValues[1]) / y_range) * 85);
            annotation.AnchorOffsetY = -(annotation.Height);


            annotation.SetAnchor(point);
            candleStick_chart.Annotations.Add(annotation);
            


            //candleStick_chart.Series["data"].Points;
        }
    }
}
