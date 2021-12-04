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
using System.Numerics;
namespace COP4365Project3
{
   
    public partial class StockDataForm : Form
    {
        /// <summary>
        /// lowest in the data
        /// </summary>
        int lowest;
        /// <summary>
        /// highest in the data
        /// </summary>
        int highest;

        /// <summary>
        /// minimum in the yaxis
        /// </summary>
        double chartMin;
        /// <summary>
        /// minimum in the xaxis
        /// </summary>
        double chartMax;
        /// <summary>
        /// list of of doji index
        /// </summary>
        List<int> dojiIndex;
        /// <summary>
        /// list of annotation index
        /// </summary>
        List<int> annotationIndex;
        
        /// <summary>
        /// data table to store stock data
        /// </summary>
        DataTable dt = new DataTable();

        /// <summary>
        /// stock form constructor
        /// </summary>
        /// <param name="companyName"></param>
        public StockDataForm(string companyName)
        {
            InitializeComponent();

            dojiIndex = new List<int>();
            annotationIndex = new List<int>();

            stockPattern_cbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BackColor = ColorTranslator.FromHtml("#1a152b");
            companyName_label.Text = companyName;
            companyName_label.ForeColor = Color.Gray;
            stockPattern_label.ForeColor = Color.Gray;


            //dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("High", typeof(double));
            dt.Columns.Add("Low", typeof(double));
            dt.Columns.Add("Close", typeof(double));
            dt.Columns.Add("Open", typeof(double));

            //load data: 
            var r = new StreamReader(@"..\stock.csv");
            r.ReadLine();

            //add data to datable 
            DataRow row1 = dt.NewRow();

            var line1 = r.ReadLine();
            var data1 = line1.Split(',');

            row1["High"] = data1[2];
            row1["Low"] = data1[3];
            row1["Open"] = data1[1];
            row1["Close"] = data1[4];
            row1["date"] = data1[0];
            dt.Rows.Add(row1);

            //add more data to data table.
            while (!r.EndOfStream)
            {
                DataRow row = dt.NewRow();

                

                var line = r.ReadLine();
                var data = line.Split(',');

                if (data[1] == "null" || data[2] == "null" || data[3] == "null" || data[4] == "null")
                {
                    continue;
                }

                row["High"] = data[2];
                row["Low"] = data[3];
                row["Open"] = data[1];
                row["Close"] = data[4];
                row["date"] = data[0];
                dt.Rows.Add(row);
            }

            r.Close();

            //get lowest and highest for chart y axis
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
            
            //testing  
            //Console.WriteLine(dt.Compute("min([High])", string.Empty));
            //Console.WriteLine(dt.Compute("min([Low])", string.Empty));
            //Console.WriteLine(dt.Compute("min([Open])", string.Empty));
            //Console.WriteLine(dt.Compute("min([Close])", string.Empty));


            loadChart();
        }

        /// <summary>
        /// load data to chart function.
        /// </summary>
        public void loadChart()
        {
            //design the chart
            candleStick_chart.ChartAreas["ChartArea1"].BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.BackColor = ColorTranslator.FromHtml("#1a152b");
            candleStick_chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.Gray;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.Gray;

            candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Gray;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.Gray;

            candleStick_chart.ChartAreas["ChartArea1"].AxisX.MajorTickMark.LineColor = Color.Gray;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.MajorTickMark.LineColor = Color.Gray;

            candleStick_chart.ChartAreas["ChartArea1"].AxisX.LineColor = Color.Gray;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.LineColor = Color.Gray;

            candleStick_chart.ChartAreas["ChartArea1"].AxisY.Minimum = lowest - 10;
            candleStick_chart.ChartAreas["ChartArea1"].AxisY.Maximum = highest + 10;
            chartMin = lowest - 10;
            chartMax = highest + 10;



            //set up the chart
            candleStick_chart.Series["data"].XValueMember = "date";
            candleStick_chart.Series["data"].YValueMembers = "High,Low,Close,Open";

            candleStick_chart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            candleStick_chart.Series["data"].CustomProperties = "PriceDownColor=Green,PriceUpColor=Red";
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

            candleStick_chart.Update();

            //var point1 = candleStick_chart.Series["data"].Points

            //code to loop through candlesticks ( datapoint)
            int i = 0;
            foreach (DataPoint p in candleStick_chart.Series["data"].Points)
            {
                Console.WriteLine( i + " " + p);
                i++;
              
            }
        }


        /// <summary>
        /// called when changed the selected item in stock pattern combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stockPattern_cbBox_SelectedIndexChanged(object sender,
       System.EventArgs e)
        {
            
            string selectedItem = stockPattern_cbBox.SelectedItem.ToString();
            candleStick_chart.Annotations.Clear();

            dojiIndex.Clear();
            annotationIndex.Clear();


            switch (selectedItem)
            {
                case "Neutral":
                    isDoji((chartMax - chartMin) / 5);
                    isNeutral((chartMax - chartMin) / 5);
                    break;
                case "Long-legged":
                    isDoji((chartMax - chartMin) / 5);
                    isLong_legged((chartMax - chartMin) / 5);
                    break;
                case "Gravestone":
                    isDoji((chartMax - chartMin) / 5);
                    isGravestone((chartMax - chartMin) / 5);
                    break;
                case "DragonFly":
                    isDoji((chartMax - chartMin) / 5);
                    isDragonFly((chartMax - chartMin) / 5);
                    break;
                case "Bullish Marubozus (Green)":
                    isBullish_Marubozus((chartMax - chartMin) / 5);
                    break;
                case "Bearish Marubozus (Red)":
                    isBearish_Marubozus((chartMax - chartMin) / 5);
                    break;
            }


            annotatePattern();
        }


        /// <summary>
        /// draw the box around the recognized patterns
        /// </summary>
        public void annotatePattern()
        {
            foreach(int i in annotationIndex)
            {
                var point = candleStick_chart.Series["data"].Points[i];
                double y_range = candleStick_chart.ChartAreas["ChartArea1"].AxisY.Maximum - candleStick_chart.ChartAreas["ChartArea1"].AxisY.Minimum;
                RectangleAnnotation annotation = new RectangleAnnotation();
                annotation.BackColor = Color.FromArgb(128, Color.White);
                //annotation.BackColor = Color.Transparent;
                //annotation.ToolTip = "Neutral";
                annotation.Width = 50 / candleStick_chart.Series["data"].Points.Count;
                annotation.Height = ((point.YValues[0] - point.YValues[1]) / y_range) * 85;

                annotation.AnchorOffsetY = -(annotation.Height);
                annotation.SetAnchor(point);
                candleStick_chart.Annotations.Add(annotation);
            }
        }

        /// <summary>
        /// check if candle stick is doji
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="scale"></param>
        public void isDoji(double interval, double scale =.05)
        {
            double threshold = interval * scale;
            Console.WriteLine("Scale: " + threshold);

            int pos = 0;
            foreach (DataPoint point in candleStick_chart.Series["data"].Points)
            {
                double remainder = Math.Abs(point.YValues[2] - point.YValues[3]);
                if (remainder <= threshold)
                {
                    dojiIndex.Add(pos);
                }
                pos++;

            }
        }

        /// <summary>
        /// check if candle is neutral doji
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="scale"></param>
        public void isNeutral(double interval, double scale = .05, double scale2 = .085)
        {

            double threshold = interval * scale;
            double threshold2 = interval * scale2;
            Console.WriteLine("Scale: " + threshold);

            int pos = 0;
            foreach(DataPoint point in candleStick_chart.Series["data"].Points)
            {
                double high = point.YValues[0];
                double low = point.YValues[1];
                double close = point.YValues[2];
                double open = point.YValues[3];
                 
                //close(2) and open(3). 
                double remainder = Math.Abs(point.YValues[2] - point.YValues[3]);
                double top = Math.Abs(high - close);
                double bottom = Math.Abs(open - low);


                if ( close > open)
                {
                    top = Math.Abs( high - close);
                   bottom = Math.Abs(open - low);
                }
                else if (close <= open)
                {
                   top = Math.Abs(high - open);
                   bottom = Math.Abs(close - low);
                }

                if (remainder <= threshold && top <= threshold2 && bottom <= threshold2 && Math.Abs(top - bottom) / bottom <= .15)
                {
                    dojiIndex.Add(pos);
                    annotationIndex.Add(pos);
                }

                pos++;
            }
        }

        /// <summary>
        /// check if candle stick is long legged doji
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="scale"></param>
        public void isLong_legged(double interval,double scale = .70)
        {
            Console.WriteLine("called long-legged");
            double threshold = interval * scale;
            Console.WriteLine("Threshold: " + threshold);
            Console.WriteLine("interval: " + interval);
            foreach(int i in dojiIndex)
            {
                var p = candleStick_chart.Series["data"].Points[i];


                
                double remainder = Math.Abs(p.YValues[0] - p.YValues[1]);
                Console.WriteLine("remainder: " + remainder);
                if (remainder >= threshold)
                {
                    annotationIndex.Add(i);
                }

            }
        }

        /// <summary>
        /// check if candle stick is gravestone doji
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="scale"></param>
        public void isGravestone(double interval, double scale = .03)
        {
            double threshold = interval * scale;
            Console.WriteLine("threshold: " + threshold);

            foreach(int i in dojiIndex)
            {
                var p = candleStick_chart.Series["data"].Points[i];

                double remainder;
                if (p.YValues[2] > p.YValues[3])
                {
                    remainder = Math.Abs(p.YValues[1] - p.YValues[3]);

                }
                else
                {
                    remainder = Math.Abs(p.YValues[1] - p.YValues[2]);
                }

                Console.WriteLine("remainder: " + remainder);
                if (remainder <= threshold)
                {
                    annotationIndex.Add(i);
                }
            }
        }


        /// <summary>
        /// check if candlestick is dragonfly doji
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="scale"></param>
        public void isDragonFly(double interval, double scale = 0.065)
        {
         
            double threshold = interval * scale;
            Console.WriteLine("threshold: " + threshold);
            foreach (int i in dojiIndex)
            {
                var p = candleStick_chart.Series["data"].Points[i];

                double remainder;
                if(p.YValues[2] > p.YValues[3])
                {
                    remainder = Math.Abs(p.YValues[0] - p.YValues[2]);
                     
                }
                else
                {
                    remainder = Math.Abs(p.YValues[0] - p.YValues[3]);
                }

                Console.WriteLine("remainder: " + remainder);
                if (remainder <= threshold)
                {
                    annotationIndex.Add(i);
                }

            }
        }

        /// <summary>
        /// check if candle stick is bullish marubozus(green)
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="scale"></param>
        /// <param name="threshold3"></param>
        public void isBullish_Marubozus(double interval, double scale = 0.22, double threshold3 = .14)
        {
            double threshold = interval * scale;
            Console.WriteLine("threshold: " + threshold);
            int pos = 0;
            foreach (DataPoint p in candleStick_chart.Series["data"].Points)
            {
                double remainder1;
                double remainder2;

                //bullish: 
                if( p.YValues[2] > p.YValues[3])
                {
                    remainder1 = Math.Abs(p.YValues[0] - p.YValues[2]);
                    remainder2 = Math.Abs(p.YValues[1] - p.YValues[3]);
                    double threshold1 = remainder1 / p.YValues[0] * 100;
                    double threshold2 = remainder2 / p.YValues[2] * 100;

                    //Console.WriteLine("remainder1: " + remainder1 + ", remainder2: " + remainder2);
                    Console.WriteLine("threshold1: " + threshold1 + "\n +threshold2:" + threshold2);
                    if (threshold1 <= threshold3 && threshold2 <= threshold3)
                        annotationIndex.Add(pos);
                }

                pos++;
            }

        }

        /// <summary>
        /// check if candle stick is bearish marubozus
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="scale"></param>
        /// <param name="threshold3"></param>
        public void isBearish_Marubozus(double interval, double scale = 0.22, double threshold3 = .14)
        {
            double threshold = interval * scale;
            Console.WriteLine("threshold: " + threshold);
            int pos = 0;
            foreach (DataPoint p in candleStick_chart.Series["data"].Points)
            {
                double remainder1;
                double remainder2;

                //bullish: close < open then red 
                if (p.YValues[2] < p.YValues[3])
                {
                    remainder1 = Math.Abs(p.YValues[0] - p.YValues[3]);
                    remainder2 = Math.Abs(p.YValues[1] - p.YValues[2]);
                    double threshold1 = remainder1 / p.YValues[0] * 100;
                    double threshold2 = remainder2 / p.YValues[2] * 100;

                    //Console.WriteLine("remainder1: " + remainder1 + ", remainder2: " + remainder2);
                    Console.WriteLine("threshold1: " + threshold1 + "\n +threshold2:" + threshold2);

                    if (threshold1 <= threshold3 && threshold2 <= threshold3)
                        annotationIndex.Add(pos);
                }

                pos++;
            }
        }



    }
}
