﻿
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.candleStick_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.candleStick_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // candleStick_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.candleStick_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.candleStick_chart.Legends.Add(legend1);
            this.candleStick_chart.Location = new System.Drawing.Point(131, 67);
            this.candleStick_chart.Name = "candleStick_chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.candleStick_chart.Series.Add(series1);
            this.candleStick_chart.Size = new System.Drawing.Size(557, 300);
            this.candleStick_chart.TabIndex = 0;
            this.candleStick_chart.Text = "chart1";
            // 
            // StockDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 618);
            this.Controls.Add(this.candleStick_chart);
            this.Name = "StockDataForm";
            this.Text = "stockDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.candleStick_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart candleStick_chart;
    }
}