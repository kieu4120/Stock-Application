
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
            this.SuspendLayout();
            // 
            // candleStick_period_cbBox
            // 
            this.candleStick_period_cbBox.FormattingEnabled = true;
            this.candleStick_period_cbBox.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.candleStick_period_cbBox.Location = new System.Drawing.Point(387, 515);
            this.candleStick_period_cbBox.Name = "candleStick_period_cbBox";
            this.candleStick_period_cbBox.Size = new System.Drawing.Size(225, 33);
            this.candleStick_period_cbBox.TabIndex = 0;
            // 
            // candleStick_period_label
            // 
            this.candleStick_period_label.AutoSize = true;
            this.candleStick_period_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.candleStick_period_label.Location = new System.Drawing.Point(64, 515);
            this.candleStick_period_label.Name = "candleStick_period_label";
            this.candleStick_period_label.Size = new System.Drawing.Size(241, 31);
            this.candleStick_period_label.TabIndex = 1;
            this.candleStick_period_label.Text = "Candlestick Period";
            // 
            // Ticker_label
            // 
            this.Ticker_label.AutoSize = true;
            this.Ticker_label.Location = new System.Drawing.Point(65, 67);
            this.Ticker_label.Name = "Ticker_label";
            this.Ticker_label.Size = new System.Drawing.Size(71, 25);
            this.Ticker_label.TabIndex = 2;
            this.Ticker_label.Text = "Ticker";
            // 
            // requestData_bttn
            // 
            this.requestData_bttn.Location = new System.Drawing.Point(849, 475);
            this.requestData_bttn.Name = "requestData_bttn";
            this.requestData_bttn.Size = new System.Drawing.Size(158, 73);
            this.requestData_bttn.TabIndex = 3;
            this.requestData_bttn.Text = "button1";
            this.requestData_bttn.UseVisualStyleBackColor = true;
            this.requestData_bttn.Click += new System.EventHandler(this.requestData_bttn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::COP4365Project3.Properties.Resources.dodgecoin_rocket;
            this.ClientSize = new System.Drawing.Size(1237, 633);
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
    }
}

