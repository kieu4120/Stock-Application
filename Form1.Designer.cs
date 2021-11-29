
namespace COP4365Project3
{
    partial class Form1
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
            this.candleStick_period_cbBox = new System.Windows.Forms.ComboBox();
            this.candleStick_period_label = new System.Windows.Forms.Label();
            this.Ticker_label = new System.Windows.Forms.Label();
            this.requestData_bttn = new System.Windows.Forms.Button();
            this.ticker_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.start_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.end_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // candleStick_period_cbBox
            // 
            this.candleStick_period_cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.candleStick_period_cbBox.FormattingEnabled = true;
            this.candleStick_period_cbBox.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.candleStick_period_cbBox.Location = new System.Drawing.Point(387, 515);
            this.candleStick_period_cbBox.Name = "candleStick_period_cbBox";
            this.candleStick_period_cbBox.Size = new System.Drawing.Size(353, 33);
            this.candleStick_period_cbBox.TabIndex = 0;
            // 
            // candleStick_period_label
            // 
            this.candleStick_period_label.AutoSize = true;
            this.candleStick_period_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.candleStick_period_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.candleStick_period_label.Location = new System.Drawing.Point(64, 515);
            this.candleStick_period_label.Name = "candleStick_period_label";
            this.candleStick_period_label.Size = new System.Drawing.Size(259, 31);
            this.candleStick_period_label.TabIndex = 1;
            this.candleStick_period_label.Text = "Candlestick Period";
            // 
            // Ticker_label
            // 
            this.Ticker_label.AutoSize = true;
            this.Ticker_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ticker_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Ticker_label.Location = new System.Drawing.Point(65, 67);
            this.Ticker_label.Name = "Ticker_label";
            this.Ticker_label.Size = new System.Drawing.Size(95, 31);
            this.Ticker_label.TabIndex = 2;
            this.Ticker_label.Text = "Ticker";
            // 
            // requestData_bttn
            // 
            this.requestData_bttn.Location = new System.Drawing.Point(848, 475);
            this.requestData_bttn.Name = "requestData_bttn";
            this.requestData_bttn.Size = new System.Drawing.Size(158, 73);
            this.requestData_bttn.TabIndex = 3;
            this.requestData_bttn.Text = "APPLY";
            this.requestData_bttn.UseVisualStyleBackColor = true;
            this.requestData_bttn.Click += new System.EventHandler(this.requestData_bttn_Click);
            // 
            // ticker_comboBox
            // 
            this.ticker_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ticker_comboBox.FormattingEnabled = true;
            this.ticker_comboBox.Items.AddRange(new object[] {
            "AMZN-Amazon",
            "AAPL-Apple",
            "FB-Meta",
            "NFLX-Netflix",
            "GOOG-Alphabet",
            "UBER-Uber",
            "COIN-Coinbase",
            "TLSA-Tesla",
            "MSFT-Microsoft",
            "FVRR-Fiverr"});
            this.ticker_comboBox.Location = new System.Drawing.Point(387, 67);
            this.ticker_comboBox.Name = "ticker_comboBox";
            this.ticker_comboBox.Size = new System.Drawing.Size(353, 33);
            this.ticker_comboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(65, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(65, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "End date";
            // 
            // start_dateTimePicker
            // 
            this.start_dateTimePicker.Location = new System.Drawing.Point(387, 226);
            this.start_dateTimePicker.Name = "start_dateTimePicker";
            this.start_dateTimePicker.Size = new System.Drawing.Size(365, 31);
            this.start_dateTimePicker.TabIndex = 9;
            // 
            // end_dateTimePicker
            // 
            this.end_dateTimePicker.Location = new System.Drawing.Point(387, 366);
            this.end_dateTimePicker.Name = "end_dateTimePicker";
            this.end_dateTimePicker.Size = new System.Drawing.Size(365, 31);
            this.end_dateTimePicker.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1133, 726);
            this.Controls.Add(this.end_dateTimePicker);
            this.Controls.Add(this.start_dateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ticker_comboBox);
            this.Controls.Add(this.requestData_bttn);
            this.Controls.Add(this.Ticker_label);
            this.Controls.Add(this.candleStick_period_label);
            this.Controls.Add(this.candleStick_period_cbBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox candleStick_period_cbBox;
        private System.Windows.Forms.Label candleStick_period_label;
        private System.Windows.Forms.Label Ticker_label;
        private System.Windows.Forms.Button requestData_bttn;
        private System.Windows.Forms.ComboBox ticker_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker start_dateTimePicker;
        private System.Windows.Forms.DateTimePicker end_dateTimePicker;
    }
}

