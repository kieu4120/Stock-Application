
namespace COP4365Project3
{
    partial class StockDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.candleStick_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.companyName_label = new System.Windows.Forms.Label();
            this.stockPattern_cbBox = new System.Windows.Forms.ComboBox();
            this.stockPattern_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.candleStick_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // candleStick_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.candleStick_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.candleStick_chart.Legends.Add(legend2);
            this.candleStick_chart.Location = new System.Drawing.Point(248, 262);
            this.candleStick_chart.Name = "candleStick_chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.Legend = "Legend1";
            series2.Name = "data";
            series2.YValuesPerPoint = 4;
            this.candleStick_chart.Series.Add(series2);
            this.candleStick_chart.Size = new System.Drawing.Size(1426, 623);
            this.candleStick_chart.TabIndex = 0;
            this.candleStick_chart.Text = "chart1";
            // 
            // companyName_label
            // 
            this.companyName_label.AutoSize = true;
            this.companyName_label.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.companyName_label.Location = new System.Drawing.Point(90, 38);
            this.companyName_label.Name = "companyName_label";
            this.companyName_label.Size = new System.Drawing.Size(273, 106);
            this.companyName_label.TabIndex = 1;
            this.companyName_label.Text = "label1";
            // 
            // stockPattern_cbBox
            // 
            this.stockPattern_cbBox.FormattingEnabled = true;
            this.stockPattern_cbBox.Items.AddRange(new object[] {
            "Neutral",
            "Long-legged",
            "Gravestone",
            "DragonFly",
            "Bullish Marubozus (Green)",
            "Bearish Marubozus (Red)"});
            this.stockPattern_cbBox.Location = new System.Drawing.Point(1553, 101);
            this.stockPattern_cbBox.Name = "stockPattern_cbBox";
            this.stockPattern_cbBox.Size = new System.Drawing.Size(121, 33);
            this.stockPattern_cbBox.TabIndex = 2;
            this.stockPattern_cbBox.SelectedIndexChanged += new System.EventHandler(this.stockPattern_cbBox_SelectedIndexChanged);
            // 
            // stockPattern_label
            // 
            this.stockPattern_label.AutoSize = true;
            this.stockPattern_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stockPattern_label.Location = new System.Drawing.Point(887, 101);
            this.stockPattern_label.Name = "stockPattern_label";
            this.stockPattern_label.Size = new System.Drawing.Size(315, 31);
            this.stockPattern_label.TabIndex = 3;
            this.stockPattern_label.Text = "Recognize stock pattern:";
            // 
            // StockDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 968);
            this.Controls.Add(this.stockPattern_label);
            this.Controls.Add(this.stockPattern_cbBox);
            this.Controls.Add(this.companyName_label);
            this.Controls.Add(this.candleStick_chart);
            this.Name = "StockDataForm";
            this.Text = "stockDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.candleStick_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart candleStick_chart;
        private System.Windows.Forms.Label companyName_label;
        private System.Windows.Forms.ComboBox stockPattern_cbBox;
        private System.Windows.Forms.Label stockPattern_label;
    }
}